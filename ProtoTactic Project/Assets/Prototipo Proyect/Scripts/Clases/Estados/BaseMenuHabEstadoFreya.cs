//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// BaseMenuHabEstadoFreya.cs (21/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base del menu accion									\\
// Fecha Mod:		21/07/2017													\\
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
	/// <para>Clase base del menu accion.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/BaseMenuHabEstadoFreya")]
	public abstract class BaseMenuHabEstadoFreya : EstadoFreya
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Titulo del menu actual</para>
		/// </summary>
		public string tituloMenu;								// Titulo del menu actual
		/// <summary>
		/// <para>Opciones del menu actuales</para>
		/// </summary>
		public List<string> opcionesMenu;						// Opciones del menu actuales
		#endregion

		#region Estados
		/// <summary>
		/// <para>Cuando se entra al estado</para>
		/// </summary>
		public override void Enter()// Cuando se entra al estado
		{
			base.Enter();
			SeleccionarArea(Turno.unidad.Area.pos);
			if (control.Actual == Controladores.Humano) LoadMenu();

		}

		/// <summary>
		/// <para>Cuando se sale del estado</para>
		/// </summary>
		public override void Exit()// Cuando se sale del estado
		{
			base.Exit();
			PanelHabilidades.Ocultar();
		}

		/// <summary>
		/// <para>Cuando se mueve</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnMove(object sender, InfoEventArgs<Punto> e)// Cuando se mueve
		{
			if (e.info.x > 0 || e.info.y < 0)
			{
				PanelHabilidades.Next();
			}
			else
			{
				PanelHabilidades.Anterior();
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
				Confirmar();
			}
			else
			{
				Cancelar();
			}
		}
		#endregion

		#region Metodos
		public abstract void LoadMenu();
		public abstract void Confirmar();
		public abstract void Cancelar();
		#endregion
	}
}