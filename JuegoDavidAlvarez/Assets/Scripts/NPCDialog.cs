using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCDialog : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image dialogueImage;
    [SerializeField] private Sprite characterPortrait;
    [SerializeField] private TextAsset inkJsonAsset;
    [SerializeField] public String nomVariable;
    private GameObject joyButtonA;

    private bool isPlayerInRange;
    private bool didDialogueStart;

    private GameObject player;

    private GameObject inkManager;

    private GameObject decisionManager;

    private bool visited = false;

    private string personTag;

    //[SerializeField] private GameObject endDayEvent;

    private GameObject sirena3;
    private bool sirenaCanMove;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inkManager = GameObject.FindWithTag("InkManager");
        decisionManager = GameObject.FindWithTag("DecisionManager");
        joyButtonA = GameObject.FindWithTag("buttonA");

        sirena3 = GameObject.FindWithTag("sirena3");
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange && joyButtonA.GetComponent<joystickController>().pressed)
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

            if(this.tag == "chicaTienda3")
            {
                if(!player.GetComponent<PlayerController>().endedDuplicateGame)
                {
                    player.GetComponent<PlayerController>().canPlayDuplicateGame = true;
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

            if(this.tag == "sirena3")
            {
                if(decisionManager.GetComponent<DecisionManager>().sirenaHablaPirata != "Si")
                {
                    inkManager.GetComponent<InkManager>().peopleTalked --;
                    Debug.Log("Se mueve el objeto "+gameObject.tag.ToString());
                    //gameObject.transform.Translate(Vector3.left * Time.deltaTime * 3);
                    //gameObject.transform.Translate(new Vector2(6,gameObject.transform.position.y) * Time.deltaTime * 3);
                    sirenaCanMove = true;
                }

                decisionManager.GetComponent<DecisionManager>().sirenaHablaPirata = "Si";
                decisionManager.GetComponent<DecisionManager>().actualizarValor("sirenaHablaPirata", decisionManager.GetComponent<DecisionManager>().sirenaHablaPirata);
            }

            if(this.tag == "pirata3" && decisionManager.GetComponent<DecisionManager>().sirenaHablaPirata == "No")
            {
                sirena3.SetActive(false);
            }

            if(this.tag == "standScene4")
            {
                player.GetComponent<PlayerController>().canShoot = true;
                inkManager.GetComponent<InkManager>().peopleTalked = 0;
            }

            if (this.tag == "crystal")
            {
                inkManager.GetComponent<InkManager>().peopleTalked = 0;
                player.GetComponent<PlayerController>().canFinishScene = true;
            }

        }

        if(SceneManager.GetActiveScene().name == "Scene3")
        {
            if (sirenaCanMove)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 4);
            }

            if (sirena3.transform.position.x <= 6)
            {
                sirenaCanMove = false;
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

