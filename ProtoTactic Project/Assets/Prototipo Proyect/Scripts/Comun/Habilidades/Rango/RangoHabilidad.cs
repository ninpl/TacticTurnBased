//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// RangoHabilidad.cs (25/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase Base del rango de habilidad							\\
// Fecha Mod:		25/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Comun;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase Base del rango de habilidad</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/RangoHabilidad")]
	public abstract class RangoHabilidad : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Rango horizontal</para>
		/// </summary>
		public int horizontal = 1;							// Rango horizontal
		/// <summary>
		/// <para>Rango vertical</para>
		/// </summary>
		public int vertical = int.MaxValue;                 // Rango vertical
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Orientacion</para>
		/// </summary>
		public virtual bool OrientacionPos
		{
			get { return true; }
		}

		/// <summary>
		/// <para>Direccion orientacion</para>
		/// </summary>
		public virtual bool OrientacionDir
		{
			get { return false; }
		}

		/// <summary>
		/// <para>Unidad</para>
		/// </summary>
		public Unidad Unidad
		{
			get { return GetComponentInParent<Unidad>(); }
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Obtener el area a rango</para>
		/// </summary>
		/// <param name="grid"></param>
		/// <returns></returns>
		public abstract List<Area> GetAreasARango(Glitch.Comun.Grid grid);// Obtener el area a rango
		#endregion
	}
}