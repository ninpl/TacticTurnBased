//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// TipoTasaExitoFull.cs (28/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase determinante para la tasa de exito Full				\\
// Fecha Mod:		28/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase determinante para la tasa de exito Full</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/TipoTasaExitoFull")]
	public class TipoTasaExitoFull : TasaExito
	{
		#region Propiedades
		public override bool IsAngulo
		{
			get { return false; }
		}
		#endregion

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

			if (AutomaticEvasion(defensor)) return Final(100);

			return Final(0);
		}
		#endregion
	}
}