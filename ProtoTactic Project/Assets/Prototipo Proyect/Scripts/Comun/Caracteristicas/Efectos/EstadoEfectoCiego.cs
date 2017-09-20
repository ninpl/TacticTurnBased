//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EstadoEfectoCiego.cs (28/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Efecto Ciego												\\
// Fecha Mod:		28/07/2017													\\
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
	/// <para>Efecto Ciego</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/EstadoEfectoCiego")]
	public class EstadoEfectoCiego : EfectoEstadoUnidad
	{
		#region Metodos
		/// <summary>
		/// <para>Cuando se activa</para>
		/// </summary>
		private void OnEnable()// Cuando se activa
		{
			this.AddObservador(OnTasaExitoStatusCheck, TasaExito.StatusCheckNotificacion);
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		private void OnDisable()// Cuando se desactiva
		{
			this.RemoveObservador(OnTasaExitoStatusCheck, TasaExito.StatusCheckNotificacion);
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Comprobar la tasa de exito</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnTasaExitoStatusCheck(object sender, object args)// Comprobar la tasa de exito
		{
			Info<Unidad, Unidad, int> info = args as Info<Unidad, Unidad, int>;
			Unidad unidad = GetComponentInParent<Unidad>();
			if (unidad == info.arg0)
			{
				// El atacante es ciego
				info.arg2 += 50;
			}
			else if (unidad == info.arg1)
			{
				// El defensor es ciego
				info.arg2 -= 20;
			}
		}
		#endregion
	}
}