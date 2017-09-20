//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CondicionComparacionStats.cs (31/07/2017)									\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Comparacion de estadisticas									\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Comparacion de estadisticas</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/CondicionComparacionStats")]
	public class CondicionComparacionStats : CondicionEstadoUnidad
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Estadisticas</para>
		/// </summary>
		private Stats stats;										// Estadisticas
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Tipo de stats</para>
		/// </summary>
		public TipoStats Tipo
		{
			get;
			private set;
		}

		/// <summary>
		/// <para>Valor</para>
		/// </summary>
		public int Valor
		{
			get;
			private set;
		}

		/// <summary>
		/// <para>Condicion</para>
		/// </summary>
		public Func<bool> Condicion
		{
			get;
			private set;
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Cargador de <see cref="CondicionComparacionStats"/></para>
		/// </summary>
		private void Awake()// Cargador de CondicionComparacionStats
		{
			stats = GetComponentInParent<Stats>();
		}

		/// <summary>
		/// <para>Inicializacion de <see cref="CondicionComparacionStats"/></para>
		/// </summary>
		/// <param name="tipo"></param>
		/// <param name="valor"></param>
		/// <param name="condicion"></param>
		public void Init(TipoStats tipo, int valor, Func<bool> condicion)// Inicializacion de CondicionComparacionStats
		{
			this.Tipo = tipo;
			this.Valor = valor;
			this.Condicion = condicion;
			this.AddObservador(OnStatCambia, Stats.CuandoCambioNotificacion(tipo), stats);
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando no esta activo</para>
		/// </summary>
		private void OnDisable()// Cuando no esta activo
		{
			this.RemoveObservador(OnStatCambia, Stats.CuandoCambioNotificacion(Tipo), stats);
		}

		/// <summary>
		/// <para>Igual a</para>
		/// </summary>
		/// <returns></returns>
		public bool IgualA()// Igual a
		{
			return stats[Tipo] == Valor;
		}

		/// <summary>
		/// <para>Menos que</para>
		/// </summary>
		/// <returns></returns>
		public bool MenosQue()// Menos que
		{
			return stats[Tipo] < Valor;
		}

		/// <summary>
		/// <para>Menos que o igual a</para>
		/// </summary>
		/// <returns></returns>
		public bool MenosQueOIgualA()// Menos que o igual a
		{
			return stats[Tipo] <= Valor;
		}

		/// <summary>
		/// <para>Mas que</para>
		/// </summary>
		/// <returns></returns>
		public bool MasQue()// Mas que
		{
			return stats[Tipo] > Valor;
		}

		/// <summary>
		/// <para>Mas que o igual a</para>
		/// </summary>
		/// <returns></returns>
		public bool MasQueOIgualA()// Mas que o igual a
		{
			return stats[Tipo] >= Valor;
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando cambia el stat</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnStatCambia(object sender, object args)// Cuando cambia el stat
		{
			if (Condicion != null && !Condicion()) Remove();
		}
		#endregion
	}
}