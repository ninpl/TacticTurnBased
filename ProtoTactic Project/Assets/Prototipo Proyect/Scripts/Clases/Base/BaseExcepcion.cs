//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// BaseExcepcion.cs (22/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base de excepcion										\\
// Fecha Mod:		22/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase base de excepcion.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/BaseExcepcion")]
	public class BaseExcepcion
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Toogle</para>
		/// </summary>
		public readonly bool defaultToggle;                             // Toogle
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Toogle</para>
		/// </summary>
		public bool Toggle { get; private set; }
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="BaseExcepcion"/></para>
		/// </summary>
		/// <param name="defaultToggle">Toggle</param>
		public BaseExcepcion(bool defaultToggle)// Constructor de BaseExcepcion
		{
			this.defaultToggle = defaultToggle;
			Toggle = defaultToggle;
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Voltea el toggle</para>
		/// </summary>
		public void FlipToggle()// Voltea el toggle
		{
			Toggle = !defaultToggle;
		}
		#endregion
	}
}