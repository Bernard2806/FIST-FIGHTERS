Escuela Tecnica Nº1 "Mariano Moreno" - 7toB 

![Logo de la Escuela](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQTekzz0AyAqjoSEVvnl6EIGzfdFfNvRRgTia4tJGoruA&s)

- Alumno: Bernardo Andrés, González Erramuspe
- Curso: 7ºB

---
# Practica de Clases en Consola 1
Actividades:
- Cambiar de color, el usuario tambien deberá ingresar el color al que desea cambiar
- Recibir daño, el usuario tambien deberá ingresar la fuerza del daño recibido
- Atacar, suponiendo que el usuario controla al primer jugardor, deberá atacar al jugador 2
---
# Práctica de Clases en Consola 2
Actividades:

En base a la actividad anterior vamos a agregarle a nuestros jugadores la posibilidad de usar pociones de curación, ya sea de vida o mana.

En primer lugar vamos a crear una Clase que represente nuestra Poción, pero vamos a utilizar herencia. Una poción va a curar vida, mientras que la otra va a curar mana.

Nuestra poción base (de las cuales van a heredar las de Vida y Mana) van a tener los siguientes atributos: “Mínimo” y “Máximo”. Mientras que van a tener el siguiente método “Usar” que va a recibir un Personaje y curar en consecuencia (ya sea Vida o Mana). La forma de curar es aleatoria en base al mínimo y máximo que cura la poción. Las pociones no pueden curar más del máximo de vida o mana inicial de los personajes.

En nuestro menú vamos a agregar una opción nueva para dar una poción (vida o mana) a alguno de los dos personajes. En ese momento se nos pide que tipo de poción vamos a darle y el mínimo y máximo que va a curar. Luego mostrará el total curado al personaje.
---
# Agregar inventario
En base a la actividad anterior vamos a agregarle a nuestros jugadores la posibilidad de tener un inventario donde podrán guardar sus pociones para consumirlas posteriormente.

Teniendo en cuenta en el diagrama adjunto y lo visto en la clase anterior:
- Crear la clase abstracta Item
- Crear la clase Inventario
   Implementar el método AgregarItem
   Implementar el método QuitarItem
- Modificar la herencia de la clase pocion para que sea hija de Item
- Modificar el método CrearPersonaje para que cree un inventario
- Modificar el método CrearPersonaje para que el usuario puede elegir una opción para guardar en el inventario del personaje
- Modificar el método MostrarPersonaje para que muestre los ítems del inventario
- Modificar tomar poción para que tome las pociones del inventario
