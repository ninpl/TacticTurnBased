//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// DialoguerData.cs (21/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase de las conversaciones									\\
// Fecha Mod:		15/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase de las conversaciones.</para>
	/// </summary>
	[System.Serializable, AddComponentMenu("Moon Antonio/Glitch/Clases/DialoguerData")]
	public class DialoguerData
	{
		#region Variables
		/// <summary>
		/// <para>Mensajes</para>
		/// </summary>
		public List<string> mensages;					// Mensajes
		/// <summary>
		/// <para>Personaje</para>
		/// </summary>
		public Sprite personaje;						// Personaje
		/// <summary>
		/// <para>Nombre</para>
		/// </summary>
		public string nombre;                           // Nombre
		/// <summary>
		/// <para>Anchor</para>
		/// </summary>
		public TextAnchor anchor;						// Anchor
		#endregion
	}
}