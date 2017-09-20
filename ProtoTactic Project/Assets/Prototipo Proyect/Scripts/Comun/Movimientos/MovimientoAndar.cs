//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MovimientoAndar.cs (14/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Logica del movimiento andar									\\
// Fecha Mod:		15/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Logica del movimiento andar.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Movimientos/MovimientoAndar")]
	public class MovimientoAndar : Movimiento
	{
		#region Metodos
		/// <summary>
		/// <para>Comprueba la distancia de busqueda</para>
		/// </summary>
		/// <param name="from">Area inicial</param>
		/// <param name="to">Area destino</param>
		/// <returns></returns>
		public override bool CompruebaBusqueda(Area from, Area to)
		{
			// Salir si la distancia en altura entre las dos areas es mayor a lo que la unidad puede saltar
			if ((Mathf.Abs(from.altura - to.altura) > Salto)) return false;

			// Salir si el area esta ocupada por un enemigo
			if (to.contenido != null) return false;

			return base.CompruebaBusqueda(from, to);
		}

		/// <summary>
		/// <para>Logica</para>
		/// </summary>
		/// <param name="area"></param>
		/// <returns></returns>
		public override IEnumerator Logica(Area area)// Logica
		{
			// Posicionar unidad en el area
			unidad.Posicionar(area);

			// Inicializar lista con el camino
			List<Area> camino = new List<Area>();
			while (area != null)
			{
				camino.Insert(0, area);
				area = area.prev;
			}

			// Mover a cada punto de direccion en sucesion
			for (int i = 1; i < camino.Count; i++)
			{
				Area from = camino[i - 1];
				Area to = camino[i];

				Direcciones dir = from.GetDireccion(to);

				if (unidad.dir != dir)yield return StartCoroutine(Giro(dir));

				if (from.altura == to.altura)
				{
					yield return StartCoroutine(Andar(to));
				}
				else
				{
					yield return StartCoroutine(Saltar(to));
				}	
			}
			yield return null;
		}

		/// <summary>
		/// <para>La unidad anda hasta el objetivo</para>
		/// </summary>
		/// <param name="target">Objetivo</param>
		/// <returns></returns>
		public IEnumerator Andar(Area target)// La unidad anda hasta el objetivo
		{
			Tweener tweener = transform.MoveTo(target.Centro, 0.5f, EasingEquations.Linear);

			while (tweener != null) yield return null;
		}

		/// <summary>
		/// <para>La unidad salta hasta el objetivo</para>
		/// </summary>
		/// <param name="to">Objetivo</param>
		/// <returns></returns>
		public IEnumerator Saltar(Area to)// La unidad salta hasta el objetivo
		{
			Tweener tweener = transform.MoveTo(to.Centro, 0.5f, EasingEquations.Linear);

			Tweener t2 = pivote.MoveToLocal(new Vector3(0, Area.alturaForzada * 2f, 0), tweener.duration / 2f, EasingEquations.EaseOutQuad);
			t2.loopCount = 1;
			t2.loopType = EasingControl.LoopType.PingPong;

			while (tweener != null) yield return null;
		}
		#endregion
	}
}