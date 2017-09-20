//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// PanelConversacion.cs (04/08/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controlador del panel de conversacion						\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.UI
{
	/// <summary>
	/// <para>Controlador del panel de conversacion.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/UI/Paneles/PanelConversacion")]
	public class PanelConversacion : MonoBehaviour
	{
		#region Variables
		/// <summary>
		/// <para>Texto del dialogo</para>
		/// </summary>
		public Text texto;							// Texto del dialogo
		/// <summary>
		/// <para>Imagen del personaje</para>
		/// </summary>
		public Image avatar;						// Imagen del personaje
		/// <summary>
		/// <para>Flecha para seguir</para>
		/// </summary>
		public GameObject flecha;					// Flecha para seguir
		/// <summary>
		/// <para>Panel raiz</para>
		/// </summary>
		public Panel panel;							// Panel raiz
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="PanelConversacion"/></para>
		/// </summary>
		private void Start()// Inicializador de PanelConversacion
		{
			// Setup
			Vector3 pos = flecha.transform.localPosition;
			flecha.transform.localPosition = new Vector3(pos.x, pos.y + 5, pos.z);
			Tweener t = flecha.transform.MoveToLocal(new Vector3(pos.x, pos.y - 5, pos.z), 0.5f, EasingEquations.EaseInQuad);
			t.loopType = EasingControl.LoopType.PingPong;
			t.loopCount = -1;
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Iniciar dialogo</para>
		/// </summary>
		/// <param name="dialogo"></param>
		/// <returns></returns>
		public IEnumerator InitDialogo(DialoguerData dialogo)// Iniciar dialogo
		{
			// Fijar imagen del personaje
			avatar.sprite = dialogo.personaje;
			avatar.SetNativeSize();

			// Iniciar texto
			for (int n = 0; n < dialogo.mensages.Count; n++)
			{
				texto.text = dialogo.mensages[n];
				flecha.SetActive(n + 1 < dialogo.mensages.Count);
				yield return null;
			}
		}
		#endregion
	}
}