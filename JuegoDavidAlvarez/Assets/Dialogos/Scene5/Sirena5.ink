VAR sirenaHablaPirata = ""

-> start

=== start ===
{ sirenaHablaPirata == "No": -> noSirena }
{ sirenaHablaPirata != "No": -> siSirena }
->END


=== noSirena ===
Hola, buenos días...
Parece que no has dormido esta noche...
...
Muchas gracias por pasar estos días aqui
...
¿Te vas ya? Que lástima...
...
...
***Ha sido un placer conocerte
¡Espera!
No se si he podido disimular muy bien... Porque necesito vivir en el agua... Soy una sirena
Fuí la última en llegar aquí, antes de que tu vinieras
Me trajo el pirata cuando me conoció...
He oido que en las historias que os cuentas dicen que nuestro canto son malas noticias
¡Pero no todas las sirenas somos así!
...
Perdona... Es algo que siempre he querido decir a un humano...
Me enrollo... Quería decirte que me gustaría volver a verte...
-> END

=== siSirena ===
Hola, buenos días...
Parece que no has dormido esta noche...
...
Muchas gracias por pasar estos días aqui
...
¿Te vas ya? Que lástima...
...
...
***Ha sido un placer conocerte
¡Espera!
No se si he podido disimular muy bien... Porque necesito vivir en el agua... Soy una sirena
Fuí la última en llegar aquí, antes de que tu vinieras
Me trajo el pirata cuando me conoció...
Nos habíamos distanciado un poco, pero yo quería volver a hablar con él... Te lo agradezco mucho
He oido que en las historias que os cuentas dicen que nuestro canto son malas noticias
¡Pero no todas las sirenas somos así!
...
Perdona... Es algo que siempre he querido decir a un humano...
Me enrollo... Quería decirte que me gustaría volver a verte...
-> END

=== After ===
Quería decirte que me gustaría volver a verte...
-> END