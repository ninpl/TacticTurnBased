//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// TipoTasaExitoS.cs (28/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase determinante para la tasa de exito RES				\\
// Fecha Mod:		28/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase determinante para la tasa de exito RES</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/TipoTasaExitoS")]
	public class TipoTasaExitoS : TasaExito
	{
		#region Metodos
		/// <summary>
		/// <para>Devuelve un valor en el rango de 0 a 100 como un porcentaje de probabilidad de que una habilidad tenga exito</para>
		/// </summary>
		/// <param name="atacante">Atacante</param>
		/// <param name="defensor">Defensor</param>
		/// <returns></returns>
		public override int Calcular(Area target)// Devuelve un valor en el rango de 0 a 100 como un porcentaje de probabilidad de que una habilidad tenga exito
		{
			Unidad defensor = target.contenido.GetComponent<Unidad>();

			if (AutomaticExito(defensor)) return Final(100);

			if (AutomaticEvasion(defensor)) return Final(0);

			int res = GetResistencia(defensor);
			res = AjustarEfectosStatus(defensor, res);
			res = AjustarFranqueo(defensor, res);
			res = Mathf.Clamp(res, 0, 100);
			return Final(res);
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Obtiene la resistencia de la unidad</para>
		/// </summary>
		/// <param name="target">Unidad</param>
		/// <returns></returns>
		private int GetResistencia(Unidad target)// Obtiene la resistencia de la unidad
		{
			Stats s = target.GetComponentInParent<Stats>();
			return s[TipoStats.RES];
		}

		/// <summary>
		/// <para>Ajusta el franqueo de las unidades</para>
		/// </summary>
		/// <param name="atacante"></param>
		/// <param name="defensor"></param>
		/// <param name="porcentaje"></param>
		/// <returns></returns>
		private int AjustarFranqueo(Unidad defensor, int porcentaje)// Ajusta el franqueo de las unidades
		{
			switch (atacante.GetFranqueo(defensor))
			{
				case Franqueo.Delante:
					return porcentaje;
				case Franqueo.Lados:
					return porcentaje - 10;
				default:
					return porcentaje - 20;
			}
		}
		#endregion
	}
}