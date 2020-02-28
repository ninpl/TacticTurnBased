//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// FranqueoExtension.cs (19/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Extension de la clase Franqueo								\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Comun;
#endregion

namespace MoonAntonio.Glitch.Extensiones
{
	/// <summary>
	/// <para>Extension de la clase Franqueo.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Extensiones/FranqueoExtension")]
	public static class FranqueoExtension
	{
		#region API
		/// <summary>
		/// <para>Obtiene el franqueo de un atacante a un objetivo</para>
		/// </summary>
		/// <param name="atacante">Atacante</param>
		/// <param name="objetivo">Objetivo</param>
		/// <returns></returns>
		public static Franqueo GetFranqueo(this Unidad atacante, Unidad objetivo)// Obtiene el franqueo de un atacante a un objetivo
		{
			// Obtener datos
			Vector2 dirTarget = objetivo.dir.GetNormal();
			Vector2 dirAprox = ((Vector2)(objetivo.Area.pos - atacante.Area.pos)).normalized;
			float punt = Vector2.Dot(dirAprox, dirTarget);

			// Obtener franqueo
			if (punt >= 0.45f) return Franqueo.Detras;
			if (punt <= -0.45f) return Franqueo.Delante;

			return Franqueo.Lados;
		}
		#endregion
	}
}