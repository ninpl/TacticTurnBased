//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Equipable.cs (22/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base del item equipable								\\
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
	/// <para>Clase base del item equipable.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Items/Equipable")]
	public class Equipable : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Ubicacion predeterminada</para>
		/// </summary>
		public SlotsEquipo slotsPrincipales;			// Ubicacion predeterminada
		/// <summary>
		/// <para>Ubicacion slots secundarios</para>
		/// </summary>
		public SlotsEquipo slotsSecundarios;			// Ubicacion slots secundarios
		/// <summary>
		/// <para>Slots donde ya hay un item</para>
		/// </summary>
		public SlotsEquipo slots;                       // Slots donde ya hay un item
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Item equipado</para>
		/// </summary>
		private bool isEquipado;                        // Item equipado
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando esta equipado</para>
		/// </summary>
		public void OnEquipar()// Cuando esta equipado
		{
			if (isEquipado) return;

			isEquipado = true;

			Caracteristica[] caracteristicas = GetComponentsInChildren<Caracteristica>();
			for (int n = 0; n < caracteristicas.Length; n++)
			{
				caracteristicas[n].Activar(gameObject);
			}
		}

		/// <summary>
		/// <para>Cuando esta desequipado</para>
		/// </summary>
		public void OnDesequipar()// Cuando esta desequipado
		{
			if (!isEquipado) return;

			isEquipado = false;

			Caracteristica[] caracteristicas = GetComponentsInChildren<Caracteristica>();
			for (int n = 0; n < caracteristicas.Length; n++)
			{
				caracteristicas[n].Desactivar();
			}
		}
		#endregion
	}
}