//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// DuracionCondicionEstadoUnidad.cs (26/07/2017)								\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base de la duracion de la condicion del estado		\\
// Fecha Mod:		26/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase base de la duracion de la condicion del estado</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/DuracionCondicionEstadoUnidad")]
	public class DuracionCondicionEstadoUnidad : CondicionEstadoUnidad
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Duracion de la condicion</para>
		/// </summary>
		public int duracion = 10;                                           // Duracion de la condicion
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando se activa</para>
		/// </summary>
		private void OnEnable()// Cuando se activa
		{
			this.AddObservador(OnNewTurno, TurnoController.ComienzoRondaNotificacion);
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		private void OnDisable()// Cuando se desactiva
		{
			this.RemoveObservador(OnNewTurno, TurnoController.ComienzoRondaNotificacion);
		}

		/// <summary>
		/// <para>Cuando es un nuevo turno</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnNewTurno(object sender, object args)// Cuando es un nuevo turno
		{
			duracion--;
			if (duracion <= 0) Remove();
		}
		#endregion
	}
}