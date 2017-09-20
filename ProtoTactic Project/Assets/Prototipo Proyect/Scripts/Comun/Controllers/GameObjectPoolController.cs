//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// GameObjectPoolController.cs (21/08/2017)										\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controlador de la pool de gameobjects						\\
// Fecha Mod:		22/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
using MoonAntonio.Glitch.Data;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Controlador de la pool de gameobjects.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Controllers/GameObjectPoolController")]
	public class GameObjectPoolController : MonoBehaviour
	{
		#region Singleton
		/// <summary>
		/// <para>Singleton de <see cref="GameObjectPoolController"/></para>
		/// </summary>
		private static GameObjectPoolController instance;							// Singleton de GameObjectPoolController
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Pool</para>
		/// </summary>
		private static Dictionary<string, PoolData> pools = new Dictionary<string, PoolData>();
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Singleton</para>
		/// </summary>
		private static GameObjectPoolController Instance
		{
			get
			{
				if (instance == null) CrearInstancia();
				return instance;
			}
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="GameObjectPoolController"/></para>
		/// </summary>
		private void Awake()// Inicializador de GameObjectPoolController
		{
			// Singleton
			if (instance != null && instance != this)
			{
				Destroy(this);
			}
			else
			{
				instance = this;
			}	
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Fijar el maximo de la pool</para>
		/// </summary>
		/// <param name="key"></param>
		/// <param name="maxCount"></param>
		public static void SetMaxCount(string key, int maxCount)// Fijar el maximo de la pool
		{
			if (!pools.ContainsKey(key)) return;
			PoolData data = pools[key];
			data.maxCount = maxCount;
		}

		/// <summary>
		/// <para>Agrega una entrada nueva.</para>
		/// </summary>
		/// <param name="key"></param>
		/// <param name="prefab"></param>
		/// <param name="puntuacion"></param>
		/// <param name="maxCount"></param>
		/// <returns></returns>
		public static bool AddEntrada(string key, GameObject prefab, int puntuacion, int maxCount)// Agrega una entrada nueva
		{
			if (pools.ContainsKey(key)) return false;

			PoolData data = new PoolData();
			data.prefab = prefab;
			data.maxCount = maxCount;
			data.pool = new Queue<Poolable>(puntuacion);
			pools.Add(key, data);

			for (int n = 0; n < puntuacion; n++)
			{
				EnCola(CrearInstanciaPoolable(key, prefab));
			}	

			return true;
		}

		/// <summary>
		/// <para>Limpiar una entrada</para>
		/// </summary>
		/// <param name="key"></param>
		public static void ClearEntrada(string key)// Limpiar una entrada
		{
			if (!pools.ContainsKey(key)) return;

			PoolData data = pools[key];
			while (data.pool.Count > 0)
			{
				Poolable obj = data.pool.Dequeue();
				GameObject.Destroy(obj.gameObject);
			}
			pools.Remove(key);
		}

		/// <summary>
		/// <para>Pone en la cola un objeto</para>
		/// </summary>
		/// <param name="sender"></param>
		public static void EnCola(Poolable sender)// Pone en la cola un objeto
		{
			if (sender == null || sender.isPooled || !pools.ContainsKey(sender.key)) return;

			PoolData data = pools[sender.key];
			if (data.pool.Count >= data.maxCount)
			{
				Destroy(sender.gameObject);
				return;
			}

			data.pool.Enqueue(sender);
			sender.isPooled = true;
			sender.transform.SetParent(Instance.transform);
			sender.gameObject.SetActive(false);
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Crea una instancia de <see cref="GameObjectPoolController"/></para>
		/// </summary>
		private static void CrearInstancia()// Crea una instancia de GameObjectPoolController
		{
			GameObject obj = new GameObject("GameObject Pool Controller");
			DontDestroyOnLoad(obj);
			instance = obj.AddComponent<GameObjectPoolController>();
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Crea un poolable</para>
		/// </summary>
		/// <param name="key"></param>
		/// <param name="prefab"></param>
		/// <returns></returns>
		private static Poolable CrearInstanciaPoolable(string key, GameObject prefab)// Crea un poolable
		{
			GameObject instance = Instantiate(prefab) as GameObject;
			Poolable p = instance.AddComponent<Poolable>();
			p.key = key;
			return p;
		}

		/// <summary>
		/// <para>Pone en cola un poolable</para>
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static Poolable EnColaPoolable(string key)// Pone en cola un poolable
		{
			if (!pools.ContainsKey(key)) return null;

			PoolData data = pools[key];
			if (data.pool.Count == 0) return CrearInstanciaPoolable(key, data.prefab);

			Poolable obj = data.pool.Dequeue();
			obj.isPooled = false;
			return obj;
		}
		#endregion
	}
}