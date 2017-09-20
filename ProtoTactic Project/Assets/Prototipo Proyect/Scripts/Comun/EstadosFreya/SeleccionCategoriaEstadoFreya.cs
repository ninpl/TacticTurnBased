//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// SeleccionCategoriaEstadoFreya.cs (22/07/2017)								\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado de seleccion de categoria							\\
// Fecha Mod:		25/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun.Estados
{
	/// <summary>
	/// <para>Estado de seleccion de categoria.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/SeleccionCategoriaEstadoFreya")]
	public class SeleccionCategoriaEstadoFreya : BaseMenuHabEstadoFreya
	{
		#region Estados
		/// <summary>
		/// <para>Cuando se entra en el estado</para>
		/// </summary>
		public override void Enter()// Cuando se entra en el estado
		{
			base.Enter();
			PanelEstadisticas.MostrarAliado(Turno.unidad.gameObject);
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
				opcionesMenu = new List<string>();
			}
			else
			{
				opcionesMenu.Clear();
			}

			tituloMenu = "Accion";
			opcionesMenu.Add("Ataque");

			CatalogoHabilidades cat = Turno.unidad.GetComponentInChildren<CatalogoHabilidades>();
			for (int n = 0; n < cat.CategoriaCount(); n++)
			{
				opcionesMenu.Add(cat.GetCategoria(n).name);
			}	

			PanelHabilidades.Mostrar(tituloMenu, opcionesMenu);
		}

		/// <summary>
		/// <para>Confirmar</para>
		/// </summary>
		public override void Confirmar()// Confirmar
		{
			if (PanelHabilidades.Seleccion == 0)
			{
				Atacar();
			}
			else
			{
				SetCategoria(PanelHabilidades.Seleccion - 1);
			}	
		}

		/// <summary>
		/// <para>Cancelar</para>
		/// </summary>
		public override void Cancelar()// Cancelar
		{
			freya.CambiarEstado<SeleccionComandoEstadoFreya>();
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Selecciona la categoria atacar</para>
		/// </summary>
		private void Atacar()// Selecciona la categoria atacar
		{
			Turno.habilidad = Turno.unidad.GetComponentInChildren<Habilidad>();
			freya.CambiarEstado<SeleccionarObjetivoHabilidadEstadoFreya>();
		}

		/// <summary>
		/// <para>Fija la categoria elegida</para>
		/// </summary>
		/// <param name="index"></param>
		private void SetCategoria(int index)// Fija la categoria elegida
		{
			SeleccionAccionEstadoFreya.categoria = index;
			freya.CambiarEstado<SeleccionAccionEstadoFreya>();
		}
		#endregion
	}
}