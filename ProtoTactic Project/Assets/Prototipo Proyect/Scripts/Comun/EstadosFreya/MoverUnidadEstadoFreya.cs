//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MoverUnidadEstadoFreya.cs (11/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado de Freya para mover una unidad						\\
// Fecha Mod:		02/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Comun;
#endregion

namespace MoonAntonio.Glitch.Comun.Estados
{
	/// <summary>
	/// <para>Estado de Freya para mover una unidad.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/MoverUnidadEstadoFreya")]
	public class MoverUnidadEstadoFreya : EstadoFreya
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Areas para mover la unidad</para>
		/// </summary>
		List<Area> areas;                               // Areas para mover la unidad
		#endregion

		#region Estados
		/// <summary>
		/// <para>Cuando entra en el estado</para>
		/// </summary>
		public override void Enter()// Cuando entra en el estado
		{
			base.Enter();

			// Cambiar el estado de seguimiento
			EstadoActualInit = MoonAntonio.Glitch.Sistemas.EstadosFreyaSeguimiento.MoviendoUnidad;

			// Obtener las areas a rango
			Movimiento mover = Turno.unidad.GetComponent<Movimiento>();
			areas = mover.GetAreasInRango(Grid);

			// Seleccionar areas
			Grid.SeleccionarAreas(areas);

			// Actualizar el panel de la unidad
			ActualizarPanelInfoUnidad(Pos);

			// Si el turno es de la IA, iniciar su paso
			if (control.Actual == Controladores.Maquina) StartCoroutine(IAMoverUnidad());
		}

		/// <summary>
		/// <para>Cuando sale del estado</para>
		/// </summary>
		public override void Exit()// Cuando sale del estado
		{
			base.Exit();

			// Deseleccionar las areas
			Grid.DeSeleccionarAreas(areas);
			areas = null;

			// Ocultar el panel de estadisticas
			PanelEstadisticas.OcultarAliado();
		}

		/// <summary>
		/// <para>Evento de movimiento</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnMove(object sender, InfoEventArgs<Punto> e)// Evento de movimiento
		{
			// Seleccionar el area y actualizar el panel de info
			SeleccionarArea(e.info + Pos);
			ActualizarPanelInfoUnidad(Pos);
		}

		/// <summary>
		/// <para>Evento de click</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnFire(object sender, InfoEventArgs<int> e)// Evento de click
		{
			// Cambiar a la secuencia de movimiento o volver a la seleccion de comando
			if (e.info == 0)
			{
				if (areas.Contains(freya.AreaActual)) freya.CambiarEstado<SecuenciaMovimientoEstadoFreya>();
			}
			else
			{
				freya.CambiarEstado<SeleccionComandoEstadoFreya>();
			}
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Movimiento de la unidad IA</para>
		/// </summary>
		/// <returns></returns>
		public IEnumerator IAMoverUnidad()// Movimiento de la unidad IA
		{
			Punto cursorPos = Pos;

			// Calcular el plan
			while (cursorPos != Turno.plan.posMovi)
			{
				if (cursorPos.x < Turno.plan.posMovi.x) cursorPos.x++;
				if (cursorPos.x > Turno.plan.posMovi.x) cursorPos.x--;
				if (cursorPos.y < Turno.plan.posMovi.y) cursorPos.y++;
				if (cursorPos.y > Turno.plan.posMovi.y) cursorPos.y--;

				// Seleccionar area y esperar
				SeleccionarArea(cursorPos);
				yield return new WaitForSeconds(0.25f);
			}

			// Esperar
			yield return new WaitForSeconds(0.5f);

			// Empezar la secuencia de movimiento
			freya.CambiarEstado<SecuenciaMovimientoEstadoFreya>();
		}
		#endregion
	}
}