//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// BaseSelectorHabilidades.cs (16/08/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Base del selector de habilidades							\\
// Fecha Mod:		16/08/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.AI;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Base del selector de habilidades</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/BaseSelectorHabilidades")]
	public abstract class BaseSelectorHabilidades : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Unidad</para>
		/// </summary>
		public Unidad unidad;								// Unidad
		/// <summary>
		/// <para>Catalogo de habilidades</para>
		/// </summary>
		public CatalogoHabilidades catalogoHabilidades;		// Catalogo de habilidades
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="BaseSelectorHabilidades"/></para>
		/// </summary>
		private void Start()// Inicializador de BaseSelectorHabilidades
		{
			unidad = GetComponentInParent<Unidad>();
			catalogoHabilidades = unidad.GetComponentInChildren<CatalogoHabilidades>();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Eleccion</para>
		/// </summary>
		/// <param name="plan"></param>
		public abstract void Eleccion(PlanDeAtaque plan);
		#endregion

		#region Funcionalidades
		/// <summary>
		/// <para>Busca una habilidad</para>
		/// </summary>
		/// <param name="nombreHabilidad"></param>
		/// <returns></returns>
		public Habilidad Buscar(string nombreHabilidad)// Busca una habilidad
		{
			for (int n = 0; n < catalogoHabilidades.transform.childCount; n++)
			{
				Transform categoria = catalogoHabilidades.transform.GetChild(n);
				Transform hijo = categoria.Find(nombreHabilidad);
				if (hijo != null) return hijo.GetComponent<Habilidad>();
			}
			return null;
		}

		/// <summary>
		/// <para>Por defecto</para>
		/// </summary>
		/// <returns></returns>
		public Habilidad Default()// Por defecto
		{
			return unidad.GetComponentInChildren<Habilidad>();
		}
		#endregion
	}
}