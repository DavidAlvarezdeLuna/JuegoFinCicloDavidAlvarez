VAR magiaLiberada = ""

-> start

=== start ===
{ magiaLiberada == "No": -> noMagia }
{ magiaLiberada != "No": -> siMagia }
-> END

=== noMagia ===
¡Buenos días viajero!
Te diría que hay novedades hoy, pero tú lo sabes de primera mano, parece ser. 
¿Entonces ya puedo contarte un poco sobre mí?
Verás... Mi manía de vigilar la entrada se debe a que he sido guardia de un castillo durante más años de los que podrías imaginar.
¡Mi deber es garantizar la seguridad de mi pueblo!
*** ¿Un castillo?
Si... pero la reina...
Nada, preocupaciones mías.
Me alegro de haberte conocido, viajero.
Estaría encantado de anunciar tu llegada otra vez.
-> END

=== siMagia ===
¡Buenos días viajero!
Te diría que hay novedades hoy, pero tú lo sabes de primera mano, parece ser .
¿Entonces ya puedo contarte un poco sobre mí?
Verás... Mi manía de vigilar la entrada se debe a que he sido guardia de un castillo durante más años de los que podrías imaginar.
¡Mi deber es garantizar la seguridad de mi pueblo!
*** ¿Un castillo?
¡Si! Y te doy mi más sincera gratitud por recuperar a nuestra reina.
¡Eres un heroe, uno de esos de los libros que los humanos hoy en día consideran de fantasía!
Me alegro de haberte conocido, viajero.
Estaría encantado de anunciar tu llegada otra vez.
-> END

=== After ===
Me alegro de haberte conocido, viajero.
Estaría encantado de anunciar tu llegada otra vez.
-> END




