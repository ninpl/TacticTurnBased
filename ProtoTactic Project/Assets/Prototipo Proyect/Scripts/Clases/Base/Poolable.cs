//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Poolable.cs (10/07/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase para el manager de la pool							\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase para el manager de la pool.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/Poolable")]
	public class Poolable : MonoBehaviour
	{
		#region Variables
		public string key;
		public bool isPooled;
		#endregion
	}
}