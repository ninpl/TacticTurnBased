//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MovimientoVolar.cs (14/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Logica del movimiento volar									\\
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
	/// <para>Logica del movimiento volar.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Movimientos/MovimientoVolar")]
	public class MovimientoVolar : Movimiento
	{
		#region Metodos
		/// <summary>
		/// <para>Logica</para>
		/// </summary>
		/// <param name="area">Area</param>
		/// <returns></returns>
		public override IEnumerator Logica(Area area)// Logica
		{
			// Almacenar la distancia entre el area de inicio y el area de destino
			float dist = Mathf.Sqrt(Mathf.Pow(area.pos.x - unidad.Area.pos.x, 2) + Mathf.Pow(area.pos.y - unidad.Area.pos.y, 2));

			// Posicionar la unidad
			unidad.Posicionar(area);

			// Volar lo suficientemente alto como para no atravesar ningun area de tierra
			float y = Area.alturaForzada * 10;
			float duracion = (y - pivote.position.y) * 0.5f;
			Tweener tweener = pivote.MoveToLocal(new Vector3(0, y, 0), duracion, EasingEquations.EaseInOutQuad);
			while (tweener != null) yield return null;

			// Gire hacia la direccion general
			Direcciones dir;
			Vector3 toArea = (area.Centro - transform.position);
			if (Mathf.Abs(toArea.x) > Mathf.Abs(toArea.z))
			{
				dir = toArea.x > 0 ? Direcciones.Este : Direcciones.Oeste;
			}
			else
			{
				dir = toArea.z > 0 ? Direcciones.Norte : Direcciones.Sur;
			}

			// Girar
			yield return StartCoroutine(Giro(dir));

			// Mover hacia la direccion general
			duracion = dist * 0.5f;
			tweener = transform.MoveTo(area.Centro, duracion, EasingEquations.EaseInOutQuad);
			while (tweener != null) yield return null;

			// Aterrizar
			duracion = (y - area.Centro.y) * 0.5f;
			tweener = pivote.MoveToLocal(Vector3.zero, 0.5f, EasingEquations.EaseInOutQuad);
			while (tweener != null) yield return null;
		}
		#endregion
	}
}