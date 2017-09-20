//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Mana.cs (29/07/2017)															\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Control de la Mana de la unidad								\\
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
	/// <para>Control de la Mana de la unidad</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Componentes/Mana")]
	public class Mana : MonoBehaviour
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Unidad</para>
		/// </summary>
		private Unidad unidad;						// Unidad
		/// <summary>
		/// <para>Estadisticas</para>
		/// </summary>
		private Stats stats;                        // Estadisticas
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Mana actual</para>
		/// </summary>
		public int MP
		{
			get { return stats[TipoStats.MP]; }
			set { stats[TipoStats.MP] = value; }
		}

		/// <summary>
		/// <para>Mana maxio</para>
		/// </summary>
		public int MMP
		{
			get { return stats[TipoStats.MMP]; }
			set { stats[TipoStats.MMP] = value; }
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="Mana"/></para>
		/// </summary>
		private void Awake()// Inicializador de Mana
		{
			stats = GetComponent<Stats>();
			unidad = GetComponent<Unidad>();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando se activa</para>
		/// </summary>
		private void OnEnable()// Cuando se activa
		{
			this.AddObservador(OnMPCambia, Stats.CuandoCambieNotificacion(TipoStats.MP), stats);
			this.AddObservador(OnMMPCambia, Stats.CuandoCambioNotificacion(TipoStats.MMP), stats);
			this.AddObservador(OnTurnoComienza, TurnoController.TurnoComienzoNotificacion, unidad);
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		private void OnDisable()// Cuando se desactiva
		{
			this.RemoveObservador(OnMPCambia, Stats.CuandoCambieNotificacion(TipoStats.MP), stats);
			this.RemoveObservador(OnMMPCambia, Stats.CuandoCambioNotificacion(TipoStats.MMP), stats);
			this.RemoveObservador(OnTurnoComienza, TurnoController.TurnoComienzoNotificacion, unidad);
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando el mana cambia</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnMPCambia(object sender, object args)// Cuando el mana cambia
		{
			CambioValorExcepcion vce = args as CambioValorExcepcion;
			vce.AddModificador(new ClampValorModificador(int.MaxValue, 0, stats[TipoStats.MHP]));
		}

		/// <summary>
		/// <para>Cuando el mana maximo cambia</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnMMPCambia(object sender, object args)// Cuando el mana maximo cambia
		{
			int oldMMP = (int)args;
			if (MMP > oldMMP)
			{
				MP += MMP - oldMMP;
			}
			else
			{
				MP = Mathf.Clamp(MP, 0, MMP);
			}
		}

		/// <summary>
		/// <para>Cuando el turno comienza</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnTurnoComienza(object sender, object args)// Cuando el turno comienza
		{
			if (MP < MMP) MP += Mathf.Max(Mathf.FloorToInt(MMP * 0.1f), 1);
		}
		#endregion
	}
}