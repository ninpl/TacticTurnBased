//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// PoderHabilidadFisico.cs (30/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Poder de habilidad fisica									\\
// Fecha Mod:		30/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Poder de habilidad fisica</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/PoderHabilidadFisico")]
	public class PoderHabilidadFisico : BasePoderHabilidad
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Nivel</para>
		/// </summary>
		public int nivel;                           // Nivel
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Obtiene el ataque base</para>
		/// </summary>
		/// <returns></returns>
		public override int GetBaseAtaque()// Obtiene el ataque base
		{
			return GetComponentInParent<Stats>()[TipoStats.ATK];
		}

		/// <summary>
		/// <para>Obtiene la defensa base</para>
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public override int GetBaseDefensa(Unidad target)// Obtiene la defensa base
		{
			return target.GetComponent<Stats>()[TipoStats.DEF];
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Obtiene el poder</para>
		/// </summary>
		/// <returns></returns>
		public override int GetPoder()// Obtiene el poder
		{
			return nivel;
		}
		#endregion
	}
}