VAR conejitosEncontrados = ""

-> start

=== start ===
Hola.
He sentido la magia esta noche... Me despertó, ¿Sabes?
Fuiste tú, lo sé, noté como te desplazabas poco antes de dormirme.
Me han pedido que te hable de esos fantasmas... Bueno, no son fantasmas en realidad.
Parece ser que nuestros ancestros los colocaron como parte de la prueba para liberar la magia.
Pero nunca tuvieron vida, te lo aseguro. Son muñecos imbuidos con magia, que cumplen la función que se les designó.
...
¿Te preguntas por qué te digo yo todo esto?
La respuesta es que tengo una sensibilidad especial a la energía... Puedo notaros a todos los que estáis alrededor...
Siento vuestra energía, vuestra magia... Y he de decir que tú espíritu se ha enriquecido con esta experiencia.
***Si, he descubierto que tener fe no es un error
Me alegro.
También quería confesar que te mentí, ¡Perdón!
Siempre se donde está el conejito, porque detecto su aura.

{ conejitosEncontrados == 0 : -> conejitos01 }
{ conejitosEncontrados == 1 : -> conejitos01 }
{ conejitosEncontrados == 2 : -> conejitos23 }
{ conejitosEncontrados == 3 : -> conejitos23 }
{ conejitosEncontrados == 4 : -> conejitos4 }
->END


=== conejitos01 ===
No le has hecho mucho caso... Pobrecito.
En fin, no pasa nada, yo jugaré con él.
¡ADIÓS!
-> END

=== conejitos23 ===
Lo has encontrado bastantes días, ¡Bien hecho!
Yo seguiré jugando con él, no te preocupes. 
¡ADIÓS!
-> END

=== conejitos4 ===
Lo has encontrado todos los días, ¡Fantástico!
Yo seguiré jugando con él, no te preocupes.
Pero te va a echar de menos, lo noto en su aura...
¡ADIÓS!
-> END

=== After ===
¡ADIÓS!
-> END