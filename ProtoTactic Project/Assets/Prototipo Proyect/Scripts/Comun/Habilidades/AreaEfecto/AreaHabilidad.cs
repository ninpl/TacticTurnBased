//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// AreaHabilidad.cs (31/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Area de efecto de la habilidad								\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Comun;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Area de efecto de la habilidad</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/AreaHabilidad")]
	public abstract class AreaHabilidad : MonoBehaviour
	{
		#region Metodos
		/// <summary>
		/// <para>Obtener las areas en el area</para>
		/// </summary>
		/// <param name="board"></param>
		/// <param name="pos"></param>
		/// <returns></returns>
        public abstract List<Area> GetAreasEnArea(Glitch.Comun.Grid board, Punto pos);
		#endregion
	}
}