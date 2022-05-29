using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viejaoHada : MonoBehaviour
{
    private GameObject vieja;
    private GameObject hada;
    private GameObject decisionManager;
    // Start is called before the first frame update
    void Start()
    {
        vieja = GameObject.FindWithTag("viejaMisteriosa5");
        hada = GameObject.FindWithTag("viejaTransformada5");
        decisionManager = GameObject.FindWithTag("DecisionManager");
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(decisionManager.GetComponent<DecisionManager>().sirenaHablaPirata + " " + decisionManager.GetComponent<DecisionManager>().listaValores.Count + " " + decisionManager.GetComponent<DecisionManager>().listaVariables.Count);
        Debug.Log(decisionManager.GetComponent<DecisionManager>().listaValores[decisionManager.GetComponent<DecisionManager>().listaVariables.IndexOf("magiaLiberada")]);
        if (decisionManager.GetComponent<DecisionManager>().listaValores[decisionManager.GetComponent<DecisionManager>().listaVariables.IndexOf("magiaLiberada")].ToString() == "Si")
        {
            vieja.gameObject.SetActive(false);
        }
        else
        {
            hada.gameObject.SetActive(false);
        }

        Destroy(this);
    }
}
