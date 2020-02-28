//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CreadorConversacionesEditor.cs (21/07/2017)									\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Herramienta para crear conversaciones						\\
// Fecha Mod:		21/07/2017													\\
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
	/// <para>Herramienta para crear conversaciones.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Tools/CreadorConversacionesEditor")]
	public class CreadorConversacionesEditor
	{
		#region Menus
		[MenuItem("Assets/Create/Glitch/Crear Conversacion")]
		public static void CrearConversacionData()
		{
			ScriptableObjectUtility.CreateAsset<ConversacionData>();
		}

		[MenuItem("Glitch/Crear Conversacion")]
		public static void CrearConversacionDatGa()
		{
			ScriptableObjectUtility.CreateAsset<ConversacionData>();
		}
		#endregion
	}
}