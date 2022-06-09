VAR armaMinijuego = ""

-> start

=== start ===
¡¡Bonjour!!
¡Bienvenido a mi tiendecilla!
(Venga, cuéntale un poco de que va ésto.)
Un duendecillo me pasó el negocio, sabes... ¡Soy la jefa!
¡Mira mira, vendo cosas muy chulas!
***Muy bien, compraré algo
Asi me gusta, ¡GRACIAS!
(¡Una sonrisa y venta asegurada, que buena soy!)
->continue

***Bueno, por mirar...
Vaya hombre, que soso.
(Cuidado, no debo perder al cliente)
-> continue

=== continue ===
(Espera un momento...)
Bueno, vamos a hacer una cosa, ¿OK?
No vas a comprar, te voy a hacer una demostración gratis de mis productos.
Vamos a jugar a una cosa que a mí... ¡ME ENCANTA!
El objetivo del juego es disparar a los objetivos que aparecen. Son 30 en total. ¡A ver cuantos destruyes!
Venga, elige el arma que vas a usar. Son todas de juguete, que lo sepas.
***La pistola
-> pistola

***La varita
-> varita

=== pistola ===
~armaMinijuego = "Pistola"
Has elegido la pistola, que práctico.
-> continue2

=== varita ===
~armaMinijuego = "Varita"
Has elegido la varita, que mágico.
-> continue2

=== continue2 ===
Pues great, ¡Ya puedes jugar, pero solo una vez, luego tengo que dejar todo limpio!
Toca el puestecillo para empezar
-> END

=== After ===
El objetivo del juego es disparar a los objetivos que aparecen. Son 30 en total.
Toca el puestecillo para empezar.
-> END

