//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// CreadorOficiosEditor.cs (25/07/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Tool para crear los oficios									\\
// Fecha Mod:		25/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using MoonAntonio.Glitch.Comun;
#endregion

namespace MoonAntonio.Glitch.Tools
{
	/// <summary>
	/// <para>Tool para crear los oficios.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Tools/CreadorOficiosEditor")]
	public static class CreadorOficiosEditor
	{
		#region Menu
		/// <summary>
		/// <para>Menu de la herramienta</para>
		/// </summary>
		[MenuItem("Glitch/Crear Oficios")]
		public static void Menu()// Menu de la herramienta
		{
			CrearDirectorios();
			ParseStatsIniciales();
			ParseStatsCrecimiento();
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Crea los directorios necesarios</para>
		/// </summary>
		private static void CrearDirectorios()// Crea los directorios necesarios
		{
			if (!AssetDatabase.IsValidFolder("Assets/Prototipo Proyect/Resources/Oficios")) AssetDatabase.CreateFolder("Assets/Prototipo Proyect/Resources", "Oficios");
		}

		/// <summary>
		/// <para>Parse los stats iniciales</para>
		/// </summary>
		private static void ParseStatsIniciales()// Parse los stats iniciales
		{
			string readPath = string.Format("{0}/Prototipo Proyect/Settings/OficioInicioStats.csv", Application.dataPath);
			string[] readText = File.ReadAllLines(readPath);

			for (int n = 1; n < readText.Length; n++)
			{
				ParseStatsIniciales(readText[n]);
			}

		}

		/// <summary>
		/// <para>Parse los stats iniciales</para>
		/// </summary>
		/// <param name="linea"></param>
		private static void ParseStatsIniciales(string linea)// Parse los stats iniciales
		{
			string[] elementos = linea.Split(',');
			GameObject obj = GetOCrear(elementos[0]);
			Oficio oficio = obj.GetComponent<Oficio>();

			for (int i = 1; i < Oficio.statOrden.Length + 1; i++)
			{
				oficio.baseStats[i - 1] = Convert.ToInt32(elementos[i]);
			}

			CaracteristicaModificadorStat evasion = GetCaracteristica(obj, TipoStats.EVD);
			evasion.valor = Convert.ToInt32(elementos[8]);

			CaracteristicaModificadorStat res = GetCaracteristica(obj, TipoStats.RES);
			res.valor = Convert.ToInt32(elementos[9]);

			CaracteristicaModificadorStat movimiento = GetCaracteristica(obj, TipoStats.MOV);
			movimiento.valor = Convert.ToInt32(elementos[10]);

			CaracteristicaModificadorStat salto = GetCaracteristica(obj, TipoStats.JMP);
			salto.valor = Convert.ToInt32(elementos[11]);
		}

		/// <summary>
		/// <para>Parse los stats de crecimientos</para>
		/// </summary>
		private static void ParseStatsCrecimiento()// Parse los stats de crecimientos
		{
			string readPath = string.Format("{0}/Prototipo Proyect/Settings/OficioProgresoStats.csv", Application.dataPath);
			string[] readText = File.ReadAllLines(readPath);

			for (int n = 1; n < readText.Length; n++)
			{
				ParseStatsCrecimiento(readText[n]);
			}
		}

		/// <summary>
		/// <para>Parse los stats de crecimientos</para>
		/// </summary>
		/// <param name="linea"></param>
		private static void ParseStatsCrecimiento(string linea)// Parse los stats de crecimientos
		{
			string[] elementos = linea.Split(',');
			GameObject obj = GetOCrear(elementos[0]);
			Oficio oficio = obj.GetComponent<Oficio>();

			for (int n = 1; n < elementos.Length; n++)
			{
				oficio.crecimientoStats[n - 1] = Convert.ToSingle(elementos[n]);
			}
		}

		/// <summary>
		/// <para>Obtiene una caracteristica</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="tipo"></param>
		/// <returns></returns>
		private static CaracteristicaModificadorStat GetCaracteristica(GameObject obj, TipoStats tipo)// Obtiene una caracteristica
		{
			CaracteristicaModificadorStat[] caraMod = obj.GetComponents<CaracteristicaModificadorStat>();
			for (int n = 0; n < caraMod.Length; n++)
			{
				if (caraMod[n].tipo == tipo)
				{
					return caraMod[n];
				}
			}

			CaracteristicaModificadorStat caracteristica = obj.AddComponent<CaracteristicaModificadorStat>();
			caracteristica.tipo = tipo;
			return caracteristica;
		}

		/// <summary>
		/// <para>Obtiene o crea un oficio</para>
		/// </summary>
		/// <param name="nomOficio"></param>
		/// <returns></returns>
		private static GameObject GetOCrear(string nomOficio)// Obtiene o crea un oficio
		{
			string fullPath = string.Format("Assets/Prototipo Proyect/Resources/Oficios/{0}.prefab", nomOficio);
			GameObject obj = AssetDatabase.LoadAssetAtPath<GameObject>(fullPath);

			if (obj == null) obj = Crear(fullPath);

			return obj;
		}

		/// <summary>
		/// <para>Crea un oficio</para>
		/// </summary>
		/// <param name="fullPath"></param>
		/// <returns></returns>
		private static GameObject Crear(string fullPath)// Crea un oficio
		{
			GameObject instance = new GameObject("temp");
			instance.AddComponent<Oficio>();
			GameObject prefab = PrefabUtility.CreatePrefab(fullPath, instance);
			GameObject.DestroyImmediate(instance);
			return prefab;
		}
		#endregion
	}
}