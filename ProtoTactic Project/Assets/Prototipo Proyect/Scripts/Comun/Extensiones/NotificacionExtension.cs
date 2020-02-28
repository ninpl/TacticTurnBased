//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// NotificacionExtension.cs (20/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Extension de la clase notificacion							\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using Handler = System.Action<System.Object, System.Object>;
using MoonAntonio.Glitch.Comun;
#endregion

namespace MoonAntonio.Glitch.Extensiones
{
	/// <summary>
	/// <para>Extension de la clase gameobject.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Extensiones/NotificacionExtension")]
	public static class NotificacionExtension
	{
		#region API
		/// <summary>
		/// <para>Envia una notificacion</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="nombreNotificacion"></param>
		public static void EnviarNotificacion(this object obj, string nombreNotificacion)// Envia una notificacion
		{
			NotificacionController.instance.EnviarNotificacion(nombreNotificacion, obj);
		}

		/// <summary>
		/// <para>Envia una notificacion</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="nombreNotificacion"></param>
		/// <param name="e"></param>
		public static void EnviarNotificacion(this object obj, string nombreNotificacion, object e)// Envia una notificacion
		{
			NotificacionController.instance.EnviarNotificacion(nombreNotificacion, obj, e);
		}

		/// <summary>
		/// <para>Agrega un observador</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="handler"></param>
		/// <param name="nombreNotificacion"></param>
		public static void AddObservador(this object obj, Handler handler, string nombreNotificacion)// Agrega un observador
		{
			NotificacionController.instance.AddObservador(handler, nombreNotificacion);
		}

		/// <summary>
		/// <para>Agrega un observador</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="handler"></param>
		/// <param name="nombreNotificacion"></param>
		/// <param name="sender"></param>
		public static void AddObservador(this object obj, Handler handler, string nombreNotificacion, object sender)// Agrega un observador
		{
			NotificacionController.instance.AddObservador(handler, nombreNotificacion, sender);
		}

		/// <summary>
		/// <para>Quitar un observador</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="handler"></param>
		/// <param name="nombreNotificacion"></param>
		public static void RemoveObservador(this object obj, Handler handler, string nombreNotificacion)// Quitar un observador
		{
			NotificacionController.instance.RemoveObservador(handler, nombreNotificacion);
		}

		/// <summary>
		/// <para>Quitar un observador</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="handler"></param>
		/// <param name="nombreNotificacion"></param>
		/// <param name="sender"></param>
		public static void RemoveObservador(this object obj, Handler handler, string nombreNotificacion, System.Object sender)// Quitar un observador
		{
			NotificacionController.instance.RemoveObservador(handler, nombreNotificacion, sender);
		}
		#endregion
	}
}