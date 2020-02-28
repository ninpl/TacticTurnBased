//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MenuInfoController.cs (13/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controller del menu info									\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.UI;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Controller del menu info.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Controllers/MenuInfoController")]
	public class MenuInfoController : MonoBehaviour
	{
		#region Constantes
		/// <summary>
		/// <para>Clave para mostrar la info</para>
		/// </summary>
		private const string MostrarKey = "Mostrar";				// Clave para mostrar la info
		/// <summary>
		/// <para>Clave para ocultar la info</para>
		/// </summary>
		private const string OcultarKey = "Ocultar";				// Clave para ocultar la info
		#endregion

		#region Variables Publicas
		/// <summary>
		/// <para>Panel aliado</para>
		/// </summary>
		[SerializeField] private PanelInfo panelAliado;				// Panel aliado
		/// <summary>
		/// <para>Panel enemigo</para>
		/// </summary>
		[SerializeField] private PanelInfo panelEnemigo;			// Panel enemigo
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Transicion del panel aliado</para>
		/// </summary>
		private Tweener transicionPanelAliado;						// Transicion del panel aliado
		/// <summary>
		/// <para>Transicion del panel enemigo</para>
		/// </summary>
		private Tweener transicionPanelEnemigo;						// Transicion del panel enemigo
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="MenuInfoController"/></para>
		/// </summary>
		private void Start()// Inicializador de MenuInfoController
		{
			// Fijar la posicion actual
			if (panelAliado.panel.PosicionActual == null) panelAliado.panel.SetPosicion(OcultarKey, false);
			if (panelEnemigo.panel.PosicionActual == null) panelEnemigo.panel.SetPosicion(OcultarKey, false);
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Mostrar la info del aliado</para>
		/// </summary>
		/// <param name="obj"></param>
		public void MostrarAliado(GameObject obj)// Mostrar la info del aliado
		{
			panelAliado.VerInfo(obj);
			MoverPanel(panelAliado, MostrarKey, ref transicionPanelAliado);
		}

		/// <summary>
		/// <para>Ocultar la info del aliado</para>
		/// </summary>
		public void OcultarAliado()// Ocultar la info del aliado
		{
			MoverPanel(panelAliado, OcultarKey, ref transicionPanelAliado);
		}

		/// <summary>
		/// <para>Mostrar la info del enemigo</para>
		/// </summary>
		/// <param name="obj"></param>
		public void MostrarEnemigo(GameObject obj)// Mostrar la info del enemigo
		{
			panelEnemigo.VerInfo(obj);
			MoverPanel(panelEnemigo, MostrarKey, ref transicionPanelEnemigo);
		}

		/// <summary>
		/// <para>Ocultar la info del enemigo</para>
		/// </summary>
		public void OcultarEnemigo()// Ocultar la info del enemigo
		{
			MoverPanel(panelEnemigo, OcultarKey, ref transicionPanelEnemigo);
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Mueve el panel a una posicion</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="pos"></param>
		/// <param name="t"></param>
		private void MoverPanel(PanelInfo obj, string pos, ref Tweener t)// Mueve el panel a una posicion
		{
			Panel.Posicion objetivo = obj.panel[pos];
			if (obj.panel.PosicionActual != objetivo)
			{
				if (t != null) t.Stop();
				t = obj.panel.SetPosicion(pos, true);
				t.duration = 0.5f;
				t.equation = EasingEquations.EaseOutQuad;
			}
		}
		#endregion
	}
}
