//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ModificadorValor.cs (22/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base de los valores modificados						\\
// Fecha Mod:		26/07/2017													\\
// Ultima Mod:		Refactorizar Modificador									\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase base de los valores modificados.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/ModificadorValor")]
	public abstract class ModificadorValor : Modificador
	{
		#region Metodos
		public ModificadorValor(int sortOrder) : base(sortOrder) { }
		public abstract float Modificador(float fromValue, float toValue);
		#endregion
	}
}