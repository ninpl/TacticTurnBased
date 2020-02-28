//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// SecuenciaMovimientoEstadoFreya.cs (21/07/2017)								\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado donde las unidades se mueven							\\
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
	/// <para>Estado donde las unidades se mueven.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/SecuenciaMovimientoEstadoFreya")]
	public class SecuenciaMovimientoEstadoFreya : EstadoFreya
	{
		#region Estados
		/// <summary>
		/// <para>Cuando entra en el estado</para>
		/// </summary>
		public override void Enter()// Cuando entra en el estado
		{
			base.Enter();
			StartCoroutine("Movimiento");
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Mueve a la unidad</para>
		/// </summary>
		/// <returns></returns>
		public IEnumerator Movimiento()// Mueve a la unidad
		{
			Movimiento m = Turno.unidad.GetComponent<Movimiento>();
			yield return StartCoroutine(m.Logica(freya.AreaActual));
			Turno.puedeUnidadMover = true;
			freya.CambiarEstado<SeleccionComandoEstadoFreya>();
		}
		#endregion
	}
}
