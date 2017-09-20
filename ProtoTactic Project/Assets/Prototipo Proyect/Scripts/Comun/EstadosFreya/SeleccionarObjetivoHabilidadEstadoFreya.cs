//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// SeleccionarObjetivoHabilidadEstadoFreya.cs (25/07/2017)						\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado de objetivo de habilidad								\\
// Fecha Mod:		25/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun.Estados
{
	/// <summary>
	/// <para>Estado de objetivo de habilidad</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/SeleccionarObjetivoHabilidadEstadoFreya")]
	public class SeleccionarObjetivoHabilidadEstadoFreya : EstadoFreya
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Areas</para>
		/// </summary>
		private List<Area> areas;                               // Areas
		/// <summary>
		/// <para>Rango de la habilidad</para>
		/// </summary>
		private RangoHabilidad rangoHabilidad;                  // Rango de la habilidad
		#endregion

		#region Estados
		/// <summary>
		/// <para>Cuando se entra al estado</para>
		/// </summary>
		public override void Enter()// Cuando se entra al estado
		{
			base.Enter();
			rangoHabilidad = Turno.habilidad.GetComponent<RangoHabilidad>();
			SeleccionarAreas();
			PanelEstadisticas.MostrarAliado(Turno.unidad.gameObject);

			if (rangoHabilidad.OrientacionDir) ActualizarPanelInfoObjetivo(Pos);
			if (control.Actual == Controladores.Maquina) StartCoroutine(IAObjetivo());
		}

		/// <summary>
		/// <para>Cuando se sale del estado</para>
		/// </summary>
		public override void Exit()// Cuando se sale del estado
		{
			base.Exit();
			Grid.DeSeleccionarAreas(areas);
			PanelEstadisticas.OcultarAliado();
			PanelEstadisticas.OcultarEnemigo();
		}

		/// <summary>
		/// <para>Cuando se mueve</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnMove(object sender, InfoEventArgs<Punto> e)// Cuando se mueve
		{
			if (rangoHabilidad.OrientacionDir)
			{
				CambiarDireccion(e.info);
			}
			else
			{
				SeleccionarArea(e.info + Pos);
				ActualizarPanelInfoObjetivo(Pos);
			}
		}

		/// <summary>
		/// <para>Cuando se hace click</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnFire(object sender, InfoEventArgs<int> e)// Cuando se hace click
		{
			if (e.info == 0)
			{
				if (rangoHabilidad.OrientacionDir || areas.Contains(Grid.GetArea(Pos))) freya.CambiarEstado<ConfirmarObjetivoHabilidadEstadoFreya>();
			}
			else
			{
				freya.CambiarEstado<SeleccionCategoriaEstadoFreya>();
			}
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Cambia la direccion</para>
		/// </summary>
		/// <param name="p"></param>
		private void CambiarDireccion(Punto p)// Cambia la direccion
		{
			Direcciones dir = p.GetDireccion();
			if (Turno.unidad.dir != dir)
			{
				Grid.DeSeleccionarAreas(areas);
				Turno.unidad.dir = dir;
				Turno.unidad.Actualizar();
				SeleccionarAreas();
			}
		}

		/// <summary>
		/// <para>Selecciona las areas a rango</para>
		/// </summary>
		private void SeleccionarAreas()// Selecciona las areas a rango
		{
			areas = rangoHabilidad.GetAreasARango(Grid);
			Grid.SeleccionarAreas(areas);
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Logica del objetivo</para>
		/// </summary>
		/// <returns></returns>
		private IEnumerator IAObjetivo()// Logica del objetivo
		{
			if (rangoHabilidad.OrientacionDir)
			{
				CambiarDireccion(Turno.plan.dirAtaque.GetNormal());
				yield return new WaitForSeconds(0.25f);
			}
			else
			{
				Punto cursorPos = Pos;
				while (cursorPos != Turno.plan.posAtaque)
				{
					if (cursorPos.x < Turno.plan.posAtaque.x) cursorPos.x++;
					if (cursorPos.x > Turno.plan.posAtaque.x) cursorPos.x--;
					if (cursorPos.y < Turno.plan.posAtaque.y) cursorPos.y++;
					if (cursorPos.y > Turno.plan.posAtaque.y) cursorPos.y--;
					SeleccionarArea(cursorPos);
					yield return new WaitForSeconds(0.25f);
				}
			}
			yield return new WaitForSeconds(0.5f);
			freya.CambiarEstado<ConfirmarObjetivoHabilidadEstadoFreya>();
		}
		#endregion
	}
}