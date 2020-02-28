//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// LvlCreatorInspector.cs (07/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Inspector de LvlCreator										\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEditor;
#endregion

namespace MoonAntonio.Glitch.PreProduccion
{
	/// <summary>
	/// <para>Inspector de LvlCreator</para>
	/// </summary>
	[CustomEditor(typeof(LvlCreator))]
	public class LvlCreatorInspector : Editor
	{
		#region Propiedades
		/// <summary>
		/// <para>LvlCreator actual.</para>
		/// </summary>
		public LvlCreator Actual
		{
			get { return (LvlCreator)target; }
		}
		#endregion

		#region GUI
		/// <summary>
		/// <para>Interfaz</para>
		/// </summary>
		public override void OnInspectorGUI()// Interfaz
		{
			DrawDefaultInspector();

			if (GUILayout.Button("Clear")) Actual.Clear();

			if (GUILayout.Button("Elevar")) Actual.Elevar();

			if (GUILayout.Button("Reducir")) Actual.Reducir();

			if (GUILayout.Button("Elevar Areas")) Actual.ElevarAreas();

			if (GUILayout.Button("Reducir Areas")) Actual.ReducirAreas();

			if (GUILayout.Button("Guardar")) Actual.Guardar();

			if (GUILayout.Button("Cargar")) Actual.Cargar();

			// TODO Crear una cruceta

			if (GUI.changed) Actual.ActualizarPuntero();
		}
		#endregion
	}
}