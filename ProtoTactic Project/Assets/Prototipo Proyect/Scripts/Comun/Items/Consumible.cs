//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Consumible.cs (22/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Consumible													\\
// Fecha Mod:		22/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Consumible.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Items/Consumible")]
	public class Consumible : MonoBehaviour
	{
		#region Metodos
		/// <summary>
		/// <para>Consumir un consumible</para>
		/// </summary>
		/// <param name="target">Objetivo</param>
		public void Consumir(GameObject target)// Consumir un consumible
		{
			Caracteristica[] caracteristicas = GetComponentsInChildren<Caracteristica>();
			for (int n = 0; n < caracteristicas.Length; n++)
			{
				caracteristicas[n].Aplicar(target);
			}
		}
		#endregion
	}
}