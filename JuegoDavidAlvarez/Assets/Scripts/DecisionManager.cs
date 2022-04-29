using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionManager : MonoBehaviour
{
    //public string[] listaVariables = ["huevoGallina","marMontania"];
    //public string[] listaValores = ["",""];
    ArrayList listaVariables = new ArrayList();
    ArrayList listaValores = new ArrayList();
    
    //0
    public string huevoGallina = "";
    //hombrePreguntas, escena 1
    //Opciones: Huevo, Gallina

    //1
    public string marMontania = "";
    //pirata, escena 1
    //Opciones: Mar, Montania

    //2
    public int targetHit = 0;
    //chicaTienda, escena2
    //numero de dianas golpeadas en el minijuego

    //3
    public string guardaSecreto = "";
    //hombrPreguntas, escena2
    //Opciones: Si, Si2, No
    //Si2 es que le convenciste pero necesitaste argumentar mas que la pregunta inicial

    //4
    public int conejitosEncontrados = 0;
    //conejitos, varias escenas
    //Numero de veces que interactuas con un conejito

    //5
    public string hablaViejaEscena2 = "No";
    //viejaMisteriosa, escena2
    //Cambia a si si hablas con la viejaMisteriosa en la escena2

    void Start()
    {
        listaVariables.Add("huevoGallina"); //0
        listaVariables.Add("marMontania"); //1
        listaVariables.Add("targetHit"); //2
        listaVariables.Add("guardaSecreto"); //3
        listaVariables.Add("conejitosEncontrados"); //4
        listaVariables.Add("hablaViejaEscena2"); //4

        listaValores.Add("");
        listaValores.Add("");
        listaValores.Add("");
        listaValores.Add("");
        listaValores.Add("");
        listaValores.Add("No");
    }


    public void actualizarValor(string nom, string valor)
    {
        this.listaValores[listaVariables.IndexOf(nom)] = valor;
        for(int i = 0; i<listaValores.Count; i++)
        {
            Debug.Log("El decisionManager tiene "+listaVariables[i].ToString()+": "+listaValores[i].ToString());
        }
    }

    //Funcion que devuelve el valor de la variable solicitada
    public string getValue(string nom)
    {
        Debug.Log("el getValue del decisionManager devuelve "+this.listaValores[listaVariables.IndexOf(nom)].ToString());
        return this.listaValores[listaVariables.IndexOf(nom)].ToString();
    }

}
