//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EstadoEfectoKO.cs (26/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Efecto KO													\\
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
	/// <para>Efecto KO</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/EstadoEfectoKO")]
	public class EstadoEfectoKO : EfectoEstadoUnidad
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Unidad</para>
		/// </summary>
		private Unidad unidad;					// Unidad
		/// <summary>
		/// <para>Estadisticas</para>
		/// </summary>
		private Stats stats;                    // Estadisticas
		#endregion

		#region Inicializaciones
		/// <summary>
		/// <para>Inicializacion de <see cref="EstadoEfectoKO"/></para>
		/// </summary>
		private void Awake()// Inicializacion de EstadoEfectoKO
		{
			unidad = GetComponentInParent<Unidad>();
			stats = unidad.GetComponent<Stats>();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando se activa</para>
		/// </summary>
		private void OnEnable()// Cuando se activa
		{
			unidad.transform.localScale = new Vector3(0.75f, 0.1f, 0.75f);
			this.AddObservador(OnTurnoComprobar, TurnoController.CambioTurnoNotificacion, unidad);
			this.AddObservador(OnStatCounterCambia, Stats.CuandoCambieNotificacion(TipoStats.CTR), stats);
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		private void OnDisable()// Cuando se desactiva
		{
			unidad.transform.localScale = Vector3.one;
			this.RemoveObservador(OnTurnoComprobar, TurnoController.CambioTurnoNotificacion, unidad);
			this.RemoveObservador(OnStatCounterCambia, Stats.CuandoCambieNotificacion(TipoStats.CTR), stats);
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Comprobar el turno</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnTurnoComprobar(object sender, object args)// Comprobar el turno
		{
			// No permitir que una unidad KO tome turnos
			BaseExcepcion exc = args as BaseExcepcion;
			if (exc.defaultToggle == true) exc.FlipToggle();
		}

		/// <summary>
		/// <para>Comprobar el cambio de counter</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnStatCounterCambia(object sender, object args)// Comprobar el cambio de counter
		{
			// No permitir que una unidad KO incremente el contador de turno
			CambioValorExcepcion exc = args as CambioValorExcepcion;
			if (exc.toValue > exc.fromValue) exc.FlipToggle();
		}
		#endregion
	}
}