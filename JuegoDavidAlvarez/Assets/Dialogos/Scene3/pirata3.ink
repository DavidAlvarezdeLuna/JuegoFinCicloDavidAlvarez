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
No te habia visto
Hoy tengo el dia libre, estaba buscando al pececillo que se baña aqui, ¿Sabes quien te digo?
Me pareció verte hablar con ella ayer, ¿Te dijo donde iba a estar hoy? ¿No?
Vaya, lástima... Bueno, no te preocupes, solo queria charlar, no es nada importante
¡ADIOS!
-> END

=== conSirena ===
lalala... hoy toca descansaaaaarrrr
Mi barco cuidarrrr, lalalalaaaa
¿Hola grumete, que hay?
Hoy tengo el dia libre
Mira, ha venido este pececito a hablar conmigo hoy
Me ha dicho que a veces soy muy ruidoso, tengo que tener cuidado con eso
Tengo que intentar hacer menos ruido, shhh...
Adios
-> END

=== After ===
Adios calamarcillo, que pases un buen día
-> END