//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// BaseObjetivoBatalla.cs (07/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base del objetivo de batalla							\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Sistemas;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Clases
{
	/// <summary>
	/// <para>Clase base del objetivo de batalla.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/BaseObjetivoBatalla")]
	public abstract class BaseObjetivoBatalla : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Sistema freya</para>
		/// </summary>
		public Freya freya;									// Sistema freya
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Tipo de victoria</para>
		/// </summary>
		private Bandos victoria = Bandos.None;				// Tipo de victoria
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Tipo de victoria</para>
		/// </summary>
		public Bandos Victoria
		{
			get { return victoria; }
			set { victoria = value; }
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializacion de <see cref="BaseObjetivoBatalla"/></para>
		/// </summary>
		public virtual void Awake()// Inicializacion de BaseObjetivoBatalla
		{
			freya = GetComponent<Freya>();
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando el HP cambia</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		public virtual void OnHPCambiaNotificacion(object sender, object args)// Cuando el HP cambia
		{
			ComprobarGameOver();
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Cuando se activa</para>
		/// </summary>
		public virtual void OnEnable()// Cuando se activa
		{
			this.AddObservador(OnHPCambiaNotificacion, Stats.CuandoCambioNotificacion(TipoStats.HP));
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		public virtual void OnDisable()// Cuando se desactiva
		{
			this.RemoveObservador(OnHPCambiaNotificacion, Stats.CuandoCambioNotificacion(TipoStats.HP));
		}

		/// <summary>
		/// <para>Comprueba el game over</para>
		/// </summary>
		public virtual void ComprobarGameOver()// Comprueba el game over
		{
			if (PartyDerrotada(Bandos.Aliado)) Victoria = Bandos.Enemigo;
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Comprueba si la party dada esta derrotada</para>
		/// </summary>
		/// <param name="tipo"></param>
		/// <returns></returns>
		public virtual bool PartyDerrotada(Bandos tipo)// Comprueba si la party dada esta derrotada
		{
			for (int n = 0; n < freya.unidades.Count; n++)
			{
				Bando bando = freya.unidades[n].GetComponent<Bando>();

				if (bando == null) continue;

				if (bando.tipo == tipo && !IsDerrotada(freya.unidades[n])) return false;
			}
			return true;
		}

		/// <summary>
		/// <para>Comprueba si una unidad ha sido derrotada</para>
		/// </summary>
		/// <param name="unidad"></param>
		/// <returns></returns>
		public virtual bool IsDerrotada(Unidad unidad)// Comprueba si una unidad ha sido derrotada
		{
			Vida vida = unidad.GetComponent<Vida>();
			if (vida) return vida.MinHP == vida.HP;

			Stats stats = unidad.GetComponent<Stats>();
			return stats[TipoStats.HP] == 0;
		}
		#endregion
	}
}