//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CreadorCatalogoHabilidadesEditor.cs (31/07/2017)								\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Herramienta para crear catalogos de habilidades				\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEditor;
using MoonAntonio.Glitch.Data;
#endregion

namespace MoonAntonio.Glitch.Tools
{
	/// <summary>
	/// <para>Herramienta para crear catalogos de habilidades</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Tools/CreadorCatalogoHabilidadesEditor")]
	public class CreadorCatalogoHabilidadesEditor
	{
		#region Menus
		[MenuItem("Assets/Create/Glitch/Crear Catalogo Habilidades")]
		public static void CrearCatalogoHabilidades()
		{
			ScriptableObjectUtility.CreateAsset<CatalogoHabilidadData>();
		}

		[MenuItem("Glitch/Crear Catalogo Habilidades")]
		public static void CrearCatalogoHabilidadesDat()
		{
			ScriptableObjectUtility.CreateAsset<CatalogoHabilidadData>();
		}
		#endregion
	}
}