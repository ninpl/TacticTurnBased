//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// NotificacionController.cs (10/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controlador de las notificaciones							\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// <para>Este delegado es similar a un EventHandler:</para>
/// <para>el primer parametro es el remitente,</para>
/// <para>el segundo parametro son los argumentos/informacion a pasar</para>   
/// </summary>
using Handler = System.Action<System.Object, System.Object>;
/// <summary>
/// <para>El SenderTable mapas de un objeto (remitente de una notificacion),</para> 
/// <para>a una lista de metodos Handler</para>
/// <para>* Nota - Cuando no se especifica ningun remitente para SenderTable,</para>
/// <para>el NotificacionController se utiliza como la llave del remitente</para>
/// </summary>
using SenderTable = System.Collections.Generic.Dictionary<System.Object, System.Collections.Generic.List<System.Action<System.Object, System.Object>>>;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Controlador de las notificaciones.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Controllers/NotificacionController")]
	public class NotificacionController
	{
		#region Variables Privadas
		/// <summary>
		/// <para>El diccionario: "key" (string) representa una propiedad de nombre de notificacion a ser observada</para>
		/// <para>El diccionario: "value" (SenderTable) se correlaciona entre las tablas secundarias de remitente y observador</para>
		/// </summary>
		private Dictionary<string, SenderTable> tabla = new Dictionary<string, SenderTable>();
		/// <summary>
		/// <para>Lista de los Handler invocados en este mismo momento</para>
		/// </summary>
		private HashSet<List<Handler>> invocando = new HashSet<List<Handler>>();
		#endregion

		#region Singleton
		/// <summary>
		/// <para>Singleton de <see cref="NotificacionController"/></para>
		/// </summary>
		public readonly static NotificacionController instance = new NotificacionController();
		private NotificacionController() { }
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Agrega un observador</para>
		/// </summary>
		/// <param name="handler"></param>
		/// <param name="nombreNotificacion"></param>
		public void AddObservador(Handler handler, string nombreNotificacion)// Agrega un observador
		{
			AddObservador(handler, nombreNotificacion, null);
		}

		/// <summary>
		/// <para>Agrega un observador</para>
		/// </summary>
		/// <param name="handler"></param>
		/// <param name="nombreNotificacion"></param>
		/// <param name="sender"></param>
		public void AddObservador(Handler handler, string nombreNotificacion, System.Object sender)// Agrega un observador
		{
			// Si no hay handler
			if (handler == null)
			{
				Debug.LogError("No se puede agregar un controlador de eventos nulo para la notificacion, " + nombreNotificacion);
				return;
			}

			// Si no hay nombre
			if (string.IsNullOrEmpty(nombreNotificacion))
			{
				Debug.LogError("No se puede observar una notificacion sin nombre.");
				return;
			}

			// Si no esta en la tabla, agregarlo
			if (!tabla.ContainsKey(nombreNotificacion)) tabla.Add(nombreNotificacion, new SenderTable());

			SenderTable subTabla = tabla[nombreNotificacion];
			System.Object key = (sender != null) ? sender : this;

			// Si no esta en la subtabla, agregarlo
			if (!subTabla.ContainsKey(key)) subTabla.Add(key, new List<Handler>());

			// Comprobar si se esta invocando, sino agregar a la lista
			List<Handler> list = subTabla[key];
			if (!list.Contains(handler))
			{
				if (invocando.Contains(list)) subTabla[key] = list = new List<Handler>(list);

				list.Add(handler);
			}
		}

		/// <summary>
		/// <para>Quitar un observador</para>
		/// </summary>
		/// <param name="handler"></param>
		/// <param name="nombreNotificacion"></param>
		public void RemoveObservador(Handler handler, string nombreNotificacion)// Quitar un observador
		{
			RemoveObservador(handler, nombreNotificacion, null);
		}

		/// <summary>
		/// <para>Quitar un observador</para>
		/// </summary>
		/// <param name="handler"></param>
		/// <param name="nombreNotificacion"></param>
		/// <param name="sender"></param>
		public void RemoveObservador(Handler handler, string nombreNotificacion, System.Object sender)// Quitar un observador
		{
			// Si no hay handler
			if (handler == null)
			{
				Debug.LogError("No se puede quitar un controlador de eventos nulo para la notificacion, " + nombreNotificacion);
				return;
			}

			// Si no hay nombre
			if (string.IsNullOrEmpty(nombreNotificacion))
			{
				Debug.LogError("Se requiere un nombre de notificacion para detener la observacion.");
				return;
			}

			// No es necesario actuar si no supervisamos esta notificacion
			if (!tabla.ContainsKey(nombreNotificacion)) return;

			SenderTable subTabla = tabla[nombreNotificacion];
			System.Object key = (sender != null) ? sender : this;

			if (!subTabla.ContainsKey(key)) return;

			// Comprobar si se esta invocando, sino agregar a la lista
			List<Handler> list = subTabla[key];
			int index = list.IndexOf(handler);
			if (index != -1)
			{
				if (invocando.Contains(list)) subTabla[key] = list = new List<Handler>(list);
				list.RemoveAt(index);
			}
		}

		/// <summary>
		/// <para>Limpiar las tablas</para>
		/// </summary>
		public void Clean()// Limpiar las tablas
		{
			// Crear una tabla
			string[] noKeys = new string[tabla.Keys.Count];
			tabla.Keys.CopyTo(noKeys, 0);

			// Recorrer el array
			for (int n = noKeys.Length - 1; n >= 0; n--)
			{
				string nomNotificacion = noKeys[n];
				SenderTable senderTabla = tabla[nomNotificacion];
				object[] senKeys = new object[senderTabla.Keys.Count];
				senderTabla.Keys.CopyTo(senKeys, 0);

				for (int i = senKeys.Length - 1; i >= 0; i--)
				{
					object sender = senKeys[i];
					List<Handler> handlers = senderTabla[sender];
					if (handlers.Count == 0) senderTabla.Remove(sender);
				}

				if (senderTabla.Count == 0) tabla.Remove(nomNotificacion);
			}
		}

		/// <summary>
		/// <para>Envia una notificacion</para>
		/// </summary>
		/// <param name="nombreNotificacion"></param>
		public void EnviarNotificacion(string nombreNotificacion)// Envia una notificacion
		{
			EnviarNotificacion(nombreNotificacion, null);
		}

		/// <summary>
		/// <para>Envia una notificacion</para>
		/// </summary>
		/// <param name="nombreNotificacion"></param>
		/// <param name="sender"></param>
		public void EnviarNotificacion(string nombreNotificacion, System.Object sender)// Envia una notificacion
		{
			EnviarNotificacion(nombreNotificacion, sender, null);
		}

		/// <summary>
		/// <para>Envia una notificacion</para>
		/// </summary>
		/// <param name="nombreNotificacion"></param>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void EnviarNotificacion(string nombreNotificacion, System.Object sender, System.Object e)// Envia una notificacion
		{
			// Si no hay nombre
			if (string.IsNullOrEmpty(nombreNotificacion))
			{
				Debug.LogError("Un nombre de notificacion es necesario.");
				return;
			}

			// No es necesario actuar si no supervisamos esta notificacion
			if (!tabla.ContainsKey(nombreNotificacion)) return;

			// Enviar a los observadores que especificaron un remitente para observar
			SenderTable subTabla = tabla[nombreNotificacion];
			if (sender != null && subTabla.ContainsKey(sender))
			{
				List<Handler> handlers = subTabla[sender];
				invocando.Add(handlers);
				for (int n = 0; n < handlers.Count; n++)
				{
					handlers[n](sender, e);
				}	
				invocando.Remove(handlers);
			}

			// Enviar a los observadores que no especificaron un remitente para observar
			if (subTabla.ContainsKey(this))
			{
				List<Handler> handlers = subTabla[this];
				invocando.Add(handlers);
				for (int i = 0; i < handlers.Count; i++)
				{
					handlers[i](sender, e);
				}
				invocando.Remove(handlers);
			}
		}
		#endregion
	}
}