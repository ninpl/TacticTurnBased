//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// IndicadorAciertos.cs (05/08/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Componente del IndicadorAciertos							\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace MoonAntonio.Glitch.UI
{
	/// <summary>
	/// <para>Componente del IndicadorAciertos.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/UI/Componentes/IndicadorAciertos")]
	public class IndicadorAciertos : MonoBehaviour
	{
		#region Constantes
		/// <summary>
		/// <para>Clave para mostrar la info</para>
		/// </summary>
		private const string MostrarKey = "Mostrar";				// Clave para mostrar la info
		/// <summary>
		/// <para>Clave para ocultar la info</para>
		/// </summary>
		private const string OcultarKey = "Ocultar";                // Clave para ocultar la info
		#endregion

		#region Variables Publicas
		/// <summary>
		/// <para>Canvas del indicador</para>
		/// </summary>
		[SerializeField] private Canvas canvas;						// Canvas del indicador
		/// <summary>
		/// <para>Panel del indicador</para>
		/// </summary>
		[SerializeField] private Panel panel;						// Panel del indicador
		/// <summary>
		/// <para>Flecha del indicador</para>
		/// </summary>
		[SerializeField] private Image arrow;						// Flecha del indicador
		/// <summary>
		/// <para>Texto del indicador</para>
		/// </summary>
		[SerializeField] private Text texto;						// Texto del indicador
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Transicion</para>
		/// </summary>
		private Tweener transicion;                                 // Transicion
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializa <see cref="IndicadorAciertos"/></para>
		/// </summary>
		private void Start()// Inicializa IndicadorAciertos
		{
			panel.SetPosicion(OcultarKey, false);
			canvas.gameObject.SetActive(false);
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Fija los stats</para>
		/// </summary>
		/// <param name="valor">Valor obtenido</param>
		/// <param name="amount"></param>
		public void SetStats(int valor, int acierto)// Fija los stats
		{
			arrow.fillAmount = (valor / 100f);
			texto.text = string.Format("{0}% {1}pt(s)", valor, Mathf.Abs(acierto));
			texto.color = acierto > 0 ? Color.green : Color.red;
		}

		/// <summary>
		/// <para>Muestra el indicador</para>
		/// </summary>
		public void Mostrar()// Muestra el indicador
		{
			canvas.gameObject.SetActive(true);
			SetPanelPos(MostrarKey);
		}

		/// <summary>
		/// <para>Oculta el indicador</para>
		/// </summary>
		public void Ocultar()// Oculta el indicador
		{
			SetPanelPos(OcultarKey);
			transicion.completedEvent += delegate (object sender, System.EventArgs e)
			{
				canvas.gameObject.SetActive(false);
			};
		}

		/// <summary>
		/// <para>Fija la posicion del panel</para>
		/// </summary>
		/// <param name="pos"></param>
		private void SetPanelPos(string pos)// Fija la posicion del panel
		{
			if (transicion != null && transicion.IsPlaying) transicion.Stop();

			transicion = panel.SetPosicion(pos, true);
			transicion.duration = 0.5f;
			transicion.equation = EasingEquations.EaseInOutQuad;
		}
		#endregion
	}
}