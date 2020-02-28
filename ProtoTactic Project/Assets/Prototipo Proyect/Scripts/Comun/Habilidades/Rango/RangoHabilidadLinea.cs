//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// RangoHabilidadLinea.cs (25/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase tipo de rango de habilidad en linea					\\
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
	/// <para>Clase tipo de rango de habilidad en linea</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/RangoHabilidadLinea")]
	public class RangoHabilidadLinea : RangoHabilidad
	{
		#region Propiedades
		/// <summary>
		/// <para>Orientacion</para>
		/// </summary>
		public override bool OrientacionDir
		{
			get { return true; }
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
			Punto posInicial = Unidad.Area.pos;
			Punto posFinal;
			List<Area> retValue = new List<Area>();

			switch (Unidad.dir)
			{
				case Direcciones.Norte:
					posFinal = new Punto(posInicial.x, grid.Max.y);
					break;
				case Direcciones.Este:
					posFinal = new Punto(grid.Max.x, posInicial.y);
					break;
				case Direcciones.Sur:
					posFinal = new Punto(posInicial.x, grid.Min.y);
					break;
				default: // West
					posFinal = new Punto(grid.Min.x, posInicial.y);
					break;
			}

			int dist = 0;
			while (posInicial != posFinal)
			{
				if (posInicial.x < posFinal.x) posInicial.x++;
				else if (posInicial.x > posFinal.x) posInicial.x--;

				if (posInicial.y < posFinal.y) posInicial.y++;
				else if (posInicial.y > posFinal.y) posInicial.y--;

				Area a = grid.GetArea(posInicial);
				if (a != null && Mathf.Abs(a.altura - Unidad.Area.altura) <= vertical) retValue.Add(a);

				dist++;
				if (dist >= horizontal) break;
			}

			return retValue;
		}
		#endregion
	}
}