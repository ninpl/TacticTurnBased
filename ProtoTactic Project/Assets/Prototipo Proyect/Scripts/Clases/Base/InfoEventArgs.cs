//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// InfoEventArgs.cs (10/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase que obtiene todos los eventos de datos				\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase que obtiene todos los eventos de datos.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/InfoEventArgs")]
	public class InfoEventArgs<T> : EventArgs
	{
		#region Variables
		/// <summary>
		/// <para>Evento</para>
		/// </summary>
		public T info;                              // Evento
		#endregion

		#region Constructores
		/// <summary>
		/// <para>Constructor</para>
		/// </summary>
		public InfoEventArgs()// Constructor
		{
			info = default(T);
		}

		/// <summary>
		/// <para>Constructor</para>
		/// </summary>
		/// <param name="info"></param>
		public InfoEventArgs(T info)// Constructor
		{
			this.info = info;
		}
		#endregion
	}
}