//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// SeleccionAccionEstadoFreya.cs (22/07/2017)									\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado de seleccion de accion								\\
// Fecha Mod:		22/07/2017													\\
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
	/// <para>Estado de seleccion de accion.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/SeleccionAccionEstadoFreya")]
	public class SeleccionAccionEstadoFreya : BaseMenuHabEstadoFreya
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Categoria de la accion</para>
		/// </summary>
		public static int categoria;							// Categoria de la accion
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Catalogo de habilidades</para>
		/// </summary>
		private CatalogoHabilidades catalogo;					// Catalogo de habilidades
		#endregion

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
			catalogo = Turno.unidad.GetComponentInChildren<CatalogoHabilidades>();
			GameObject cat = catalogo.GetCategoria(categoria);
			tituloMenu = cat.name;

			int count = catalogo.HabilidadesCount(cat);
			if (opcionesMenu == null)
			{
				opcionesMenu = new List<string>(count);
			}
			else
			{
				opcionesMenu.Clear();
			}	

			bool[] bloqueados = new bool[count];
			for (int n = 0; n < count; n++)
			{
				Habilidad hab = catalogo.GetHabilidad(categoria, n);
				CosteHabilidadMagica coste = hab.GetComponent<CosteHabilidadMagica>();
				if (coste)
				{
					opcionesMenu.Add(string.Format("{0}: {1}", hab.name, coste.valor));
				}
				else
				{
					opcionesMenu.Add(hab.name);
				}
					
				bloqueados[n] = !hab.PuedeRealizar();
			}

			PanelHabilidades.Mostrar(tituloMenu, opcionesMenu);

			for (int n = 0; n < count; n++)
			{
				PanelHabilidades.SetBloqueoBtn(n, bloqueados[n]);
			}	
		}

		/// <summary>
		/// <para>Confirmar</para>
		/// </summary>
		public override void Confirmar()// Confirmar
		{
			Turno.habilidad = catalogo.GetHabilidad(categoria, PanelHabilidades.Seleccion);
			freya.CambiarEstado<SeleccionarObjetivoHabilidadEstadoFreya>();
		}

		/// <summary>
		/// <para>Cancelar</para>
		/// </summary>
		public override void Cancelar()// Cancelar
		{
			freya.CambiarEstado<SeleccionCategoriaEstadoFreya>();
		}
		#endregion
	}
}