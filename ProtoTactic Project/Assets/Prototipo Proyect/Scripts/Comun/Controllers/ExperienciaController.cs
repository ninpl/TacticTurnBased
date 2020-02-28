//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ExperienciaController.cs (25/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controlador del reparto de experiencia						\\
// Fecha Mod:		25/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using Party = System.Collections.Generic.List<UnityEngine.GameObject>;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Controlador del reparto de experiencia</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Controllers/ExperienciaController")]
	public static class ExperienciaController
	{
		#region Constantes
		/// <summary>
		/// <para>Minimo level bonus</para>
		/// </summary>
		private const float minLevelBonus = 1.5f;							// Minimo level bonus
		/// <summary>
		/// <para>Maximo level bonus</para>
		/// </summary>
		private const float maxLevelBonus = 0.5f;                           // Maximo level bonus
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Reparte el premio de la experiencia</para>
		/// </summary>
		/// <param name="cantidad"></param>
		/// <param name="grupo"></param>
		public static void PremioExperiencia(int cantidad, Party grupo)// Reparte el premio de la experiencia
		{
			// Crea una lista de todos los componentes de rango de los aventureros
			List<Nivel> niveles = new List<Nivel>(grupo.Count);
			for (int n = 0; n < grupo.Count; n++)
			{
				Nivel nivel = grupo[n].GetComponent<Nivel>();
				if (nivel != null) niveles.Add(nivel);
			}

			// Determinar el rango menor y mayor
			int min = int.MaxValue;
			int max = int.MinValue;
			for (int n = niveles.Count - 1; n >= 0; n--)
			{
				min = Mathf.Min(niveles[n].LVL, min);
				max = Mathf.Max(niveles[n].LVL, max);
			}

			// Porcentaje de cantidad a conceder por unidad en funcion de su nivel
			float[] cantidades = new float[niveles.Count];
			float cantidadTotal = 0;
			for (int n = niveles.Count - 1; n >= 0; n--)
			{
				float porcentaje = (float)(niveles[n].LVL - min) / (float)(max - min);
				cantidades[n] = Mathf.Lerp(minLevelBonus, maxLevelBonus, porcentaje);
				cantidadTotal += cantidades[n];
			}

			// Distribuir el premio
			for (int n = niveles.Count - 1; n >= 0; n--)
			{
				int subCantidad = Mathf.FloorToInt((cantidades[n] / cantidadTotal) * cantidad);
				niveles[n].EXP += subCantidad;
			}
		}
		#endregion
	}
}