//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// DerrotarUnEnemigoObjetivoBatalla.cs (07/07/2017)								\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Objetivo de batalla eliminacion unidad						\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Objetivo de batalla eliminacion unidad.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Objetivo Batalla/DerrotarUnEnemigoObjetivoBatalla")]
	public class DerrotarUnEnemigoObjetivoBatalla : BaseObjetivoBatalla
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Objetivo de la batalla</para>
		/// </summary>
		public Unidad target;                                       // Objetivo de la batalla
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Comprueba el game over</para>
		/// </summary>
		public override void ComprobarGameOver()// Comprueba el game over
		{
			base.ComprobarGameOver();

			if (Victoria == Bandos.None && IsDerrotada(target)) Victoria = Bandos.Aliado;
		}
		#endregion
	}
}