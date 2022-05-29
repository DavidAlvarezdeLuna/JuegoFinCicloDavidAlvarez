VAR conejitosEncontrados = ""

-> start

=== start ===
Hola
He sentido la magia esta noche... Me despertó, ¿sabes?
Fuiste tú, lo se, noté como como te desplazabas poco antes de dormirme
Me han pedido que te hable de esos zombies... Bueno, no son zombies en realidad
Parece ser que nuestros ancestros los colocaron como parte de la prueba para liberar la magia
Pero nunca tuvieron vida, te lo aseguro. Son muñecos imbuidos con magia, que cumplen la función que se les designó
...
¿Te preguntas porque te digo yo todo esto?
La respuesta es que tengo una sensibilidad especial a la energía... Puedo notaros a todos los que estais alrededor...
Siento vuestra energía, vuestra magia... Y he de decir que tú espíritu se ha enriquecido con esta experiencia
***Si, he descubierto que tener fe no es un error
Me alegro
También te quería decir que te menti, ¡Perdón!
Siempre se donde está el conejito, porque detecto su energía

{ conejitosEncontrados == 0 : -> conejitos01 }
{ conejitosEncontrados == 1 : -> conejitos01 }
{ conejitosEncontrados == 2 : -> conejitos23 }
{ conejitosEncontrados == 3 : -> conejitos23 }
{ conejitosEncontrados == 4 : -> conejitos4 }
->END


=== conejitos01 ===
No le has hecho mucho caso... Pobrecito
En fin, no pasa nada, yo jugaré con él
¡ADIOS!
-> END

=== conejitos23 ===
Lo has encontrado bastante días, ¡Bien hecho!
Yo seguiré jugando con el, no te preocupes 
¡ADIOS!
-> END

=== conejitos4 ===
Lo has encontrado todos los días, ¡Fantástico!
Yo seguiré jugando con el, no te preocupes
Pero te va a echar de menos, lo noto en su aura...
¡ADIOS!
-> END

=== After ===
¡ADIOS!
-> END