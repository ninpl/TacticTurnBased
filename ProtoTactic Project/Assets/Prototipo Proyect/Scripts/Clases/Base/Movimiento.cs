//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Movimiento.cs (14/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base de los tipos de movimientos						\\
// Fecha Mod:		15/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase base de los tipos de movimientos.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/Movimiento")]
	public abstract class Movimiento : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Unidad actual.</para>
		/// </summary>
		public Unidad unidad;									// Unidad actual
		/// <summary>
		/// <para>Pivote de la unidad.</para>
		/// </summary>
		public Transform pivote;                                // Pivote de la unidad
		/// <summary>
		/// <para>Referencia a stats</para>
		/// </summary>
		public Stats stats;                                     // Referencia a stats
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Rango de movimiento</para>
		/// </summary>
		public int Rango
		{
			get { return stats[TipoStats.MOV]; }
		}

		/// <summary>
		/// <para>Rango de salto</para>
		/// </summary>
		public int Salto
		{
			get { return stats[TipoStats.JMP]; }
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="Movimiento"/>.</para>
		/// </summary>
		public virtual void Awake()// Inicializador de Movimiento
		{
			unidad = GetComponent<Unidad>();
			pivote = transform.Find("Pivote");
		}

		/// <summary>
		/// <para>Inicializador de <see cref="Movimiento"/>.</para>
		/// </summary>
		public virtual void Start()// Inicializador de Movimiento
		{
			stats = GetComponent<Stats>();
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Obtener areas a rango.</para>
		/// </summary>
		/// <param name="grid">Grid del nivel.</param>
		/// <returns></returns>
        public virtual List<Area> GetAreasInRango(Glitch.Comun.Grid grid)// Obtener areas a rango
		{
			List<Area> retValue = grid.Buscar(unidad.Area, CompruebaBusqueda);
			Filtro(retValue);
			return retValue;
		}

		/// <summary>
		/// <para>Comprueba la distancia de busqueda.</para>
		/// </summary>
		/// <param name="from">Area inicial</param>
		/// <param name="to">Area destino</param>
		/// <returns></returns>
		public virtual bool CompruebaBusqueda(Area from, Area to)// Comprueba la distancia de busqueda
		{
			return (from.distancia + 1) <= Rango;
		}

		/// <summary>
		/// <para>Comprueba que no pase por otras unidades o sitios bloqueados.</para>
		/// </summary>
		/// <param name="areas">Areas</param>
		public virtual void Filtro(List<Area> areas)// Comprueba que no pase por otras unidades o sitios bloqueados
		{
			for (int n = areas.Count - 1; n >= 0; n--)
			{
				if (areas[n].contenido != null) areas.RemoveAt(n);
			}
		}

		/// <summary>
		/// <para>Logica</para>
		/// </summary>
		/// <param name="area">Area</param>
		/// <returns></returns>
		public abstract IEnumerator Logica(Area area);// Logica

		/// <summary>
		/// <para>Realiza el giro de la unidad hacia una direccion.</para>
		/// </summary>
		/// <param name="dir">Direccion</param>
		/// <returns></returns>
		public virtual IEnumerator Giro(Direcciones dir)// Realiza el giro de la unidad hacia una direccion
		{
			TransformLocalEulerTweener a = (TransformLocalEulerTweener)transform.RotateToLocal(dir.DireccionAVector3(), 0.25f, EasingEquations.EaseInOutQuad);

			// Cuando giramos entre el norte y el oeste, debemos hacer una excepcion para que parezca que la unidad
			// gira de la manera mas eficiente (ya que 0 y 360 es igual)
			if (Mathf.Approximately(a.startTweenValue.y, 0f) && Mathf.Approximately(a.endTweenValue.y, 270f))
			{
				a.startTweenValue = new Vector3(a.startTweenValue.x, 360f, a.startTweenValue.z);
			}
			else if (Mathf.Approximately(a.startTweenValue.y, 270) && Mathf.Approximately(a.endTweenValue.y, 0))
			{
				a.endTweenValue = new Vector3(a.startTweenValue.x, 360f, a.startTweenValue.z);
			}

			// Fijamos la direccion de la unidad
			unidad.dir = dir;

			while (a != null) yield return null;
		}
		#endregion
	}
}