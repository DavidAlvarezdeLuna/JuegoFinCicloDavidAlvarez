VAR huevoGallina = ""

-> decision

=== decision ===
Cual fue primero, ¿El huevo o la gallina?
*** El huevo
-> knot_1
*** La gallina
-> knot_2

=== knot_1 ===
~huevoGallina = "Huevo"
Aja... ya veo
-> continuar

=== knot_2 ===
~huevoGallina = "Gallina"
Aja... ya veo
-> continuar

=== continuar ===
{ huevoGallina == "Huevo": Huevo dices...}
{ huevoGallina == "Gallina": Entonces la gallina...}
Perdona, no lo puedo evitar
Me dedico a investigar... muchas cosas
Encantado de conocerte, viajero
Si necesitas algo, no dudes en pedirme ayuda
¡Adios!
-> END

=== After ===
-> continuar
-> END