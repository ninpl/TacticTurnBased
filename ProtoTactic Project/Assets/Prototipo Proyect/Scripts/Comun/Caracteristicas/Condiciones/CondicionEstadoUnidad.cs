//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CondicionEstadoUnidad.cs (26/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base de la condicion del estado						\\
// Fecha Mod:		26/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Clase base de la condicion del estado</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/CondicionEstadoUnidad")]
	public class CondicionEstadoUnidad : MonoBehaviour
	{
		#region Metodos
		/// <summary>
		/// <para>Quita una condicion</para>
		/// </summary>
		public virtual void Remove()// Quita una condicion
		{
			EstadoUnidad estado = GetComponentInParent<EstadoUnidad>();
			if (estado)
			{
				estado.Remove(this);
			}
		}
		#endregion
	}
}