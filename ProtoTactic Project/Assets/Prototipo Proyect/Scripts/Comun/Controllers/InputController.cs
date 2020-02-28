//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// InputController.cs (10/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controlador del input del usuario							\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
using System;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Controlador del input del usuario.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Controllers/InputController")]
	public class InputController : MonoBehaviour
	{
		#region Eventos
		public static event EventHandler<InfoEventArgs<Punto>> moveEvent;
		public static event EventHandler<InfoEventArgs<int>> fireEvent;
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Input horizontal</para>
		/// </summary>
		private Repeticion hor = new Repeticion("Horizontal");              // Input horizontal
		/// <summary>
		/// <para>Input vertical</para>
		/// </summary>
		private Repeticion ver = new Repeticion("Vertical");                // Input vertical
		/// <summary>
		/// <para>Botones del click.</para>
		/// </summary>
		private string[] btns = new string[] { "Fire1", "Fire2", "Fire3" }; // Botones del click
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="InputController"/>.</para>
		/// </summary>
		private void Update()// Actualizador de InputController
		{
			// Asignar variables
			int x = hor.Update();
			int y = ver.Update();

			// Si se ha presionado algun boton
			if (x != 0 || y != 0)
			{
				// Si hay eventos de movimiento
				if (moveEvent != null) moveEvent(this, new InfoEventArgs<Punto>(new Punto(x, y)));
			}

			// Recorremos la matriz de botones
			for (int i = 0; i < 3; ++i)
			{
				// Si se ha presionado el boton
				if (Input.GetButtonUp(btns[i]))
				{
					// Si hay eventos de click
					if (fireEvent != null) fireEvent(this, new InfoEventArgs<int>(i));
				}
			}
		}
		#endregion
	}
}