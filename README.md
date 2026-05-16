# ZigZag

Juego 3D sencillo desarrollado en Unity como parte de un curso de aprendizaje de C# y Unity. El objetivo es controlar a un personaje que avanza automáticamente por una ruta en zigzag, cambiar de dirección en el momento correcto, recoger cristales y conseguir la mayor puntuación posible antes de caer al vacío.

## Descripción

En este proyecto el jugador controla un personaje que se desplaza constantemente hacia delante. Al pulsar una tecla, el personaje cambia su dirección entre derecha e izquierda para seguir una ruta generada dinámicamente. Durante la partida aparecen cristales en algunos bloques de la ruta; al recogerlos, aumenta la puntuación.

El juego termina cuando el personaje cae fuera del camino. La escena se reinicia automáticamente y se conserva la mejor puntuación usando `PlayerPrefs`.

## Características principales

- Movimiento automático del personaje mediante `Rigidbody`.
- Cambio de dirección con la tecla `Space`.
- Inicio de partida con la tecla `Enter`.
- Generación procedural de bloques de ruta en zigzag.
- Aparición aleatoria de cristales cada cierto número de bloques.
- Sistema de puntuación y mejor puntuación guardada.
- Reinicio de la escena al caer del escenario.
- Cámara que sigue al personaje manteniendo la distancia inicial.
- Música de fondo persistente entre escenas con patrón Singleton básico.
- Efecto de partículas al recoger cristales.

## Controles

| Tecla | Acción |
|---|---|
| `Enter` | Iniciar la partida |
| `Space` | Cambiar la dirección del personaje |

## Scripts principales

### `ControlPersonaje.cs`

Controla el comportamiento principal del jugador:

- Obtiene las referencias al `Rigidbody`, `Animator` y `GameManager`.
- Mueve al personaje en `FixedUpdate` usando `MovePosition`.
- Cambia la dirección del personaje al pulsar `Space`.
- Usa un `Raycast` para detectar si el personaje sigue sobre el suelo.
- Reinicia la partida si el personaje cae por debajo de cierta altura.
- Detecta cristales con `OnTriggerEnter`, suma puntos, instancia partículas y destruye el cristal recogido.

### `GameManager.cs`

Gestiona el estado general del juego:

- Inicia la partida con `Enter`.
- Activa la generación de ruta.
- Controla la puntuación actual.
- Actualiza la interfaz de puntuación.
- Guarda y recupera la mejor puntuación con `PlayerPrefs`.
- Reinicia la escena cuando el jugador pierde.

### `Ruta.cs`

Se encarga de construir la ruta:

- Instancia nuevas piezas de camino cada cierto tiempo.
- Decide aleatoriamente si la siguiente pieza aparece hacia la derecha o hacia la izquierda.
- Guarda la última posición generada para continuar desde ahí.
- Activa cristales en algunos bloques según un intervalo aleatorio configurable.

### `SeguimientoCamara.cs`

Hace que la cámara siga al jugador:

- Calcula la distancia inicial entre cámara y jugador.
- Actualiza la posición de la cámara en `LateUpdate` para seguir al objetivo de forma estable.

### `MusicaFondo.cs`

Controla la música de fondo:

- Usa una instancia estática para evitar duplicados.
- Mantiene el objeto de música entre cargas de escena usando `DontDestroyOnLoad`.

## Estructura recomendada del proyecto

```text
Assets/
├── Scripts/
│   ├── ControlPersonaje.cs
│   ├── GameManager.cs
│   ├── MusicaFondo.cs
│   ├── Ruta.cs
│   └── SeguimientoCamara.cs
├── Prefabs/
├── Materials/
├── Scenes/
├── Audio/
└── Particles/
