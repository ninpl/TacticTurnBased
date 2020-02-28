//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// EstadoUnidadController.cs (31/07/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controla el estado de KO en combate							\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Extensiones;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Controla el estado de KO en combate</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Controllers/EstadoUnidadController")]
	public class EstadoUnidadController : MonoBehaviour
	{
		#region Metodos
		/// <summary>
		/// <para>Cuando se activa</para>
		/// </summary>
		private void OnEnable()// Cuando se activa
		{
			this.AddObservador(OnHPCambiaNotificacion, Stats.CuandoCambioNotificacion(TipoStats.HP));
		}

		/// <summary>
		/// <para>Cuando se desactiva</para>
		/// </summary>
		private void OnDisable()// Cuando se desactiva
		{
			this.RemoveObservador(OnHPCambiaNotificacion, Stats.CuandoCambioNotificacion(TipoStats.HP));
		}

		/// <summary>
		/// <para>Cuando el HP cambia</para>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnHPCambiaNotificacion(object sender, object args)// Cuando el HP cambia
		{
			Stats stats = sender as Stats;
			if (stats[TipoStats.HP] == 0)
			{
				EstadoUnidad estado = stats.GetComponentInChildren<EstadoUnidad>();
				CondicionComparacionStats condicion = estado.Add<EstadoEfectoKO, CondicionComparacionStats>();
				condicion.Init(TipoStats.HP, 0, condicion.IgualA);
			}
		}
		#endregion
	}
}