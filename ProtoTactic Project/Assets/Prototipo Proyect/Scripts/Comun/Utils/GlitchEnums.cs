//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// GlitchEnums.cs (14/07/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Enums utiles para el proyecto								\\
// Fecha Mod:		12/08/2017													\\
// Ultima Mod:		Refactorizacion												\\
//******************************************************************************\\

namespace MoonAntonio.Glitch.Comun
{
	/// <summary>
	/// <para>Direcciones</para>
	/// </summary>
	public enum Direcciones
	{
		Norte,
		Este,
		Sur,
		Oeste
	}

	/// <summary>
	/// <para>Tipos de estadisticas</para>
	/// </summary>
	public enum TipoStats
	{
		LVL,    // Nivel
		EXP,    // Experiencia
		HP,     // Vida
		MHP,    // Vida Maxima
		MP,     // Mana
		MMP,    // Mana Maxima
		ATK,    // Ataque Fisico
		DEF,    // Defensa Fisica
		MAT,    // Ataque Magico
		MDF,    // Defensa Magica
		EVD,    // Evasion
		RES,    // Resistencia
		SPD,    // Velocidad
		MOV,    // Movimiento
		JMP,    // Salto
		CTR,    // Counter (Orden Turno)
		Count   // Count
	}

	/// <summary>
	/// <para>Espacios de equipo</para>
	/// </summary>
	[System.Flags]
	public enum SlotsEquipo
	{
		None = 0,
		Primaria = 1 << 0,      // Generalmente un arma (espada, etc)
		Secundaria = 1 << 1,    // Generalmente un escudo, pero podria ser otra espada
		Cabeza = 1 << 2,        // Casco, sombrero, etc
		Cuerpo = 1 << 3,        // Armadura, tunica, etc
		Accesorio = 1 << 4      // Anillo, pendiente, etc
	}

	/// <summary>
	/// <para>Razas</para>
	/// </summary>
	public enum Razas
	{
		Humano,
		Elfo,
		Dragun,
		Ibero,
		Hada,
		Dios,
		Sabio,
		Oscuro
	}

	/// <summary>
	/// <para>Tipos de franqueo</para>
	/// </summary>
	public enum Franqueo
	{
		Delante,
		Lados,
		Detras
	}

	/// <summary>
	/// <para>Tipo de movimiento</para>
	/// </summary>
	public enum TipoMovimiento
	{
		Andar,
		Volar,
		Teleportar
	}

	/// <summary>
	/// <para>Bandos del combate</para>
	/// </summary>
	public enum Bandos
	{
		None = 0,
		Neutral = 1 << 0,
		Aliado = 1 << 1,
		Enemigo = 1 << 2
	}

	/// <summary>
	/// <para>Objetivos de unidad</para>
	/// </summary>
	public enum Objetivos
	{
		None,
		UnoMismo,
		Aliado,
		Enemigo,
		Area
	}

	/// <summary>
	/// <para>Controladores</para>
	/// </summary>
	public enum Controladores
	{
		None,
		Humano,
		Maquina
	}
}