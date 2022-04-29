VAR armaMinijuego = ""

-> start

=== start ===
¡¡Bonjour!!
¡Bienvenido a mi tiendecilla!
(Venga, cuéntale de que va esto)
Un duendecillo me paso el negocio, sabes... ¡Soy la jefa!
¡Mira mira, vendo cosas muy chulas!
***Muy bien, compraré algo
Asi me gusta
->continue

***Bueno, por mirar...
Vaya hombre, que soso
(Cuidado, no debo perder al cliente)
-> continue

=== continue ===
(Espera un momento...)
Bueno, vamos a hacer una cosa, ¿Ok?
Vamos a jugar a una cosa que a mi... ¡ME ENCANTA!
El objetivo del juego es disparar a los objetivos que aparecen. Son 30 en total. ¡A ver cuantos destruyes!
Venga, elige el arma que vas a usar. Son todas de juguete, que lo sepas
***La pistola
-> pistola

***La varita
-> varita

=== pistola ===
~armaMinijuego = "Pistola"
Has elegido la pistola, que practico
-> continue2

=== varita ===
~armaMinijuego = "Varita"
Has elegido la varita, que magico
-> continue2

=== continue2 ===
Pues great, ¡Ya puedes jugar!
Toca el puestecillo para empezar
-> END

=== After ===
El objetivo del juego es disparar a los objetivos que aparecen. Son 30 en total. ¡A ver cuantos destruyes!
Toca el puestecillo para empezar
-> END

