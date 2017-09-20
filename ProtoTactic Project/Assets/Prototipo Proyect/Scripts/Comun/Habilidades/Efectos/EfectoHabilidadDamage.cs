//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EfectoHabilidadDamage.cs (29/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase del damage											\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase del damage</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/EfectoHabilidadDamage")]
	public class EfectoHabilidadDamage : BaseEfectoHabilidad
	{
		#region Metodos
		/// <summary>
		/// <para>Predice el damage de un ataque</para>
		/// </summary>
		/// <param name="target">Area de ataque</param>
		/// <returns></returns>
		public override int Predecir(Area target)// Predice el damage de un ataque
		{
			Unidad atacante = GetComponentInParent<Unidad>();
			Unidad defensor = target.contenido.GetComponent<Unidad>();

			// Obtener la base de ataque de los atacantes considerando
			// los objetos, ayudas, estado y equipo, etc
			int ataque = GetStat(atacante, defensor, GetAtaqueNotificacion, 0);

			// Obtener la base de defensa de los atacantes considerando
			// los objetos, ayudas, estado y equipo, etc
			int defensa = GetStat(atacante, defensor, GetDefensaNotificacion, 0);

			// Calcular el damage base
			int damage = ataque - (defensa / 2);
			damage = Mathf.Max(damage, 1);

			// Obtener las habilidades de los stats considerando posibles variaciones
			int poder = GetStat(atacante, defensor, GetPoderNotificacion, 0);

			// Aplicar bonus
			damage = poder * damage / 100;
			damage = Mathf.Max(damage, 1);

			// Ajusta el damage basado en una variedad de otros controles como
			// damage elemental, golpes criticos, multiplicadores de damage, etc.
			damage = GetStat(atacante, defensor, AjustarDamageNotificacion, damage);

			// Comprueba el limite
			damage = Mathf.Clamp(damage, minDamage, maxDamage);
			return -damage;
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Aplica el damage en un area</para>
		/// </summary>
		/// <param name="target">Area</param>
		public override int OnAplicar(Area target)// Aplica el damage en un area
		{
			Unidad defensor = target.contenido.GetComponent<Unidad>();

			// Predecir el valor
			int value = Predecir(target);

			// Agregar una variacion
			value = Mathf.FloorToInt(value * UnityEngine.Random.Range(0.9f, 1.1f));

			// Comprobar el rango
			value = Mathf.Clamp(value, minDamage, maxDamage);

			// Aplicar el damage
			Stats s = defensor.GetComponent<Stats>();
			s[TipoStats.HP] += value;
			return value;
		}
		#endregion
	}
}