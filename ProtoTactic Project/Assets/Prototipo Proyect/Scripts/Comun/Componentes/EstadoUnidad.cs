//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EstadoUnidad.cs (26/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base del status										\\
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
	/// <para>Clase base del status</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Componentes/EstadoUnidad")]
	public class EstadoUnidad : MonoBehaviour
	{
		#region Notificaciones
		public const string AddNotificacion = "EstadoUnidad.AddNotificacion";
		public const string RemoveNotificacion = "EstadoUnidad.RemoveNotificacion";
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Agrega un efecto</para>
		/// </summary>
		/// <typeparam name="T">Efecto de estado</typeparam>
		/// <typeparam name="U">Condicion de estado</typeparam>
		/// <returns></returns>
		public U Add<T, U>() where T : EfectoEstadoUnidad where U : CondicionEstadoUnidad// Agrega un efecto
		{
			T efecto = GetComponentInChildren<T>();

			if (efecto == null)
			{
				efecto = gameObject.AddChildComponent<T>();
				this.EnviarNotificacion(AddNotificacion, efecto);
			}

			return efecto.gameObject.AddChildComponent<U>();
		}

		/// <summary>
		/// <para>Quita una condicion</para>
		/// </summary>
		/// <param name="target">Condicion</param>
		public void Remove(CondicionEstadoUnidad target)// Quita una condicion
		{
			EfectoEstadoUnidad efecto = target.GetComponentInParent<EfectoEstadoUnidad>();

			target.transform.SetParent(null);
			Destroy(target.gameObject);

			CondicionEstadoUnidad condicion = efecto.GetComponentInChildren<CondicionEstadoUnidad>();
			if (condicion == null)
			{
				efecto.transform.SetParent(null);
				Destroy(efecto.gameObject);
				this.EnviarNotificacion(RemoveNotificacion, efecto);
			}
		}
		#endregion
	}
}