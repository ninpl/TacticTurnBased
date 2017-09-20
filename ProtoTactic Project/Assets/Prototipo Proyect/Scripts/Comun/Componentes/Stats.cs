//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Stats.cs (22/07/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estadisticas de las unidades								\\
// Fecha Mod:		22/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Estadisticas de las unidades.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Componentes/Stats")]
	public class Stats : MonoBehaviour
	{
		#region Variables Estaticas
		private static Dictionary<TipoStats, string> cuandoCambieNotificacion = new Dictionary<TipoStats, string>();
		private static Dictionary<TipoStats, string> cuandoCambioNotificacion = new Dictionary<TipoStats, string>();
		#endregion

		#region Variables Publicas
		/// <summary>
		/// <para>Data de las estadisticas</para>
		/// </summary>
		public int[] data = new int[(int)TipoStats.Count];                 // Data de las estadisticas
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Tipos de estadisticas</para>
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public int this[TipoStats s]
		{
			get { return data[(int)s]; }
			set { SetValue(s, value, true); }
		}
		#endregion

		#region API
		/// <summary>
		/// <para>Cuando Cambie</para>
		/// </summary>
		/// <param name="tipo"></param>
		/// <returns></returns>
		public static string CuandoCambieNotificacion(TipoStats tipo)// Cuando Cambie
		{
			if (!cuandoCambieNotificacion.ContainsKey(tipo)) cuandoCambieNotificacion.Add(tipo, string.Format("Stats.{0}CuandoCambie", tipo.ToString()));
			return cuandoCambieNotificacion[tipo];
		}

		/// <summary>
		/// <para>Cuando Cambio</para>
		/// </summary>
		/// <param name="tipo"></param>
		/// <returns></returns>
		public static string CuandoCambioNotificacion(TipoStats tipo)// Cuando Cambio
		{
			if (!cuandoCambioNotificacion.ContainsKey(tipo)) cuandoCambioNotificacion.Add(tipo, string.Format("Stats.{0}Cambio", tipo.ToString()));
			return cuandoCambioNotificacion[tipo];
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Fija el valor</para>
		/// </summary>
		/// <param name="tipo"></param>
		/// <param name="value"></param>
		/// <param name="permitirExcepcion"></param>
		public void SetValue(TipoStats tipo, int value, bool permitirExcepcion)// Fija el valor
		{
			int valorAntiguo = this[tipo];

			// Comprobar los valores
			if (valorAntiguo == value) return;

			if (permitirExcepcion)
			{
				// Permitir excepciones a la regla aquí
				CambioValorExcepcion exc = new CambioValorExcepcion(valorAntiguo, value);

				// La notificacion es unica por tipo de stats
				this.EnviarNotificacion(CuandoCambieNotificacion(tipo), exc);


				// ¿Algo modifico el valor?
				value = Mathf.FloorToInt(exc.GetValorModificador());

				// ¿Algo anulo el cambio?
				if (exc.Toggle == false || value == valorAntiguo) return;
			}

			data[(int)tipo] = value;
			this.EnviarNotificacion(CuandoCambioNotificacion(tipo), valorAntiguo);
		}
		#endregion
	}
}