//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CosteHabilidadMagica.cs (31/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Coste de la habilidad magica								\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Coste de la habilidad magica</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/CosteHabilidadMagica")]
	public class CosteHabilidadMagica : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Coste de la habilidad</para>
		/// </summary>
		public int valor;								// Coste de la habilidad
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Habilidad</para>
		/// </summary>
		private Habilidad hab;							// Habilidad
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="CosteHabilidadMagica"/></para>
		/// </summary>
		private void Awake()// Inicializador de CosteHabilidadMagica
		{
			hab = GetComponent<Habilidad>();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando se activa</para>
		/// </summary>
		private void OnEnable()// Cuando se activa
		{
			this.AddObservador(OnComprobacionPuedeRealizar, Habilidad.ComprobacionPuedeRealizar, hab);
			this.AddObservador(OnRealizoNotificacion, Habilidad.RealizoNotificacion, hab);
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		private void OnDisable()// Cuando se desactiva
		{
			this.RemoveObservador(OnComprobacionPuedeRealizar, Habilidad.ComprobacionPuedeRealizar, hab);
			this.RemoveObservador(OnRealizoNotificacion, Habilidad.RealizoNotificacion, hab);
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando se puede realizar</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnComprobacionPuedeRealizar(object sender, object args)// Cuando se puede realizar
		{
			Stats s = GetComponentInParent<Stats>();
			if (s[TipoStats.MP] < valor)
			{
				BaseExcepcion exc = (BaseExcepcion)args;
				exc.FlipToggle();
			}
		}

		/// <summary>
		/// <para>Cuando se realizo</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnRealizoNotificacion(object sender, object args)// Cuando se realizo
		{
			Stats s = GetComponentInParent<Stats>();
			s[TipoStats.MP] -= valor;
		}
		#endregion
	}
}