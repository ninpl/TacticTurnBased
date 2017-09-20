//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MovimientoTeletransporte.cs (14/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Logica del movimiento teletransporte						\\
// Fecha Mod:		15/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Logica del movimiento teletransporte.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Movimientos/MovimientoTeletransporte")]
	public class MovimientoTeletransporte : Movimiento
	{
		#region Metodos
		/// <summary>
		/// <para>Logica</para>
		/// </summary>
		/// <param name="area">Area</param>
		/// <returns></returns>
		public override IEnumerator Logica(Area area)// Logica
		{
			// Posicionar unidad
			unidad.Posicionar(area);

			// Crear efecto
			Tweener spin = pivote.RotateToLocal(new Vector3(0, 360, 0), 0.5f, EasingEquations.EaseInOutQuad);
			spin.loopCount = 1;
			spin.loopType = EasingControl.LoopType.PingPong;

			Tweener desaparecerEff = transform.ScaleTo(Vector3.zero, 0.5f, EasingEquations.EaseInBack);

			while (desaparecerEff != null) yield return null;

			// Cambiar la posicion
			transform.position = area.Centro;

			// Aparecer
			Tweener aparecerEff = transform.ScaleTo(Vector3.one, 0.5f, EasingEquations.EaseOutBack);
			while (aparecerEff != null) yield return null;
		}
		#endregion
	}
}