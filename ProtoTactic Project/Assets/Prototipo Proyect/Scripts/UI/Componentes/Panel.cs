//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Panel.cs (05/08/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Gestiona el control del panel								\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System;
using System.Collections.Generic;
#endregion

namespace MoonAntonio.Glitch.UI
{
	/// <summary>
	/// <para>Gestiona el control del panel.</para>
	/// </summary>
	[RequireComponent(typeof(LayoutAnchor)), AddComponentMenu("Moon Antonio/Glitch/UI/Componentes/Panel")]
	public class Panel : MonoBehaviour
	{
		#region Clase Base
		[Serializable]
		public class Posicion
		{
			#region Variables Publicas
			/// <summary>
			/// <para>Nombre de la posicion</para>
			/// </summary>
			public string nombre;					// Nombre de la posicion
			/// <summary>
			/// <para>Anchor de la posicion</para>
			/// </summary>
			public TextAnchor anchor;				// Anchor de la posicion
			/// <summary>
			/// <para>Anchor del padre</para>
			/// </summary>
			public TextAnchor anchorParent;			// Anchor del padre
			/// <summary>
			/// <para>Offset de la posicion</para>
			/// </summary>
			public Vector2 offset;					// Offset de la posicion
			#endregion

			#region Constructores
			/// <summary>
			/// <para>Constructor de <see cref="Posicion"/></para>
			/// </summary>
			/// <param name="nom"></param>
			public Posicion(string nom)// Constructor de Posicion
			{
				this.nombre = nom;
			}

			/// <summary>
			/// <para>Constructor de <see cref="Posicion"/></para>
			/// </summary>
			/// <param name="nom"></param>
			/// <param name="anch"></param>
			/// <param name="anchParent"></param>
			public Posicion(string nom, TextAnchor anch, TextAnchor anchParent) : this(nom)// Constructor de Posicion
			{
				this.anchor = anch;
				this.anchorParent = anchParent;
			}

			/// <summary>
			/// <para>Constructor de <see cref="Posicion"/></para>
			/// </summary>
			/// <param name="nom"></param>
			/// <param name="anch"></param>
			/// <param name="anchParent"></param>
			/// <param name="offset"></param>
			public Posicion(string nom, TextAnchor anch, TextAnchor anchParent, Vector2 offset) : this(nom, anch, anchParent)// Constructor de Posicion
			{
				this.offset = offset;
			}
			#endregion
		}
		#endregion

		#region Variables Publicas
		/// <summary>
		/// <para>Lista de las posiciones</para>
		/// </summary>
		[SerializeField]public List<Posicion> listaPosiciones;							// Lista de las posiciones
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Mapa de posiciones</para>
		/// </summary>
		private Dictionary<string, Posicion> posicionMap;								// Mapa de posiciones
		/// <summary>
		/// <para>Anchor del layout</para>
		/// </summary>
		private LayoutAnchor anchor;													// Anchor del layout
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Posicion</para>
		/// </summary>
		/// <param name="nombre"></param>
		/// <returns></returns>
		public Posicion this[string nombre]
		{
			get
			{
				if (posicionMap.ContainsKey(nombre)) return posicionMap[nombre];

				return null;
			}
		}

		/// <summary>
		/// <para>Posicion actual</para>
		/// </summary>
		public Posicion PosicionActual
		{
			get;
			private set;
		}

		/// <summary>
		/// <para>Transicion</para>
		/// </summary>
		public Tweener Transicion
		{
			get;
			private set;
		}

		/// <summary>
		/// <para>En transicion</para>
		/// </summary>
		public bool InTransicion
		{
			get { return Transicion != null; }
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Cargador de <see cref="Panel"/></para>
		/// </summary>
		private void Awake()// Cargador de Panel
		{
			// Obtener los datos
			anchor = GetComponent<LayoutAnchor>();
			posicionMap = new Dictionary<string, Posicion>(listaPosiciones.Count);

			// Agregar las posiciones
			for (int n = listaPosiciones.Count - 1; n >= 0; n--)
			{
				AddPosicion(listaPosiciones[n]);
			}	
		}

		/// <summary>
		/// <para>Inicializador de <see cref="Panel"/></para>
		/// </summary>
		private void Start()// Inicializador de Panel
		{
			// Aplicar posicion por defecto
			if (PosicionActual == null && listaPosiciones.Count > 0) SetPosicion(listaPosiciones[0], false);
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Agrega la posicion dada a la lista del mapa</para>
		/// </summary>
		/// <param name="pos"></param>
		public void AddPosicion(Posicion pos)// Agrega la posicion dada a la lista del mapa
		{
			posicionMap[pos.nombre] = pos;
		}

		/// <summary>
		/// <para>Quita la posicion dada de la lista del mapa</para>
		/// </summary>
		/// <param name="pos"></param>
		public void RemovePosicion(Posicion pos)// Quita la posicion dada de la lista del mapa
		{
			if (posicionMap.ContainsKey(pos.nombre)) posicionMap.Remove(pos.nombre);
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Fija la posicion dada</para>
		/// </summary>
		/// <param name="nomPosicion"></param>
		/// <param name="animacion"></param>
		/// <returns></returns>
		public Tweener SetPosicion(string nomPosicion, bool animacion)// Fija la posicion dada
		{
			return SetPosicion(this[nomPosicion], animacion);
		}

		/// <summary>
		/// <para>Fija la posicion dada</para>
		/// </summary>
		/// <param name="pos"></param>
		/// <param name="animacion"></param>
		/// <returns></returns>
		public Tweener SetPosicion(Posicion pos, bool animacion)// Fija la posicion dada
		{
			PosicionActual = pos;

			// Comprobar la posicion actual
			if (PosicionActual == null) return null;

			// Detener la transicion
			if (InTransicion) Transicion.Stop();

			// Comprobar si hay animacion
			if (animacion)
			{
				// Mover a la posicion
				Transicion = anchor.MoverToAnchorPosicion(pos.anchor, pos.anchorParent, pos.offset);
				return Transicion;
			}
			else
			{
				// Ajustar al anchor
				anchor.SnapToAnchorPosicion(pos.anchor, pos.anchorParent, pos.offset);
				return null;
			}
		}
		#endregion
	}
}