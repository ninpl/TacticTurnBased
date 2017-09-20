//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// AreaHabilidadEntera.cs (25/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase tipo de area de efecto full							\\
// Fecha Mod:		25/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase tipo de area de efecto full</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/AreaHabilidadEntera")]
	public class AreaHabilidadEntera : AreaHabilidad
	{
		#region Metodos
		/// <summary>
		/// <para>Obtener el area en area</para>
		/// </summary>
		/// <param name="grid">Grid</param>
		/// <param name="pos">Posicion</param>
		/// <returns></returns>
		public override List<Area> GetAreasEnArea(Grid board, Punto pos)
		{
			RangoHabilidad rh = GetComponent<RangoHabilidad>();
			return rh.GetAreasARango(board);
		}
		#endregion
	}
}