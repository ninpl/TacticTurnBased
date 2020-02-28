//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// DerrotarTodosEnemigoObjetivoBatalla.cs (07/07/2017)							\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Objetivo de batalla eliminacion total						\\
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
	/// <para>Objetivo de batalla eliminacion total.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Objetivo Batalla/DerrotarTodosEnemigoObjetivoBatalla")]
	public class DerrotarTodosEnemigoObjetivoBatalla : BaseObjetivoBatalla
	{
		#region Metodos
		/// <summary>
		/// <para>Comprueba el game over</para>
		/// </summary>
		public override void ComprobarGameOver()// Comprueba el game over
		{
			base.ComprobarGameOver();

			if (Victoria == Bandos.None && PartyDerrotada(Bandos.Enemigo)) Victoria = Bandos.Aliado;
		}
		#endregion
	}
}