//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// TipoTasaExitoA.cs (28/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase determinante para la tasa de exito EVD				\\
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
	/// <para>Clase determinante para la tasa de exito EVD</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/TipoTasaExitoA")]
	public class TipoTasaExitoA : TasaExito
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

			if (AutomaticExito(defensor)) return Final(0);

			if (AutomaticEvasion(defensor)) return Final(100);

			int evasion = GetEvasion(defensor);
			evasion = AjustarFranqueo(defensor, evasion);
			evasion = AjustarEfectosStatus(defensor, evasion);
			evasion = Mathf.Clamp(evasion, 5, 95);
			return Final(evasion);
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Obtiene la evasion de la unidad</para>
		/// </summary>
		/// <param name="target">Unidad</param>
		/// <returns></returns>
		private int GetEvasion(Unidad target)// Obtiene la evasion de la unidad
		{
			Stats s = target.GetComponentInParent<Stats>();
			return Mathf.Clamp(s[TipoStats.EVD], 0, 100);
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
					return porcentaje / 2;
				default:
					return porcentaje / 4;
			}
		}
		#endregion
	}
}