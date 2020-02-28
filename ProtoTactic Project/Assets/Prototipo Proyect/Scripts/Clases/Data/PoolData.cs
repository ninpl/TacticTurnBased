//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// PoolData.cs (17/07/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Data de la pool												\\
// Fecha Mod:		12/07/2017													\\
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
	/// <para>Data de la pool	.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Data/PoolData")]
	public class PoolData
	{
		#region Variables
		public GameObject prefab;
		public int maxCount;
		public Queue<Poolable> pool;
		#endregion
	}
}