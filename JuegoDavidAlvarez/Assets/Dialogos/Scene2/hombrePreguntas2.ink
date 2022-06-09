VAR guardaSecreto = ""

Digamos que un joven roba una barra de pan de una panadería.
Tú descubres al joven, el cual, apurado, te explica que no tiene dinero y su hermana se está muriendo de hambre.
Dime, ¿Qué harías en esa situación?
*** Delataría al joven
-> opcion1
*** Le dejaría pasar, me da pena
-> opcion2
*** No me fio, puede que me este engañando
-> opcion3
*** Pagaría yo la barra de pan
-> opcion4

=== opcion1 ===
¿Así, sin más? ¿Tú crees que eso es justicia?
***Si lo permitimos, habrá mas robos
-> opcion1_1
***La panadería pierde por el robo
-> opcion1_2
***El joven debería haberlo hablado
-> opcion1_3

=== opcion2 ===
~guardaSecreto = "Si"
Entiendo... Eres una persona bondadosa...
Como todo, tiene sus defectos y sus virtudes, pero es bonito creer.
-> continue

=== opcion3 ===
También puede que diga la verdad
***Tienes razon
-> opcion3_1
***Ojalá todo fuera tan sencillo
-> opcion3_2

=== opcion4 ===
~guardaSecreto = "Si"
Oh... Sorprendente respuesta, ¡Me gusta!
De esa forma le concederías otra oportunidad...
-> continue

=== opcion1_1 ===
~guardaSecreto = "No"
Entiendo... No te diré que es incorrecto, pero aun así... Si eres el único que puede salvarle...
-> continue

=== opcion1_2 ===
~guardaSecreto = "No"
No creo que una barra de pan suponga la diferencia para la familia de la panadería, pero sí para esos dos jóvenes.
-> continue

=== opcion1_3 ===
~guardaSecreto = "Si2"
Interesante... Buscas una solución que agrade a todas las partes...
-> continue

=== opcion3_1 ===
~guardaSecreto = "Si2"
Creo que lo mas importante es escuchar y conocer cada caso, para obrar de la mejor forma posible, en beneficio de todos.
Aunque en algunos casos encontrar la solución sea una utopía...
-> continue

=== opcion3_2 ===
~guardaSecreto = "No"
Por esa misma razón deberías darle la oportunidad... Creo que no tenemos el mismo punto de vista.
...
-> continue

=== continue ===
Ya veo, ya veo...
Bueno, esta pregunta era mas complicada que la de ayer, ¿No te parece?
Ah, y antes de que se me olvide.
¡Buenos días viajero!
-> END


=== After ===
Bueno, esta pregunta era mas complicada que la de ayer, ¿No te parece?
Ah, y antes de que se me olvide.
¡Buenos días viajero!
-> END