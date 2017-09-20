//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EfectoHabilidadVida.cs (31/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase del heal												\\
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
	/// <para>Clase del heal</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/EfectoHabilidadVida")]
	public class EfectoHabilidadVida : BaseEfectoHabilidad
	{
		#region Metodos
		/// <summary>
		/// <para>Predice el heal de una habilidad</para>
		/// </summary>
		/// <param name="target">Area de heal</param>
		/// <returns></returns>
		public override int Predecir(Area target)// Predice el heal de una habilidad
		{
			Unidad atacante = GetComponentInParent<Unidad>();
			Unidad defensor = target.contenido.GetComponent<Unidad>();
			return GetStat(atacante, defensor, GetPoderNotificacion, 0);
		}

		/// <summary>
		/// <para>Aplica el heal en un area</para>
		/// </summary>
		/// <param name="target">Area</param>
		public override int OnAplicar(Area target)// Aplica el heal en un area
		{
			Unidad defensor = target.contenido.GetComponent<Unidad>();

			// Predecir el valor
			int value = Predecir(target);

			// Agregar variacion
			value = Mathf.FloorToInt(value * Random.Range(0.9f, 1.1f));

			// Comprobar limites
			value = Mathf.Clamp(value, minDamage, maxDamage);

			// Aplicar el valor
			Stats s = defensor.GetComponent<Stats>();
			s[TipoStats.HP] += value;
			return value;
		}
		#endregion
	}
}