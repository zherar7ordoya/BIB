/*

--------------------
NOTAS SOBRE HERENCIA
--------------------

Inheritance is not code-sharing
===============================
Si solo se trata de compartir código, ponlo en una librería (o clase) separada y
referéncialo.

Is-a relationship
=================
Esta relación tiene que tener sentido. Se dice que gato «is-a» animal. Pero si
vamos por el lado de lugar donde pongo personas, entonces auto «is-a casa» (lo
cual sí tiene sentido si estamos hablando de «lugar donde pongo gente», pero
deja de tenerlo si estamos hablando de «lugar donde duerme gente»).

Need to share common logic
==========================
No solo propiedades, no solo nombre de métodos, sino lógica común. De otro modo,
pierde sentido, y entonces, ¿para qué heredar?

Sharing just properties or method signtures is not enough
=========================================================
(Ver punto anterior) Por ejemplo, si todas las clases hijas tienen un método con
la misma firma, pero diferente implementación (lo cual implica la sobreescritura
del método), entonces se hizo código que no aportó valor alguno.

Inheritance can put you in a corner
===================================
Si se empieza a transitar el camino de la herencia, llegará un momento en que ya
no se podrá seguir estirando la relación «is-a». Ésta es una lección dolorosa
porque no se ve venir la situación hasta que ya es tarde: aunque al principio
tenía sentido, luego la relación no se puede estirar porque ya no es lógica.
(Ver segundo punto).

You need to ask the question: WHAT IS THE POINT?
================================================
¿Cuál es el sentido de hacer ésta herencia? ¿Qué se gana con ella? Si solo se
trata de compartir propiedades y firma de métodos, entonces no tiene sentido, 
solo nos arrincona en que no agrega nada de valor y sí complica el código.

*/
using System.Collections.Generic;

namespace BetterOODemo
{
    class Program
    {
        static void Main()
        {
            List<IRental> rentals = new()
            {
                new Truck() { CurrentRenter = "Truck Renter" },
                new Sailboat() { CurrentRenter = "Sailboat Renter" },
                new Car() { CurrentRenter = "Car Renter" }
            };

            foreach (var r in rentals)
            {
                if (r is Truck t)
                {
                    
                }

            }
        }
    }
}
