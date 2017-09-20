//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Nivel.cs (22/07/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Nivel de las unidades										\\
// Fecha Mod:		22/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Nivel de las unidades.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Componentes/Nivel")]
	public class Nivel : MonoBehaviour
	{
		#region Constantes
		/// <summary>
		/// <para>Minimo de nivel</para>
		/// </summary>
		public const int minLevel = 1;						// Minimo de nivel
		/// <summary>
		/// <para>Maximo de nivel</para>
		/// </summary>
		public const int maxLevel = 99;						// Maximo de nivel
		/// <summary>
		/// <para>Maxima experiencia</para>
		/// </summary>
		public const int maxExperiencia = 999999;           // Maxima experiencia
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Estadisticas</para>
		/// </summary>
		private Stats stats;								// Estadisticas
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Nivel</para>
		/// </summary>
		public int LVL
		{
			get { return stats[TipoStats.LVL]; }
		}

		/// <summary>
		/// <para>Experiencia</para>
		/// </summary>
		public int EXP
		{
			get { return stats[TipoStats.EXP]; }
			set { stats[TipoStats.EXP] = value; }
		}

		/// <summary>
		/// <para>Porcentaje nivel</para>
		/// </summary>
		public float PorcentajeNivel
		{
			get { return (float)(LVL - minLevel) / (float)(maxLevel - minLevel); }
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Cargador de <see cref="Nivel"/></para>
		/// </summary>
		private void Awake()// Cargador de Nivel
		{
			stats = GetComponent<Stats>();
		}

		/// <summary>
		/// <para>Inicializador de <see cref="Nivel"/></para>
		/// </summary>
		/// <param name="level"></param>
		public void Init(int level)// Inicializador de Nivel
		{
			stats.SetValue(TipoStats.LVL, level, false);
			stats.SetValue(TipoStats.EXP, ExperienciaPorNivel(level), false);
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando se activa</para>
		/// </summary>
		private void OnEnable()// Cuando se activa
		{
			this.AddObservador(OnExpCambia, Stats.CuandoCambieNotificacion(TipoStats.EXP), stats);
			this.AddObservador(OnExpCambio, Stats.CuandoCambioNotificacion(TipoStats.EXP), stats);
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		private void OnDisable()// Cuando se desactiva
		{
			this.RemoveObservador(OnExpCambia, Stats.CuandoCambieNotificacion(TipoStats.EXP), stats);
			this.RemoveObservador(OnExpCambio, Stats.CuandoCambioNotificacion(TipoStats.EXP), stats);
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando la experiencia cambia</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnExpCambia(object sender, object args)// Cuando la experiencia cambia
		{
			CambioValorExcepcion vce = args as CambioValorExcepcion;
			vce.AddModificador(new ClampValorModificador(int.MaxValue, EXP, maxExperiencia));
		}

		/// <summary>
		/// <para>Cuando la experiencia cambio</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnExpCambio(object sender, object args)// Cuando la experiencia cambio
		{
			stats.SetValue(TipoStats.LVL, NivelPorExperiencia(EXP), false);
		}
		#endregion

		#region API
		/// <summary>
		/// <para>Experiencia por nivel</para>
		/// </summary>
		/// <param name="level"></param>
		/// <returns></returns>
		public static int ExperienciaPorNivel(int level)// Experiencia por nivel
		{
			float porcentajeNivel = Mathf.Clamp01((float)(level - minLevel) / (float)(maxLevel - minLevel));
			return (int)EasingEquations.EaseInQuad(0, maxExperiencia, porcentajeNivel);
		}

		/// <summary>
		/// <para>Nivel por experiencia</para>
		/// </summary>
		/// <param name="exp"></param>
		/// <returns></returns>
		public static int NivelPorExperiencia(int exp)// Nivel por experiencia
		{
			int lvl = maxLevel;

			for (; lvl >= minLevel; lvl--)
			{
				if (exp >= ExperienciaPorNivel(lvl)) break;
			}

			return lvl;
		}
		#endregion
	}
}