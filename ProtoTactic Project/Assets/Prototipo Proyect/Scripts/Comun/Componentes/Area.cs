//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Area.cs (07/07/2017)															\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase del area de cada objeto del grid						\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase del area de cada objeto del grid.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Componentes/Area")]
	public class Area : MonoBehaviour
	{
		#region Variables Constantes
		/// <summary>
		/// <para>Fuerza la altura de cada objeto.</para>
		/// </summary>
		public const float alturaForzada = 0.25f;                           // Fuerza la altura de cada objeto
		#endregion

		#region Variables Publicas
		/// <summary>
		/// <para>Posicion X/Z en el grid.</para>
		/// </summary>
		public Punto pos;                                                   // Posicion X/Z en el grid
		/// <summary>
		/// <para>Altura Y del area en el grid.</para>
		/// </summary>
		public int altura;                                                  // Altura Y del area en el grid
		/// <summary>
		/// <para>Objeto que contiene esta area.</para>
		/// </summary>
		public GameObject contenido;                                        // Objeto que contiene esta area
		/// <summary>
		/// <para>Area que se ha pasado.</para>
		/// </summary>
		[HideInInspector] public Area prev;                                 // Area que se ha pasado
		/// <summary>
		/// <para>Distancia que se ha recorrido para llegar a esta area.</para>
		/// </summary>
		[HideInInspector] public int distancia;                             // Distancia que se ha recorrido para llegar a esta area
		/// <summary>
		/// <para>Seleccion</para>
		/// </summary>
		public GameObject seleccion;										// Seleccion
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Centro de la area.</para>
		/// </summary>
		public Vector3 Centro
		{
			get { return new Vector3(pos.x, altura * alturaForzada, pos.y); }
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Carga y actualiza la area.</para>
		/// </summary>
		/// <param name="p">Posicion</param>
		/// <param name="h">Altura</param>
		public void Load(Punto p, int h)// Carga y actualiza la area
		{
			pos = p;
			altura = h;
			ActualizarPosEsc();
		}

		/// <summary>
		/// <para>Carga como vector 3.</para>
		/// </summary>
		/// <param name="v">Posicion</param>
		public void Load(Vector3 v)// Carga como vector 3
		{
			Load(new Punto((int)v.x, (int)v.z), (int)v.y);
		}
		#endregion

		#region PreProduccion
		/// <summary>
		/// <para>Eleva la altura del area.</para>
		/// </summary>
		public void Elevar()// Eleva la altura del area
		{
			altura++;
			ActualizarPosEsc();
		}

		/// <summary>
		/// <para>Reduce la altura del area.</para>
		/// </summary>
		public void Reducir()// Reduce la altura del area
		{
			altura--;
			ActualizarPosEsc();
		}

		/// <summary>
		/// <para>Actualiza la posicion del area.</para>
		/// </summary>
		public void ActualizarPosicion()// Actualiza la posicion del area
		{
			ActualizarPosEsc();
		}
		#endregion

		#region Metodos Internos
		/// <summary>
		/// <para>Actualiza la posicion y escala del area</para>
		/// </summary>
		private void ActualizarPosEsc()// Actualiza la posicion y escala del area
		{
			transform.localPosition = new Vector3(pos.x, altura * alturaForzada / 2f, pos.y);
			transform.localScale = new Vector3(1f, altura * alturaForzada, 1f);
		}
		#endregion
	}
}
