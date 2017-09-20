//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Vida.cs (29/07/2017)															\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Control de la vida de la unidad								\\
// Fecha Mod:		29/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Control de la vida de la unidad</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Componentes/Vida")]
	public class Vida : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Minimo de HP</para>
		/// </summary>
		public int MinHP = 0;									// Minimo de HP
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Stats de la unidad</para>
		/// </summary>
		private Stats stats;                                    // Stats de la unidad
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Vida actual</para>
		/// </summary>
		public int HP
		{
			get { return stats[TipoStats.HP]; }
			set { stats[TipoStats.HP] = value; }
		}

		/// <summary>
		/// <para>Vida maxima</para>
		/// </summary>
		public int MHP
		{
			get { return stats[TipoStats.MHP]; }
			set { stats[TipoStats.MHP] = value; }
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="Vida"/></para>
		/// </summary>
		private void Awake()// Inicializador de Vida
		{
			stats = GetComponent<Stats>();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando se activa</para>
		/// </summary>
		private void OnEnable()// Cuando se activa
		{
			this.AddObservador(OnHPCambia, Stats.CuandoCambieNotificacion(TipoStats.HP), stats);
			this.AddObservador(OnMHPCambia, Stats.CuandoCambioNotificacion(TipoStats.MHP), stats);
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		private void OnDisable()// Cuando se desactiva
		{
			this.RemoveObservador(OnHPCambia, Stats.CuandoCambieNotificacion(TipoStats.HP), stats);
			this.RemoveObservador(OnMHPCambia, Stats.CuandoCambioNotificacion(TipoStats.MHP), stats);
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando cambia la vida</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnHPCambia(object sender, object args)// Cuando cambia la vida
		{
			CambioValorExcepcion vce = args as CambioValorExcepcion;
			vce.AddModificador(new ClampValorModificador(int.MaxValue, 0, stats[TipoStats.MHP]));
		}

		/// <summary>
		/// <para>Cuando cambia la vida maxima</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnMHPCambia(object sender, object args)// Cuando cambia la vida maxima
		{
			int oldMHP = (int)args;
			if (MHP > oldMHP)
			{
				HP += MHP - oldMHP;
			}
			else
			{
				HP = Mathf.Clamp(HP, 0, MHP);
			}
		}
		#endregion
	}
}