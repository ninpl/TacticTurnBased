//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// RangoHabilidadCono.cs (25/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase tipo de rango de habilidad en cono					\\
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
	/// <para>Clase tipo de rango de habilidad en cono</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/RangoHabilidadCono")]
	class RangoHabilidadCono : RangoHabilidad
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
			Punto pos = Unidad.Area.pos;
			List<Area> retValue = new List<Area>();
			int dir = (Unidad.dir == Direcciones.Norte || Unidad.dir == Direcciones.Este) ? 1 : -1;
			int lateral = 1;

			if (Unidad.dir == Direcciones.Norte || Unidad.dir == Direcciones.Sur)
			{
				for (int n = 1; n <= horizontal; n++)
				{
					int min = -(lateral / 2);
					int max = (lateral / 2);
					for (int i = min; i <= max; i++)
					{
						Punto next = new Punto(pos.x + i, pos.y + (n * dir));
						Area area = grid.GetArea(next);
						if (ComprobarAreaValida(area)) retValue.Add(area);
					}
					lateral += 2;
				}
			}
			else
			{
				for (int n = 1; n <= horizontal; n++)
				{
					int min = -(lateral / 2);
					int max = (lateral / 2);
					for (int i = min; i <= max; i++)
					{
						Punto next = new Punto(pos.x + (n * dir), pos.y + i);
						Area area = grid.GetArea(next);
						if (ComprobarAreaValida(area)) retValue.Add(area);
					}
					lateral += 2;
				}
			}

			return retValue;
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Comprueba si es valida la area</para>
		/// </summary>
		/// <param name="a">Area</param>
		/// <returns></returns>
		private bool ComprobarAreaValida(Area a)// Comprueba si es valida la area
		{
			return a != null && Mathf.Abs(a.altura - Unidad.Area.altura) <= vertical;
		}
		#endregion
	}
}