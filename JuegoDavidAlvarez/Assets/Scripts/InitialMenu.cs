using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InitialMenu : MonoBehaviour
{

    //[SerializeField] private GameObject creditosPanel;
    //[SerializeField] private GameObject resultadosPanel;

    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;    
    public FirebaseUser User;

    [SerializeField] private GameObject textUsu;
    [SerializeField] private GameObject textPass;
    [SerializeField] private GameObject errMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
    }

    public void loginUser([SerializeField] GameObject buttonsContainer)
    {
        //COMPROBAR SI EL USUARIO Y LA CONTRASEÑA EXISTEN EN FIREBASE
        //LO TENDRE ALMACENADO HASTA QUE SE CAMBIE

        for(int i=0; i<buttonsContainer.transform.childCount; i++)
        {
            if(buttonsContainer.transform.GetChild(i).gameObject.tag == "meterUsuario")
            {
                buttonsContainer.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                buttonsContainer.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public void registerUser([SerializeField] GameObject buttonsContainer)
    {
        //INTRODUCIR EN FIREBASE EL USUARIO NUEVO
        //LO TENDRE ALMACENADO HASTA QUE SE CAMBIE

        //if(textUsu.GetComponent<Text>().text.Length > 0 && textPass.GetComponent<Text>().text.Length >= 8)
        //{
            //var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(textUsu.GetComponent<Text>().text, textPass.GetComponent<Text>().text);
            //Wait until the task completes
            //yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            //User = RegisterTask.Result;

            for(int i=0; i<buttonsContainer.transform.childCount; i++)
            {
                if(buttonsContainer.transform.GetChild(i).gameObject.tag == "meterUsuario")
                {
                    buttonsContainer.transform.GetChild(i).gameObject.SetActive(false);
                }
                else
                {
                    buttonsContainer.transform.GetChild(i).gameObject.SetActive(true);
                }
            }  
        //}
        //else
        //{
        //    errMessage.GetComponent<Text>().GetComponent<Text>().text = "ERROR";
        //}

    }

    public void logoutUser([SerializeField] GameObject buttonsContainer)
    {
        for(int i=0; i<buttonsContainer.transform.childCount; i++)
        {
            if(buttonsContainer.transform.GetChild(i).gameObject.tag == "meterUsuario")
            {
                buttonsContainer.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                buttonsContainer.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void nuevaPartida()
    {
        //SI EXISTIA EL USUARIO, PONER LAS VARIABLES EN SUS VALORES INICIALES (EN REALIDAD SIEMPRE SE PONDRAN LOS VALORES INICIALES)
        SceneManager.LoadSceneAsync("Scene1");
    }

        public void cargarPartida()
    {
        //COMPROBAR SI EL USUARIO Y LA CONTRASEÑA INTRODUCIDOS COINCIDEN CON LA BASE DE DATOS
        //SI NO COINCIDEN
            //LANZAR MENSAJE DE ERROR
        //SI COINCIDEN
            //CARGAR LAS VARIABLES ALMACENADAS EN FIREBASE, DEL USUARIO, EN EL SCENEMANAGER
            //SceneManager.LoadSceneAsync(decisionManager.GetComponent<DecisionManager>().sceneActual);

    }

    public void salirJuego()
    {
        //Salir del juego
        Application.Quit();

        //Salir del editor, version ordenador
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void abrirPanel([SerializeField] GameObject panel)
    {
        panel.SetActive(true);
    }

    public void cerrarPanel([SerializeField] GameObject panel)
    {
        panel.SetActive(false);
    }


}
