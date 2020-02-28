//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Grid.cs (11/07/2017)															\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controlador del grid de combate								\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.Data;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Controlador del grid de combate.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Componentes/Grid")]
	public class Grid : MonoBehaviour
	{
		#region Test
		// TEST Solo para ver tecnicamente la seleccion del area. Cambiar para el metodo final.
		Color colorAreaSeleccionada = new Color(0, 1, 1, 1);
		Color colorAreaDeseleccionada = new Color(1, 1, 1, 1);

		public void SeleccionarAreas(List<Area> tiles)
		{
			for (int i = tiles.Count - 1; i >= 0; --i)
			{
				tiles[i].GetComponent<Renderer>().material.SetColor("_Color", colorAreaSeleccionada);
				tiles[i].seleccion.SetActive(true);
			}	
		}

		public void DeSeleccionarAreas(List<Area> tiles)
		{
			for (int i = tiles.Count - 1; i >= 0; --i)
			{
				tiles[i].GetComponent<Renderer>().material.SetColor("_Color", colorAreaDeseleccionada);
				tiles[i].seleccion.SetActive(false);
			}	
		}
		#endregion

		#region Variables Publicas
		/// <summary>
		/// <para>Areas del grid.</para>
		/// </summary>
		public Dictionary<Punto, Area> areas = new Dictionary<Punto, Area>();                   // Areas del grid
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Prefab del area.</para>
		/// </summary>
		[SerializeField] private GameObject prefabArea;                                         // Prefab del area
		/// <summary>
		/// <para>Minimo de mapa</para>
		/// </summary>
		private Punto min;																		// Minimo de mapa
		/// <summary>
		/// <para>Maximo de mapa</para>
		/// </summary>
		private Punto max;                                                                      // Maximo de mapa
		/// <summary>
		/// <para>Direcciones en forma de array.</para>
		/// </summary>
		private Punto[] dirs = new Punto[4]{new Punto(0, 1),new Punto(0, -1),new Punto(1, 0),new Punto(-1, 0)};// Direcciones en forma de array
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Minimo de mapa</para>
		/// </summary>
		public Punto Min
		{
			get { return min; }
		}

		/// <summary>
		/// <para>Maximo de mapa</para>
		/// </summary>
		public Punto Max
		{
			get { return max; }
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Carga el nivel.</para>
		/// </summary>
		/// <param name="data">Data del nivel.</param>
		public void Load(LevelData data)// Carga el nivel
		{
			min = new Punto(int.MaxValue, int.MaxValue);
			max = new Punto(int.MinValue, int.MinValue);

			// Instanciar las areas en sus posiciones
			for (int n = 0; n < data.areasPos.Count; n++)
			{
				GameObject go = Instantiate(prefabArea) as GameObject;
				go.transform.SetParent(transform);
				Area a = go.GetComponent<Area>();
				a.Load(data.areasPos[n]);
				areas.Add(a.pos, a);

				min.x = Mathf.Min(min.x, a.pos.x);
				min.y = Mathf.Min(min.y, a.pos.y);
				max.x = Mathf.Max(max.x, a.pos.x);
				max.y = Mathf.Max(max.y, a.pos.y);
			}

			// TODO Unir con el proyecto la pool de props
			// Instanciar los props del nivel
			/*for (int n = 0; n < data.areaProps.Count; n++)
			{
				PoolCreator pool = this.gameObject.transform.GetComponent<PoolCreator>();
				GameObject go = pool.Crear(data.prefabsProps[n]);
				go.transform.parent = transform;
				go.transform.position = new Vector3(data.areaProps[n].x, data.areaProps[n].y, data.areaProps[n].z);
				go.name = data.prefabsProps[n];
			}*/
		}

		/// <summary>
		/// <para>Busca una lista de areas a partir de un area concreta con unos criterios.</para>
		/// <para>Criterios: Desde donde se mueve, hacia donde y si se permite o no el movimiento.</para>
		/// </summary>
		/// <param name="pInicio">Punto inicial.</param>
		/// <param name="addArea"></param>
		/// <returns>Devuelve una lista de areas.</returns>
		public List<Area> Buscar(Area pInicio, Func<Area, Area, bool> addArea)
		{
			// Inicializar la lista de la busqueda
			List<Area> retValue = new List<Area>();
			retValue.Add(pInicio);

			// Limpiar la busqueda
			ClearBusqueda();

			// Inicializar las colas de areasSiguientes y proximas
			Queue<Area> areasSiguientes = new Queue<Area>();
			Queue<Area> areasAhora = new Queue<Area>();

			// Agregar a la cola para comprobar ahora
			pInicio.distancia = 0;
			areasAhora.Enqueue(pInicio);

			// Iniciar el loop de la logica
			while (areasAhora.Count > 0)
			{
				// Quita y obtiene el primer objeto
				Area a = areasAhora.Dequeue();

				// Creamos un bucle en las 4 direcciones
				for (int n = 0; n < 4; n++)
				{
					// Obtener el area siguiente a la direccion dada
					Area next = GetArea(a.pos + dirs[n]);

					// Comprobar que el area que se comprueba no es null y que la distancia es menor al objetivo
					if (next == null || next.distancia <= a.distancia + 1) continue;

					// Comprobar el protocolo (Criterio)
					if (addArea(a, next))
					{
						// Agregar a la cola de siguientes y a la lista que se devolvera
						next.distancia = a.distancia + 1;
						next.prev = a;
						areasSiguientes.Enqueue(next);
						retValue.Add(next);
					}
				}

				// Comprobar si se ha mirado toda la cola de ahora y intercambiamos las colas
				if (areasAhora.Count == 0) IntercambiarColas(ref areasAhora, ref areasSiguientes);
			}

			return retValue;
		}

		/// <summary>
		/// <para>Obtiene un <see cref="Area"/> mediante un <see cref="Punto"/> de coordenadas.</para>
		/// </summary>
		/// <param name="p">Punto donde esta el area.</param>
		/// <returns></returns>
		public Area GetArea(Punto p)// Obtiene un Area mediante un Punto de coordenadas
		{
			return areas.ContainsKey(p) ? areas[p] : null;
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Limpiar la busqueda</para>
		/// </summary>
		private void ClearBusqueda()// Limpiar la busqueda
		{
			foreach (Area a in areas.Values)
			{
				// Reset
				a.prev = null;
				a.distancia = int.MaxValue;
			}
		}

		/// <summary>
		/// <para>Intercambia dos colas.</para>
		/// </summary>
		/// <param name="a">Cola A</param>
		/// <param name="b">Cola B</param>
		private void IntercambiarColas(ref Queue<Area> a, ref Queue<Area> b)// Intercambia dos colas
		{
			Queue<Area> temp = a;
			a = b;
			b = temp;
		}
		#endregion
	}
}