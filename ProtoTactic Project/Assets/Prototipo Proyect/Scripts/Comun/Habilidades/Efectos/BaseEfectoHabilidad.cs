//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// BaseEfectoHabilidad.cs (29/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base de los efectos de habilidades					\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase base de los efectos de habilidades</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/BaseEfectoHabilidad")]
	public abstract class BaseEfectoHabilidad : MonoBehaviour
	{
		#region Notificaciones
		public const string GetAtaqueNotificacion = "BaseEfectoHabilidad.GetAtaqueNotificacion";
		public const string GetDefensaNotificacion = "BaseEfectoHabilidad.GetDefensaNotificacion";
		public const string GetPoderNotificacion = "BaseEfectoHabilidad.GetPoderNotificacion";
		public const string AjustarDamageNotificacion = "BaseEfectoHabilidad.AjustarDamageNotificacion";
		public const string EsquivadoNotificacion = "BaseEfectoHabilidad.EsquivadoNotificacion";
		public const string HitNotificacion = "BaseEfectoHabilidad.HitNotificacion";
		#endregion

		#region Variables
		/// <summary>
		/// <para>Damage minimo</para>
		/// </summary>
		public const int minDamage = -999;							// Damage minimo
		/// <summary>
		/// <para>Damage maximo</para>
		/// </summary>
		public const int maxDamage = 999;                           // Damage maximo
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Aplica el efecto de una habilidad</para>
		/// </summary>
		/// <param name="target">Area</param>
		public void Aplicar(Area target)// Aplica el efecto de una habilidad
		{
			if (GetComponent<EfectoHabilidadObjetivo>().IsTarget(target) == false) return;

			if (GetComponent<TasaExito>().CalcularParaGolpear(target))
			{
				this.EnviarNotificacion(HitNotificacion, OnAplicar(target));
			}
			else
			{
				this.EnviarNotificacion(EsquivadoNotificacion);
			}
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Predice el efecto de una habilidad</para>
		/// </summary>
		/// <param name="target">Area</param>
		/// <returns></returns>
		public abstract int Predecir(Area target);// Predice el efecto de una habilidad

		/// <summary>
		/// <para>Cuando se aplica un efecto</para>
		/// </summary>
		/// <param name="target">Area</param>
		/// <returns></returns>
		public abstract int OnAplicar(Area target);// Cuando se aplica un efecto

		/// <summary>
		/// <para>Obtiene un stat</para>
		/// </summary>
		/// <param name="atacante"></param>
		/// <param name="objetivo"></param>
		/// <param name="notificacion"></param>
		/// <param name="valorInicial"></param>
		/// <returns></returns>
		public virtual int GetStat(Unidad atacante, Unidad objetivo, string notificacion, int valorInicial)// Obtiene un stat
		{
			var mods = new List<ModificadorValor>();
			var info = new Info<Unidad, Unidad, List<ModificadorValor>>(atacante, objetivo, mods);
			this.EnviarNotificacion(notificacion, info);
			mods.Sort(Comparar);

			float value = valorInicial;
			for (int n = 0; n < mods.Count; n++)
			{
				value = mods[n].Modificador(valorInicial, value);
			}

			int retValue = Mathf.FloorToInt(value);
			retValue = Mathf.Clamp(retValue, minDamage, maxDamage);
			return retValue;
		}

		/// <summary>
		/// <para>Comparar dos modificadores de valor</para>
		/// </summary>
		/// <param name="x">Valor 0</param>
		/// <param name="y">Valor 1</param>
		/// <returns></returns>
		private int Comparar(ModificadorValor x, ModificadorValor y)// Comparar dos modificadores de valor
		{
			return x.sortOrder.CompareTo(y.sortOrder);
		}
		#endregion
	}
}