//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MultValorModificador.cs (22/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Modificador de valor - Multiplicar							\\
// Fecha Mod:		26/07/2017													\\
// Ultima Mod:		Refactorizar Modificador									\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Modificador de valor - Multiplicar.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Modificadores/MultValorModificador")]
	public class MultValorModificador : ModificadorValor
	{
		#region Variables
		/// <summary>
		/// <para>Multiplicar</para>
		/// </summary>
		public readonly float toMultiply;                   // Multiplicar
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="MultValueModificador"/></para>
		/// </summary>
		/// <param name="sortOrder">Order</param>
		/// <param name="toMultiply">Multiplicador</param>
		public MultValorModificador(int sortOrder, float toMultiply) : base(sortOrder)// Constructor de MultValueModificador
		{
			this.toMultiply = toMultiply;
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Modificador</para>
		/// </summary>
		/// <param name="value">Valor</param>
		/// <returns></returns>
		public override float Modificador(float fromValue, float toValue)// Modificador
		{
			return toValue * toMultiply;
		}
		#endregion
	}
}