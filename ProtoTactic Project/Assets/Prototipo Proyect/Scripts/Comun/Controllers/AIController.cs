//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// AIController.cs (31/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controla la IA del enemigo									\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Sistemas;
using MoonAntonio.Glitch.Extensiones;
using MoonAntonio.Glitch.AI;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Controla la IA del enemigo</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Controllers/AIController")]
	public class AIController : MonoBehaviour
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Controlador de batalla</para>
		/// </summary>
		private Freya freya;								// Controlador de batalla
		/// <summary>
		/// <para>Unidad cercana</para>
		/// </summary>
		private Unidad unidadCercana;						// Unidad cercana
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Unidad enemiga actual</para>
		/// </summary>
		private Unidad Unidad
		{
			get { return freya.turno.unidad; }
		}

		/// <summary>
		/// <para>Alianza</para>
		/// </summary>
		private Bando Bando
		{
			get { return Unidad.GetComponent<Bando>(); }
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="AIController"/></para>
		/// </summary>
		private void Awake()// Inicializador de AIController
		{
			// Obtener freya
			freya = GetComponent<Freya>();
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Evaluar el plan de ataque</para>
		/// </summary>
		/// <returns></returns>
		public PlanDeAtaque Evaluar()// Evaluar el plan de ataque
		{
			// Obtener el plan de ataque y el patron
			PlanDeAtaque plan = new PlanDeAtaque();
			PatronAtaque patron = Unidad.GetComponentInChildren<PatronAtaque>();

			// Si hay patron, seleccionar plan, sino dar uno por defecto
			if (patron)
			{
				patron.Eleccion(plan);
			}
			else
			{
				PatronAtaqueGeneral(plan);
			}

			// Comprobar la posicion y direccion y preparar la accion
			if (IsPosicionIndependiente(plan))
			{
				PlanPosicionIndependiente(plan);
			}
			else if (IsDireccionIndependiente(plan))
			{
				PlanDireccionIndependiente(plan);
			}
			else
			{
				PlanDirectionDependent(plan);
			}	

			// Mover hacia el oponente
			if (plan.habilidad == null) MoverHaciaOponente(plan);

			return plan;
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Asigna solo atacar</para>
		/// </summary>
		/// <param name="plan"></param>
		private void PatronAtaqueGeneral(PlanDeAtaque plan)// Asigna solo atacar
		{
			// Solo obtiene la habilidad de ataque
			plan.habilidad = Unidad.GetComponentInChildren<Habilidad>();
			plan.objetivo = Objetivos.Enemigo;
		}

		/// <summary>
		/// <para>Selecciona el plan de movimiento</para>
		/// </summary>
		/// <param name="plan"></param>
		private void PlanPosicionIndependiente(PlanDeAtaque plan)// Selecciona el plan de movimiento
		{
			// Generar la lista de las opciones de movimiento
			List<Area> opcionesMov = GetOpcionesMovimiento();

			// Seleccionar una opcion
			Area area = opcionesMov[Random.Range(0, opcionesMov.Count)];

			// Seleccionar la posicion
			plan.posMovi = plan.posAtaque = area.pos;
		}

		/// <summary>
		/// <para>Selecciona el plan de direccion</para>
		/// </summary>
		/// <param name="plan"></param>
		private void PlanDireccionIndependiente(PlanDeAtaque plan)// Selecciona el plan de direccion
		{
			// Obtener datos
			Area areaInicial = Unidad.Area;
			Dictionary<Area, OpcionAtaque> mapeo = new Dictionary<Area, OpcionAtaque>();
			RangoHabilidad rangoHab = plan.habilidad.GetComponent<RangoHabilidad>();
			List<Area> opcionesMov = GetOpcionesMovimiento();

			// Comprobar las opciones de movimiento
			for (int n = 0; n < opcionesMov.Count; n++)
			{
				// Posicionar la unidad en la siguiente area
				Area sigArea = opcionesMov[n];
				Unidad.Posicionar(sigArea);

				// Obtener las posibles opciones de ataque
				List<Area> opcionesAtaq = rangoHab.GetAreasARango(freya.grid);

				// Comprobar las opciones de ataques
				for (int i = 0; i < opcionesAtaq.Count; i++)
				{
					Area areaAtaque = opcionesAtaq[i];
					OpcionAtaque opcionAtaq = null;

					// Comprobar si el area puede ser atacada
					if (mapeo.ContainsKey(areaAtaque))
					{
						opcionAtaq = mapeo[areaAtaque];
					}
					else
					{
						// Cambiar la ocpion
						opcionAtaq = new OpcionAtaque();
						mapeo[areaAtaque] = opcionAtaq;
						opcionAtaq.objetivo = areaAtaque;
						opcionAtaq.direccion = Unidad.dir;
						AnalizarLocalizacionAtaque(plan, opcionAtaq);
					}

					// Moveer hacia la siguiente area
					opcionAtaq.AddMovimientoObjetivo(sigArea);
				}
			}

			// Posicionar unidad
			Unidad.Posicionar(areaInicial);
			List<OpcionAtaque> list = new List<OpcionAtaque>(mapeo.Values);

			// Elegir la mejor opcion
			ElegirMejorOpcion(plan, list);
		}

		/// <summary>
		/// <para>Selecciona el plan de direccion</para>
		/// </summary>
		/// <param name="plan"></param>
		private void PlanDirectionDependent(PlanDeAtaque plan)// Selecciona el plan de direccion
		{
			// Obtener datos
			Area areaInicial = Unidad.Area;
			Direcciones dirInicial = Unidad.dir;
			List<OpcionAtaque> list = new List<OpcionAtaque>();
			List<Area> opcionesMov = GetOpcionesMovimiento();

			// Comprobar las opciones de movimiento
			for (int n = 0; n < opcionesMov.Count; n++)
			{
				Area sigArea = opcionesMov[n];
				Unidad.Posicionar(sigArea);

				// Comprobar las ocpiones de direccion
				for (int i = 0; i < 4; i++)
				{
					Unidad.dir = (Direcciones)i;
					OpcionAtaque opcionAtaq = new OpcionAtaque();
					opcionAtaq.objetivo = sigArea;
					opcionAtaq.direccion = Unidad.dir;
					AnalizarLocalizacionAtaque(plan, opcionAtaq);
					opcionAtaq.AddMovimientoObjetivo(sigArea);
					list.Add(opcionAtaq);
				}
			}

			// Posicionar unidad
			Unidad.Posicionar(areaInicial);
			Unidad.dir = dirInicial;

			// Elegir la mejor opcion
			ElegirMejorOpcion(plan, list);
		}

		/// <summary>
		/// <para>Analiza la localizacion del ataque</para>
		/// </summary>
		/// <param name="plan"></param>
		/// <param name="opcionAtq"></param>
		private void AnalizarLocalizacionAtaque(PlanDeAtaque plan, OpcionAtaque opcionAtq)// Analiza la localizacion del ataque
		{
			// Obtener datos
			AreaHabilidad area = plan.habilidad.GetComponent<AreaHabilidad>();
			List<Area> areas = area.GetAreasEnArea(freya.grid, opcionAtq.objetivo.pos);

			// Obtener objetivos y habilidades
			opcionAtq.areaObjetivos = areas;
			opcionAtq.isAreaPeligrosa = IsHabilidadRealizable(plan, Unidad.Area);

			// Analizar areas
			for (int n = 0; n < areas.Count; n++)
			{
				Area areaAnali = areas[n];
				if (Unidad.Area == areas[n] || !plan.habilidad.IsTarget(areaAnali)) continue;

				// Comprobar si es realizable la habilidad y fijarla
				bool isRealizable = IsHabilidadRealizable(plan, areaAnali);
				opcionAtq.AddMarca(areaAnali, isRealizable);
			}
		}

		/// <summary>
		/// <para>Elige la mejor opcion</para>
		/// </summary>
		/// <param name="plan"></param>
		/// <param name="opcionesAtq"></param>
		private void ElegirMejorOpcion(PlanDeAtaque plan, List<OpcionAtaque> opcionesAtq)// Elige la mejor opcion
		{
			int mejorPuntuacion = 1;
		
			List<OpcionAtaque> mejoresOpciones = new List<OpcionAtaque>();

			// Comprobar opciones
			for (int n = 0; n < opcionesAtq.Count; n++)
			{
				// Calcular la puntuacion de la opcion
				OpcionAtaque opcion = opcionesAtq[n];
				int puntuacion = opcion.GetPuntuacion(Unidad, plan.habilidad);

				// Comprobar si es mejor que la actual en puntuacion
				if (puntuacion > mejorPuntuacion)
				{
					// Sustituir la nueva opcion por la anterior
					mejorPuntuacion = puntuacion;
					mejoresOpciones.Clear();
					mejoresOpciones.Add(opcion);
				}
				else if (puntuacion == mejorPuntuacion)
				{
					// Si es igual, agregarla a la lista
					mejoresOpciones.Add(opcion);
				}
			}

			if (mejoresOpciones.Count == 0)
			{
				// No hay opciones
				plan.habilidad = null;
				return;
			}

			List<OpcionAtaque> seleccionesFinales = new List<OpcionAtaque>();
			mejorPuntuacion = 0;

			// Comprobar las mejores ocpiones
			for (int i = 0; i < mejoresOpciones.Count; i++)
			{
				// Calcular la puntuacion de la opcion
				OpcionAtaque opcion = mejoresOpciones[i];
				int puntuacion = opcion.MejorPuntuacionAngulo;

				// Comprobar si es mejor que la actual en puntuacion
				if (puntuacion > mejorPuntuacion)
				{
					// Sustituir la nueva opcion por la anterior
					mejorPuntuacion = puntuacion;
					seleccionesFinales.Clear();
					seleccionesFinales.Add(opcion);
				}
				else if (puntuacion == mejorPuntuacion)
				{
					// Si es igual, agregarla a la lista
					seleccionesFinales.Add(opcion);
				}
			}

			// Seleccionar la opcion elegida
			OpcionAtaque eleccion = seleccionesFinales[Random.Range(0, seleccionesFinales.Count)];
			plan.posAtaque = eleccion.objetivo.pos;
			plan.dirAtaque = eleccion.direccion;
			plan.posMovi = eleccion.MejorMovimientoArea.pos;
		}

		/// <summary>
		/// <para>Buscar una unidad cercana</para>
		/// </summary>
		private void BuscarUnidadCercana()// Buscar una unidad cercana
		{
			unidadCercana = null;

			// Buscar con un criterio
			freya.grid.Buscar(Unidad.Area, delegate (Area arg1, Area arg2)
			{
				if (unidadCercana == null && arg2.contenido != null)
				{
					Bando bando = arg2.contenido.GetComponentInChildren<Bando>();
					if (bando != null && Bando.IsCalculo(bando, Objetivos.Enemigo))
					{
						// Si la alianza esta
						Unidad unidad = bando.GetComponent<Unidad>();
						Stats stats = unidad.GetComponent<Stats>();
						// Si la unidad no esta KO
						if (stats[TipoStats.HP] > 0)
						{
							// Obtener la unidad cercana
							unidadCercana = unidad;
							return true;
						}
					}
				}
				return unidadCercana == null;
			});
		}

		/// <summary>
		/// <para>Mueve la unidad hacia el oponente</para>
		/// </summary>
		/// <param name="plan"></param>
		private void MoverHaciaOponente(PlanDeAtaque plan)// Mueve la unidad hacia el oponente
		{
			// Obtener las opciones de movimiento
			List<Area> opcionesMov = GetOpcionesMovimiento();

			// Buscar unidades cercanas
			BuscarUnidadCercana();

			// Si se ha encontrado unidades cercanas
			if (unidadCercana != null)
			{
				// Comprobar que hay area
				Area area = unidadCercana.Area;
				while (area != null)
				{
					// Mover
					if (opcionesMov.Contains(area))
					{
						plan.posMovi = area.pos;
						return;
					}
					area = area.prev;
				}
			}

			plan.posMovi = Unidad.Area.pos;
		}

		/// <summary>
		/// <para>Determina la direccion de franqueo</para>
		/// </summary>
		/// <returns></returns>
		public Direcciones DeterminarDireccionFranqueo()// Determina la direccion de franqueo
		{
			Direcciones dir = (Direcciones)Random.Range(0, 4);

			// Buscar una unidad cerca
			BuscarUnidadCercana();

			// Si se ha encontrado una unidad cerca
			if (unidadCercana != null)
			{
				// Obtener la direccion de inicio
				Direcciones dirInicio = Unidad.dir;
				for (int n = 0; n < 4; n++)
				{
					Unidad.dir = (Direcciones)n;
					if (unidadCercana.GetFranqueo(Unidad) == Franqueo.Delante)
					{
						dir = Unidad.dir;
						break;
					}
				}
				Unidad.dir = dirInicio;
			}
			return dir;
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Comprueba si la posicion es independiente</para>
		/// </summary>
		/// <param name="plan"></param>
		/// <returns></returns>
		private bool IsPosicionIndependiente(PlanDeAtaque plan)// Comprueba si la posicion es independiente
		{
			RangoHabilidad rango = plan.habilidad.GetComponent<RangoHabilidad>();
			return rango.OrientacionPos == false;
		}

		/// <summary>
		/// <para>Comprueba si la direccion es independiente</para>
		/// </summary>
		/// <param name="plan"></param>
		/// <returns></returns>
		private bool IsDireccionIndependiente(PlanDeAtaque plan)// Comprueba si la direccion es independiente
		{
			RangoHabilidad rango = plan.habilidad.GetComponent<RangoHabilidad>();
			return !rango.OrientacionDir;
		}

		/// <summary>
		/// <para>Comprueba si la habilidad se puede realizar</para>
		/// </summary>
		/// <param name="plan"></param>
		/// <param name="area"></param>
		/// <returns></returns>
		private bool IsHabilidadRealizable(PlanDeAtaque plan, Area area)// Comprueba si la habilidad se puede realizar
		{
			bool isRealizable = false;

			// Si el objetivo es un area
			if (plan.objetivo == Objetivos.Area)
			{
				isRealizable = true;
			}	
			else if (plan.objetivo != Objetivos.None)
			{
				// Si no es un area, pero si una unidad
				Bando other = area.contenido.GetComponentInChildren<Bando>();
				if (other != null && Bando.IsCalculo(other, plan.objetivo)) isRealizable = true;
			}

			return isRealizable;
		}

		/// <summary>
		/// <para>Obtener las areas a rango para el movimiento</para>
		/// </summary>
		/// <returns></returns>
		private List<Area> GetOpcionesMovimiento()// Obtener las areas a rango para el movimiento
		{
			return Unidad.GetComponent<Movimiento>().GetAreasInRango(freya.grid);
		}
		#endregion
	}
}