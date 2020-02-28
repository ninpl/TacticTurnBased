//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Bando.cs (31/07/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Tipo de bando												\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Tipo de bando</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Componentes/Bando")]
	public class Bando : MonoBehaviour
	{
		#region Variables
		/// <summary>
		/// <para>Tipo de bando</para>
		/// </summary>
		public Bandos tipo;							// Tipo de bando
		/// <summary>
		/// <para>Determina si esta confusa la unidad</para>
		/// </summary>
		public bool IsConfuso;						// Determina si esta confusa la unidad
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Determina el bando</para>
		/// </summary>
		/// <param name="bando"></param>
		/// <param name="objetivos"></param>
		/// <returns></returns>
		public bool IsCalculo(Bando bando, Objetivos objetivos)// Determina el bando
		{
			bool isCalculo = false;
			switch (objetivos)
			{
				case Objetivos.UnoMismo:
					isCalculo = bando == this;
					break;
				case Objetivos.Aliado:
					isCalculo = tipo == bando.tipo;
					break;
				case Objetivos.Enemigo:
					isCalculo = (tipo != bando.tipo) && bando.tipo != Bandos.Neutral;
					break;
			}
			return IsConfuso ? !isCalculo : isCalculo;
		}
		#endregion
	}
}