VAR conejitosEncontrados = ""

-> start

=== start ===
¡Hombre tio, que pasa!
¡Te ha comido la lengua el conejo, o que pasa!
Por fin puedo abrir la boca, y no hacer ese ruidito, chaval
¡AHEM! Me presento
Soy el conejito, pero no como los de tu mundo, esos no son inteligentes...
Mi especie es superior, ¡Hasta nos ponemos camisetas molonas!
Te dijo la chavala esa que me buscaras, ¡La verdad es que el escondite es la caña!

{ conejitosEncontrados == 0 : -> conejitos0 }
{ conejitosEncontrados == 1 : -> conejitos1 }
{ conejitosEncontrados == 2 : -> conejitos2 }
{ conejitosEncontrados == 3 : -> conejitos3 }
{ conejitosEncontrados == 4 : -> conejitos4 }
->END


=== conejitos0 ===
Y has pasado de mi, que me den ganas de llorar, asi te lo digo
Ale, pues si quieres volver a buscarme, porque no me vas a encontrar, aqui estaré
-> END

=== conejitos1 ===
Y te ha dado para presentarte y nada mas, vaya modales
Ale, pues si quieres volver a buscarme, porque no me vas a encontrar, aqui estaré
-> END

=== conejitos2 ===
Pero me parece que he ganado yo, ¡TOMA YA!
Ale, pues si quieres volver a buscarme, porque no me vas a encontrar, aqui estaré
-> END

=== conejitos3 ===
No me encontraste una vez, bien jugado
Ale, pues si quieres volver a buscarme, porque no me vas a encontrar, aqui estaré
-> END

=== conejitos4 ===
¡Pero siempre me encuentras, tio! Y yo que pensaba que esconderme detrás del banco era la mejor idea que habia tenido....
Ale, pues si quieres volver a buscarme, porque no me vas a encontrar, aqui estaré
-> END

=== After ===
Ale, pues si quieres volver a buscarme, porque no me vas a encontrar, aqui estaré
-> END