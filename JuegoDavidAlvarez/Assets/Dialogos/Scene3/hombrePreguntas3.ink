VAR guardaSecreto = ""

-> start

=== start ===
{ guardaSecreto == "No": -> noConfia }
{ guardaSecreto != "No": -> siConfia }
->END

=== noConfia ===
Saludos, periodista. No me habias contado que lo eras.
Lo siento, hoy no estoy de humor para hacerte una pregunta
Estoy preocupado por nuestra... anciana. Está enfermando rápidamente
Disculpa, necesito seguir investigando
-> END

=== siConfia ===
Buenos días, viajero
Me he enterado de que eres periodista. Te voy a contar una leyenda de este lugar, con la condición de que no lo cuentes
Confío en que comprenderás la razón cuando te vayas de aqui...
Se cuenta que en esta ciudad hay un pasadizo subterraneo. En el interior de este, se encuentra una fuente de energia vital
Que fue sellada hace mas de mil años por nuestros antepasados, esperando a ser liberada cuando la magia de este mundo se empiece a agotar
LLevo un tiempo intentando encontrar ese pasadizo, pero me temo que también esta sellado.
Unos escritos antiguos detallan que para desbloquear el sello 
Es necesario que un humano que busque la verdad proyecte la magia hacia el sello...
Tengo razones para creer que el momento designado por nuestros antepasados ha llegado... Necesito dar con la clave
-> END

=== After ===
Estoy ocupado, disculpa
-> END