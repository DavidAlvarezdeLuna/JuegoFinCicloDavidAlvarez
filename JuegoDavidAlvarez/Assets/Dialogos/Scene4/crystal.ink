VAR magiaLiberada = "No"

-> start

=== start ===
¿Qué es esto?
Es una especie de mineral, un cristal.
No parece de este mundo...
Tiene una ranura, que parece diseñada para tocarla con un dedo.
Pero, ¿Eso quiere decir que este cristal es artificial?
Debo tocarlo, ¿Pero con que dedo?
***Meñique
-> continuar
***Anular
~magiaLiberada = "Si"
->continuar
***Corazón
-> continuar
***Índice
-> continuar
***Pulgar
-> continuar

=== continuar ===
Siento... algo extraño, no lo puedo explicar.
No lo entiendo, no tiene sentido lógico.
{ magiaLiberada == "Si": Parece que esa energía fluye hacia la salida, como atraída hacia algo...}
Tengo que salir de aquí.
-> END

=== After ===
Siento... algo extraño, no lo puedo explicar.
No lo entiendo, no tiene sentido lógico.
{ magiaLiberada == "Si": Parece que esa energía fluye hacia la salida, como atraída hacia algo...}
Tengo que salir de aquí.
-> END