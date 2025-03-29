# Trabajo Práctico N°01

Fecha de Inicio: 26/03/2025 23:30:00
Fecha de Fin: 09/04/2025 18:30:00

Contenidos que se repasarán:

- Manipulación de objetos en Unity 3D.
- Movimiento WASD con Físicas.
- Rotación Mouse.
- Manipulación de Rigidbody.
- Raycast.

Este proyecto se avanzará con los siguientes Trabajos Prácticos, por lo que la realización del siguiente
dependerá de éste y será acumulativo. Por lo que la entrega completa del siguiente Trabajo Práctico es la
suma de él mismo y éste.

Ejercicio:

- Descargar Unity Hub y la versión de Unity: [2022.3.15f1](https://unity.com/es/releases/editor/archive)
- Crear un proyecto 3D.
- Crear un jugador que actúe como un Drone de la siguiente manera:
  - Moverse con WASD hacia los costados teniendo de referencia el forward del jugador.
  - Con Ctrl va hacia abajo y con Espacio, hacia arriba.
    - No frena su impulso a menos que nos movamos en sentido opuesto (Sin rozamiento
    con el aire).
    - (Edit: El movimiento puede ser Local o Global, elección propia y lo que sientan más
    fluido)
  - Que rote con el mouse. (Puede dar fuerza Torque o que se comporte como un shooter).
  - Que posea una mira, láser o lo que sienta conveniente para ayudar al jugador a apuntar y
    pueda disparar con el click y calcular el punto de impacto con RayCast.
  - El jugador debe tener Vida y Daño.
    - Pierde Vida si choca con cosas. (por ejemplo al chocar 3 veces que muera o que
    dependa de la velocidad del choque).
    - Daña a los enemigos hasta matarlos.
- Un Spawner de enemigos.
  - Que estos enemigos aparezcan y se muevan en alguna dirección.
  - Que puedan ser dañados y destruidos.
  - Que spawneen diferentes tipos de enemigos
