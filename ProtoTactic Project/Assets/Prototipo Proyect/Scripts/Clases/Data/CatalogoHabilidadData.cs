//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CatalogoHabilidadData.cs (31/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Data del catalogo de habilidades							\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.Data
{
	/// <summary>
	/// <para>Data del catalogo de habilidades</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Data/CatalogoHabilidadData")]
	public class CatalogoHabilidadData : ScriptableObject
	{
		#region Clase
		[System.Serializable]
		public class Categoria
		{
			public string nombre;
			public string[] lista;
		}
		#endregion

		#region Variables
		public Categoria[] categorias;
		#endregion
	}
}