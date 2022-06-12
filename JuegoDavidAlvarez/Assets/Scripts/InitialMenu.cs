using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Firestore;
using Firebase.Extensions;

public class InitialMenu : MonoBehaviour
{
    private GameObject decisionManager;
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;    
    public FirebaseUser User;
    FirebaseFirestore db;

    [SerializeField] private GameObject textUsu;
    [SerializeField] private GameObject textPass;
    [SerializeField] private GameObject errMessage;
    [SerializeField] GameObject buttonsContainer;

    private bool registroUsu = false;
    private bool loginUsu = false;
    private bool canLoadScene = false;
    private bool cargarResultados = false;
    private bool errorRegistro = false;
    private bool errorLogin = false;

    [SerializeField] private GameObject panelNoVer;
    [SerializeField] private GameObject resultadosPanel;
    

    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        decisionManager = GameObject.FindWithTag("DecisionManager");
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
                //Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(registroUsu || loginUsu)
        {
            textUsu.GetComponent<Text>().text = "";
            textPass.GetComponent<Text>().text = "";
            abrirMenuUsuario();
            if(registroUsu)
            {
                createDocument();
            }
            decisionManager.GetComponent<DecisionManager>().usuActual = textUsu.GetComponent<Text>().text;
            
            registroUsu = false;
            loginUsu = false;
            errMessage.transform.GetChild(0).GetComponent<Text>().text = "Usuario: "+decisionManager.GetComponent<DecisionManager>().usuActual;
        }

        if(canLoadScene)
        {
            canLoadScene = false;
            if(decisionManager.GetComponent<DecisionManager>().sceneActual != 6)
            {
                loadDocument();
                SceneManager.LoadSceneAsync("Scene" + decisionManager.GetComponent<DecisionManager>().sceneActual);
            }
            else
            {
                errMessage.transform.GetChild(0).GetComponent<Text>().text = "Partida finalizada. Selecciona Nueva partida para comenzar una nueva";
            }
            //Debug.Log("Scene"+decisionManager.GetComponent<DecisionManager>().sceneActual); 
        }

        if (cargarResultados)
        {
            cargarResultados = false;
            if (decisionManager.GetComponent<DecisionManager>().sceneActual != 6)
            {
                panelNoVer.gameObject.SetActive(true);
            }
            for(int i=0; i<decisionManager.GetComponent<DecisionManager>().listaValores.Count; i++)
            {
                resultadosPanel.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = decisionManager.GetComponent<DecisionManager>().listaValores[i].ToString();
            }
            resultadosPanel.gameObject.SetActive(true);
        }

        if (errorRegistro)
        {
            errorRegistro = false;
            errMessage.transform.GetChild(0).GetComponent<Text>().text = "Error. El usuario ya existe";
        }

        if (errorLogin)
        {
            errorLogin = false;
            errMessage.transform.GetChild(0).GetComponent<Text>().text = "Error. Usuario o contraseña incorrecto";
        }
    }

    void Awake()
    {

    }

    private void InitializeFirebase()
    {
        //Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
    }

    public void loginUser([SerializeField] GameObject buttonsContainer)
    {
        mainCamera.GetComponent<clickSound>().playClickSound();

        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(textUsu.GetComponent<Text>().text, textPass.GetComponent<Text>().text).ContinueWith(task => {
        if (task.IsCanceled) {
            errorLogin = true;
            //Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
            return;
        }
        if (task.IsFaulted) {
            errorLogin = true;
            //Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
            return;
        }

        if(task.IsCompleted)
        {
            Debug.Log(loginUsu);
            loginUsu = true;
            
            Debug.Log(loginUsu);
            errMessage.transform.GetChild(0).GetComponent<Text>().text = "Sesión iniciada con éxito";
        }

        Firebase.Auth.FirebaseUser newUser = task.Result;
        //Debug.LogFormat("User signed in successfully: {0} ({1})",
            //newUser.DisplayName, newUser.UserId);
        });

    }

    public void registerUser()
    {
        mainCamera.GetComponent<clickSound>().playClickSound();

        if (textUsu.GetComponent<Text>().text.Length > 0 && textPass.GetComponent<Text>().text.Length >= 8)
        {
            FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(textUsu.GetComponent<Text>().text, textPass.GetComponent<Text>().text).ContinueWith(task => {
            if (task.IsCanceled) {
                errorRegistro = true;
                //Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                errorRegistro = true;
                //Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            if(task.IsCompleted)
            {
                registroUsu = true;
                errMessage.transform.GetChild(0).GetComponent<Text>().text = "Registrado con éxito";
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            //Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                //newUser.DisplayName, newUser.UserId);
                
            });

        }
        else
        {
            errMessage.transform.GetChild(0).GetComponent<Text>().text = "El usuario debe ser un correo y la contraseña tener al menos 8 caracteres";
        }
    }

    public void logoutUser([SerializeField] GameObject buttonsContainer)
    {
        mainCamera.GetComponent<clickSound>().playClickSound();

        errMessage.transform.GetChild(0).GetComponent<Text>().text = "";
        abrirMenuLogin();
    }

    public void nuevaPartida()
    {
        mainCamera.GetComponent<clickSound>().playClickSound();
        SceneManager.LoadSceneAsync("Scene1");
    }

    public void salirJuego()
    {
        mainCamera.GetComponent<clickSound>().playClickSound();
        //Salir del juego
        Debug.Log("SALIR DEL JUEGO");
        Application.Quit();

        //Salir del editor, version ordenador
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void abrirPanel([SerializeField] GameObject panel)
    {
        mainCamera.GetComponent<clickSound>().playClickSound();

        if (panel.tag == "creditosPanel")
        {
            panel.SetActive(true);
        }
        
        if(panel.tag == "resultadosPanel")
        {
            db = FirebaseFirestore.DefaultInstance;
            DocumentReference docRef = db.Collection("Registro").Document(decisionManager.GetComponent<DecisionManager>().usuActual);
            docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
            {
                DocumentSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    Debug.Log("Document data for " + snapshot.Id + " document:");
                    Dictionary<string, object> reg = snapshot.ToDictionary();
                    foreach (KeyValuePair<string, object> pair in reg)
                    {
                        if (pair.Key != "sceneActual")
                        {
                            //Debug.Log(pair.Key + ": " + pair.Value);
                            decisionManager.GetComponent<DecisionManager>().listaValores[decisionManager.GetComponent<DecisionManager>().listaVariables.IndexOf(pair.Key)] = pair.Value.ToString();
                            Debug.Log(pair.Key + ": " + pair.Value + " cargado");
                            if (pair.Key == "conejitosEncontrados")
                            {
                                decisionManager.GetComponent<DecisionManager>().conejitosEncontrados = int.Parse(pair.Value.ToString());
                            }
                        }
                        else
                        {
                            decisionManager.GetComponent<DecisionManager>().sceneActual = int.Parse(pair.Value.ToString());
                        }

                    }                
                    cargarResultados = true;
                }
                else
                {
                    //Debug.Log("Document " + snapshot.Id + " does not exist!");
                }
            });
        }
        
    }

    public void cerrarPanel([SerializeField] GameObject panel)
    {
        mainCamera.GetComponent<clickSound>().playClickSound();
        panel.SetActive(false);

        if(panel.tag == "resultadosPanel")
        {
            panelNoVer.gameObject.SetActive(false);
        }
    }

    public void abrirMenuUsuario()
    {
        for (int i=0; i<buttonsContainer.transform.childCount; i++)
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

    public void abrirMenuLogin()
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

    public void createDocument()
    {
        db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("Registro").Document(textUsu.GetComponent<Text>().text);
        Dictionary<string, object> reg = new Dictionary<string, object>
        {
            { "sceneActual", "1" },
            { "huevoGallina", "" },
            { "marMontania", "" },
            { "targetHit", "0" },
            { "guardaSecreto", "" },
            { "conejitosEncontrados", "0" },
            { "hablaViejaEscena2", "No" },
            { "sirenaHablaPirata", "No" },
            { "superadasDuplicator", "" },
            { "zombiesHit", "0" },
            { "magiaLiberada", "No" }

        };
        docRef.SetAsync(reg).ContinueWithOnMainThread(task => {
                //Debug.Log("Saved user in database");
        });
    } 

    public void loadDocument()
    {
        db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("Registro").Document(decisionManager.GetComponent<DecisionManager>().usuActual);
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
        DocumentSnapshot snapshot = task.Result;
        if (snapshot.Exists) 
        {
            //Debug.Log("Document data for "+ snapshot.Id+" document:");
            Dictionary<string, object> reg = snapshot.ToDictionary();
            foreach (KeyValuePair<string, object> pair in reg) 
            {
                if(pair.Key != "sceneActual")
                {
                    //Debug.Log(pair.Key + ": "+ pair.Value);
                    decisionManager.GetComponent<DecisionManager>().listaValores[decisionManager.GetComponent<DecisionManager>().listaVariables.IndexOf(pair.Key)] = pair.Value.ToString();
                    Debug.Log(pair.Key + ": "+ pair.Value + " cargado");
                    if(pair.Key == "conejitosEncontrados")
                    {
                        decisionManager.GetComponent<DecisionManager>().conejitosEncontrados = int.Parse(pair.Value.ToString());
                    }
                }
                else
                {
                    decisionManager.GetComponent<DecisionManager>().sceneActual = int.Parse(pair.Value.ToString());
                }
            }
            canLoadScene = true;
        } 
        else 
        {
            //Debug.Log("Document "+snapshot.Id+" does not exist!");
        }
        });
    } 

}
