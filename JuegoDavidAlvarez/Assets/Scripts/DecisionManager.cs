using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;


public class DecisionManager : MonoBehaviour
{
    //public string[] listaVariables = ["huevoGallina","marMontania"];
    //public string[] listaValores = ["",""];
    FirebaseFirestore db;
    public string usuActual = "";
    public int sceneActual = 1;
    public ArrayList listaVariables = new ArrayList();
    public ArrayList listaValores = new ArrayList();
    
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

    //6
    public string sirenaHablaPirata = "No";
    //Pirata, escena3
    //Cambia si hablas primero con la sirena o el pirata en la escena3

    //7
    public string superadasDuplicator = "";
    //juego Duplicator, escena3
    //fases superadas en el juego del duplicator

    //AQUI SE AÑADEN LAS VARIABLES


    public static DecisionManager Instance;

    private void Awake() 
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;

        listaVariables.Add("huevoGallina"); //0
        listaVariables.Add("marMontania"); //1
        listaVariables.Add("targetHit"); //2
        listaVariables.Add("guardaSecreto"); //3
        listaVariables.Add("conejitosEncontrados"); //4
        listaVariables.Add("hablaViejaEscena2"); //5
        listaVariables.Add("sirenaHablaPirata"); //6
        listaVariables.Add("superadasDuplicator"); //7
        

        listaValores.Add("");
        listaValores.Add("");
        listaValores.Add("0");
        listaValores.Add("");
        listaValores.Add("0");
        listaValores.Add("No");
        listaValores.Add("No");
        listaValores.Add("");
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

    public void updateDatabase()
    {
        DocumentReference usuRef = db.Collection("Registro").Document(usuActual);
        db.RunTransactionAsync(transaction =>
            {
                return transaction.GetSnapshotAsync(usuRef).ContinueWith((snapshotTask) =>
                {
                    DocumentSnapshot snapshot = snapshotTask.Result;
                    //long newPopulation = snapshot.GetValue<long>("Population") + 1;
                    Dictionary<string, object> updates = new Dictionary<string, object>
                    {   
                        { "sceneActual", sceneActual.ToString() },
                        { "huevoGallina", this.listaValores[listaVariables.IndexOf("huevoGallina")].ToString() },
                        { "marMontania", this.listaValores[listaVariables.IndexOf("marMontania")].ToString() },
                        { "targetHit", this.listaValores[listaVariables.IndexOf("targetHit")].ToString() },
                        { "guardaSecreto", this.listaValores[listaVariables.IndexOf("guardaSecreto")].ToString() },
                        { "conejitosEncontrados", this.listaValores[listaVariables.IndexOf("conejitosEncontrados")].ToString() },
                        { "hablaViejaEscena2", this.listaValores[listaVariables.IndexOf("hablaViejaEscena2")].ToString() },
                        { "sirenaHablaPirata", this.listaValores[listaVariables.IndexOf("sirenaHablaPirata")].ToString() },
                        { "superadasDuplicator", this.listaValores[listaVariables.IndexOf("superadasDuplicator")].ToString() }
                    };
                    transaction.Update(usuRef, updates);
                });
            });
    }

}
