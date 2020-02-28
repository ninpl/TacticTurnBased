//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// TurnoController.cs (25/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controlador del turno										\\
// Fecha Mod:		25/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Sistemas;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Controlador del turno</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Controllers/TurnoController")]
	public class TurnoController : MonoBehaviour
	{
		#region Constantes
		/// <summary>
		/// <para>Cantidad de CTR para poder ser elegible para el turno</para>
		/// </summary>
		private const int turnoActivacion = 1000;                       // Cantidad de CTR para poder ser elegible para el turno
		/// <summary>
		/// <para>Minimo de CTR para tomar un turno</para>
		/// </summary>
		private const int turnoCoste = 500;								// Minimo de CTR para tomar un turno
		/// <summary>
		/// <para>Coste de movimiento</para>
		/// </summary>
		private const int movCoste = 300;								// Coste de movimiento
		/// <summary>
		/// <para>Coste de accion</para>
		/// </summary>
		private const int accionCoste = 200;							// Coste de accion
		#endregion

		#region Notificaciones
		public const string ComienzoRondaNotificacion = "TurnoController.ComienzoRondaNotificacion";
		public const string CambioTurnoNotificacion = "TurnoController.CambioTurnoNotificacion";
		public const string TurnoComienzoNotificacion = "TurnoController.TurnoComienzoNotificacion";
		public const string TurnoCompletadoNotificacion = "TurnoController.TurnoCompletadoNotificacion";
		public const string FinRondaNotificacion = "TurnoController.FinRondaNotificacion";
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Ronda</para>
		/// </summary>
		/// <returns></returns>
		public IEnumerator Ronda()// Ronda
		{
			// Obtener el sistema freya
			Freya freya = GetComponent<Freya>();

			while (true)
			{
				this.EnviarNotificacion(ComienzoRondaNotificacion);

				// Obtener las unidades actuales
				List<Unidad> unidades = new List<Unidad>(freya.unidades);

				// Agregar al stats
				for (int n = 0; n < unidades.Count; n++)
				{
					Stats s = unidades[n].GetComponent<Stats>();
					s[TipoStats.CTR] += s[TipoStats.SPD];
				}

				// Ordenar las unidades
				unidades.Sort((a, b) => GetCounter(a).CompareTo(GetCounter(b)));

				// Tomar turno
				for (int n = unidades.Count - 1; n >= 0; n--)
				{
					if (TomarTurno(unidades[n]))
					{
						// Cambiar el turno a la unidad
						freya.turno.Cambio(unidades[n]);
						unidades[n].EnviarNotificacion(TurnoComienzoNotificacion);

						yield return unidades[n];

						// Obtener el coste minimo del turno
						int coste = turnoCoste;

						// Modificar los parametros de la unidad (Ataque / Mover)
						if (freya.turno.puedeUnidadMover) coste += movCoste;
						if (freya.turno.puedeUnidadAtacar) coste += accionCoste;

						// Quitar el CTR por haber movido o atacado
						Stats s = unidades[n].GetComponent<Stats>();
						s.SetValue(TipoStats.CTR, s[TipoStats.CTR] - coste, false);

						unidades[n].EnviarNotificacion(TurnoCompletadoNotificacion);
					}
				}
				// Terminar la ronda
				this.EnviarNotificacion(FinRondaNotificacion);
			}
		}
		#endregion

		#region Funcionalidades
		/// <summary>
		/// <para>Toma el turno de una unidad</para>
		/// </summary>
		/// <param name="target">Unidad</param>
		/// <returns></returns>
		private bool TomarTurno(Unidad target)// Toma el turno de una unidad
		{
			BaseExcepcion exc = new BaseExcepcion(GetCounter(target) >= turnoActivacion);
			target.EnviarNotificacion(CambioTurnoNotificacion, exc);
			return exc.Toggle;
		}

		/// <summary>
		/// <para>Obtener el counter de una unidad</para>
		/// </summary>
		/// <param name="target">Unidad</param>
		/// <returns></returns>
		private int GetCounter(Unidad target)// Obtener el counter de una unidad
		{
			return target.GetComponent<Stats>()[TipoStats.CTR];
		}
		#endregion
	}
}