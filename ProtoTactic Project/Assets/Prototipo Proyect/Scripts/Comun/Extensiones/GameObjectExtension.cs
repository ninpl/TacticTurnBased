//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// GameObjectExtension.cs (19/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Extension de la clase gameobject							\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.Extensiones
{
	/// <summary>
	/// <para>Extension de la clase gameobject.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Extensiones/GameObjectExtension")]
	public static class GameObjectExtension
	{
		#region API
		/// <summary>
		/// <para>Agrega un componente al hijo</para>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static T AddChildComponent<T>(this GameObject obj) where T : MonoBehaviour
		{
			GameObject hijo = new GameObject(typeof(T).Name);
			hijo.transform.SetParent(obj.transform);
			return hijo.AddComponent<T>();
		}
		#endregion
	}
}
