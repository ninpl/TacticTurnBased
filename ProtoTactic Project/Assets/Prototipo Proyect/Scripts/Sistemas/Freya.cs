//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Freya.cs (11/07/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Sistema de batalla de Glitch								\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Data;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.Comun.Estados;
using MoonAntonio.Glitch.UI;
#endregion

namespace MoonAntonio.Glitch.Sistemas
{
	/// <summary>
	/// <para>Sistema de batalla de Glitch.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Sistemas/Freya")]
	public class Freya : Odin
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Camara de combate.</para>
		/// </summary>
		public CamaraController cam;                            // Camara de combate
		/// <summary>
		/// <para>Grid del juego.</para>
		/// </summary>
		public Glitch.Comun.Grid grid;										// Grid del juego
		/// <summary>
		/// <para>Data del nivel.</para>
		/// </summary>
		public LevelData levelData;								// Data del nivel
		/// <summary>
		/// <para>Cursor actual.</para>
		/// </summary>
		public Transform cursor;								// Cursor actual
		/// <summary>
		/// <para>Posicion actual.</para>
		/// </summary>
		public Punto pos;                                       // Posicion actual
		/// <summary>
		/// <para>Turno actual</para>
		/// </summary>
		public Turno turno = new Turno();						// Turno actual
		/// <summary>
		/// <para>Unidades de combate</para>
		/// </summary>
		public List<Unidad> unidades = new List<Unidad>();		// Unidades de combate
		/// <summary>
		/// <para>Ronda</para>
		/// </summary>
		public IEnumerator ronda;                               // Ronda
		/// <summary>
		/// <para>Logica del enemigo</para>
		/// </summary>
		public AIController cpu;								// Logica del enemigo
		/// <summary>
		/// <para>Panel de habilidades</para>
		/// </summary>
		public MenuHabilidadesController panelHabilidades;		// Panel de habilidades
		/// <summary>
		/// <para>Panel de las estadisticas</para>
		/// </summary>
		public MenuInfoController panelEstadisticas;			// Panel de las estadisticas
		/// <summary>
		/// <para>Panel de mensajes</para>
		/// </summary>
		public MensajesBatallaController panelMensajes;         // Panel de mensajes
		/// <summary>
		/// <para>Panel indicador de acierto</para>
		/// </summary>
		public IndicadorAciertos panelIndicador;				// Panel indicador de acierto
		/// <summary>
		/// <para>Estado actual</para>
		/// </summary>
		public EstadosFreyaSeguimiento estadoActualInit;        // Estado actual
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Area actual.</para>
		/// </summary>
		public Area AreaActual
		{
			get { return grid.GetArea(pos); }
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="Freya"/>.</para>
		/// </summary>
		private void Start()// Inicializador de Freya
		{
			CambiarEstado<InitEstadoFreya>();
		}
		#endregion
	}

	/// <summary>
	/// <para>Estados de freya</para>
	/// </summary>
	public enum EstadosFreyaSeguimiento
	{
		None,
		Inicializando,
		MoviendoUnidad,
		ConfirmandoObjetivo,
		Conversacion,
		Explorando,
		FinalizandoBatalla,
		Franqueando,
		RealizandoHabilidad,
		SecuenciaMovimientoUnidad,
		SeleccionandoAccion,
		SeleccionandoCategoria,
		SeleccionandoObjetivo,
		SeleccionandoUnidad,
		SeleccionandoComando
	}
}