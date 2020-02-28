//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Caracteristica.cs (22/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base de la caracteristica								\\
// Fecha Mod:		22/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase base de la caracteristica.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/Caracteristica")]
	public abstract class Caracteristica : MonoBehaviour
	{
		#region Propiedades
		/// <summary>
		/// <para>Objetivo de la caracteristica</para>
		/// </summary>
		public GameObject Objetivo
		{
			get;
			private set;
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Activar la caracteristica</para>
		/// </summary>
		/// <param name="target">Objetivo</param>
		public void Activar(GameObject target)// Activar la caracteristica
		{
			if (Objetivo == null)
			{
				Objetivo = target;
				OnAplicar();
			}
		}

		/// <summary>
		/// <para>Desactivar la caracteristica</para>
		/// </summary>
		public void Desactivar()// Desactivar la caracteristica
		{
			if (Objetivo != null)
			{
				OnQuitar();
				Objetivo = null;
			}
		}

		/// <summary>
		/// <para>Aplica una caracteristica</para>
		/// </summary>
		/// <param name="target">Objetivo</param>
		public void Aplicar(GameObject target)// Aplica una caracteristica
		{
			Objetivo = target;
			OnAplicar();
			Objetivo = null;
		}
		#endregion

		#region Privadas
		public abstract void OnAplicar();
		public virtual void OnQuitar() { }
		#endregion
	}
}