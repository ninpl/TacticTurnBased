//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CreadorUnidadesEditor.cs (31/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Herramienta para crear unidades								\\
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
	/// <para>Herramienta para crear unidades</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Tools/CreadorUnidadesEditor")]
	public class CreadorUnidadesEditor
	{
		#region Menus
		[MenuItem("Assets/Create/Glitch/Crear Unidad")]
		public static void CrearUnidades()
		{
			ScriptableObjectUtility.CreateAsset<UnidadData>();
		}

		[MenuItem("Glitch/Crear Unidad")]
		public static void CrearUnidadesDat()
		{
			ScriptableObjectUtility.CreateAsset<UnidadData>();
		}
		#endregion
	}
}