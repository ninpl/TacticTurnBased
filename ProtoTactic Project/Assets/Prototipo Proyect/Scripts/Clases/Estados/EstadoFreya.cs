//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EstadoFreya.cs (11/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase general del estado de Freya(Batalla)					\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Sistemas;
using MoonAntonio.Glitch.Data;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.UI;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase general del estado de Freya(Batalla)</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/EstadoFreya")]
	public abstract class EstadoFreya : Estado
	{
		#region Variables publica
		/// <summary>
		/// <para>Sistema de combate.</para>
		/// </summary>
		public Freya freya;                         // Sistema de combate
		/// <summary>
		/// <para>Controlador actual CPU/Jugador</para>
		/// </summary>
		public Controlador control;                 // Controlador actual CPU/Jugador
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Camara de Combate.</para>
		/// </summary>
		public CamaraController Camara
		{
			get { return freya.cam; }
		}

		/// <summary>
		/// <para>Grid del juego.</para>
		/// </summary>
		public Grid Grid
		{
			get { return freya.grid; }
		}

		/// <summary>
		/// <para>Data del nivel</para>
		/// </summary>
		public LevelData LevelData
		{
			get { return freya.levelData; }
		}

		/// <summary>
		/// <para>Cursor actual</para>
		/// </summary>
		public Transform Cursor
		{
			get { return freya.cursor; }
		}

		/// <summary>
		/// <para>Posicion actual.</para>
		/// </summary>
		public Punto Pos
		{
			get { return freya.pos; }
			set { freya.pos = value; }
		}

		/// <summary>
		/// <para>Actual area</para>
		/// </summary>
		public Area AreaActualSel
		{
			get { return freya.AreaActual; }
		}

		/// <summary>
		/// <para>Turno actual</para>
		/// </summary>
		public Turno Turno
		{
			get { return freya.turno; }
		}

		/// <summary>
		/// <para>Unidades actuales</para>
		/// </summary>
		public List<Unidad> Unidades
		{
			get { return freya.unidades; }
		}

		/// <summary>
		/// <para>Panel de habilidades</para>
		/// </summary>
		public MenuHabilidadesController PanelHabilidades
		{
			get { return freya.panelHabilidades; }
		}

		/// <summary>
		/// <para>Panel de las estadisticas.</para>
		/// </summary>
		public MenuInfoController PanelEstadisticas
		{
			get { return freya.panelEstadisticas; }
		}

		/// <summary>
		/// <para>Indicador de acierto</para>
		/// </summary>
		public IndicadorAciertos PanelIndicadorAcierto { get { return freya.panelIndicador; } }

		/// <summary>
		/// <para>Estado actual</para>
		/// </summary>
		public EstadosFreyaSeguimiento EstadoActualInit
		{
			get { return freya.estadoActualInit; }
			set { freya.estadoActualInit = value; }
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="EstadoFreya"/>.</para>
		/// </summary>
		public virtual void Awake()// Inicializador de EstadoFreya
		{
			freya = GetComponent<Freya>();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando entra en el estado</para>
		/// </summary>
		public override void Enter()// Cuando entra en el estado
		{
			control = (Turno.unidad != null) ? Turno.unidad.GetComponent<Controlador>() : null;
			base.Enter();
		}

		/// <summary>
		/// <para>Agregar oyentes</para>
		/// </summary>
		public override void AddListeners()// Agregar oyentes
		{
			if (control == null || control.Actual == Controladores.Humano)
			{
				InputController.moveEvent += OnMove;
				InputController.fireEvent += OnFire;
			}
		}

		/// <summary>
		/// <para>Quitar oyentes</para>
		/// </summary>
		public override void RemoveListeners()// Quitar oyentes
		{
			InputController.moveEvent -= OnMove;
			InputController.fireEvent -= OnFire;
		}

		/// <summary>
		/// <para>Actualiza el panel unidad</para>
		/// </summary>
		/// <param name="p"></param>
		public virtual void ActualizarPanelInfoUnidad(Punto p)// Actualiza el panel unidad
		{
			Unidad target = GetUnidad(p);
			if (target != null)
				PanelEstadisticas.MostrarAliado(target.gameObject);
			else
				PanelEstadisticas.OcultarAliado();
		}

		/// <summary>
		/// <para>Actualiza el panel objetivo</para>
		/// </summary>
		/// <param name="p"></param>
		public virtual void ActualizarPanelInfoObjetivo(Punto p)// Actualiza el panel objetivo
		{
			Unidad target = GetUnidad(p);
			if (target != null)
				PanelEstadisticas.MostrarEnemigo(target.gameObject);
			else
				PanelEstadisticas.OcultarEnemigo();
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Evento de movimiento.</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void OnMove(object sender, InfoEventArgs<Punto> e)// Evento de movimiento
		{

		}

		/// <summary>
		/// <para>Evento de click.</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void OnFire(object sender, InfoEventArgs<int> e)// Evento de click
		{

		}
		#endregion

		#region Funcionalidades
		/// <summary>
		/// <para>Selecciona la area.</para>
		/// </summary>
		/// <param name="p">Coordenadas del punto</param>
		public virtual void SeleccionarArea(Punto p)// Selecciona la area
		{
			if (Pos == p || !Grid.areas.ContainsKey(p)) return;

			Pos = p;
			Cursor.localPosition = Grid.areas[p].Centro;
		}

		/// <summary>
		/// <para>Obtiene una unidad</para>
		/// </summary>
		/// <param name="p">Punto</param>
		/// <returns></returns>
		public virtual Unidad GetUnidad(Punto p)// Obtiene una unidad
		{
			Area t = Grid.GetArea(p);
			GameObject content = t != null ? t.contenido : null;
			return content != null ? content.GetComponent<Unidad>() : null;
		}

		/// <summary>
		/// <para>El jugador gana</para>
		/// </summary>
		/// <returns></returns>
		public virtual bool PlayerWin()// El jugador gana
		{
			return freya.GetComponent<BaseObjetivoBatalla>().Victoria == Bandos.Aliado;
		}

		/// <summary>
		/// <para>El jugador pierde</para>
		/// </summary>
		/// <returns></returns>
		public virtual bool PlayerOver()// El jugador pierde
		{
			return freya.GetComponent<BaseObjetivoBatalla>().Victoria != Bandos.None;
		}
		#endregion
	}
}