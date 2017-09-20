//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// AreaHabilidadEspecifica.cs (25/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase tipo de area de efecto especifica						\\
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
	/// <para>Clase tipo de area de efecto especifica</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/AreaHabilidadEspecifica")]
	public class AreaHabilidadEspecifica : AreaHabilidad
	{
		#region Variables
		/// <summary>
		/// <para>Horizontal</para>
		/// </summary>
		public int horizontal;				// Horizontal
		/// <summary>
		/// <para>Vertical</para>
		/// </summary>
		public int vertical;				// Vertical
		/// <summary>
		/// <para>Area</para>
		/// </summary>
		private Area area;					// Area
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Obtener el area en area</para>
		/// </summary>
		/// <param name="grid">Grid</param>
		/// <param name="pos">Posicion</param>
		/// <returns></returns>
		public override List<Area> GetAreasEnArea(Grid grid, Punto pos)// Obtener el area en area
		{
			area = grid.GetArea(pos);
			return grid.Buscar(area, Criterio);
		}
		#endregion

		#region Funcionalidades
		/// <summary>
		/// <para>Criterio</para>
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		private bool Criterio(Area from, Area to)// Criterio
		{
			return (from.distancia + 1) <= horizontal && Mathf.Abs(to.altura - area.altura) <= vertical;
		}
		#endregion
	}
}