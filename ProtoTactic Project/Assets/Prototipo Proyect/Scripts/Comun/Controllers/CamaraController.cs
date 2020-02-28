//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CamaraController.cs (11/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Control de la camara										\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Control de la camara.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Controllers/CamaraController")]
	public class CamaraController : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Velocidad de movimiento de la camara.</para>
		/// </summary>
		public float velocidad = 3f;                                // Velocidad de movimiento de la camara
		/// <summary>
		/// <para>Objetivo de la camara.</para>
		/// </summary>
		public Transform target;                                    // Objetivo de la camara
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Transform de la camara.</para>
		/// </summary>
		private Transform camara;                                   // Transform de la camara
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="CamaraController"/>.</para>
		/// </summary>
		private void Awake()// Inicializador de CamaraController
		{
			// Asignar camara
			camara = transform;
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="CamaraController"/>.</para>
		/// </summary>
		private void Update()// Actualizador de CamaraController
		{
			if (target) camara.position = Vector3.Lerp(camara.position, target.position, velocidad * Time.deltaTime);
		}
		#endregion
	}
}