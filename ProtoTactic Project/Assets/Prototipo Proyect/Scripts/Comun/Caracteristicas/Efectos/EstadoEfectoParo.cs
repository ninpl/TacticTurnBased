//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EstadoEfectoParo.cs (26/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Efecto Paro													\\
// Fecha Mod:		26/07/2017													\\
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
	/// <para>Efecto Paro</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/EstadoEfectoParo")]
	public class EstadoEfectoParo : EfectoEstadoUnidad
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Estadisticas</para>
		/// </summary>
		private Stats stats;                // Estadisticas
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando se activa</para>
		/// </summary>
		private void OnEnable()// Cuando se activa
		{
			stats = GetComponentInParent<Stats>();
			if (stats) this.AddObservador(OnCounterCambia, Stats.CuandoCambieNotificacion(TipoStats.CTR), stats);
			this.AddObservador(OnAutomaticAciertoComprueba, TasaExito.AutomaticExitoCheckNotificacion);
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		private void OnDisable()// Cuando se desactiva
		{
			this.RemoveObservador(OnCounterCambia, Stats.CuandoCambieNotificacion(TipoStats.CTR), stats);
			this.RemoveObservador(OnAutomaticAciertoComprueba, TasaExito.AutomaticExitoCheckNotificacion);
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando el counter cambia</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnCounterCambia(object sender, object args)// Cuando el counter cambia
		{
			CambioValorExcepcion exc = args as CambioValorExcepcion;
			exc.FlipToggle();
		}

		/// <summary>
		/// <para>Cuando se comprueba el acierto automatico</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnAutomaticAciertoComprueba(object sender, object args)// Cuando se comprueba el acierto automatico
		{
			Unidad uni = GetComponentInParent<Unidad>();
			MatchExcepcion exc = args as MatchExcepcion;
			if (uni == exc.objetivo) exc.FlipToggle();
		}
		#endregion

	}
}
