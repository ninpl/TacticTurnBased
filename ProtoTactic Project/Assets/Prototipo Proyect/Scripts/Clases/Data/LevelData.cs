//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// LevelData.cs (07/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Data de niveles												\\
// Fecha Mod:		12/07/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
#endregion

namespace MoonAntonio.Glitch.Data
{
	/// <summary>
	/// <para>Data de niveles.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Data/LevelData")]
	public class LevelData : ScriptableObject
	{
		#region Variables
		/// <summary>
		/// <para>Areas del Nivel.</para>
		/// </summary>
		public List<Vector3> areasPos;						// Areas del Nivel
		/// <summary>
		/// <para>Prefabs de props del Nivel.</para>
		/// </summary>
		public List<string> prefabsProps;                   // Prefabs de props del Nivel
		/// <summary>
		/// <para>Area de los props.</para>
		/// </summary>
		public List<Vector3> areaProps;						// Area de los props
		#endregion
	}
}