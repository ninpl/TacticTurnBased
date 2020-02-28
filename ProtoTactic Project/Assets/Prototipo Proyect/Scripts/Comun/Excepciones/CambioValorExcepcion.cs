//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CambioValorExcepcion.cs (22/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Subclase con los diferentes modificadores de valor			\\
// Fecha Mod:		26/07/2017													\\
// Ultima Mod:		Refactorizar Modificador									\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Subclase con los diferentes modificadores de valor.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/CambioValorExcepcion")]
	public class CambioValorExcepcion : BaseExcepcion
	{
		#region Variables
		/// <summary>
		/// <para>Del valor</para>
		/// </summary>
		public readonly float fromValue;					// De valor
		/// <summary>
		/// <para>Al valor</para>
		/// </summary>
		public readonly float toValue;						// Al valor
		/// <summary>
		/// <para>Lista de modificadores</para>
		/// </summary>
		public List<ModificadorValor> modificadores;           // Lista de modificadores
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Delta</para>
		/// </summary>
		public float Delta
		{
			get { return toValue - fromValue; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="CambioValueExcepcion"/></para>
		/// </summary>
		/// <param name="fromValue">Del valor</param>
		/// <param name="toValue">Al valor</param>
		public CambioValorExcepcion(float fromValue, float toValue) : base (true)// Constructor de CambioValueExcepcion
		{
			this.fromValue = fromValue;
			this.toValue = toValue;
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Agrega un modificador a la lista</para>
		/// </summary>
		/// <param name="m">Nuevo Modificador</param>
		public void AddModificador(ModificadorValor m)// Agrega un modificador a la lista
		{
			if (modificadores == null) modificadores = new List<ModificadorValor>();

			modificadores.Add(m);
		}
		#endregion

		#region Funcionalidades
		/// <summary>
		/// <para>Obtiene el modificador</para>
		/// </summary>
		/// <returns></returns>
		public float GetValorModificador()// Obtiene el modificador
		{
			if (modificadores == null) return toValue;

			float value = toValue;
			modificadores.Sort(Compare);

			for (int n = 0; n < modificadores.Count; n++)
			{
				value = modificadores[n].Modificador(fromValue, value);
			}

			return value;
		}

		/// <summary>
		/// <para>Compara dos modificadores</para>
		/// </summary>
		/// <param name="x">Modificador 1</param>
		/// <param name="y">Modificador 2</param>
		/// <returns></returns>
		private int Compare(ModificadorValor x, ModificadorValor y)// Compara dos modificadores
		{
			return x.sortOrder.CompareTo(y.sortOrder);
		}
		#endregion
	}
}