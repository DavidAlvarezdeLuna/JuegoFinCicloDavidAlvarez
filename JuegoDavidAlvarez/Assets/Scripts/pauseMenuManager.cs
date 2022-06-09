using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelPausa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cerrarMenuPausa()
    {
        panelPausa.SetActive(false);
    }

    public void volverMenuPrincipal()
    {
        SceneManager.LoadSceneAsync("Intro");
    }
}
