//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// ScriptableObjectUtility.cs (28/08/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Tool para crear scriptableObjects facilmente				\\
// Fecha Mod:		28/08/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEditor;
using System.IO;
#endregion

namespace MoonAntonio.Glitch.Tools
{
	/// <summary>
	/// <para>Tool para crear scriptableObjects facilmente</para>
	/// </summary>
	public static class ScriptableObjectUtility
	{
		#region API
		/// <summary>
		/// <para>Crear un asset</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public static void CreateAsset<T>() where T : ScriptableObject
		{
			T asset = ScriptableObject.CreateInstance<T>();

			string path = AssetDatabase.GetAssetPath(Selection.activeObject);
			if (path == "")
			{
				path = "Assets";
			}
			else if (Path.GetExtension(path) != "")
			{
				path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
			}

			string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T).ToString() + ".asset");

			AssetDatabase.CreateAsset(asset, assetPathAndName);

			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
			EditorUtility.FocusProjectWindow();
			Selection.activeObject = asset;
		}
		#endregion
	}
}