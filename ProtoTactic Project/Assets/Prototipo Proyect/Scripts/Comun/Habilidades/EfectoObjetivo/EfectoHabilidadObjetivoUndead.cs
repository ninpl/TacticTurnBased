//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EfectoHabilidadObjetivoUndead.cs (31/07/2017)								\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Habilidad efecto undead										\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Habilidad efecto undead</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/EfectoHabilidadObjetivoUndead")]
	public class EfectoHabilidadObjetivoUndead : EfectoHabilidadObjetivo
	{
		#region Variables
		/// <summary>
		/// <para>Indica si esta presente</para>
		/// </summary>
		public bool toggle;                                         // Indica si esta presente
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Target</para>
		/// </summary>
		/// <param name="area"></param>
		/// <returns></returns>
		public override bool IsTarget(Area area)// Target
		{
			if (area == null || area.contenido == null) return false;

			bool hasComponente = area.contenido.GetComponent<Undead>() != null;
			if (hasComponente != toggle) return false;

			Stats s = area.contenido.GetComponent<Stats>();
			return s != null && s[TipoStats.HP] > 0;
		}
		#endregion
	}
}