//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// RangoHabilidadConstante.cs (25/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase tipo de rango de habilidad constante					\\
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
	/// <para>Clase tipo de rango de habilidad constante</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/RangoHabilidadConstante")]
	public class RangoHabilidadConstante : RangoHabilidad
	{
		#region Metodos
		/// <summary>
		/// <para>Obtener el area a rango</para>
		/// </summary>
		/// <param name="grid">Grid</param>
		/// <returns></returns>
		public override List<Area> GetAreasARango(Grid grid)// Obtener el area a rango
		{
			return grid.Buscar(Unidad.Area, Criterio);
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
			return (from.distancia + 1) <= horizontal && Mathf.Abs(to.altura - Unidad.Area.altura) <= vertical;
		}
		#endregion
	}
}