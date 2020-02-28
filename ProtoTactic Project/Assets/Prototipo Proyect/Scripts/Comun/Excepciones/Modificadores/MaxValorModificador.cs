//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MaxValueModificador.cs (22/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Modificador de valor - Max									\\
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
	/// <para>Modificador de valor - Max.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Modificadores/MaxValorModificador")]
	public class MaxValorModificador : ModificadorValor
	{
		#region Variables
		/// <summary>
		/// <para>Maximo</para>
		/// </summary>
		public float max;                                       // Maximo
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="MaxValorModificador"/></para>
		/// </summary>
		/// <param name="sortOrder">Order</param>
		/// <param name="max">Maximo</param>
		public MaxValorModificador(int sortOrder, float max) : base(sortOrder)// Constructor de MaxValorModificador
		{
			this.max = max;
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
			return Mathf.Max(toValue, max);
		}
		#endregion
	}
}