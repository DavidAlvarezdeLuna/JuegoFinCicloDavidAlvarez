using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InitialMenu : MonoBehaviour
{

    //[SerializeField] private GameObject creditosPanel;
    //[SerializeField] private GameObject resultadosPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

        //Salir del editor
        UnityEditor.EditorApplication.isPlaying = false;
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
