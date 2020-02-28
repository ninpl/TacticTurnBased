//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// SeleccionarUnidadEstadoFreya.cs (21/07/2017)									\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado que controla la seleccion de unidades				\\
// Fecha Mod:		15/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun.Estados
{
	/// <summary>
	/// <para>Estado que controla la seleccion de unidades.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/SeleccionarUnidadEstadoFreya")]
	public class SeleccionarUnidadEstadoFreya : EstadoFreya
	{
		#region Estados
		/// <summary>
		/// <para>Entrar en el Estado</para>
		/// </summary>
		public override void Enter()// Entrar en el Estado
		{
			base.Enter();
			StartCoroutine("CambiarUnidadActual");
		}

		/// <summary>
		/// <para>Sale del Estado</para>
		/// </summary>
		public override void Exit()// Sale del Estado
		{
			base.Exit();
			PanelEstadisticas.OcultarAliado();
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Cambia la unidad actual</para>
		/// </summary>
		/// <returns></returns>
		private IEnumerator CambiarUnidadActual()// Cambia la unidad actual
		{
			freya.ronda.MoveNext();
			SeleccionarArea(Turno.unidad.Area.pos);
			ActualizarPanelInfoUnidad(Pos);
			yield return null;
			freya.CambiarEstado<SeleccionComandoEstadoFreya>();
		}
		#endregion
	}
}