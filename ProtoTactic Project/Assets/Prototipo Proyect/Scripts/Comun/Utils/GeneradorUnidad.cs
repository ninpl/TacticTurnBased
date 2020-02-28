//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// GeneradorUnidad.cs (31/07/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Generar una unidad											\\
// Fecha Mod:		31/07/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using MoonAntonio.Glitch.Clases;
using MoonAntonio.Glitch.Data;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Generar una unidad</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/GeneradorUnidad")]
	public static class GeneradorUnidad
	{
		#region API
		/// <summary>
		/// <para>Crea una unidad</para>
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="level"></param>
		/// <returns></returns>
		public static GameObject Crear(string nombre, int level)// Crea una unidad
		{
			UnidadData recipe = Resources.Load<UnidadData>("Unidades Data/" + nombre);
			if (recipe == null)
			{
				Debug.LogError("No encontrado data con nombre: " + nombre);
				return null;
			}
			return Crear(recipe, level);
		}

		/// <summary>
		/// <para>Crea una unidad</para>
		/// </summary>
		/// <param name="data"></param>
		/// <param name="nivel"></param>
		/// <returns></returns>
		public static GameObject Crear(UnidadData data, int nivel)// Crea una unidad
		{
			GameObject obj = InstanciarPrefab("Unidades/" + data.modelo);
			obj.name = data.name;
			obj.AddComponent<Unidad>();
			AddStats(obj);
			AddMovimiento(obj, data.tipoMovimiento);
			obj.AddComponent<EstadoUnidad>();
			obj.AddComponent<Equipamiento>();
			AddOficio(obj, data.oficio);
			AddNivel(obj, nivel);
			obj.AddComponent<Vida>();
			obj.AddComponent<Mana>();
			AddAtaque(obj, data.ataque);
			AddCatalogoHabilidades(obj, data.catalogoHabilidades);
			AddBando(obj, data.bando);
			AddPatronAtaque(obj, data.estrategia);
			return obj;
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Instancia un prefab</para>
		/// </summary>
		/// <param name="nombre"></param>
		/// <returns></returns>
		private static GameObject InstanciarPrefab(string nombre)// Instancia un prefab
		{
			GameObject prefab = Resources.Load<GameObject>(nombre);
			if (prefab == null)
			{
				Debug.LogError("No se ha encontrado prefab con nombre: " + nombre);
				return new GameObject(nombre);
			}
			GameObject instance = GameObject.Instantiate(prefab);
			instance.name = instance.name.Replace("(Clone)", "");
			return instance;
		}

		/// <summary>
		/// <para>Agrega el componente stats</para>
		/// </summary>
		/// <param name="obj"></param>
		private static void AddStats(GameObject obj)// Agrega el componente stats
		{
			Stats s = obj.AddComponent<Stats>();
			s.SetValue(TipoStats.LVL, 1, false);
		}

		/// <summary>
		/// <para>Agrega un oficio</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="name"></param>
		private static void AddOficio(GameObject obj, string name)// Agrega un oficio
		{
			GameObject instance = InstanciarPrefab("Oficios/" + name);
			instance.transform.SetParent(obj.transform);
			Oficio oficio = instance.GetComponent<Oficio>();
			oficio.ActivarOficio();
			oficio.CargarStatsIniciales();
		}

		/// <summary>
		/// <para>Agrega el movimiento</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="tipo"></param>
		private static void AddMovimiento(GameObject obj, TipoMovimiento tipo)// Agrega el movimiento
		{
			switch (tipo)
			{
				case TipoMovimiento.Andar:
					obj.AddComponent<MovimientoAndar>();
					break;
				case TipoMovimiento.Volar:
					obj.AddComponent<MovimientoVolar>();
					break;
				case TipoMovimiento.Teleportar:
					obj.AddComponent<MovimientoTeletransporte>();
					break;
			}
		}

		/// <summary>
		/// <para>Agrega un bando</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="tipo"></param>
		private static void AddBando(GameObject obj, Bandos tipo)// Agrega un bando
		{
			Bando bando = obj.AddComponent<Bando>();
			bando.tipo = tipo;
		}

		/// <summary>
		/// <para>Agrega el nivel</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="nivel"></param>
		private static void AddNivel(GameObject obj, int nivel)// Agrega el nivel
		{
			Nivel niv = obj.AddComponent<Nivel>();
			niv.Init(nivel);
		}

		/// <summary>
		/// <para>Agrega un ataque</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="nombre"></param>
		private static void AddAtaque(GameObject obj, string nombre)// Agrega un ataque
		{
			GameObject instance = InstanciarPrefab("Habilidades/" + nombre);
			instance.transform.SetParent(obj.transform);
		}

		/// <summary>
		/// <para>Agrega el catalogo de habilidades</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="name"></param>
		private static void AddCatalogoHabilidades(GameObject obj, string name)// Agrega el catalogo de habilidades
		{
			GameObject main = new GameObject("Catalogo Habilidades");
			main.transform.SetParent(obj.transform);
			main.AddComponent<CatalogoHabilidades>();

			CatalogoHabilidadData data = Resources.Load<CatalogoHabilidadData>("Catalogo Habilidades Data/" + name);
			if (data == null)
			{
				Debug.LogError("No encontrado data del catalogo de habilidades con nombre: " + name);
				return;
			}

			for (int i = 0; i < data.categorias.Length; i++)
			{
				GameObject category = new GameObject(data.categorias[i].nombre);
				category.transform.SetParent(main.transform);

				for (int j = 0; j < data.categorias[i].lista.Length; ++j)
				{
					string nomHabilidad = string.Format("Habilidades/{0}/{1}", data.categorias[i].nombre, data.categorias[i].lista[j]);
					GameObject hab = InstanciarPrefab(nomHabilidad);
					hab.name = data.categorias[i].lista[j];
					hab.transform.SetParent(category.transform);
				}
			}
		}

		/// <summary>
		/// <para>Agrega un patron de ataque</para>
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="name"></param>
		private static void AddPatronAtaque(GameObject obj, string name)// Agrega un patron de ataque
		{
			Controlador control = obj.AddComponent<Controlador>();
			if (string.IsNullOrEmpty(name))
			{
				control.normal = Controladores.Humano;
			}
			else
			{
				control.normal = Controladores.Maquina;
				GameObject instance = InstanciarPrefab("Patrones Ataque/" + name);
				instance.transform.SetParent(obj.transform);
			}
		}
		#endregion
	}
}