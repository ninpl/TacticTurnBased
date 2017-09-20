//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EfectoHabilidadObjetivo.cs (25/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base del area de efecto del objetivo					\\
// Fecha Mod:		25/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Comun;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase base del area de efecto del objetivo</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/EfectoHabilidadObjetivo")]
	public abstract class EfectoHabilidadObjetivo : MonoBehaviour
	{
		#region Metodos
		/// <summary>
		/// <para>Determina si tiene objetivo</para>
		/// </summary>
		/// <param name="area">Area</param>
		/// <returns></returns>
		public abstract bool IsTarget(Area area);// Determina si tiene objetivo
		#endregion
	}
}