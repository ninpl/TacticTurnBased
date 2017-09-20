//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MinValorModificador.cs (22/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Modificador de valor - Min									\\
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
	/// <para>Modificador de valor - Min.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Modificadores/MinValorModificador")]
	public class MinValorModificador : ModificadorValor
	{
		#region Variables
		/// <summary>
		/// <para>Minimo</para>
		/// </summary>
		public float min;                           // Minimo
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="MinValueModificador"/></para>
		/// </summary>
		/// <param name="sortOrder">Order</param>
		/// <param name="min">Minimo</param>
		public MinValorModificador(int sortOrder, float min) : base(sortOrder)// Constructor de MinValorModificador
		{
			this.min = min;
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
			return Mathf.Min(min, toValue);
		}
		#endregion
	}
}