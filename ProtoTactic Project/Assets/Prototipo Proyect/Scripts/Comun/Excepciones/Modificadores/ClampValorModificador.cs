//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ClampValorModificador.cs (22/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Modificador de valor - Clamp								\\
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
	/// <para>Modificador de valor - Clamp.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Modificadores/ClampValorModificador")]
	public class ClampValorModificador : ModificadorValor
	{
		#region Variables
		/// <summary>
		/// <para>Minimo</para>
		/// </summary>
		public readonly float min;								// Minimo
		/// <summary>
		/// <para>Maximo</para>
		/// </summary>
		public readonly float max;                              // Maximo
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="ClampValorModificador"/></para>
		/// </summary>
		/// <param name="sortOrder">Order</param>
		/// <param name="min">Minimo</param>
		/// <param name="max">Maximo</param>
		public ClampValorModificador(int sortOrder, float min, float max) : base(sortOrder)// Constructor de ClampValorModificador
		{
			this.min = min;
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
			return Mathf.Clamp(toValue, min, max);
		}
		#endregion
	}
}