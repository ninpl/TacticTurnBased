//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ConversacionEstadoFreya.cs (21/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado para la conversacion									\\
// Fecha Mod:		21/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Data;
#endregion

namespace MoonAntonio.Glitch.Comun.Estados
{
	/// <summary>
	/// <para>Estado para la conversacion.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/ConversacionEstadoFreya")]
	public class ConversacionEstadoFreya : EstadoFreya
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Controlador de la conversacion</para>
		/// </summary>
		private ConversacionController converController;			// Controlador de la conversacion
		/// <summary>
		/// <para>Data de la conversacion</para>
		/// </summary>
		private ConversacionData data;								// Data de la conversacion
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="ConversacionEstadoFreya"/></para>
		/// </summary>
		public override void Awake()// Inicializador de ConversacionEstadoFreya
		{
			base.Awake();
			converController = freya.GetComponentInChildren<ConversacionController>();
		}
		#endregion

		#region Estados
		/// <summary>
		/// <para>Cuando se entra en el estado</para>
		/// </summary>
		public override void Enter()// Cuando se entra en el estado
		{
			base.Enter();
			if (PlayerOver())
			{
				if (PlayerWin())
				{
					data = Resources.Load<ConversacionData>("Conversaciones/GanarEscena001");
				}
				else
				{
					data = Resources.Load<ConversacionData>("Conversaciones/PerderEscena001");
				}	
			}
			else
			{
				data = Resources.Load<ConversacionData>("Conversaciones/IntroEscena001");
			}
			converController.InitConversacion(data);
		}

		/// <summary>
		/// <para>Cuando se sale del estado</para>
		/// </summary>
		public override void Exit()// Cuando se sale del estado
		{
			base.Exit();
			if (data) Resources.UnloadAsset(data);
		}

		/// <summary>
		/// <para>Agrega oyentes</para>
		/// </summary>
		public override void AddListeners()// Agrega oyentes
		{
			base.AddListeners();
			ConversacionController.EventoCompletado += OnCompleteConversacion;
		}

		/// <summary>
		/// <para>Quita oyentes</para>
		/// </summary>
		public override void RemoveListeners()// Quita oyentes
		{
			base.RemoveListeners();
			ConversacionController.EventoCompletado -= OnCompleteConversacion;
		}

		/// <summary>
		/// <para>Cuando se hace un click</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnFire(object sender, InfoEventArgs<int> e)// Cuando se hace un click
		{
			base.OnFire(sender, e);
			converController.Next();
		}

		/// <summary>
		/// <para>Cuando se completa la conversacion</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCompleteConversacion(object sender, System.EventArgs e)// Cuando se completa la conversacion
		{
			if (PlayerOver())
			{
				freya.CambiarEstado<FinalizarBatallaEstadoFreya>();
			}
			else
			{
				freya.CambiarEstado<SeleccionarUnidadEstadoFreya>();
			}	
		}
		#endregion
	}
}
