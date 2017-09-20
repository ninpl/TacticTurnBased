//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// FranqueoEstadoFreya.cs (25/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado de freya para controlar el calculo del franqueo		\\
// Fecha Mod:		25/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun.Estados
{
	/// <summary>
	/// <para>Estado de freya para controlar el calculo del franqueo</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/FranqueoEstadoFreya")]
	public class FranqueoEstadoFreya : EstadoFreya
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Direccion inicial de la unidad</para>
		/// </summary>
		private Direcciones dirInicio;                              // Direccion inicial de la unidad
		#endregion

		#region Estados
		/// <summary>
		/// <para>Cuando se entra en el estado</para>
		/// </summary>
		public override void Enter()// Cuando se entra en el estado
		{
			base.Enter();
			dirInicio = Turno.unidad.dir;
			SeleccionarArea(Turno.unidad.Area.pos);

			if (control.Actual == Controladores.Maquina) StartCoroutine(IAControl());
		}

		/// <summary>
		/// <para>Cuando se sale del estado</para>
		/// </summary>
		public override void Exit()// Cuando se sale del estado
		{
			base.Exit();
		}

		/// <summary>
		/// <para>Cuando se mueve</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnMove(object sender, InfoEventArgs<Punto> e)// Cuando se mueve
		{
			Turno.unidad.dir = e.info.GetDireccion();
			Turno.unidad.Actualizar();
		}

		/// <summary>
		/// <para>Cuando se hace click</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnFire(object sender, InfoEventArgs<int> e)// Cuando se hace click
		{
			switch (e.info)
			{
				case 0:
					freya.CambiarEstado<SeleccionarUnidadEstadoFreya>();
					break;
				case 1:
					Turno.unidad.dir = dirInicio;
					Turno.unidad.Actualizar();
					freya.CambiarEstado<SeleccionComandoEstadoFreya>();
					break;
			}
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>IA Franqueo</para>
		/// </summary>
		/// <returns></returns>
		IEnumerator IAControl()// IA Franqueo
		{
			yield return new WaitForSeconds(0.5f);
			Turno.unidad.dir = freya.cpu.DeterminarDireccionFranqueo();
			Turno.unidad.Actualizar();

			yield return new WaitForSeconds(0.5f);
			freya.CambiarEstado<SeleccionarUnidadEstadoFreya>();
		}
		#endregion
	}
}