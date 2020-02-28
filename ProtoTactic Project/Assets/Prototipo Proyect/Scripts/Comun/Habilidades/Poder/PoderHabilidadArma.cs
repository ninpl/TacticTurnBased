//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// PoderHabilidadArma.cs (30/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Poder de habilidad arma										\\
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
	/// <para>Poder de habilidad arma</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/PoderHabilidadArma")]
	public class PoderHabilidadArma : BasePoderHabilidad
	{
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

		/// <summary>
		/// <para>Obtiene el poder</para>
		/// </summary>
		/// <returns></returns>
		public override int GetPoder()// Obtiene el poder
		{
			int poder = PoderArmaEquipada();
			return poder > 0 ? poder : PoderArmaDesequipada();
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Obtiene el poder del arma equipada</para>
		/// </summary>
		/// <returns></returns>
		private int PoderArmaEquipada()// Obtiene el poder del arma equipada
		{
			int power = 0;
			Equipamiento eq = GetComponentInParent<Equipamiento>();
			Equipable item = eq.GetItem(SlotsEquipo.Primaria);
			CaracteristicaModificadorStat[] features = item.GetComponentsInChildren<CaracteristicaModificadorStat>();

			for (int i = 0; i < features.Length; i++)
			{
				if (features[i].tipo == TipoStats.ATK)
					power += features[i].valor;
			}

			return power;
		}

		/// <summary>
		/// <para>Obtiene el poder del arma desequipada</para>
		/// </summary>
		/// <returns></returns>
		private int PoderArmaDesequipada()// Obtiene el poder del arma desequipada
		{
			Oficio job = GetComponentInParent<Oficio>();
			for (int i = 0; i < Oficio.statOrden.Length; i++)
			{
				if (Oficio.statOrden[i] == TipoStats.ATK) return job.baseStats[i];
			}
			return 0;
		}
		#endregion
	}
}