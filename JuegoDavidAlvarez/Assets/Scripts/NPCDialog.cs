using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class NPCDialog : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image dialogueImage;
    [SerializeField] private Sprite characterPortrait;
    [SerializeField] private TextAsset inkJsonAsset;

    [SerializeField] public String nomVariable;

    private bool isPlayerInRange;
    private bool didDialogueStart;

    private GameObject player;

    private GameObject inkManager;

    private GameObject decisionManager;

    private bool visited = false;

    private string personTag;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inkManager = GameObject.FindWithTag("InkManager");
        decisionManager = GameObject.FindWithTag("DecisionManager");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            if(player.GetComponent<PlayerController>().canMove)
            {
                //didDialogueStart = true;
                dialogueImage.sprite = characterPortrait; 
                player.GetComponent<PlayerController>().canMove = false;
                inkManager.GetComponent<InkManager>().StartStory(inkJsonAsset, nomVariable, visited, personTag);
                //player.GetComponent<PlayerController>().canMove = true;
                visited = true;
            }

            if(this.tag == "chicaTienda2")
            {
                if(!player.GetComponent<PlayerController>().endedShootGame)
                {
                    player.GetComponent<PlayerController>().canPlayShootGame = true;
                }
                
            }

            if(this.tag == "viejaMisteriosa2")
            {
                if(decisionManager.GetComponent<DecisionManager>().hablaViejaEscena2 != "Si")
                {
                    inkManager.GetComponent<InkManager>().peopleTalked --;
                }
                
                decisionManager.GetComponent<DecisionManager>().hablaViejaEscena2 = "Si";
                decisionManager.GetComponent<DecisionManager>().actualizarValor("hablaViejaEscena2", decisionManager.GetComponent<DecisionManager>().hablaViejaEscena2);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            personTag = this.tag;
            Debug.Log("Zona dialogo "+personTag);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            personTag = "";
            Debug.Log("No Zona dialogo");
        }
    }
}

