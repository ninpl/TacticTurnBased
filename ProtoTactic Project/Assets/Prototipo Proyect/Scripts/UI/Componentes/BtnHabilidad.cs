//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// BtnHabilidad.cs (05/08/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Componente del btn de habilidad								\\
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
	/// <para>Componente del btn de habilidad.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/UI/Componentes/BtnHabilidad")]
	public class BtnHabilidad : MonoBehaviour
	{
		#region Enum
		/// <summary>
		/// <para>Estado del boton</para>
		/// </summary>
		[System.Flags]
		public enum Estados
		{
			None = 0,
			Seleccionado = 1 << 0,
			Bloqueado = 1 << 1
		}
		#endregion

		#region Variables Publicas
		/// <summary>
		/// <para>Posicionador de boton</para>
		/// </summary>
		[SerializeField] private Image posicionador;					// Posicionador de boton
		/// <summary>
		/// <para>Sprite en estado normal</para>
		/// </summary>
		[SerializeField] private Sprite spriteNormal;					// Sprite en estado normal
		/// <summary>
		/// <para>Sprite en estado seleccionado</para>
		/// </summary>
		[SerializeField] private Sprite spriteSeleccionado;				// Sprite en estado seleccionado
		/// <summary>
		/// <para>Sprite en estado bloqueado</para>
		/// </summary>
		[SerializeField] private Sprite spriteBloqueado;				// Sprite en estado bloqueado
		/// <summary>
		/// <para>Texto del boton</para>
		/// </summary>
		[SerializeField] private Text texto;							// Texto del boton
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Outline del btn</para>
		/// </summary>
		private Outline outline;										// Outline del btn
		/// <summary>
		/// <para>Estado del boton</para>
		/// </summary>
		private Estados estado;											// Estado del boton
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Texto del boton</para>
		/// </summary>
		public string Texto
		{
			get { return texto.text; }
			set { texto.text = value; }
		}

		/// <summary>
		/// <para>Determina si el boton esta bloqueado</para>
		/// </summary>
		public bool IsBloqueado
		{
			get { return (Estado & Estados.Bloqueado) != Estados.None; }
			set {
				if (value)
				{
					Estado |= Estados.Bloqueado;
				}
				else
				{
					Estado &= ~Estados.Bloqueado;
				}	
			}
		}

		/// <summary>
		/// <para>Determina si el boton esta seleccionado</para>
		/// </summary>
		public bool IsSeleccionado
		{
			get { return (Estado & Estados.Seleccionado) != Estados.None; }
			set {
				if (value)
				{
					Estado |= Estados.Seleccionado;
				}
				else
				{
					Estado &= ~Estados.Seleccionado;
				}	
			}
		}

		/// <summary>
		/// <para>Estado del boton</para>
		/// </summary>
		public Estados Estado
		{
			get { return estado; }
			set
			{
				if (estado == value) return;
				estado = value;

				if (IsBloqueado)
				{
					posicionador.sprite = spriteBloqueado;
					texto.color = Color.gray;
					outline.effectColor = new Color32(20, 36, 44, 255);
				}
				else if (IsSeleccionado)
				{
					posicionador.sprite = spriteSeleccionado;
					texto.color = new Color32(249, 210, 118, 255);
					outline.effectColor = new Color32(255, 160, 72, 255);
				}
				else
				{
					posicionador.sprite = spriteNormal;
					texto.color = Color.white;
					outline.effectColor = new Color32(20, 36, 44, 255);
				}
			}
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="BtnHabilidad"/></para>
		/// </summary>
		private void Awake()// Inicializador de BtnHabilidad
		{
			outline = texto.GetComponent<Outline>();
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Resetea el boton</para>
		/// </summary>
		public void Reset()// Resetea el boton
		{
			Estado = Estados.None;
		}
		#endregion
	}
}