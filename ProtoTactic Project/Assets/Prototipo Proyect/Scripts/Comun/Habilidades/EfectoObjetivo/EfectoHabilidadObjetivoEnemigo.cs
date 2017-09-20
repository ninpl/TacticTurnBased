//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EfectoHabilidadObjetivoEnemigo.cs (25/07/2017)								\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base del area de efecto del objetivo	Enemigo			\\
// Fecha Mod:		25/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase base del area de efecto del objetivo Enemigo</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/EfectoHabilidadObjetivoEnemigo")]
	public class EfectoHabilidadObjetivoEnemigo : EfectoHabilidadObjetivo
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Bando</para>
		/// </summary>
		private Bando bando;                                // Bando
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="EfectoHabilidadObjetivoEnemigo"/></para>
		/// </summary>
		private void Start()// Inicializador de EfectoHabilidadObjetivoEnemigo
		{
			bando = GetComponentInParent<Bando>();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Determina si tiene objetivo</para>
		/// </summary>
		/// <param name="area">Area</param>
		/// <returns></returns>
		public override bool IsTarget(Area area)// Determina si tiene objetivo
		{
			if (area == null || area.contenido == null)
				return false;

			Bando bandoAre = area.contenido.GetComponentInChildren<Bando>();
			return bando.IsCalculo(bandoAre, Objetivos.Enemigo);
		}
		#endregion
	}
}