//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// InitEstadoFreya.cs (11/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Estado de inicializacion de Freya							\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun.Estados
{
	/// <summary>
	/// <para>Estado de inicializacion de Freya.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Estados/InitEstadoFreya")]
	public class InitEstadoFreya : EstadoFreya
	{
		#region Eventos
		/// <summary>
		/// <para>Entrar en el Estado.</para>
		/// </summary>
		public override void Enter()// Entrar en el Estado
		{
			base.Enter();
			StartCoroutine(Init());
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Inicializa el Sistema de Combate.</para>
		/// </summary>
		/// <returns></returns>
		private IEnumerator Init()// Inicializa el Sistema de Combate
		{
			EstadoActualInit = Sistemas.EstadosFreyaSeguimiento.Inicializando;
			Grid.Load(LevelData);
			Punto p = new Punto((int)LevelData.areasPos[0].x, (int)LevelData.areasPos[0].z);
			SeleccionarArea(p);
			SpawnTestUnidades(); // TODO Testeo
			freya.ronda = freya.gameObject.AddComponent<TurnoController>().Ronda();
			AddCondicionVictoria();
			yield return null;
			freya.CambiarEstado<ConversacionEstadoFreya>();
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Agrega la condicion de victoria</para>
		/// </summary>
		private void AddCondicionVictoria()// Agrega la condicion de victoria
		{
			DerrotarUnEnemigoObjetivoBatalla condicion = freya.gameObject.AddComponent<DerrotarUnEnemigoObjetivoBatalla>();
			Unidad enemigo = Unidades[Unidades.Count - 1];
			condicion.target = enemigo;
			Vida vida = enemigo.GetComponent<Vida>();
			vida.MinHP = 10;
		}
		#endregion

		#region Test
		/// <summary>
		/// <para>Instancia las unidades</para>
		/// </summary>
		private void SpawnTestUnidades()// Instancia las unidades
		{
			string[] recipes = new string[]
			{
			"Moon",
			"Bandido"
			};

			GameObject contenedorUnidades = new GameObject("Unidades");
			contenedorUnidades.transform.SetParent(freya.transform);

			List<Area> localizaciones = new List<Area>(Grid.areas.Values);
			for (int i = 0; i < recipes.Length; ++i)
			{
				int level = UnityEngine.Random.Range(9, 12);
				GameObject instance = GeneradorUnidad.Crear(recipes[i], level);
				instance.transform.SetParent(contenedorUnidades.transform);

				int random = UnityEngine.Random.Range(0, localizaciones.Count);
				Area randomArea = localizaciones[random];
				localizaciones.RemoveAt(random);

				Unidad unidad = instance.GetComponent<Unidad>();
				unidad.Posicionar(randomArea);
				unidad.dir = (Direcciones)UnityEngine.Random.Range(0, 4);
				unidad.Actualizar();

				Unidades.Add(unidad);
			}

			SeleccionarArea(Unidades[0].Area.pos);
		}
		#endregion
	}
}