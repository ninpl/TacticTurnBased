//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ConfirmarObjetivoHabilidadEstadoFreya.cs (25/07/2017)						\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado de freya para confirmar el objetivo de habilidad		\\
// Fecha Mod:		25/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.UI;
#endregion

namespace MoonAntonio.Glitch.Comun.Estados
{
	/// <summary>
	/// <para>Estado de freya para confirmar el objetivo de habilidad</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/ConfirmarObjetivoHabilidadEstadoFreya")]
	public class ConfirmarObjetivoHabilidadEstadoFreya : EstadoFreya
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Areas</para>
		/// </summary>
		private List<Area> areas;                       // Areas
		/// <summary>
		/// <para>Area de habilidad</para>
		/// </summary>
		private AreaHabilidad areaHabilidad;			// Area de habilidad
		/// <summary>
		/// <para>Index</para>
		/// </summary>
		private int index = 0;                          // Index
		#endregion

		#region Estados
		/// <summary>
		/// <para>Cuando se entra en el estado</para>
		/// </summary>
		public override void Enter()// Cuando se entra en el estado
		{
			base.Enter();
			areaHabilidad = Turno.habilidad.GetComponent<AreaHabilidad>();
			areas = areaHabilidad.GetAreasEnArea(Grid, Pos);
			Grid.SeleccionarAreas(areas);
			BuscarObjetivos();
			ActualizarPanelInfoUnidad(Turno.unidad.Area.pos);

			if (Turno.objetivos.Count > 0)
			{
				if (control.Actual == Controladores.Humano) PanelIndicadorAcierto.Mostrar();
				SetObjetivo(0);
			}
			if (control.Actual == Controladores.Maquina) StartCoroutine(IAConfirmarObjetivo());
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
			PanelIndicadorAcierto.Ocultar();
		}

		/// <summary>
		/// <para>Cuando se mueve</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnMove(object sender, InfoEventArgs<Punto> e)// Cuando se mueve
		{
			if (e.info.y > 0 || e.info.x > 0)
			{
				SetObjetivo(index + 1);
			}
			else
			{
				SetObjetivo(index - 1);
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
				if (Turno.objetivos.Count > 0)
				{
					freya.CambiarEstado<RealizarHabilidadEstadoFreya>();
				}
			}
			else
			{
				freya.CambiarEstado<SeleccionarObjetivoHabilidadEstadoFreya>();
			}	
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Busca los objetivos</para>
		/// </summary>
		private void BuscarObjetivos()// Busca los objetivos
		{
			Turno.objetivos = new List<Area>();
			for (int n = 0; n < areas.Count; n++)
			{
				if (Turno.habilidad.IsTarget(areas[n])) Turno.objetivos.Add(areas[n]);
			}	
		}

		/// <summary>
		/// <para>Fija un objetivo</para>
		/// </summary>
		/// <param name="target">Objetivo</param>
		private void SetObjetivo(int target)// Fija un objetivo
		{
			index = target;

			if (index < 0) index = Turno.objetivos.Count - 1;

			if (index >= Turno.objetivos.Count) index = 0;

			if (Turno.objetivos.Count > 0)
			{
				ActualizarPanelInfoObjetivo(Turno.objetivos[index].pos);
				ActualizarTasaExitoUI();
			}
		}

		/// <summary>
		/// <para>Actualiza la tasa de exito de la UI</para>
		/// </summary>
		private void ActualizarTasaExitoUI()// Actualiza la tasa de exito de la UI
		{
			int cambio = 0;
			int valor = 0;
			Area objetivo = Turno.objetivos[index];
			Transform obj = Turno.habilidad.transform;

			for (int n = 0; n < obj.childCount; n++)
			{
				EfectoHabilidadObjetivo objetivoHab = obj.GetChild(n).GetComponent<EfectoHabilidadObjetivo>();
				if (objetivoHab.IsTarget(objetivo))
				{
					TasaExito tasaExito = objetivoHab.GetComponent<TasaExito>();
					cambio = tasaExito.Calcular(objetivo);

					BaseEfectoHabilidad efecto = objetivoHab.GetComponent<BaseEfectoHabilidad>();
					valor = efecto.Predecir(objetivo);
					break;
				}
			}

			PanelIndicadorAcierto.SetStats(cambio, valor);
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>IA que Confirma un objetivo</para>
		/// </summary>
		/// <returns></returns>
		private IEnumerator IAConfirmarObjetivo()// IA que Confirma un objetivo
		{
			freya.panelMensajes.InitMensaje(Turno.habilidad.name);
			yield return new WaitForSeconds(2f);
			freya.CambiarEstado<RealizarHabilidadEstadoFreya>();
		}
		#endregion
	}
}