//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EfectoHabilidadEsuna.cs (29/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase que inflinge el efecto de habilidad					\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System;
using System.Collections.Generic;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase que inflinge el efecto de habilidad</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/EfectoHabilidadEsuna")]
	public class EfectoHabilidadEsuna : BaseEfectoHabilidad
	{
		#region Variables Privadas
		private static HashSet<Type> tipos;
		#endregion

		#region Propiedades
		static HashSet<Type> Tipos
		{
			get
			{
				if (tipos == null)
				{
					tipos = new HashSet<Type>();
					tipos.Add(typeof(EstadoEfectoVeneno));
					tipos.Add(typeof(EstadoEfectoCiego));
				}
				return tipos;
			}
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Predice el damage</para>
		/// </summary>
		/// <param name="target">Area</param>
		/// <returns></returns>
		public override int Predecir(Area target)// Predice el damage
		{
			return 0;
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Aplica el damage</para>
		/// </summary>
		/// <param name="target">Area</param>
		public override int OnAplicar(Area target)
		{
			Unidad defensor = target.contenido.GetComponent<Unidad>();
			EstadoUnidad estado = defensor.GetComponentInChildren<EstadoUnidad>();

			DuracionCondicionEstadoUnidad[] candidatos = estado.GetComponentsInChildren<DuracionCondicionEstadoUnidad>();
			for (int i = candidatos.Length - 1; i >= 0; --i)
			{
				EfectoEstadoUnidad efecto = candidatos[i].GetComponentInParent<EfectoEstadoUnidad>();
				if (Tipos.Contains(efecto.GetType())) candidatos[i].Remove();
			}
			return 0;
		}
		#endregion
	}
}