//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// LvlCreator.cs (07/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Tool para crear escenarios									\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;
using System.Collections.Generic;
using MoonAntonio.Glitch.Comun;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Data;
#endregion

namespace MoonAntonio.Glitch.PreProduccion
{
	/// <summary>
	/// <para>Tool para crear escenarios.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/PreProduccion/LvlCreator")]
	public class LvlCreator : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Nombre del nivel.</para>
		/// </summary>
		public string nomNivel;										// Nombre del nivel
		/// <summary>
		/// <para>LevelData del nivel.</para>
		/// </summary>
		[SerializeField] public LevelData levelData;                // LevelData del nivel
		/// <summary>
		/// <para>Prefab del area.</para>
		/// </summary>
		[SerializeField] public GameObject prefabArea;				// Prefab del area
		/// <summary>
		/// <para>Prefab del cursor.</para>
		/// </summary>
		[SerializeField] public GameObject prefabCursor;			// Prefab del cursor
		/// <summary>
		/// <para>Anchura del rectangulo.</para>
		/// </summary>
		[SerializeField] public int w = 10;							// Anchura del rectangulo
		/// <summary>
		/// <para>Profundidad del rectangulo.</para>
		/// </summary>
		[SerializeField] public int d = 10;							// Profundidad del rectangulo
		/// <summary>
		/// <para>Altura del rectangulo.</para>
		/// </summary>
		[SerializeField] public int h = 10;							// Altura del rectangulo
		/// <summary>
		/// <para>Posicion del cursor.</para>
		/// </summary>
		[SerializeField] public Punto pos;							// Posicion del cursor
		/// <summary>
		/// <para>Datos del nuevo area.</para>
		/// </summary>
		Dictionary<Punto, Area> areaNivel = new Dictionary<Punto, Area>();// Datos del nuevo area
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Puntero donde se controla el cursor.</para>
		/// </summary>
		private Transform puntero;									// Puntero donde se controla el cursor
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Puntero de la escena.</para>
		/// </summary>
		Transform Puntero
		{
			get
			{
				if (puntero == null)
				{
					GameObject instance = Instantiate(prefabCursor) as GameObject;
					puntero = instance.transform;
				}
				return puntero;
			}
		}
		#endregion

		#region API
		/// <summary>
		/// <para>Eleva el area.</para>
		/// </summary>
		public void Elevar()// Eleva el area
		{
			ElevarArea(pos);
		}

		/// <summary>
		/// <para>Reduce el area.</para>
		/// </summary>
		public void Reducir()// Reduce el area
		{
			ReducirArea(pos);
		}

		/// <summary>
		/// <para>Eleva areas de un rectangulo.</para>
		/// </summary>
		public void ElevarAreas()// Eleva areas de un rectangulo
		{
			Rect r = RandomRect();
			ElevarRect(r);
		}

		/// <summary>
		/// <para>Reduce areas de un rectangulo.</para>
		/// </summary>
		public void ReducirAreas()// Reduce areas de un rectangulo
		{
			Rect r = RandomRect();
			ReducirRect(r);
		}

		/// <summary>
		/// <para>Actualiza el puntero.</para>
		/// </summary>
		public void ActualizarPuntero()// Actualiza el puntero
		{
			Area a = areaNivel.ContainsKey(pos) ? areaNivel[pos] : null;
			Puntero.localPosition = a != null ? a.Centro : new Vector3(pos.x, 0, pos.y);
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Guarda el nivel.</para>
		/// </summary>
		public void Guardar()// Guarda el nivel
		{
			// Ruta de guardado de los niveles
			string filePath = Application.dataPath + "/Prototipo Proyect/Resources/Levels";

			// Comprueba si el directorio no existe
			if (!Directory.Exists(filePath)) CrearDirectorio();

			// Crear la instancia del nivel
			LevelData nivel = ScriptableObject.CreateInstance<LevelData>();
			nivel.areasPos = new List<Vector3>(areaNivel.Count);

			// Agregar los elementos
			foreach (Area a in areaNivel.Values)
			{
				nivel.areasPos.Add(new Vector3(a.pos.x, a.altura, a.pos.y));
			}


			string nombreNivel = string.Format("Assets/Prototipo Proyect/Resources/Levels/{1}.asset", filePath, nomNivel);

			// Crear el nivel
			AssetDatabase.CreateAsset(nivel, nombreNivel);
		}

		/// <summary>
		/// <para>Carga un nivel.</para>
		/// </summary>
		public void Cargar()// Carga un nivel
		{
			// Limpiar la escena
			Clear();

			// Comprobar si hay leveldata
			if (levelData == null) return;

			// Recorrer e instanciar el nivel
			foreach (Vector3 v in levelData.areasPos)
			{
				Area a = Crear();
				a.Load(v);
				areaNivel.Add(a.pos, a);
			}

			// TODO Instanciar props del nivel
			/*for (int n = 0; n < levelData.areaProps.Count; n++)
			{
				// Instanciar
				PoolCreator pool = this.gameObject.transform.GetComponent<PoolCreator>();
				GameObject go = pool.Crear(levelData.prefabsProps[n]);
				go.transform.parent = transform;
				go.transform.position = new Vector3(levelData.areaProps[n].x, levelData.areaProps[n].y, levelData.areaProps[n].z);
				go.name = levelData.prefabsProps[n];
			}*/
		}

		/// <summary>
		/// <para>Limpia la escena.</para>
		/// </summary>
		public void Clear()// Limpia la escena
		{
			// Recorrer la jerarquia
			for (int n = transform.childCount - 1; n >= 0; n--)
			{
				DestroyImmediate(transform.GetChild(n).gameObject);
			}

			areaNivel.Clear();
		}
		#endregion

		#region Metodos privados
		/// <summary>
		/// <para>Crea un gameobject</para>
		/// </summary>
		/// <param name="go"></param>
		/// <returns></returns>
		private Area Crear()// Crea un gameobject
		{
			GameObject instance = Instantiate(prefabArea) as GameObject;
			instance.transform.parent = transform;
			return instance.GetComponent<Area>();
		}

		/// <summary>
		/// <para>Obtiene o crea un area.</para>
		/// </summary>
		/// <param name="p">Punto donde obtener o crear.</param>
		/// <returns></returns>
		private Area GetOCrear(Punto p)// Obtiene o crea un area
		{
			if (areaNivel.ContainsKey(p)) return areaNivel[p];

			Area a = Crear();
			a.Load(p, 0);
			areaNivel.Add(p, a);

			return a;
		}

		/// <summary>
		/// <para>Crea el directorio</para>
		/// </summary>
		private void CrearDirectorio()// Crea el directorio
		{
			// Obtener la ruta de resources
			string filePath = Application.dataPath + "/Prototipo Proyect/Resources";

			// Comprobar si existe la ruta
			if (!Directory.Exists(filePath))
			{
				AssetDatabase.CreateFolder("Assets", "Resources");
			}

			filePath += "/Levels";
			if (!Directory.Exists(filePath))
			{
				AssetDatabase.CreateFolder("Assets/Prototipo Proyect/Resources", "Levels");
			}

			// Refrescar
			AssetDatabase.Refresh();
		}

		/// <summary>
		/// <para>Eleva el rectangulo.</para>
		/// </summary>
		/// <param name="rect"></param>
		private void ElevarRect(Rect rect)// Eleva el rectangulo
		{
			for (int y = (int)rect.yMin; y < (int)rect.yMax; y++)
			{
				for (int x = (int)rect.xMin; x < (int)rect.xMax; x++)
				{
					Punto p = new Punto(x, y);
					ElevarArea(p);
				}
			}
		}

		/// <summary>
		/// <para>Reduce el rectangulo.</para>
		/// </summary>
		/// <param name="rect"></param>
		private void ReducirRect(Rect rect)// Reduce el rectangulo
		{
			for (int y = (int)rect.yMin; y < (int)rect.yMax; y++)
			{
				for (int x = (int)rect.xMin; x < (int)rect.xMax; x++)
				{
					Punto p = new Punto(x, y);
					ReducirArea(p);
				}
			}
		}

		/// <summary>
		/// <para>Eleva un area.</para>
		/// </summary>
		/// <param name="p">Punto donde elevar el area.</param>
		private void ElevarArea(Punto p)// Eleva un area
		{
			Area a = GetOCrear(p);
			if (a.altura < h) a.Elevar();
		}

		/// <summary>
		/// <para>Reduce un area.</para>
		/// </summary>
		/// <param name="p">Punto donde reducir el area.</param>
		private void ReducirArea(Punto p)// Reduce un area
		{
			if (!areaNivel.ContainsKey(p)) return;

			Area a = areaNivel[p];
			a.Reducir();

			if (a.altura <= 0)
			{
				areaNivel.Remove(p);
				DestroyImmediate(a.gameObject);
			}
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Crea un rectangulo.</para>
		/// </summary>
		/// <returns>Un rectangulo dentro de unos parametros.</returns>
		private Rect RandomRect()// Crea un rectangulo
		{
			int x = Random.Range(0, w);
			int y = Random.Range(0, d);
			int n = Random.Range(1, w - x + 1);
			int h = Random.Range(1, d - y + 1);
			return new Rect(x, y, n, h);
		}
		#endregion
	}
}
