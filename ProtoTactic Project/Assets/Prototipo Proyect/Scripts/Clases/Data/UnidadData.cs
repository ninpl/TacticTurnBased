//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// UnidadData.cs (31/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Data de la unidad											\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Comun;
#endregion

namespace MoonAntonio.Glitch.Data
{
	/// <summary>
	/// <para>Data de la unidad</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Data/UnidadData")]
	public class UnidadData : ScriptableObject
	{
		#region Variables
		/// <summary>
		/// <para>Malla del personaje</para>
		/// </summary>
		public string modelo;								// Malla del personaje
		/// <summary>
		/// <para>Oficio del personaje</para>
		/// </summary>
		public string oficio;								// Oficio del personaje
		/// <summary>
		/// <para>Ataque del personaje</para>
		/// </summary>
		public string ataque;								// Ataque del personaje
		/// <summary>
		/// <para>Catalogo de habilidades del personaje</para>
		/// </summary>
		public string catalogoHabilidades;					// Catalogo de habilidades del personaje
		/// <summary>
		/// <para>Tipo de movimientos del personaje</para>
		/// </summary>
		public TipoMovimiento tipoMovimiento;				// Tipo de movimientos del personaje
		/// <summary>
		/// <para>Bando del personaje</para>
		/// </summary>
		public Bandos bando;								// Bando del personaje
		/// <summary>
		/// <para>Estrategia del personaje</para>
		/// </summary>
		public string estrategia;							// Estrategia del personaje
		#endregion
	}
}