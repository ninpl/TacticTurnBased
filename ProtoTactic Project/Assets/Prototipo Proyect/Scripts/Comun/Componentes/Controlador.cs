//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Bando.cs (31/07/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Tipo de Control												\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Tipo de Control	</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Componentes/Controlador")]
	public class Controlador : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Control normal</para>
		/// </summary>
		public Controladores normal;					// Control normal
		/// <summary>
		/// <para>Control especial</para>
		/// </summary>
		public Controladores especial;					// Control especial
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Control actual</para>
		/// </summary>
		public Controladores Actual
		{
			get { return especial != Controladores.None ? especial : normal; }
		}
		#endregion
	}
}