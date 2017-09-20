//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// TasaExito.cs (28/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base de la tasa de exito								\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase base de la tasa de exito</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/TasaExito")]
	public abstract class TasaExito : MonoBehaviour
	{
		#region Notificaciones
		public const string AutomaticExitoCheckNotificacion = "TasaExito.AutomaticExitoCheckNotificacion";
		public const string AutomaticEvasionCheckNotificacion = "TasaExito.AutomaticEvasionCheckNotificacion";
		public const string StatusCheckNotificacion = "TasaExito.StatusCheckNotificacion";
		#endregion

		#region Variables Publicas
		/// <summary>
		/// <para>Atacante</para>
		/// </summary>
		public Unidad atacante;                                                 // Atacante
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Angulo</para>
		/// </summary>
		public virtual bool IsAngulo
		{
			get { return true; }
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="TasaExito"/></para>
		/// </summary>
		public virtual void Start()// Inicializador de TasaExito
		{
			atacante = GetComponentInParent<Unidad>();
		}
		#endregion

		#region Metodos Abstractos
		/// <summary>
		/// <para>Devuelve un valor en el rango de 0 a 100 como un porcentaje de probabilidad de que una habilidad tenga exito</para>
		/// </summary>
		public abstract int Calcular(Area target);
		#endregion

		#region Funcionalidades
		/// <summary>
		/// <para>Calcular antes de golpear</para>
		/// </summary>
		/// <param name="target">Area</param>
		/// <returns></returns>
		public virtual bool CalcularParaGolpear(Area target)// Calcular antes de golpear
		{
			int roll = Random.Range(0, 101);
			int chance = Calcular(target);
			return roll <= chance;
		}

		/// <summary>
		/// <para>Siempre hace exito</para>
		/// </summary>
		/// <param name="atacante"></param>
		/// <param name="objetivo"></param>
		/// <returns></returns>
		public virtual bool AutomaticExito(Unidad objetivo)// Siempre hace exito
		{
			MatchExcepcion exc = new MatchExcepcion(atacante, objetivo);
			this.EnviarNotificacion(AutomaticExitoCheckNotificacion, exc);
			return exc.Toggle;
		}

		/// <summary>
		/// <para>Siempre hace evasion</para>
		/// </summary>
		/// <param name="atacante"></param>
		/// <param name="objetivo"></param>
		/// <returns></returns>
		public virtual bool AutomaticEvasion(Unidad objetivo)// Siempre hace evasion
		{
			MatchExcepcion exc = new MatchExcepcion(atacante, objetivo);
			this.EnviarNotificacion(AutomaticEvasionCheckNotificacion, exc);
			return exc.Toggle;
		}

		/// <summary>
		/// <para>Se ajusta a los efectos</para>
		/// </summary>
		/// <param name="atacante"></param>
		/// <param name="objetivo"></param>
		/// <param name="porcentaje"></param>
		/// <returns></returns>
		public virtual int AjustarEfectosStatus(Unidad objetivo, int porcentaje)// Se ajusta a los efectos
		{
			Info<Unidad, Unidad, int> args = new Info<Unidad, Unidad, int>(atacante, objetivo, porcentaje);
			this.EnviarNotificacion(StatusCheckNotificacion, args);
			return args.arg2;
		}

		/// <summary>
		/// <para>Final</para>
		/// </summary>
		/// <param name="evasion"></param>
		/// <returns></returns>
		public virtual int Final(int evasion)// Final
		{
			return 100 - evasion;
		}
		#endregion
	}
}