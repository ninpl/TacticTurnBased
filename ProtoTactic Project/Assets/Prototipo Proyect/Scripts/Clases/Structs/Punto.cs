//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Punto.cs (07/07/2017)														\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estructura para obtener X/Y referenciando X/Z.				\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Estructura para obtener X/Y referenciando X/Z</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/Punto")]
	[System.Serializable]
	public struct Punto : IEquatable<Punto>
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Coordenada X del punto.</para>
		/// </summary>
		public int x;									// Coordenada X del punto
		/// <summary>
		/// <para>Coordenada Y del punto, referenciando a Z.</para>
		/// </summary>
		public int y;                                   // Coordenada Y del punto, referenciando a Z
		#endregion

		#region Constructor
		/// <summary>
		/// <para>Constructor de <see cref="Punto"/>.</para>
		/// </summary>
		/// <param name="x">Posicion X</param>
		/// <param name="y">Posicion Y(Z)</param>
		public Punto(int x, int y)// Constructor de Punto
		{
			this.x = x;
			this.y = y;
		}
		#endregion

		#region Operadores
		/// <summary>
		/// <para>Operador Suma.</para>
		/// </summary>
		/// <param name="a">Punto a</param>
		/// <param name="b">Punto b</param>
		/// <returns>Un nuevo punto con la suma de las dos x y las dos y por separado.</returns>
		public static Punto operator +(Punto a, Punto b)// Operador Suma
		{
			return new Punto(a.x + b.x, a.y + b.y);
		}

		/// <summary>
		/// <para>Operador Resta</para>
		/// </summary>
		/// <param name="a">Punto a</param>
		/// <param name="b">Punto b</param>
		/// <returns>Un nuevo punto con la resta de las dos x y las dos y por separado.</returns>
		public static Punto operator -(Punto a, Punto b)// Operador Resta
		{
			return new Punto(a.x - b.x, a.y - b.y);
		}

		/// <summary>
		/// <para>Operador igualacion</para>
		/// </summary>
		/// <param name="a">Punto a</param>
		/// <param name="b">Punto b</param>
		/// <returns>Si la igualacion es correcta.</returns>
		public static bool operator ==(Punto a, Punto b)// Operador igualacion
		{
			return a.x == b.x && a.y == b.y;
		}

		/// <summary>
		/// <para>Operador igualacion</para>
		/// </summary>
		/// <param name="a">Punto a</param>
		/// <param name="b">Punto b</param>
		/// <returns>Si la igualacion no es correcta.</returns>
		public static bool operator !=(Punto a, Punto b)// Operador igualacion
		{
			return !(a == b);
		}

		/// <summary>
		/// <para>Operador vector 2</para>
		/// </summary>
		/// <param name="p">Punto</param>
		public static implicit operator Vector2(Punto p)// Operador vector 2
		{
			return new Vector2(p.x, p.y);
		}
		#endregion

		#region Sobrecarga
		/// <summary>
		/// <para>Determina si el objeto especificado es igual al objeto actual.</para>
		/// </summary>
		/// <param name="obj">Objeto a igualar</param>
		/// <returns></returns>
		public override bool Equals(object obj)// Determina si el objeto especificado es igual al objeto actual.
		{
			if (obj is Punto)
			{
				Punto p = (Punto)obj;
				return x == p.x && y == p.y;
			}
			return false;
		}

		/// <summary>
		/// <para>Determina si el punto especificado es igual al punto actual.</para>
		/// </summary>
		/// <param name="p">Punto dado.</param>
		/// <returns></returns>
		public bool Equals(Punto p)// Determina si el punto especificado es igual al punto actual
		{
			return x == p.x && y == p.y;
		}

		/// <summary>
		/// <para>Obtener el identificador del objeto.</para>
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()// Obtener el identificador del objeto
		{
			return x ^ y;
		}

		/// <summary>
		/// <para>Sobrecarga el metodo <see cref="ToString"/></para>
		/// </summary>
		/// <returns></returns>
		public override string ToString()// Sobrecarga el metodo ToString
		{
			return string.Format("({0},{1})", x, y);
		}
		#endregion
	}
}
