//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// AddValorModificador.cs (22/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Modificador de valor - Add									\\
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
	/// <para>Modificador de valor - Add.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Modificadores/AddValorModificador")]
	public class AddValorModificador : ModificadorValor
	{
		#region Variables
		/// <summary>
		/// <para>Agregar valor</para>
		/// </summary>
		public readonly float toAdd;                            // Agregar valor
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="AddValorModificador"/></para>
		/// </summary>
		/// <param name="sortOrder">Orden</param>
		/// <param name="toAdd">Valor</param>
		public AddValorModificador(int sortOrder, float toAdd) : base(sortOrder)// Constructor de AddValorModificador
		{
			this.toAdd = toAdd;
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
			return toValue + toAdd;
		}
		#endregion
	}
}