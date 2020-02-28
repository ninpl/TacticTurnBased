//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// LayoutAnchor.cs (05/08/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Gestiona el control del RectTransform						\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio.Glitch.UI
{
	/// <summary>
	/// <para>Gestiona el control del RectTransform.</para>
	/// </summary>
	[RequireComponent(typeof(RectTransform)), AddComponentMenu("Moon Antonio/Glitch/UI/Componentes/LayoutAnchor")]
	public class LayoutAnchor : MonoBehaviour
	{
		#region Variables Privadas
		/// <summary>
		/// <para>Rect actual del gameobject</para>
		/// </summary>
		private RectTransform rectActual;							// Rect actual del gameobject
		/// <summary>
		/// <para>Rect padre del gameobject</para>
		/// </summary>
		private RectTransform rectParent;							// Rect padre del gameobject
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="LayoutAnchor"/></para>
		/// </summary>
		private void Awake()// Inicializador de LayoutAnchor
		{
			// Obtener los datos
			rectActual = transform as RectTransform;
			rectParent = transform.parent as RectTransform;

			// Mostrar error si no hay padre
			if (rectParent == null) Debug.LogError("Este componente requiere de un RectTransform padre para funcionar.", gameObject);
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Ajuste a la posicion del anchor</para>
		/// </summary>
		/// <param name="anchor"></param>
		/// <param name="anchorParent"></param>
		/// <param name="offset"></param>
		public void SnapToAnchorPosicion(TextAnchor anchor, TextAnchor anchorParent, Vector2 offset)// Ajuste a la posicion del anchor
		{
			rectActual.anchoredPosition = GetAnchorPosicion(anchor, anchorParent, offset);
		}

		/// <summary>
		/// <para>Mueve a la posicion del anchor</para>
		/// </summary>
		/// <param name="anchor"></param>
		/// <param name="anchorParent"></param>
		/// <param name="offset"></param>
		/// <returns></returns>
		public Tweener MoverToAnchorPosicion(TextAnchor anchor, TextAnchor anchorParent, Vector2 offset)// Mueve a la posicion del anchor
		{
			return rectActual.AnchorTo(GetAnchorPosicion(anchor, anchorParent, offset));
		}
		#endregion

		#region Funcionalidades
		/// <summary>
		/// <para>Obtener la posicion del rect</para>
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="anchor"></param>
		/// <returns></returns>
		private Vector2 GetPosicion(RectTransform rect, TextAnchor anchor)// Obtener la posicion del rect
		{
			Vector2 retValue = Vector2.zero;

			switch (anchor)
			{
				case TextAnchor.LowerCenter:
				case TextAnchor.MiddleCenter:
				case TextAnchor.UpperCenter:
					retValue.x += rect.rect.width * 0.5f;
					break;
				case TextAnchor.LowerRight:
				case TextAnchor.MiddleRight:
				case TextAnchor.UpperRight:
					retValue.x += rect.rect.width;
					break;
			}

			switch (anchor)
			{
				case TextAnchor.MiddleLeft:
				case TextAnchor.MiddleCenter:
				case TextAnchor.MiddleRight:
					retValue.y += rect.rect.height * 0.5f;
					break;
				case TextAnchor.UpperLeft:
				case TextAnchor.UpperCenter:
				case TextAnchor.UpperRight:
					retValue.y += rect.rect.height;
					break;
			}

			return retValue;
		}

		/// <summary>
		/// <para>Obtener la posicion del anchor</para>
		/// </summary>
		/// <param name="anchor"></param>
		/// <param name="anchorParent"></param>
		/// <param name="offset"></param>
		/// <returns></returns>
		public Vector2 GetAnchorPosicion(TextAnchor anchor, TextAnchor anchorParent, Vector2 offset)// Obtener la posicion del anchor
		{
			Vector2 offSetActual = GetPosicion(rectActual, anchor);
			Vector2 parentOffset = GetPosicion(rectParent, anchorParent);
			Vector2 centroAnchor = new Vector2(Mathf.Lerp(rectActual.anchorMin.x, rectActual.anchorMax.x, rectActual.pivot.x), Mathf.Lerp(rectActual.anchorMin.y, rectActual.anchorMax.y, rectActual.pivot.y));
			Vector2 anchorOffset = new Vector2(rectParent.rect.width * centroAnchor.x, rectParent.rect.height * centroAnchor.y);
			Vector2 pivotetOffset = new Vector2(rectActual.rect.width * rectActual.pivot.x, rectActual.rect.height * rectActual.pivot.y);
			Vector2 pos = parentOffset - anchorOffset - offSetActual + pivotetOffset + offset;
			pos.x = Mathf.RoundToInt(pos.x);
			pos.y = Mathf.RoundToInt(pos.y);
			return pos;
		}
		#endregion
	}
}