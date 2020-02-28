
//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// Habilidad.cs (31/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base de las habilidades								\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase base de las habilidades</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/Habilidad")]
	public class Habilidad : MonoBehaviour
	{
		#region Notificaciones
		public const string ComprobacionPuedeRealizar = "Habilidad.ComprobacionPuedeRealizar";
		public const string FalladoNotificacion = "Habilidad.FalladoNotificacion";
		public const string RealizoNotificacion = "Habilidad.RealizoNotificacion";
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Realiza la habilidad</para>
		/// </summary>
		/// <param name="objetivos"></param>
		public void Realizar(List<Area> objetivos)// Realiza la habilidad
		{
			if (!PuedeRealizar())
			{
				this.EnviarNotificacion(FalladoNotificacion);
				return;
			}

			for (int n = 0; n < objetivos.Count; n++)
			{
				Realizar(objetivos[n]);
			}	

			this.EnviarNotificacion(RealizoNotificacion);
		}
		#endregion

		#region Metodos privados
		/// <summary>
		/// <para>Realiza la habilidad</para>
		/// </summary>
		/// <param name="target"></param>
		private void Realizar(Area objetivo)// Realiza la habilidad
		{
			for (int n = 0; n < transform.childCount; n++)
			{
				Transform hijo = transform.GetChild(n);
				BaseEfectoHabilidad efecto = hijo.GetComponent<BaseEfectoHabilidad>();
				efecto.Aplicar(objetivo);
			}
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Puede realizar la habilidad</para>
		/// </summary>
		/// <returns></returns>
		public bool PuedeRealizar()// Puede realizar la habilidad
		{
			BaseExcepcion exc = new BaseExcepcion(true);
			this.EnviarNotificacion(ComprobacionPuedeRealizar, exc);
			return exc.Toggle;
		}

		/// <summary>
		/// <para>Es objetivo</para>
		/// </summary>
		/// <param name="area"></param>
		/// <returns></returns>
		public bool IsTarget(Area area)// Es objetivo
		{
			Transform obj = transform;
			for (int n = 0; n < obj.childCount; n++)
			{
				EfectoHabilidadObjetivo objetivo = obj.GetChild(n).GetComponent<EfectoHabilidadObjetivo>();
				if (objetivo.IsTarget(area)) return true;
			}
			return false;
		}
		#endregion
	}
}