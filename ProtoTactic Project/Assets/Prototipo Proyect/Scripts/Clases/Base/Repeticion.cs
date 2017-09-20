//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Repeticion.cs (10/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase que comprueba si se esta repitiendo la accion como	\\
//					la de presionar un boton.									\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase que comprueba si se esta repitiendo la accion como la de presionar un boton.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/Repeticion")]
	public class Repeticion
	{
		#region Constantes
		/// <summary>
		/// <para>Limite de tiempo entre una pulsacion y otra.</para>
		/// </summary>
		public const float limite = 0.5f;                                   // Limite de tiempo entre una pulsacion y otra
		/// <summary>
		/// <para>Velocidad de repeticion.</para>
		/// </summary>
		public const float vel = 0.25f;                                     // Velocidad de repeticion
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Auxiliar para contar el tiempo hasta el siguiente evento.</para>
		/// </summary>
		private float auxTiempo;                                            // Auxiliar para contar el tiempo hasta el siguiente evento
		/// <summary>
		/// <para>Determina si el usuario esta presionando el boton.</para>
		/// </summary>
		private bool isPresionado;                                          // Determina si el usuario esta presionando el boton
		/// <summary>
		/// <para>La axis que se ha presionado.</para>
		/// </summary>
		private string axis;                                                // La axis que se ha presionado
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="Repeticion"/></para>
		/// </summary>
		/// <param name="nombreAxis">Nombre del axis</param>
		public Repeticion(string nombreAxis)// Constructor de Repeticion
		{
			axis = nombreAxis;
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="Repeticion"/></para>
		/// </summary>
		/// <returns></returns>
		public int Update()// Actualizador de Repeticion
		{
			// El update lo llamamos nosotros manualmente, al no ser un MonoBehaviour

			// Asignamos variables
			int presionando = 0;
			int axisRawActual = Mathf.RoundToInt(Input.GetAxisRaw(axis));

			// Si se esta presionando un boton
			if (axisRawActual != 0)
			{
				// Si ha pasado el tiempo suficiente para permitir un evento
				if (Time.time > auxTiempo)
				{
					presionando = axisRawActual;
					auxTiempo = Time.time + (isPresionado ? vel : limite);
					isPresionado = true;
				}
			}
			else
			{
				// Reset
				isPresionado = false;
				auxTiempo = 0;
			}

			return presionando;
		}
		#endregion
	}
}