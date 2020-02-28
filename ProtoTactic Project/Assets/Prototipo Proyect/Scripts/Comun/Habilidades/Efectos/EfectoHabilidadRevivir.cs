//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EfectoHabilidadRevivir.cs (31/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Efecto de habilidad revivir									\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Efecto de habilidad revivir</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/EfectoHabilidadRevivir")]
	public class EfectoHabilidadRevivir : BaseEfectoHabilidad
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Porcentaje</para>
		/// </summary>
		public float porcentaje;                                // Porcentaje
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Predecir</para>
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public override int Predecir(Area target)// Predecir
		{
			Stats s = target.contenido.GetComponent<Stats>();
			return Mathf.FloorToInt(s[TipoStats.MHP] * porcentaje);
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Cuando se aplica</para>
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public override int OnAplicar(Area target)// Cuando se aplica
		{
			Stats s = target.contenido.GetComponent<Stats>();
			int value = s[TipoStats.HP] = Predecir(target);
			return value;
		}
		#endregion
	}
}