//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// OpcionAtaque.cs (17/08/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Opcion de ataque											\\
// Fecha Mod:		17/08/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.AI
{
	/// <summary>
	/// <para>Opcion de ataque</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/AI/OpcionAtaque")]
	public class OpcionAtaque
	{
		#region Clases
		/// <summary>
		/// <para>Marca</para>
		/// </summary>
		private class Marca
		{
			public Area area;
			public bool isBuena;

			public Marca(Area area, bool isBuena)
			{
				this.area = area;
				this.isBuena = isBuena;
			}
		}
		#endregion

		#region Variables Publicas
		/// <summary>
		/// <para>Objetivo</para>
		/// </summary>
		public Area objetivo;									// Objetivo
		/// <summary>
		/// <para>Direccion</para>
		/// </summary>
		public Direcciones direccion;							// Direccion
		/// <summary>
		/// <para>Area de objetivos</para>
		/// </summary>
		public List<Area> areaObjetivos = new List<Area>();		// Area de objetivos
		/// <summary>
		/// <para>Determina si el area es peligrosa</para>
		/// </summary>
		public bool isAreaPeligrosa;							// Determina si el area es peligrosa
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Marcas realizadas</para>
		/// </summary>
		private List<Marca> marcas = new List<Marca>();			// Marcas realizadas
		/// <summary>
		/// <para>Movimiento de objetivos</para>
		/// </summary>
		private List<Area> moviObjetivos = new List<Area>();	// Movimiento de objetivos
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Mejor movimiento de area</para>
		/// </summary>
		public Area MejorMovimientoArea
		{
			get;
			private set;
		}

		/// <summary>
		/// <para>Mejor puntuacion segun angulo</para>
		/// </summary>
		public int MejorPuntuacionAngulo
		{
			get;
			private set;
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Agrega movimientos hacia el objetivo</para>
		/// </summary>
		/// <param name="area"></param>
		public void AddMovimientoObjetivo(Area area)// Agrega movimientos hacia el objetivo
		{
			// No permitir mover a un area que afectaria negativamente al caster
			if (!isAreaPeligrosa && areaObjetivos.Contains(area)) return;
			moviObjetivos.Add(area);
		}

		/// <summary>
		/// <para>Agrega una marca</para>
		/// </summary>
		/// <param name="area"></param>
		/// <param name="isBuena"></param>
		public void AddMarca(Area area, bool isBuena)// Agrega una marca
		{
			marcas.Add(new Marca(area, isBuena));
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Obtiene el area que es el punto mas efectivo para que el atacante pueda atacar</para>
		/// </summary>
		/// <param name="atacante"></param>
		/// <param name="habilidad"></param>
		private void GetMejorMovObjetivo(Unidad atacante, Habilidad habilidad)// Obtiene el area que es el punto mas efectivo para que el atacante pueda atacar
		{
			if (moviObjetivos.Count == 0) return;

			if (IsAnguloHabilidadImportante(habilidad))
			{
				MejorPuntuacionAngulo = int.MinValue;
				Area areaInicio = atacante.Area;
				Direcciones dirInicio = atacante.dir;
				atacante.dir = direccion;

				List<Area> mejoresOpciones = new List<Area>();
				for (int n = 0; n < moviObjetivos.Count; n++)
				{
					atacante.Posicionar(moviObjetivos[n]);
					int puntuacion = GetPuntuacionAngulo(atacante);
					if (puntuacion > MejorPuntuacionAngulo)
					{
						MejorPuntuacionAngulo = puntuacion;
						mejoresOpciones.Clear();
					}

					if (puntuacion == MejorPuntuacionAngulo)
					{
						mejoresOpciones.Add(moviObjetivos[n]);
					}
				}

				atacante.Posicionar(areaInicio);
				atacante.dir = dirInicio;

				FiltrarMejorMovimiento(mejoresOpciones);
				MejorMovimientoArea = mejoresOpciones[UnityEngine.Random.Range(0, mejoresOpciones.Count)];
			}
			else
			{
				MejorMovimientoArea = moviObjetivos[UnityEngine.Random.Range(0, moviObjetivos.Count)];
			}
		}

		/// <summary>
		/// <para>Filtrar el mejor movimiento</para>
		/// </summary>
		/// <param name="list"></param>
		private void FiltrarMejorMovimiento(List<Area> list)// Filtrar el mejor movimiento
		{
			if (!isAreaPeligrosa) return;

			bool isPosibleDarse = false;

			for (int n = 0; n < list.Count; n++)
			{
				if (areaObjetivos.Contains(list[n]))
				{
					isPosibleDarse = true;
					break;
				}
			}

			if (isPosibleDarse)
			{
				for (int n = list.Count - 1; n >= 0; n--)
				{
					if (!areaObjetivos.Contains(list[n]))
						list.RemoveAt(n);
				}
			}
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Obtiene la puntuacion</para>
		/// </summary>
		/// <param name="caster"></param>
		/// <param name="ability"></param>
		/// <returns></returns>
		public int GetPuntuacion(Unidad atacante, Habilidad habilidad)// Obtiene la puntuacion
		{
			GetMejorMovObjetivo(atacante, habilidad);
			if (MejorMovimientoArea == null) return 0;

			int puntuacion = 0;

			for (int n = 0; n < marcas.Count; n++)
			{
				if (marcas[n].isBuena)
				{
					puntuacion++;
				}
				else
				{
					puntuacion--;
				}	
			}

			if (isAreaPeligrosa && areaObjetivos.Contains(MejorMovimientoArea)) puntuacion++;

			return puntuacion;
		}

		/// <summary>
		/// <para>Indica si el angulo de ataque es un factor importante</para>
		/// </summary>
		/// <param name="habilidad"></param>
		/// <returns></returns>
		private bool IsAnguloHabilidadImportante(Habilidad habilidad)// Indica si el angulo de ataque es un factor importante
		{
			bool isAnguloImportante = false;

			for (int n = 0; n < habilidad.transform.childCount; n++)
			{
				TasaExito acierto = habilidad.transform.GetChild(n).GetComponent<TasaExito>();
				if (acierto.IsAngulo)
				{
					isAnguloImportante = true;
					break;
				}
			}
			return isAnguloImportante;
		}

		/// <summary>
		/// <para>Obtiene la puntuacion del angulo</para>
		/// </summary>
		/// <param name="atacante"></param>
		/// <returns></returns>
		private int GetPuntuacionAngulo(Unidad atacante)// Obtiene la puntuacion del angulo
		{
			int puntuacion = 0;
			for (int n = 0; n < marcas.Count; n++)
			{
				int valor = marcas[n].isBuena ? 1 : -1;
				int multiplicador = MultiplicarPorAngulo(atacante, marcas[n].area);
				puntuacion += valor * multiplicador;
			}
			return puntuacion;
		}

		/// <summary>
		/// <para>Multiplica por el angulo</para>
		/// </summary>
		/// <param name="atacante"></param>
		/// <param name="area"></param>
		/// <returns></returns>
		private int MultiplicarPorAngulo(Unidad atacante, Area area)// Multiplica por el angulo
		{
			if (area.contenido == null) return 0;

			Unidad defensor = area.contenido.GetComponentInChildren<Unidad>();
			if (defensor == null) return 0;

			Franqueo franco = atacante.GetFranqueo(defensor);
			if (franco == Franqueo.Detras) return 90;
			if (franco == Franqueo.Lados) return 75;
			return 50;
		}
		#endregion
	}
}