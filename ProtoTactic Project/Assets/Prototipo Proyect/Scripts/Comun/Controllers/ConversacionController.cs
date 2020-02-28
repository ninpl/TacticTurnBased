//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ConversacionController.cs (10/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controlador de las conversaciones							\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System;
using System.Collections;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Data;
using MoonAntonio.Glitch.UI;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Controlador de las conversaciones.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Controllers/ConversacionController")]
	public class ConversacionController : MonoBehaviour
	{
		#region Constantes
		private const string MostrarArriba = "MostrarArriba";
		private const string MostrarAbajo = "MostrarAbajo";
		private const string OcultarArriba = "OcultarArriba";
		private const string OcultarAbajo = "OcultarAbajo";
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Panel izquierdo</para>
		/// </summary>
		[SerializeField] private PanelConversacion panelIzquierda;		// Panel izquierdo
		/// <summary>
		/// <para>Panel derecho</para>
		/// </summary>
		[SerializeField] private PanelConversacion panelDerecha;		// Panel derecho
		/// <summary>
		/// <para>Canvas del panel</para>
		/// </summary>
		private Canvas canvas;											// Canvas del panel
		/// <summary>
		/// <para>Conversacion</para>
		/// </summary>
		private IEnumerator conversacion;								// Conversacion
		/// <summary>
		/// <para>Transicion</para>
		/// </summary>
		private Tweener transicion;										// Transicion
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Evento completado</para>
		/// </summary>
		public static event EventHandler EventoCompletado;						// Evento completado
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="ConversacionController"/></para>
		/// </summary>
		private void Start()// Inicializador de ConversacionController
		{
			// Obtener el canvas
			canvas = GetComponentInChildren<Canvas>();

			// Ocultar los paneles
			if (panelIzquierda.panel.PosicionActual == null) panelIzquierda.panel.SetPosicion(OcultarAbajo, false);
			if (panelDerecha.panel.PosicionActual == null) panelDerecha.panel.SetPosicion(OcultarAbajo, false);

			// Desactivar canvas
			canvas.gameObject.SetActive(false);
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Inicia una conversacion</para>
		/// </summary>
		/// <param name="data">Conversacion a mostrar</param>
		public void InitConversacion(ConversacionData data)// Inicia una conversacion
		{
			// Activar canvas
			canvas.gameObject.SetActive(true);

			// Iniciar Conversacion
			conversacion = Secuencia(data);

			// Siguiente movimiento
			conversacion.MoveNext();
		}

		/// <summary>
		/// <para>Avanzar la conversacion</para>
		/// </summary>
		public void Next()// Avanzar la conversacion
		{
			// Si no hay conversacion, salir
			if (conversacion == null || transicion != null) return;

			// Avanzar la conversacion
			conversacion.MoveNext();
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Mueve el panel con una transicion</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="pos"></param>
		private void MoverPanel(PanelConversacion obj, string pos)// Mueve el panel con una transicion
		{
			// Setup y iniciar transicion
			transicion = obj.panel.SetPosicion(pos, true);
			transicion.duration = 0.5f;
			transicion.equation = EasingEquations.EaseOutQuad;
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Inicia la secuencia de la conversacion</para>
		/// </summary>
		/// <param name="data">Data de la conversacion</param>
		/// <returns></returns>
		public IEnumerator Secuencia(ConversacionData data)// Inicia la secuencia de la conversacion
		{
			// Recorrer la secuencia de conversacion
			for (int n = 0; n < data.list.Count; n++)
			{
				// Obtener datos
				DialoguerData sd = data.list[n];
				PanelConversacion panelActual = (sd.anchor == TextAnchor.UpperLeft || sd.anchor == TextAnchor.MiddleLeft || sd.anchor == TextAnchor.LowerLeft) ? panelIzquierda : panelDerecha;
				IEnumerator actual = panelActual.InitDialogo(sd);
				actual.MoveNext();
				string mostrar, ocultar;

				// Comprobar estado
				if (sd.anchor == TextAnchor.UpperLeft || sd.anchor == TextAnchor.UpperCenter || sd.anchor == TextAnchor.UpperRight)
				{
					mostrar = MostrarArriba;
					ocultar = OcultarArriba;
				}
				else
				{
					mostrar = MostrarAbajo;
					ocultar = OcultarAbajo;
				}

				// Transicion
				panelActual.panel.SetPosicion(ocultar, false);
				MoverPanel(panelActual, mostrar);

				yield return null;

				while (actual.MoveNext())
				{
					yield return null;

				}	

				// Transicion
				MoverPanel(panelActual, ocultar);
				transicion.completedEvent += delegate (object sender, EventArgs e)
				{
					conversacion.MoveNext();
				};

				yield return null;
			}

			// Desactivar la conversacion
			canvas.gameObject.SetActive(false);

			// Mandar evento completado
			if (EventoCompletado != null) EventoCompletado(this, EventArgs.Empty);
		}
		#endregion
	}
}