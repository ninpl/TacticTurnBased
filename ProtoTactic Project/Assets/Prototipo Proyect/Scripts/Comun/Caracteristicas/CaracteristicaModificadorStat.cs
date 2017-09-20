//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CaracteristicaModificadorStat.cs (22/07/2017)								\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Caracteristica modificadora de stat							\\
// Fecha Mod:		22/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Caracteristica modificadora de stat.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/CaracteristicaModificadorStat")]
	public class CaracteristicaModificadorStat : Caracteristica
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Tipo de stats</para>
		/// </summary>
		public TipoStats tipo;						// Tipo de stats
		/// <summary>
		/// <para>Cantidad</para>
		/// </summary>
		public int valor;                           // Cantidad
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Estadisticas</para>
		/// </summary>
		public Stats Stats
		{
			get { return Objetivo.GetComponentInParent<Stats>(); }
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando se aplica</para>
		/// </summary>
		public override void OnAplicar()// Cuando se aplica
		{
			Stats[tipo] += valor;
		}

		/// <summary>
		/// <para>Cuando se quita</para>
		/// </summary>
		public override void OnQuitar()// Cuando se quita
		{
			Stats[tipo] -= valor;
		}
		#endregion
	}
}