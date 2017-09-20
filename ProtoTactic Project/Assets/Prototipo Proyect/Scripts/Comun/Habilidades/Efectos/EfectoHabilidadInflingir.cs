//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EfectoHabilidadInflingir.cs (29/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase que inflinge el efecto de habilidad					\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System;
using System.Reflection;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase que inflinge el efecto de habilidad</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/EfectoHabilidadInflingir")]
	public class EfectoHabilidadInflingir : BaseEfectoHabilidad
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Nombre del estado</para>
		/// </summary>
		public string nombreStatus;							// Nombre del estado
		/// <summary>
		/// <para>Duracion del estado</para>
		/// </summary>
		public int duracion;								// Duracion del estado
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Predice el damage</para>
		/// </summary>
		/// <param name="target">Area</param>
		/// <returns></returns>
		public override int Predecir(Area target)// Predice el damage
		{
			return 0;
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Aplica el damage</para>
		/// </summary>
		/// <param name="target">Area</param>
		public override int OnAplicar(Area target)// Aplica el damage
		{
			Type tipoStatus = Type.GetType(nombreStatus);
			if (tipoStatus == null || !tipoStatus.IsSubclassOf(typeof(EfectoEstadoUnidad)))
			{
				Debug.LogError("EfectoEstadoUnidad Invalido");
				return 0;
			}

			MethodInfo mi = typeof(EstadoUnidad).GetMethod("Add");
			Type[] tipos = new Type[] { tipoStatus, typeof(DuracionCondicionEstadoUnidad) };
			MethodInfo constructed = mi.MakeGenericMethod(tipos);

			EstadoUnidad status = target.contenido.GetComponent<EstadoUnidad>();
			object retValue = constructed.Invoke(status, null);

			DuracionCondicionEstadoUnidad condicion = retValue as DuracionCondicionEstadoUnidad;
			condicion.duracion = duracion;
			return 0;
		}
		#endregion
	}
}