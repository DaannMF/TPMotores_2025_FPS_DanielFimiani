# Trabajo Práctico N°02

## Contenidos que se repasarán

- Importación de Modelos.
- Importación de Animaciones.
- Animator -> FSM.
- Código FSM.
- Object Pool.

Fecha de Inicio: 09/04/2025 23:30:00
Fecha de Fin: 16/04/2025 18:30:00

Este proyecto se avanzará con los siguientes Trabajos Prácticos, por lo que la realización del siguiente
dependerá de éste y será acumulativo. Por lo que la entrega completa del siguiente Trabajo Práctico es la
suma de él mismo y éste.

## Modificaciones

- ✅ Debe tener completas todas las pautas del trabajo práctico anterior.
- ✅ El control del personaje puede ser como se quiera. La única condición es que se pueda mover en
todas las direcciones.
- ✅ Toda implementación de Object Pool debe ser propia y no utilizar la de Unity o cualquier otra librería.
- ✅ El spawner de enemigos debe ser una Object Pool.
- ✅ La mira láser o predicción de trayectoria se puede prender y apagar.
- ✅ La cámara del jugador debe ser en 1ra y 3ra persona.

## Nuevas Características

- ✅ Crear un entorno completo (Un escenario completo) incluyendo modelos 3D sin primitivas de Unity.
- ✅ Los disparos deben ser un objeto 3D que se lance al objetivo. La trayectoria debe estar previamente
calculada y el objeto debe seguir dicha trayectoria. (No lanzarlo con Físicas).
- ✅ Integrar modelos humanoides con sus respectivas animaciones.
  - ✅ A partir de ahora llamaremos a estos NPC Ciudadanos, los cuales habrá Civiles y Enemigos.
  - ✅ Si el jugador elimina enemigos recibirá una recompensa.
  - ✅ Si el jugador elimina civiles debe ser penalizado.
  - ✅ Deben circular en el mapa utilizando FSM.
