//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// AreaHabilidadUnidad.cs (25/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase tipo de area de efecto de la unidad					\\
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
	/// <para>Clase tipo de area de efecto de la unidad</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/AreaHabilidadUnidad")]
	public class AreaHabilidadUnidad : AreaHabilidad
	{
		#region Metodos
		/// <summary>
		/// <para>Obtener el area en area</para>
		/// </summary>
		/// <param name="grid">Grid</param>
		/// <param name="pos">Posicion</param>
		/// <returns></returns>
		public override List<Area> GetAreasEnArea(Grid grid, Punto pos)// Obtener el area en area
		{
			List<Area> retValue = new List<Area>();
			Area area = grid.GetArea(pos);
			if (area != null) retValue.Add(area);
			return retValue;
		}
		#endregion
	}
}
