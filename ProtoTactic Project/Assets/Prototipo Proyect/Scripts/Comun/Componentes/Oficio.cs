//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Oficio.cs (25/07/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase de oficio de la unidad								\\
// Fecha Mod:		25/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase de oficio de la unidad.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Componentes/Oficio")]
	public class Oficio : MonoBehaviour
	{
		#region Variables
		/// <summary>
		/// <para>Orden de stats</para>
		/// </summary>
		public static readonly TipoStats[] statOrden = new TipoStats[]
		{
		TipoStats.MHP,
		TipoStats.MMP,
		TipoStats.ATK,
		TipoStats.DEF,
		TipoStats.MAT,
		TipoStats.MDF,
		TipoStats.SPD
		};
		/// <summary>
		/// <para>Stats con los valores iniciales</para>
		/// </summary>
		public int[] baseStats = new int[statOrden.Length];						// Stats con los valores iniciales
		/// <summary>
		/// <para>Stats con los valores de crecimiento</para>
		/// </summary>
		public float[] crecimientoStats = new float[statOrden.Length];			// Stats con los valores de crecimiento
		/// <summary>
		/// <para>Stats con los valores actuales</para>
		/// </summary>
		private Stats stats;													// Stats con los valores actuales
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Activa el oficio</para>
		/// </summary>
		public void ActivarOficio()// Activa el oficio
		{
			stats = gameObject.GetComponentInParent<Stats>();
			this.AddObservador(OnCambioLvlNotificaicon, Stats.CuandoCambioNotificacion(TipoStats.LVL), stats);

			Caracteristica[] caracteristicas = GetComponentsInChildren<Caracteristica>();
			for (int n = 0; n < caracteristicas.Length; n++)
			{
				caracteristicas[n].Activar(gameObject);
			}
		}

		/// <summary>
		/// <para>Desactiva el oficio</para>
		/// </summary>
		public void DesactivarOficio()// Desactiva el oficio
		{
			Caracteristica[] caracteristicas = GetComponentsInChildren<Caracteristica>();
			for (int n = 0; n < caracteristicas.Length; n++)
			{
				caracteristicas[n].Desactivar();
			}

			this.RemoveObservador(OnCambioLvlNotificaicon, Stats.CuandoCambioNotificacion(TipoStats.LVL), stats);
			stats = null;
		}

		/// <summary>
		/// <para>Carga los stats iniciales</para>
		/// </summary>
		public void CargarStatsIniciales()// Carga los stats iniciales
		{
			for (int n = 0; n < statOrden.Length; n++)
			{
				TipoStats tipo = statOrden[n];
				stats.SetValue(tipo, baseStats[n], false);
			}

			stats.SetValue(TipoStats.HP, stats[TipoStats.MHP], false);
			stats.SetValue(TipoStats.MP, stats[TipoStats.MMP], false);
		}

		/// <summary>
		/// <para>Cuando es destruido</para>
		/// </summary>
		private void OnDestroy()// Cuando es destruido
		{
			this.RemoveObservador(OnCambioLvlNotificaicon, Stats.CuandoCambioNotificacion(TipoStats.LVL));
		}

		/// <summary>
		/// <para>Sube de nivel el oficio</para>
		/// </summary>
		private void LevelUp()// Sube de nivel el oficio
		{
			for (int n = 0; n < statOrden.Length; n++)
			{
				TipoStats tipo = statOrden[n];
				int entero = Mathf.FloorToInt(crecimientoStats[n]);
				float fraccion = crecimientoStats[n] - entero;

				int value = stats[tipo];
				value += entero;

				if (Random.value > (1f - fraccion))
				{
					value++;
				}

				stats.SetValue(tipo, value, false);
			}

			stats.SetValue(TipoStats.HP, stats[TipoStats.MHP], false);
			stats.SetValue(TipoStats.MP, stats[TipoStats.MMP], false);
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando cambia de nivel</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		public virtual void OnCambioLvlNotificaicon(object sender, object args)// Cuando cambia de nivel
		{
			int oldValue = (int)args;
			int newValue = stats[TipoStats.LVL];

			for (int n = oldValue; n < newValue; n++)
			{
				LevelUp();
			}
		}
		#endregion
	}
}