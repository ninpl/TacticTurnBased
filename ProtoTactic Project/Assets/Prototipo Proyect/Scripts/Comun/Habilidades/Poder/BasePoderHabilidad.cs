//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// BasePoderHabilidad.cs (29/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Clase base del poder de habilidad							\\
// Fecha Mod:		29/07/2017													\\
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
	/// <para>Clase base del poder de habilidad</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Clases/BasePoderHabilidad")]
	public abstract class BasePoderHabilidad : MonoBehaviour
	{
		#region Abstractas
		public abstract int GetBaseAtaque();
		public abstract int GetBaseDefensa(Unidad target);
		public abstract int GetPoder();
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Cuando se activa</para>
		/// </summary>
		private void OnEnable()// Cuando se activa
		{
			this.AddObservador(OnGetBaseAtaque, BaseEfectoHabilidad.GetAtaqueNotificacion);
			this.AddObservador(OnGetBaseDefensa, BaseEfectoHabilidad.GetDefensaNotificacion);
			this.AddObservador(OnGetPoder, BaseEfectoHabilidad.GetPoderNotificacion);
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		private void OnDisable()// Cuando se desactiva
		{
			this.RemoveObservador(OnGetBaseAtaque, BaseEfectoHabilidad.GetAtaqueNotificacion);
			this.RemoveObservador(OnGetBaseDefensa, BaseEfectoHabilidad.GetDefensaNotificacion);
			this.RemoveObservador(OnGetPoder, BaseEfectoHabilidad.GetPoderNotificacion);
		}
		#endregion

		#region Eventos
		/// <summary>
		/// <para>Cuando obtiene el ataque</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnGetBaseAtaque(object sender, object args)// Cuando obtiene el ataque
		{
			var info = args as Info<Unidad, Unidad, List<ModificadorValor>>;
			if (info.arg0 != GetComponentInParent<Unidad>()) return;

			AddValorModificador mod = new AddValorModificador(0, GetBaseAtaque());
			info.arg2.Add(mod);
		}

		/// <summary>
		/// <para>Cuando obtiene la defensa</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnGetBaseDefensa(object sender, object args)// Cuando obtiene la defensa
		{
			var info = args as Info<Unidad, Unidad, List<ModificadorValor>>;
			if (info.arg0 != GetComponentInParent<Unidad>()) return;

			AddValorModificador mod = new AddValorModificador(0, GetBaseDefensa(info.arg1));
			info.arg2.Add(mod);
		}

		/// <summary>
		/// <para>Cuando obtiene el poder</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnGetPoder(object sender, object args)// Cuando obtiene el poder
		{
			var info = args as Info<Unidad, Unidad, List<ModificadorValor>>;
			if (info.arg0 != GetComponentInParent<Unidad>()) return;

			AddValorModificador mod = new AddValorModificador(0, GetPoder());
			info.arg2.Add(mod);
		}

		/// <summary>
		/// <para>Determina si es el mismo efecto</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <returns></returns>
		private bool IsMiEfecto(object sender)// Determina si es el mismo efecto
		{
			MonoBehaviour obj = sender as MonoBehaviour;
			return (obj != null && obj.transform.parent == transform);
		}
		#endregion
	}
}