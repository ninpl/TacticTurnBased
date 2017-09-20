//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Estado.cs (11/07/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase general del estado de la batalla						\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase general del estado de la batalla.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/Estado")]
	public abstract class Estado : MonoBehaviour
	{
		#region Metodos
		/// <summary>
		/// <para>Entrar en el <see cref="Estado"/>.</para>
		/// </summary>
		public virtual void Enter()// Entrar en el Estado
		{
			AddListeners();
		}

		/// <summary>
		/// <para>Salir del <see cref="Estado"/>.</para>
		/// </summary>
		public virtual void Exit()// Salir del Estado
		{
			RemoveListeners();
		}

		/// <summary>
		/// <para>Cuando el estado es destruido.</para>
		/// </summary>
		public virtual void OnDestroy()// Cuando el estado es destruido
		{
			RemoveListeners();
		}

		/// <summary>
		/// <para>Agregar oyentes.</para>
		/// </summary>
		public virtual void AddListeners()// Agregar oyentes
		{

		}

		/// <summary>
		/// <para>Quitar oyentes.</para>
		/// </summary>
		public virtual void RemoveListeners()// Quitar oyentes
		{

		}
		#endregion
	}
}