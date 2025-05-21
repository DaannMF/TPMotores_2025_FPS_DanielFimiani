# Trabajo Práctico N°05 - Final Parte 1

Fecha de Inicio: 07/05/2025 23:00:00
Fecha de Fin: 21/05/2025 18:30:00

Este proyecto no se avanzará más. Por lo que la realización de éste mismo es la nota acumulativa de todos
los anteriores. La integración de las solicitudes a continuación tienen fecha de vencimiento pero el proyecto
entero será el día de la fecha de entrega final.

## Entrega Completa

- ✅ Descargar Unity Hub y la versión de Unity: 2022.3.15f1 <https://unity.com/es/releases/editor/archive>
- ✅ Crear un proyecto 3D.
- Entregar:
  - Link a itchio.
        _ La web debe poseer por lo menos una build WebGL y Link a GitHub.
  - Link a Repositorio.
  - ✅ Debe tener un ReadMe con detalle de la entrega. (Cómo jugar, el autor, los créditos).
Jugador:
    - ✅ Crear un jugador que actúe como un Drone de la siguiente manera:
      - ✅ Moverse con WASD.
      - ✅ Con Ctrl va hacia abajo y con Espacio, hacia arriba.
      - ✅ Que rote con el mouse. (Puede dar fuerza Torque o que se comporte como un shooter).
      - ✅ Que posea una mira, láser o lo que sienta conveniente para ayudar al jugador a apuntar y pueda disparar con el click y calcular el punto de impacto con RayCast.
    - Dos armas distintas y que se pueda intercambiar entre estas.
      - Una como se quiera.
      - La otra debe ser un proyectil 3D que se lance sin utilizar físicas, calculando la trayectoria al momento del disparo.
    - ✅ Una mira láser: que se puede prender y apagar.
    - ✅ Pierde Vida si choca con edificaciones, piso, enemigos o cualquier objeto con el que colisione.
    - ✅ Daña a los enemigos con disparos o chocándolos hasta matarlos.
Enemigo:
    - ✅ Un Spawner de enemigos.
    - ✅ Éstos enemigos aparezcan y se muevan en alguna dirección.
    - ✅ Pueden ser dañados y destruidos.
    - Hay diferentes tipos de enemigos con habilidades diferentes.
Entorno:
    - ✅ Crear un nivel completo (escenario completo) incluyendo modelos 3D sin primitivas de Unity.
    - ✅ Integrar modelos humanoides con sus respectivas animaciones.
    - ✅ A partir de ahora llamaremos a estos NPC Ciudadanos, los cuales habrá Civiles y Enemigos.
    - ✅ Si el jugador elimina enemigos recibirá una recompensa.
    - ✅ Si el jugador elimina civiles debe ser penalizado.
    - Deben circular en el mapa utilizando FSM.
    - Hay varios niveles y uno es distinto a otro en cuanto a dificultad (no arte, aunque suma).

## Contenidos que se repasarán

- Unity 3D.
Código y Proyecto:
- Debe haber una escena “MainMenu” y otra “Gameplay”.
  - Se debe poder ir y volver las veces que se desee.
- En los cambios de escena, siempre se deberá hacer de manera async con una load bar.
- ✅ Debe hacerse uso de ObjectPool (propia no de Unity) de:
  - ✅ Balas
  - ✅ Enemigos.
  - ✅ Una vez creada la Pool y los objetos, no debe destruirse por volver al menú principal.
- Se debe poder configurar cuestiones del nivel/dificultad desde un Scriptable Object.
- ✅ Se debe utilizar herencia para:
  - ✅ Las entidades de enemigos y ciudadanos.
  - ✅ Las balas.
  - ✅ Cualquier otra situación que lo amerite.
- ✅ Se debe utilizar interfaces:Por ejemplo:
  - ✅ IDamageable.
  - ✅ IPickable.
- Se deben poder pickear “Coins” resultado de eliminar un enemigo, ésta debe destruirse pasado cierto
tiempo de aparecer.
