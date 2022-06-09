VAR sirenaHablaPirata = ""

-> start

=== start ===
{ sirenaHablaPirata == "No": -> buscaSirena }
{ sirenaHablaPirata == "Si": -> conSirena }
->END


=== buscaSirena ===
¡LALALAAAAA, HOY TOCA DESCANSAAARRRR!
¡MI BARCO CUIDARRRR!
...
¡¡¡QUE HAY GRUMETE!!!
No te habia visto.
Hoy tengo el día libre, estaba buscando al pececillo que nada aquí, ¿Sabes quién te digo?
Me pareció verte hablar con ella ayer, ¿Te dijo donde iba a estar hoy? ¿No?
Vaya, lástima... Bueno, no te preocupes, solo quería charlar, no es nada importante
¡ADIÓS CALAMARCILLO!
-> END

=== conSirena ===
Lalala... Hoy toca descansaaaaarrrr.
Mi barco cuidarrrr, lalalalaaaa.
¿Hola grumete, qué hay?
Hoy tengo el dia libre.
Mira, ha venido este pececillo a hablar conmigo hoy.
Me ha dicho que a veces soy muy ruidoso, tengo que tener cuidado con eso.
Tengo que intentar hacer menos ruido, shhh...
Adiós calamarcillo.
-> END

=== After ===
Adiós calamarcillo, que pases un buen día.
-> END