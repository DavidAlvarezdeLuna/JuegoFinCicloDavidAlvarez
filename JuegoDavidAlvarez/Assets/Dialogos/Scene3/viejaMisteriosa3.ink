VAR hablaViejaEscena2 = ""

Oooh... *cough, cough*
...
...
Eres tú...

-> start

=== start ===
{ hablaViejaEscena2 == "No": -> noConfia }
{ hablaViejaEscena2 != "No": -> siConfia }
->END

=== noConfia ===
No viniste a verme ayer...
No cumpliste con tu palabra...
***Lo siento, lo olvidé, podemos hablar ahora
-> noConfia2
Ahora... no estoy bien, no te puedo prestar atención...
-> END

=== noConfia2 ===
***¿Puedo hacer algo por usted?
No... No te preocupes, céntrate en tus cosas...
-> noConfia3

=== noConfia3 ===
***Aun no sé nada de esa mujer que me pidio ayuda...
Tal vez sea demasiado tarde para ayudarle...
Mi tiempo se acaba, me temo...

-> END

=== siConfia ===
Aún estas aquí...
Te agradezco que hablaras conmigo ayer...
Tu historia es muy interesante... Yo creo que dices la verdad... Me la contaste aunque parezca inverosímil...
Eso te honra...
La magia... Se esta acabando... Mi fin esta cerca...
***¿Puedo hacer algo por usted?
Alcanza el centro, las profundidades... Anular es la clave para liberar, al mundo de las maldades.
...
Mi tiempo se acaba, me temo...
-> END

=== After ===
Oooh... *cough, cough*
...
-> END