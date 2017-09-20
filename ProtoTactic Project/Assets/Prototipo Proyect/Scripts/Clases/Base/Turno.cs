//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Turno.cs (21/07/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase del turno de las unidades								\\
// Fecha Mod:		02/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.AI;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase del turno de las unidades.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/Turno")]
	public class Turno
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Unidad del turno</para>
		/// </summary>
		public Unidad unidad;                                       // Unidad del turno
		/// <summary>
		/// <para>Puede la unidad moverse</para>
		/// </summary>
		public bool puedeUnidadMover;								// Puede la unidad moverse
		/// <summary>
		/// <para>Puede la unidad atacar</para>
		/// </summary>
		public bool puedeUnidadAtacar;								// Puede la unidad atacar
		/// <summary>
		/// <para>La unidad esta bloqueada</para>
		/// </summary>
		public bool bloqueoMovimiento;                              // La unidad esta bloqueada
		/// <summary>
		/// <para>Habilidad actual</para>
		/// </summary>
		public Habilidad habilidad;									// Habilidad actual
		/// <summary>
		/// <para>Objetivos</para>
		/// </summary>
		public List<Area> objetivos;                                // Objetivos
		/// <summary>
		/// <para>Plan de ataque</para>
		/// </summary>
		public PlanDeAtaque plan;                                   // Plan de ataque
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Area de inicio de la unidad</para>
		/// </summary>
		private Area inicioArea;                                    // Area de inicio de la unidad
		/// <summary>
		/// <para>Direccion de inicio de la unidad</para>
		/// </summary>
		private Direcciones inicioDireccion;                        // Direccion de inicio de la unidad
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Hace el cambio de la unidad</para>
		/// </summary>
		/// <param name="actual">Unidad actual</param>
		public void Cambio(Unidad actual)// Hace el cambio de la unidad
		{
			unidad = actual;
			puedeUnidadMover = false;
			puedeUnidadAtacar = false;
			bloqueoMovimiento = false;
			inicioArea = unidad.Area;
			inicioDireccion = unidad.dir;
			plan = null;
		}

		/// <summary>
		/// <para>Desace el movimiento</para>
		/// </summary>
		public void UndoMovimiento()// Desace el movimiento
		{
			puedeUnidadMover = false;
			unidad.Posicionar(inicioArea);
			unidad.dir = inicioDireccion;
			unidad.Actualizar();
		}
		#endregion
	}
}