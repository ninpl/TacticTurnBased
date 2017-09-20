//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Modificador.cs (22/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base de los modificadores de estadisticas				\\
// Fecha Mod:		22/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase base de los modificadores de estadisticas.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/Modificador")]
	public abstract class Modificador
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Orden de la clasificacion del modificador</para>
		/// </summary>
		public readonly int sortOrder;                                          // Orden de la clasificacion del modificador
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="Modificador"/></para>
		/// </summary>
		/// <param name="sortOrder">Orden</param>
		public Modificador(int sortOrder)// Constructor de Modificador
		{
			this.sortOrder = sortOrder;
		}
		#endregion
	}
}