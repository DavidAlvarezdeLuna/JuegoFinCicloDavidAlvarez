VAR marMontania = ""

-> decision

=== decision ===
¡Hey, un nuevo tripulante en este barco!
¡¡QUE HAY GRUMETE!!
¡¡Soy pirata!!
¡He viajado en barco por TOOOODO el mundo!
¿¡Te gusta el mar, calamar!?
*** Sí, me encanta la playa
-> knot_1
*** No, soy más de montaña
-> knot_2

=== knot_1 ===
~marMontania = "Mar"
¡¡Mira, un animalillo de mar, como yo!!
-> continuar

=== knot_2 ===
~marMontania = "Montania"
¡Porque no lo has observado lo suficiente! El romper de las olas, el olor a sal... ¡EN FIN!
-> continuar

=== continuar ===
¿Te quedas a dormir en los camarotes de este pueblo? ¡ESTUPENDO!
¡¡QUE PASES UNA BUENA NOCHE!!
-> END

=== After ===
¿Te quedas a dormir en los camarotes de este pueblo? ¡ESTUPENDO!
¡¡QUE PASES UNA BUENA NOCHE!!
-> END