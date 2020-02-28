//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EfectoHabilidadObjetivoDefaultKO.cs (25/07/2017)								\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base del area de efecto del objetivo ko				\\
// Fecha Mod:		25/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase base del area de efecto del objetivo ko</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/EfectoHabilidadObjetivoDefaultKO")]
	public class EfectoHabilidadObjetivoKO : EfectoHabilidadObjetivo
	{
		#region Metodos
		/// <summary>
		/// <para>Determina si tiene objetivo</para>
		/// </summary>
		/// <param name="area">Area</param>
		/// <returns></returns>
		public override bool IsTarget(Area area)// Determina si tiene objetivo
		{
			if (area == null || area.contenido == null) return false;

			Stats s = area.contenido.GetComponent<Stats>();
			return s != null && s[TipoStats.HP] <= 0;
		}
		#endregion
	}
}