//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ConversacionData.cs (21/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Data de las conversaciones									\\
// Fecha Mod:		15/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Data
{
	/// <summary>
	/// <para>Data de las conversaciones.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Data/ConversacionData")]
	public class ConversacionData : ScriptableObject
	{
		#region Data
		public List<DialoguerData> list;
		#endregion
	}
}