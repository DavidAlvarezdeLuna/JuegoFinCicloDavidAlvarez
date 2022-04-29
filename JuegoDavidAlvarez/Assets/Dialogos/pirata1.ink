VAR marMontania = ""

-> decision

=== decision ===
¡Hey, un nuevo tripulante en este barco!
¡¡QUE HAY GRUMETE!!
¡¡Soy el pirata!!
¡He viajado en barco por TOODO el mundo!
¿¡Te gusta el mar, calamar!?
*** Si, me encanta la playa
-> knot_1
*** No, soy mas de montaña
-> knot_2

=== knot_1 ===
~marMontania = "Mar"
¡¡Mira, como yo!!
-> continuar

=== knot_2 ===
~marMontania = "Montania"
¡Porque no lo has observado lo suficiente!
-> continuar

=== continuar ===
¿Te quedas a pasar la noche? ¡ESTUPENDO!
¡¡QUE PASES UNA BUENA NOCHE!!
-> END

=== After ===
¿Te quedas a pasar la noche? ¡ESTUPENDO!
¡¡QUE PASES UNA BUENA NOCHE!!
-> END