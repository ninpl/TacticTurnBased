//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// PatronAtaque.cs (17/08/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Patron de ataque											\\
// Fecha Mod:		17/08/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.AI
{
	/// <summary>
	/// <para>Patron de ataque</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/AI/PatronAtaque")]
	public class PatronAtaque : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Seleccion</para>
		/// </summary>
		public List<BaseSelectorHabilidades> Seleccion;			// Seleccion
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Index del patron</para>
		/// </summary>
		private int index;                                      // Index del patron
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Eleccion de patron</para>
		/// </summary>
		/// <param name="plan"></param>
		public void Eleccion(PlanDeAtaque plan)// Eleccion de patron
		{
			Seleccion[index].Eleccion(plan);
			index++;
			if (index >= Seleccion.Count) index = 0;
		}
		#endregion
	}
}