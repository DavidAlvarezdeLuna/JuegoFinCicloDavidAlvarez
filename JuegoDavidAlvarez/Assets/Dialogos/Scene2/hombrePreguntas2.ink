VAR guardaSecreto = ""

Digamos que un joven roba una barra de pan de una panaderia.
Tu descubres al joven, el cual, apurado, te explica que no tiene dinero y su hermana se esta muriendo de hambre
¿Dime, que harias en esa situación?
*** Delataria al joven
-> opcion1
*** Lo dejaria pasar, me da pena
-> opcion2
*** No me fio, puede que me este engañando
-> opcion3
*** Pagaria yo la barra de pan
-> opcion4

=== opcion1 ===
¿Asi, sin mas? ¿Tu crees que eso es justicia?
***Si lo permitimos, habra mas robos
-> opcion1_1
***La panadería pierde por el robo
-> opcion1_2
***El joven debería haberlo hablado
-> opcion1_3

=== opcion2 ===
~guardaSecreto = "Si"
Entiendo... Eres una persona bondadosa
Como todo, tiene sus defectos y sus virtudes, pero es bonito confiar
-> continue

=== opcion3 ===
Tambien puede que diga la verdad
***Tienes razon
-> opcion3_1
***Ojalá todo fuera tan sencillo
-> opcion3_2

=== opcion4 ===
~guardaSecreto = "Si"
Oh... Sorprendente respuesta, me gusta
De esa forma le concederias otra oportunidad
-> continue

=== opcion1_1 ===
~guardaSecreto = "No"
Entiendo... No te dire que es incorrecto, pero aun asi...
-> continue

=== opcion1_2 ===
~guardaSecreto = "No"
No creo que una barra de pan suponga la diferencia para la familia de la panadería, pero si para esos dos pobres
-> continue

=== opcion1_3 ===
~guardaSecreto = "Si2"
Interesante... Crees que existe una solucion que beneficie mas a todos...
-> continue

=== opcion3_1 ===
~guardaSecreto = "Si2"
Creo que lo mas importante es escuchar y conocer cada caso, para obrar de la mejor forma posible, en beneficio de todos
Aunque en algunos casos sea una utopia...
-> continue

=== opcion3_2 ===
~guardaSecreto = "No"
Por esa misma razón deberías darle la oportunidad... creo que no tenemos el mismo punto de vista
...
-> continue

=== continue ===
Ya veo, ya veo...
Bueno, esta pregunta era mas complicada que la de ayer, ¿No te parece?
Ah, y antes de que se me olvide
¡Buenos días viajero!
-> END


=== After ===
Bueno, esta pregunta era mas complicada que la de ayer, ¿No te parece?
Ah, y antes de que se me olvide
¡Buenos días viajero!
-> END