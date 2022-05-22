using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.UI;

public class FirebaseManager : MonoBehaviour
{

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

    public void registro()
    {
        //comprobar formato correcto de usuario y contraseña


    }

    private IEnumerator RegisterUser(string email, string password)
    {
        var auth = FirebaseAuth.DefaultInstance;
        var registerTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);
        yield return new WaitUntil(()=>registerTask.IsCompleted);

    }

    public void inicioSesion()
    {
        //comprobar que usuario y contraseña existen
    }
}
