//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MenuHabilidadesController.cs (15/07/2017)									\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Controller del menu de habilidades							\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using MoonAntonio.Glitch.UI;
using MoonAntonio.Glitch.Clases;
#endregion

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Controller del menu de habilidades.</para>
	/// </summary>
	[AddComponentMenu("Moon Antonio/Glitch/Comun/Controllers/MenuHabilidadesController")]
	public class MenuHabilidadesController : MonoBehaviour
	{
		#region Constantes
		/// <summary>
		/// <para>Clave para mostrar la habilidad</para>
		/// </summary>
		private const string MostrarKey = "Mostrar";										// Clave para mostrar la habilidad
		/// <summary>
		/// <para>Clave para ocultar la habilidad</para>
		/// </summary>
		private const string OcultarKey = "Ocultar";										// Clave para ocultar la habilidad
		/// <summary>
		/// <para>Clave para la entrada a la pool</para>
		/// </summary>
		private const string EntradaPoolKey = "MenuHabilidadesController.Entrada";			// Clave para la entrada a la pool
		/// <summary>
		/// <para>Cuenta de las entradas del menu</para>
		/// </summary>
		private const int MenuCount = 4;													// Cuenta de las entradas del menu
		#endregion

		#region Variables Publicas
		/// <summary>
		/// <para>Boton de la entrada de la habilidad</para>
		/// </summary>
		[SerializeField] private GameObject btnPrefab;										// Boton de la entrada de la habilidad
		/// <summary>
		/// <para>Nombre del titulo</para>
		/// </summary>
		[SerializeField] private Text nombre;												// Nombre del titulo
		/// <summary>
		/// <para>Panel donde instanciar</para>
		/// </summary>
		[SerializeField] private Panel panel;												// Panel donde instanciar
		/// <summary>
		/// <para>Canvas de la raiz</para>
		/// </summary>
		[SerializeField] private GameObject canvas;											// Canvas de la raiz
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Entradas del menu</para>
		/// </summary>
		private List<BtnHabilidad> menuEntradas = new List<BtnHabilidad>(MenuCount);// Entradas del menu
		#endregion

		#region Propiedades
		/// <summary>
		/// <para>Seleccion de btn</para>
		/// </summary>
		public int Seleccion
		{
			get;
			private set;
		}
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Cargador de <see cref="MenuHabilidadesController"/></para>
		/// </summary>
		private void Awake()// Cargador de MenuHabilidadesController
		{
			GameObjectPoolController.AddEntrada(EntradaPoolKey, btnPrefab, MenuCount, int.MaxValue);
		}

		/// <summary>
		/// <para>Inicializador de <see cref="MenuHabilidadesController"/></para>
		/// </summary>
		private void Start()// Inicializador de MenuHabilidadesController
		{
			panel.SetPosicion(OcultarKey, false);
			canvas.SetActive(false);
		}
		#endregion

		#region Metodos Publicos
		/// <summary>
		/// <para>Mostrar el menu</para>
		/// </summary>
		/// <param name="titulo"></param>
		/// <param name="opciones"></param>
		public void Mostrar(string titulo, List<string> opciones)// Mostrar el menu
		{
			// Activar el canvas y limpiarlo
			canvas.SetActive(true);
			Clear();

			// Asignamos el titulo
			nombre.text = titulo;

			// Agregamos las opciones
			for (int n = 0; n < opciones.Count; n++)
			{
				BtnHabilidad entrada = PonerEnCola();
				entrada.Texto = opciones[n];
				menuEntradas.Add(entrada);
			}

			// Seleccionar la opcion por defecto
			SetSeleccion(0);
			TogglePos(MostrarKey);
		}

		/// <summary>
		/// <para>Ocultar el menu</para>
		/// </summary>
		public void Ocultar()// Ocultar el menu
		{
			// Hacer el tween y completar el evento
			Tweener t = TogglePos(OcultarKey);
			t.completedEvent += delegate (object sender, System.EventArgs e)
			{
				if (panel.PosicionActual == panel[OcultarKey])
				{
					Clear();
					canvas.SetActive(false);
				}
			};
		}

		/// <summary>
		/// <para>Bloquea o desbloquea un boton</para>
		/// </summary>
		/// <param name="index"></param>
		/// <param name="valor"></param>
		public void SetBloqueoBtn(int index, bool valor)// Bloquea o desbloquea un boton
		{
			// Comprobar el error
			if (index < 0 || index >= menuEntradas.Count) return;

			// Bloquear o desbloquear
			menuEntradas[index].IsBloqueado = valor;
			if (valor && Seleccion == index) Next();
		}

		/// <summary>
		/// <para>Pasa al siguiente boton</para>
		/// </summary>
		public void Next()
		{
			for (int n = Seleccion + 1; n < Seleccion + menuEntradas.Count; n++)// Pasa al siguiente boton
			{
				int index = n % menuEntradas.Count;
				if (SetSeleccion(index)) break;
			}
		}

		/// <summary>
		/// <para>Retrocede al btn anterior</para>
		/// </summary>
		public void Anterior()// Retrocede al btn anterior
		{
			for (int n = Seleccion - 1 + menuEntradas.Count; n > Seleccion; n--)
			{
				int index = n % menuEntradas.Count;
				if (SetSeleccion(index)) break;
			}
		}
		#endregion

		#region Metodos Privados
		/// <summary>
		/// <para>Agrega un objeto al final de la cola</para>
		/// </summary>
		/// <param name="obj"></param>
		private void AddEntradaCola(BtnHabilidad obj)// Agrega un objeto al final de la cola
		{
			Poolable p = obj.GetComponent<Poolable>();
			GameObjectPoolController.EnCola(p);
		}

		/// <summary>
		/// <para>Limpia el menu de entradas</para>
		/// </summary>
		private void Clear()// Limpia el menu de entradas
		{
			// Recorrer todo el menu de entrada
			for (int n = menuEntradas.Count - 1; n >= 0; n--)
			{
				AddEntradaCola(menuEntradas[n]);
			}
			
			// Limpiar el menu de entrada
			menuEntradas.Clear();
		}

		/// <summary>
		/// <para>Fija la seleccion</para>
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private bool SetSeleccion(int value)// Fija la seleccion
		{
			// Si el valor esta bloqueado, salir
			if (menuEntradas[value].IsBloqueado) return false;

			// Deseleccionar la seleccion de la entrada seleccionada anteriormente
			if (Seleccion >= 0 && Seleccion < menuEntradas.Count) menuEntradas[Seleccion].IsSeleccionado = false;

			Seleccion = value;

			// Seleccionar la nueva entrada
			if (Seleccion >= 0 && Seleccion < menuEntradas.Count) menuEntradas[Seleccion].IsSeleccionado = true;

			return true;
		}
		#endregion

		#region Funcionalidad
		/// <summary>
		/// <para>Poner en cola</para>
		/// </summary>
		/// <returns></returns>
		private BtnHabilidad PonerEnCola()// Poner en cola
		{
			Poolable pool = GameObjectPoolController.EnColaPoolable(EntradaPoolKey);
			BtnHabilidad entrada = pool.GetComponent<BtnHabilidad>();
			entrada.transform.SetParent(panel.transform, false);
			entrada.transform.localScale = Vector3.one;
			entrada.gameObject.SetActive(true);
			entrada.Reset();
			return entrada;
		}

		/// <summary>
		/// <para>Toogle de la posicion</para>
		/// </summary>
		/// <param name="pos"></param>
		/// <returns></returns>
		private Tweener TogglePos(string pos)// Toogle de la posicion
		{
			Tweener t = panel.SetPosicion(pos, true);
			t.duration = 0.5f;
			t.equation = EasingEquations.EaseOutQuad;
			return t;
		}
		#endregion
	}
}
