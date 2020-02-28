//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// SeleccionComandoEstadoFreya.cs (22/07/2017)									\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado de seleccion de comando								\\
// Fecha Mod:		02/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#endregion

namespace MoonAntonio.Glitch.Comun.Estados
{
	/// <summary>
	/// <para>Estado de seleccion de comando.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/SeleccionComandoEstadoFreya")]
	public class SeleccionComandoEstadoFreya : BaseMenuHabEstadoFreya
	{
		#region Estados
		/// <summary>
		/// <para>Cuando se entra en el estado</para>
		/// </summary>
		public override void Enter()// Cuando se entra en el estado
		{
			base.Enter();
			PanelEstadisticas.MostrarAliado(Turno.unidad.gameObject);
			if (control.Actual == Controladores.Maquina) StartCoroutine(IARonda());
		}

		/// <summary>
		/// <para>Cuando se sale</para>
		/// </summary>
		public override void Exit()// Cuando se sale
		{
			base.Exit();
			PanelEstadisticas.OcultarAliado();
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Carga el menu</para>
		/// </summary>
		public override void LoadMenu()// Carga el menu
		{
			if (opcionesMenu == null)
			{
				tituloMenu = "Comandos";
				opcionesMenu = new List<string>(3);
				opcionesMenu.Add("Mover");
				opcionesMenu.Add("Acciones");
				opcionesMenu.Add("Esperar");
			}

			PanelHabilidades.Mostrar(tituloMenu, opcionesMenu);
			PanelHabilidades.SetBloqueoBtn(0, Turno.puedeUnidadMover);
			PanelHabilidades.SetBloqueoBtn(1, Turno.puedeUnidadAtacar);
		}

		/// <summary>
		/// <para>Confirmar</para>
		/// </summary>
		public override void Confirmar()// Confirmar
		{
			switch (PanelHabilidades.Seleccion)
			{
				case 0: // Movee
					freya.CambiarEstado<MoverUnidadEstadoFreya>();
					break;
				case 1: // Acciones
					freya.CambiarEstado<SeleccionCategoriaEstadoFreya>();
					break;
				case 2: // Esperar
					freya.CambiarEstado<FranqueoEstadoFreya>();
					break;
			}
		}

		/// <summary>
		/// <para>Cancelar</para>
		/// </summary>
		public override void Cancelar()// Cancelar
		{
			if (Turno.puedeUnidadMover && !Turno.bloqueoMovimiento)
			{
				Turno.UndoMovimiento();
				PanelHabilidades.SetBloqueoBtn(0, false);
				SeleccionarArea(Turno.unidad.Area.pos);
			}
			else
			{
				freya.CambiarEstado<ExplorarEstadoFreya>();
			}
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Ronda de la IA</para>
		/// </summary>
		/// <returns></returns>
		private IEnumerator IARonda()// Ronda de la IA
		{
			if (Turno.plan == null)
			{
				Turno.plan = freya.cpu.Evaluar();
				Turno.habilidad = Turno.plan.habilidad;
			}

			yield return new WaitForSeconds(1f);

			if (Turno.puedeUnidadMover == false && Turno.plan.posMovi != Turno.unidad.Area.pos)
			{
				freya.CambiarEstado<MoverUnidadEstadoFreya>();
			}
			else if (Turno.puedeUnidadAtacar == false && Turno.plan.habilidad != null)
			{
				freya.CambiarEstado<SeleccionarObjetivoHabilidadEstadoFreya>();
			}
			else
			{
				freya.CambiarEstado<FranqueoEstadoFreya>();
			}
		}
		#endregion
	}
}