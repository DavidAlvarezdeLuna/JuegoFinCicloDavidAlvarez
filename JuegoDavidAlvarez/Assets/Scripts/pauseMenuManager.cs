using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelPausa;

    public void cerrarMenuPausa()
    {
        panelPausa.SetActive(false);
    }

    public void volverMenuPrincipal()
    {
        SceneManager.LoadSceneAsync("Intro");
    }
}
