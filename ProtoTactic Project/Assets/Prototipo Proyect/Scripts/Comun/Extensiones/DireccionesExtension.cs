//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// DireccionesExtension.cs (14/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Extension de la direccion									\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Comun;
#endregion

namespace MoonAntonio.Glitch.Extensiones
{
	/// <summary>
	/// <para>Extension de la direccion.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Extensiones/DireccionesExtension")]
	public static class DireccionesExtension
	{
		#region API
		/// <summary>
		/// <para>Obtiene la direccion de un area a otra.</para>
		/// </summary>
		/// <param name="areaInicial">Area de Inicio.</param>
		/// <param name="areaDestino">Area de Destino</param>
		/// <returns></returns>
		public static Direcciones GetDireccion(this Area areaInicial, Area areaDestino)// Obtiene la direccion de un area a otra
		{
			if (areaInicial.pos.y < areaDestino.pos.y) return Direcciones.Norte;
			if (areaInicial.pos.x < areaDestino.pos.x) return Direcciones.Este;
			if (areaInicial.pos.y > areaDestino.pos.y) return Direcciones.Sur;
			return Direcciones.Oeste;
		}

		/// <summary>
		/// <para>Obtiene la direccion de un punto</para>
		/// </summary>
		/// <param name="p">Punto</param>
		/// <returns></returns>
		public static Direcciones GetDireccion(this Punto p)// Obtiene la direccion de un punto
		{
			if (p.y > 0) return Direcciones.Norte;
			if (p.x > 0) return Direcciones.Este;
			if (p.y < 0) return Direcciones.Sur;
			return Direcciones.Oeste;
		}

		/// <summary>
		/// <para>Obtener normal</para>
		/// </summary>
		/// <param name="dir">Direccion</param>
		/// <returns></returns>
		public static Punto GetNormal(this Direcciones dir)// Obtener normal
		{
			switch (dir)
			{
				case Direcciones.Norte:
					return new Punto(0, 1);
				case Direcciones.Este:
					return new Punto(1, 0);
				case Direcciones.Sur:
					return new Punto(0, -1);
				default: // Direcciones.Oeste
					return new Punto(-1, 0);
			}
		}

		/// <summary>
		/// <para>Convierte una direccion en un vector3.</para>
		/// </summary>
		/// <param name="d">Direccion</param>
		/// <returns></returns>
		public static Vector3 DireccionAVector3(this Direcciones d)// Convierte una direccion en un vector3
		{
			return new Vector3(0, (int)d * 90, 0);
		}
		#endregion
	}
}