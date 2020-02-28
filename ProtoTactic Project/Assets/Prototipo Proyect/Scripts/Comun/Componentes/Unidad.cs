//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Unidad.cs (14/07/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Control de la unidad										\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Control de la unidad.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Componentes/Unidad")]
	public class Unidad : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Direccion de la unidad.</para>
		/// </summary>
		public Direcciones dir;                                         // Direccion de la unidad
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Area de la unidad.</para>
		/// </summary>
		public Area Area
		{
			get; set;
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Posiciona la unidad en un area.</para>
		/// </summary>
		/// <param name="target">Area donde posicionar la unidad.</param>
		public void Posicionar(Area target)// Posiciona la unidad en un area
		{
			// Comprobar que el area esta vacia, sino null
			if (Area != null && Area.contenido == gameObject) Area.contenido = null;

			// Agregar a la area la nueva area
			Area = target;

			// Comprobar que el objetivo no es null y asignarle este al contenido del area
			if (target != null) target.contenido = gameObject;
		}

		/// <summary>
		/// <para>Actualiza la posicion y rotacion de la unidad.</para>
		/// </summary>
		public void Actualizar()// Actualiza la posicion y rotacion de la unidad
		{
			transform.localPosition = Area.Centro;
			transform.localEulerAngles = dir.DireccionAVector3();
		}
		#endregion
	}
}