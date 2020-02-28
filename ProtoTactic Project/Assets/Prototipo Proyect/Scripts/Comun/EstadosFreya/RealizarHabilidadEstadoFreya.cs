//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// RealizarHabilidadEstadoFreya.cs (25/07/2017)									\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado para realizar la habilidad seleccionada				\\
// Fecha Mod:		25/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun.Estados
{
	/// <summary>
	/// <para>Estado para realizar la habilidad seleccionada.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/RealizarHabilidadEstadoFreya")]
	public class RealizarHabilidadEstadoFreya : EstadoFreya
	{
		#region Estados
		/// <summary>
		/// <para>Cuando se entra en el estado</para>
		/// </summary>
		public override void Enter()// Cuando se entra en el estado
		{
			base.Enter();
			Turno.puedeUnidadAtacar = true;
			if (Turno.puedeUnidadMover) Turno.bloqueoMovimiento = true;
			StartCoroutine(Logica());
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Logica</para>
		/// </summary>
		/// <returns></returns>
		private IEnumerator Logica()// Logica
		{
			// TODO animaciones, etc
			yield return null;

			// TODO Aplicar efecto de habilidad, etc
			AplicarAtaque();

			if (PlayerOver())
			{
				freya.CambiarEstado<ConversacionEstadoFreya>();
			}
			else if (!UnidadConControl())
			{
				freya.CambiarEstado<SeleccionarUnidadEstadoFreya>();
			}
			else if (Turno.puedeUnidadMover)
			{
				freya.CambiarEstado<FranqueoEstadoFreya>();
			}
			else
			{
				freya.CambiarEstado<SeleccionComandoEstadoFreya>();
			}
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Aplica el ataque</para>
		/// </summary>
		private void AplicarAtaque()// Aplica el ataque
		{
			Turno.habilidad.Realizar(Turno.objetivos);
		}
		#endregion

		#region Funcionalidades
		/// <summary>
		/// <para>Obtiene si la unidad tiene control</para>
		/// </summary>
		/// <returns></returns>
		private bool UnidadConControl()// Obtiene si la unidad tiene control
		{
			return Turno.unidad.GetComponentInChildren<EstadoEfectoKO>() == null;
		}
		#endregion
	}
}