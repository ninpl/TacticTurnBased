//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// PlanDeAtaque.cs (17/08/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase del plan de ataque									\\
// Fecha Mod:		17/08/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Comun;
#endregion

namespace MoonAntonio.Glitch.AI
{
	/// <summary>
	/// <para>Clase del plan de ataque</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/AI/PlanDeAtaque")]
	public class PlanDeAtaque
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Habilidad del plan</para>
		/// </summary>
		public Habilidad habilidad;					// Habilidad del plan
		/// <summary>
		/// <para>Objetivo</para>
		/// </summary>
		public Objetivos objetivo;					// Objetivo
		/// <summary>
		/// <para>Posicion de movimiento</para>
		/// </summary>
		public Punto posMovi;						// Posicion de movimiento
		/// <summary>
		/// <para>Posicion de ataque</para>
		/// </summary>
		public Punto posAtaque;						// Posicion de ataque
		/// <summary>
		/// <para>Direccion de ataque</para>
		/// </summary>
		public Direcciones dirAtaque;				// Direccion de ataque
		#endregion
	}
}