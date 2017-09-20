//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// FinalizarBatallaEstadoFreya.cs (21/07/2017)									\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado para la finalizacion de la batalla					\\
// Fecha Mod:		21/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.SceneManagement;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun.Estados
{
	/// <summary>
	/// <para>Estado para la finalizacion de la batalla.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/FinalizarBatallaEstadoFreya")]
	public class FinalizarBatallaEstadoFreya : EstadoFreya
	{
		#region Estados
		/// <summary>
		/// <para>Cuando se entra en el estado</para>
		/// </summary>
		public override void Enter()// Cuando se entra en el estado
		{
			base.Enter();
			SceneManager.LoadScene("BattleProto");
		}
		#endregion
	}
}