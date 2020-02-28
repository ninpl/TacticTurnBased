//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// AddCaracteristicaEstado.cs (26/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase para agregar un estado de una caracteristica			\\
// Fecha Mod:		26/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Comun;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase para agregar un estado de una caracteristica</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/AddCaracteristicaEstado")]
	public abstract class AddCaracteristicaEstado<T> : Caracteristica where T : EfectoEstadoUnidad
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Condicion </para>
		/// </summary>
		private CondicionEstadoUnidad condicionEstado;                    // Condicion
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando se aplica</para>
		/// </summary>
		public override void OnAplicar()// Cuando se aplica
		{
			EstadoUnidad estado = GetComponentInParent<EstadoUnidad>();
			condicionEstado = estado.Add<T, CondicionEstadoUnidad>();
		}

		/// <summary>
		/// <para>Cuando se quita</para>
		/// </summary>
		public override void OnQuitar()// Cuando se quita
		{
			if (condicionEstado != null) condicionEstado.Remove();
		}
		#endregion
	}
}