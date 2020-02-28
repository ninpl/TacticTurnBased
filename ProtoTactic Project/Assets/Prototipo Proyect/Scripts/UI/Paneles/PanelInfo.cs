//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// PanelInfo.cs (04/08/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controlador del panel de info								\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.UI;
using MoonAntonio.Glitch.Comun;
#endregion

namespace MoonAntonio.Glitch.UI
{
	/// <summary>
	/// <para>Controlador del panel de info.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/UI/Paneles/PanelInfo")]
	public class PanelInfo : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>BG de info</para>
		/// </summary>
		public Image background;					// BG de info
		/// <summary>
		/// <para>Imagen del personaje</para>
		/// </summary>
		public Image avatar;						// Imagen del personaje
		/// <summary>
		/// <para>Nombre del personaje</para>
		/// </summary>
		public Text nombreTxt;						// Nombre del personaje
		/// <summary>
		/// <para>Vida</para>
		/// </summary>
		public Text vidaTxt;						// Vida
		/// <summary>
		/// <para>Mana</para>
		/// </summary>
		public Text manaTxt;						// Mana
		/// <summary>
		/// <para>Nivel</para>
		/// </summary>
		public Text lvlTxt;							// Nivel
		/// <summary>
		/// <para>Panel raiz</para>
		/// </summary>
		public Panel panel;							// Panel raiz
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Ver el panel de la info</para>
		/// </summary>
		/// <param name="obj"></param>
		public void VerInfo(GameObject obj)// Ver el panel de la info
		{
			nombreTxt.text = obj.name;
			Stats stats = obj.GetComponent<Stats>();
			if (stats)
			{
				vidaTxt.text = string.Format("HP {0} / {1}", stats[TipoStats.HP], stats[TipoStats.MHP]);
				manaTxt.text = string.Format("MP {0} / {1}", stats[TipoStats.MP], stats[TipoStats.MMP]);
				lvlTxt.text = string.Format("LV. {0}", stats[TipoStats.LVL]);
			}
		}
		#endregion
	}
}