//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ExplorarEstadoFreya.cs (21/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado para explorar el mapa								\\
// Fecha Mod:		21/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun.Estados
{
	/// <summary>
	/// <para>Estado para explorar el mapa.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/ExplorarEstadoFreya")]
	public class ExplorarEstadoFreya : EstadoFreya
	{
		#region Estados
		/// <summary>
		/// <para>Cuando se entra en el estado</para>
		/// </summary>
		public override void Enter()// Cuando se entra en el estado
		{
			base.Enter();
			ActualizarPanelInfoUnidad(Pos);
		}

		/// <summary>
		/// <para>Cuando se sale del estado</para>
		/// </summary>
		public override void Exit()// Cuando se sale del estado
		{
			base.Exit();
			PanelEstadisticas.OcultarAliado();
		}

		/// <summary>
		/// <para>Cuando se mueve</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnMove(object sender, InfoEventArgs<Punto> e)// Cuando se mueve
		{
			SeleccionarArea(e.info + Pos);
			ActualizarPanelInfoUnidad(Pos);
		}

		/// <summary>
		/// <para>Cuando se hace click</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void OnFire(object sender, InfoEventArgs<int> e)// Cuando se hace click
		{
			if (e.info == 0) freya.CambiarEstado<SeleccionComandoEstadoFreya>();
		}
		#endregion

		#region Actualizador
		/*
		private void Update()
		{
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
			{
				if (hit.transform.GetComponent<Area>())
				{
					Punto p = hit.transform.GetComponent<Area>().pos;
					SeleccionarArea(p);
					ActualizarPanelInfoUnidad(Pos);
				}
			}
		}*/
		#endregion
	}
}