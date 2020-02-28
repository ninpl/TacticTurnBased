//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EfectoHabilidadObjetivoAbsorverDamage.cs (31/07/2017)						\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Efecto de habilidad absorver								\\
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
	/// <para>Efecto de habilidad absorver</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/EfectoHabilidadObjetivoAbsorverDamage")]
	public class EfectoHabilidadObjetivoAbsorverDamage : BaseEfectoHabilidad
	{
		#region Variables
		/// <summary>
		/// <para>Index</para>
		/// </summary>
		public int rastreoIndex;								// Index
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Efecto</para>
		/// </summary>
		private BaseEfectoHabilidad efecto;						// Efecto
		/// <summary>
		/// <para>Valor</para>
		/// </summary>
		private int valor;                                      // Valor
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="EfectoHabilidadObjetivoAbsorverDamage"/></para>
		/// </summary>
		private void Awake()// Inicializador de EfectoHabilidadObjetivoAbsorverDamage
		{
			efecto = GetRastreoEfecto();
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Cuando se activa</para>
		/// </summary>
		private void OnEnable()// Cuando se activa
		{
			this.AddObservador(OnEfectoHit, BaseEfectoHabilidad.HitNotificacion, efecto);
			this.AddObservador(OnEfectoEsquivado, BaseEfectoHabilidad.EsquivadoNotificacion, efecto);
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		private void OnDisable()// Cuando se desactiva
		{
			this.RemoveObservador(OnEfectoHit, BaseEfectoHabilidad.HitNotificacion, efecto);
			this.RemoveObservador(OnEfectoEsquivado, BaseEfectoHabilidad.EsquivadoNotificacion, efecto);
		}
		#endregion

		#region Funcionalidad
		public override int Predecir(Area target)
		{
			return 0;
		}

		public override int OnAplicar(Area target)
		{
			Stats s = GetComponentInParent<Stats>();
			s[TipoStats.HP] += valor;
			return valor;
		}

		/// <summary>
		/// <para>Obtiene el rastreo del efecto</para>
		/// </summary>
		/// <returns></returns>
		private BaseEfectoHabilidad GetRastreoEfecto()// Obtiene el rastreo del efecto
		{
			Transform t = GetComponentInParent<Habilidad>().transform;
			if (rastreoIndex >= 0 && rastreoIndex < t.childCount)
			{
				Transform sim = t.GetChild(rastreoIndex);
				return sim.GetComponent<BaseEfectoHabilidad>();
			}
			return null;
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando el efecto golpea</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnEfectoHit(object sender, object args)// Cuando el efecto golpea
		{
			valor = (int)args * -1;
		}

		/// <summary>
		/// <para>Cuando el efecto es esquivado</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnEfectoEsquivado(object sender, object args)// Cuando el efecto es esquivado
		{
			valor = 0;
		}
		#endregion
	}
}