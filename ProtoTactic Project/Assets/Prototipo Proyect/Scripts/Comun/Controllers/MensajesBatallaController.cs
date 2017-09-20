//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MensajesBatallaController.cs (10/07/2017)									\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controlador de los mensajes de batalla						\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Controlador de los mensajes de batalla.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Controllers/MensajesBatallaController")]
	public class MensajesBatallaController : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Texto del mensaje</para>
		/// </summary>
		[SerializeField] private Text texto;										// Texto del mensaje
		/// <summary>
		/// <para>Canvas del mensaje</para>
		/// </summary>
		[SerializeField] private GameObject canvas;									// Canvas del mensaje
		/// <summary>
		/// <para>Grupo del canvas</para>
		/// </summary>
		[SerializeField] private CanvasGroup group;									// Grupo del canvas
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Control de animacion</para>
		/// </summary>
		private EasingControl ec;									// Control de animacion
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="MensajesBatallaController"/></para>
		/// </summary>
		private void Awake()// Inicializador de MensajesBatallaController
		{
			ec = gameObject.AddComponent<EasingControl>();
			ec.duration = 0.5f;
			ec.equation = EasingEquations.EaseInOutQuad;
			ec.endBehaviour = EasingControl.EndBehaviour.Constant;
			ec.updateEvent += OnUpdateEvent;
		}
		#endregion

		#region Metodos Publicas
		/// <summary>
		/// <para>Inicia un mensaje</para>
		/// </summary>
		/// <param name="msg"></param>
		public void InitMensaje(string msg)// Inicia un mensaje
		{
			group.alpha = 0;
			canvas.SetActive(true);
			texto.text = msg;
			StartCoroutine(Secuencia());
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando el evento se actualiza</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUpdateEvent(object sender, EventArgs e)// Cuando el evento se actualiza
		{
			group.alpha = ec.currentValue;
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Inicia la secuencia del mensaje</para>
		/// </summary>
		/// <returns></returns>
		private IEnumerator Secuencia()// Inicia la secuencia del mensaje
		{
			ec.Play();

			while (ec.IsPlaying)
			{
				yield return null;
			}

			yield return new WaitForSeconds(1);

			ec.Reverse();

			while (ec.IsPlaying)
			{
				yield return null;
			}	

			canvas.SetActive(false);
		}
		#endregion
	}
}