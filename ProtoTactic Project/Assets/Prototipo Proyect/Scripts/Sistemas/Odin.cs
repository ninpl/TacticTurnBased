//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Odin.cs (11/07/2017)															\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Maquina de estados que tiene el core de los estados			\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Sistemas
{
	/// <summary>
	/// <para>Maquina de estados que tiene el core de los estados.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Sistemas/Odin")]
	public class Odin : MonoBehaviour
	{
		#region Variables Privadas
		/// <summary>
		/// <para>El estado actual de la maquina de estados.</para>
		/// </summary>
		private Estado estadoActual;                    // El estado actual de la maquina de estados
		/// <summary>
		/// <para>Esta en transicion la maquina de estados.</para>
		/// </summary>
		private bool isInTransicion;                    // Esta en transicion la maquina de estados
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Estado actual de la <see cref="MaquinaEstados"/>.</para>
		/// </summary>
		public virtual Estado EstadoActual
		{
			get { return estadoActual; }
			set { Transicion(value); }
		}
		#endregion

		#region API
		/// <summary>
		/// <para>Obtiene el estado de la <see cref="MaquinaEstados"/>.</para>
		/// </summary>
		/// <typeparam name="T">Estado</typeparam>
		/// <returns>Estado actual</returns>
		public virtual T GetEstado<T>() where T : Estado// Obtiene el estado de la MaquinaEstados
		{
			// Obtener el estado
			T target = GetComponent<T>();

			// Si no hay estado, devolver el componente estado
			if (target == null) target = gameObject.AddComponent<T>();

			return target;
		}

		/// <summary>
		/// <para>Cambia el estado ano nuevo.</para>
		/// </summary>
		/// <typeparam name="T">Nuevo Estado</typeparam>
		public virtual void CambiarEstado<T>() where T : Estado// Cambia el estado ano nuevo
		{
			EstadoActual = GetEstado<T>();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Crea una transicion para cambiar el estado.</para>
		/// </summary>
		/// <param name="newEstado">Nuevo estado.</param>
		public virtual void Transicion(Estado newEstado)// Crea una transicion para cambiar el estado
		{
			// Si el estado dado, es igual al actual o se esta en transicion, paramos la transicion.
			if (estadoActual == newEstado || isInTransicion) return;

			// Activamos la auxiliar de la transicion en progreso
			isInTransicion = true;

			// Salimos del estado actual
			if (estadoActual != null) estadoActual.Exit();

			// Cambiamos el estado actual
			estadoActual = newEstado;

			// Entramos al estado actual
			if (estadoActual != null) estadoActual.Enter();

			// Desactivamos la auxiliar de la transicion en progreso
			isInTransicion = false;
		}
		#endregion
	}
}