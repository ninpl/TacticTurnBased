//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// SelectorHabilidadFija.cs (16/08/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Selector de habilidades fijas								\\
// Fecha Mod:		16/08/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.AI;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Selector de habilidades fijas</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/SelectorHabilidadFija")]
	public class SelectorHabilidadFija : BaseSelectorHabilidades
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Objetivo</para>
		/// </summary>
		public Objetivos objetivo;							// Objetivo
		/// <summary>
		/// <para>Habilidad a elegir</para>
		/// </summary>
		public string habilidad;                            // Habilidad a elegir
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Eleccion de habilidades</para>
		/// </summary>
		/// <param name="plan"></param>
		public override void Eleccion(PlanDeAtaque plan)// Eleccion de habilidades
		{
			plan.objetivo = objetivo;
			plan.habilidad = Buscar(habilidad);

			if (plan.habilidad == null)
			{
				plan.habilidad = Default();
				plan.objetivo = Objetivos.Enemigo;
			}
		}
		#endregion

	}
}