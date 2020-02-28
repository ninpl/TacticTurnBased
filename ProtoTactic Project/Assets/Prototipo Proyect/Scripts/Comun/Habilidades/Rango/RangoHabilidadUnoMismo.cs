//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// RangoHabilidadSelf.cs (25/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase tipo de rango de habilidad a uno mismo				\\
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
	/// <para>Clase tipo de rango de habilidad a uno mismo</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/RangoHabilidadUnoMismo")]
	public class RangoHabilidadUnoMismo : RangoHabilidad
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
			List<Area> retValue = new List<Area>(1);
			retValue.Add(Unidad.Area);
			return retValue;
		}
		#endregion
	}
}