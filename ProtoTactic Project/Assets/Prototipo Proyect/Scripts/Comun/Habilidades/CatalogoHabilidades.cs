//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CatalogoHabilidades.cs (31/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Catalogo de habilidades										\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Catalogo de habilidades</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/CatalogoHabilidades")]
	public class CatalogoHabilidades : MonoBehaviour
	{
		// NOTA todos los hijos directos son categorias y los hijos directos de las categorias son habilidades

		#region Funcionalidad
		/// <summary>
		/// <para>Obtiene la cuenta de las categorias</para>
		/// </summary>
		/// <returns></returns>
		public int CategoriaCount()// Obtiene la cuenta de las categorias
		{
			return transform.childCount;
		}

		/// <summary>
		/// <para>Obtiene una categoria</para>
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public GameObject GetCategoria(int index)// Obtiene una categoria
		{
			if (index < 0 || index >= transform.childCount) return null;
			return transform.GetChild(index).gameObject;
		}

		/// <summary>
		/// <para>Obtiene la cuenta de las habilidades</para>
		/// </summary>
		/// <param name="categoria"></param>
		/// <returns></returns>
		public int HabilidadesCount(GameObject categoria)// Obtiene la cuenta de las habilidades
		{
			return categoria != null ? categoria.transform.childCount : 0;
		}

		/// <summary>
		/// <para>Obtiene una habilidad</para>
		/// </summary>
		/// <param name="indexCategoria"></param>
		/// <param name="indexHabilidad"></param>
		/// <returns></returns>
		public Habilidad GetHabilidad(int indexCategoria, int indexHabilidad)// Obtiene una habilidad
		{
			GameObject category = GetCategoria(indexCategoria);
			if (category == null || indexHabilidad < 0 || indexHabilidad >= category.transform.childCount) return null;
			return category.transform.GetChild(indexHabilidad).GetComponent<Habilidad>();
		}
		#endregion
	}
}