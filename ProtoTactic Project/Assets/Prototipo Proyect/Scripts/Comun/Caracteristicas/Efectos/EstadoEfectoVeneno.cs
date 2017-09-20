//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EstadoEfectoVeneno.cs (26/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Efecto Veneno												\\
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
	/// <para>Efecto Veneno</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/EstadoEfectoVeneno")]
	public class EstadoEfectoVeneno : EfectoEstadoUnidad
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Unidad</para>
		/// </summary>
		private Unidad unidad;                          // Unidad
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando se activa</para>
		/// </summary>
		private void OnEnable()// Cuando se activa
		{
			unidad = GetComponentInParent<Unidad>();
			if (unidad) this.AddObservador(OnNewTurno, TurnoController.TurnoComienzoNotificacion, unidad);
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		private void OnDisable()// Cuando se desactiva
		{
			this.RemoveObservador(OnNewTurno, TurnoController.TurnoComienzoNotificacion, unidad);
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando el contador cambia</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnNewTurno(object sender, object args)// Cuando el contador cambia
		{
			Stats s = GetComponentInParent<Stats>();
			int actualHP = s[TipoStats.HP];
			int maxHP = s[TipoStats.MHP];
			int reducir = Mathf.Min(actualHP, Mathf.FloorToInt(maxHP * 0.1f));
			s.SetValue(TipoStats.HP, (actualHP - reducir), false);
		}
		#endregion
	}
}