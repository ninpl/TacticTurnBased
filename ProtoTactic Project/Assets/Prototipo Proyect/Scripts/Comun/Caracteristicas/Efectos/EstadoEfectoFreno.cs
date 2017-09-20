//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EstadoEfectoFreno.cs (26/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Efecto Freno												\\
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
	/// <para>Efecto Freno</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/EstadoEfectoFreno")]
	public class EstadoEfectoFreno : EfectoEstadoUnidad
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
			if (stats) this.AddObservador(OnContadorCambia, Stats.CuandoCambieNotificacion(TipoStats.CTR), stats);
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		private void OnDisable()// Cuando se desactiva
		{
			this.RemoveObservador(OnContadorCambia, Stats.CuandoCambieNotificacion(TipoStats.CTR), stats);
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando el contador cambia</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnContadorCambia(object sender, object args)// Cuando el contador cambia
		{
			CambioValorExcepcion exc = args as CambioValorExcepcion;
			MultDeltaModificador m = new MultDeltaModificador(0, 0.5f);
			exc.AddModificador(m);
		}
		#endregion
	}
}