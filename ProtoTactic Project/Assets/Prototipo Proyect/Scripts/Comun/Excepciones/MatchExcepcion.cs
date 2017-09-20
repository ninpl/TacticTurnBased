//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MatchExcepcion.cs (28/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base de errores / exitos automaticos					\\
// Fecha Mod:		28/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase base de errores / exitos automaticos</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/MatchExcepcion")]
	public class MatchExcepcion : BaseExcepcion
	{
		#region Variables
		/// <summary>
		/// <para>Atacante</para>
		/// </summary>
		public readonly Unidad atacante;						// Atacante
		/// <summary>
		/// <para>Objetivo</para>
		/// </summary>
		public readonly Unidad objetivo;						// Objetivo
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="MatchExcepcion"/></para>
		/// </summary>
		/// <param name="atacante"></param>
		/// <param name="objetivo"></param>
		public MatchExcepcion(Unidad atacante, Unidad objetivo) : base(false)
		{
			this.atacante = atacante;
			this.objetivo = objetivo;
		}
		#endregion
	}
}