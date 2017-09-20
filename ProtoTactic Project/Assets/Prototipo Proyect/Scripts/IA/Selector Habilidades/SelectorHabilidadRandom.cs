//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// SelectorHabilidadRandom.cs (16/08/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Selector de habilidades aleatorias							\\
// Fecha Mod:		16/08/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.AI;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Selector de habilidades aleatorias</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/SelectorHabilidadRandom")]
	public class SelectorHabilidadRandom : BaseSelectorHabilidades
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Seleccion de habilidades</para>
		/// </summary>
		public List<BaseSelectorHabilidades> seleccion;						// Seleccion de habilidades
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Eleccion de habilidades</para>
		/// </summary>
		/// <param name="plan"></param>
		public override void Eleccion(PlanDeAtaque plan)// Eleccion de habilidades
		{
			int index = Random.Range(0, seleccion.Count);
			BaseSelectorHabilidades p = seleccion[index];
			p.Eleccion(plan);
		}
		#endregion
	}
}