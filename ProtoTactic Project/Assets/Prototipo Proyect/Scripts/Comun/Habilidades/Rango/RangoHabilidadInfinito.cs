//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// RangoHabilidadInfinito.cs (25/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase tipo de rango de habilidad infinito					\\
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
	/// <para>Clase tipo de rango de habilidad infinito</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/RangoHabilidadInfinito")]
	public class RangoHabilidadInfinito : RangoHabilidad
	{
		#region Propiedades
		/// <summary>
		/// <para>Orientacion</para>
		/// </summary>
		public override bool OrientacionPos
		{
			get { return false; }
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Obtener el area a rango</para>
		/// </summary>
		/// <param name="grid">Grid</param>
		/// <returns></returns>
		public override List<Area> GetAreasARango(Grid grid)// Obtener el area a rango
		{
			return new List<Area>(grid.areas.Values);
		}
		#endregion
	}
}