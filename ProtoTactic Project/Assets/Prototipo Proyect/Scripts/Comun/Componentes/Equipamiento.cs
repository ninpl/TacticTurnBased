//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Equipamiento.cs (22/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase del equipamiento										\\
// Fecha Mod:		22/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase del equipamiento.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Componentes/Equipamiento")]
	public class Equipamiento : MonoBehaviour
	{
		#region Notificaciones
		public const string EquipadoNotificacion = "Equipamiento.EquipadoNotificacion";
		public const string DesequipadoNotificacion = "Equipamiento.DesequipadoNotificacion";
		#endregion

		#region Variables
		/// <summary>
		/// <para>Objetos</para>
		/// </summary>
		private List<Equipable> items = new List<Equipable>();          // Objetos
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Objetos</para>
		/// </summary>
		public IList<Equipable> Items
		{
			get { return items.AsReadOnly(); }
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Equipar</para>
		/// </summary>
		/// <param name="item">Nuevo Objeto</param>
		/// <param name="slots">Slot</param>
		public void Equipar(Equipable item, SlotsEquipo slots)// Equipar
		{
			Desequipar(slots);

			items.Add(item);
			item.transform.SetParent(transform);
			item.slots = slots;
			item.OnEquipar();

			this.EnviarNotificacion(EquipadoNotificacion, item);
		}

		/// <summary>
		/// <para>Desequipar</para>
		/// </summary>
		/// <param name="item">Objeto</param>
		public void Desequipar(Equipable item)// Desequipar
		{
			item.OnDesequipar();
			item.slots = SlotsEquipo.None;
			item.transform.SetParent(transform);
			items.Remove(item);

			this.EnviarNotificacion(DesequipadoNotificacion, item);
		}

		/// <summary>
		/// <para>Desequipar</para>
		/// </summary>
		/// <param name="slots">Slot</param>
		public void Desequipar(SlotsEquipo slots)// Desequipar
		{
			for (int n = items.Count - 1; n >= 0; n--)
			{
				Equipable item = items[n];

				if ((item.slots & slots) != SlotsEquipo.None) Desequipar(item);
			}
		}

		/// <summary>
		/// <para>Obtiene un item</para>
		/// </summary>
		/// <param name="slots">Slot</param>
		/// <returns></returns>
		public Equipable GetItem(SlotsEquipo slots)// Obtiene un item
		{
			for (int n = items.Count - 1; n >= 0; n--)
			{
				Equipable item = items[n];
				if ((item.slots & slots) != SlotsEquipo.None) return item;
			}
			return null;
		}
		#endregion
	}
}