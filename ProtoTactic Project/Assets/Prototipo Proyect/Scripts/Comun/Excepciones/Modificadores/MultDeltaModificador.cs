//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MultDeltaModificador.cs (26/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Modificador de valor - Multiplicar (Delta)					\\
// Fecha Mod:		26/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Modificador de valor - Multiplicar (Delta).</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Modificadores/MultDeltaModificador")]
	public class MultDeltaModificador : ModificadorValor
	{
		#region Variables
		/// <summary>
		/// <para>Multiply</para>
		/// </summary>
		public readonly float toMultiply;                           // Multiply
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="MultDeltaModificador"/></para>
		/// </summary>
		/// <param name="sortOrder">Order</param>
		/// <param name="toMultiply">Multiply</param>
		public MultDeltaModificador(int sortOrder, float toMultiply) : base(sortOrder)// Constructor de MultDeltaModificador
		{
			this.toMultiply = toMultiply;
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Modificador</para>
		/// </summary>
		/// <returns></returns>
		public override float Modificador(float fromValue, float toValue)// Modificador
		{
			float delta = toValue - fromValue;
			return fromValue + delta * toMultiply;
		}
		#endregion
	}
}