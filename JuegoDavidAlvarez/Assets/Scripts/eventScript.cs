using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class eventScript : MonoBehaviour
{

    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image dialogueImage;
    [SerializeField] private Sprite characterPortrait;
    [SerializeField] private TextAsset inkJsonAsset;

    private bool isPlayerInRange;

    private GameObject player;

    private GameObject inkManager;

    //private int scene = 1;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inkManager = GameObject.FindWithTag("InkManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange)
        {
            if(player.GetComponent<PlayerController>().canMove)
            {
                dialogueImage.sprite = characterPortrait;
                Debug.Log("Evento con tag: "+this.tag+" y player canFinishScene es "+player.GetComponent<PlayerController>().canFinishScene);

                if(this.tag == "endDayEvent" && player.GetComponent<PlayerController>().canFinishScene)
                {
                    Debug.Log("Acabamos escena");
                    player.GetComponent<PlayerController>().canMove = false;
                    inkManager.GetComponent<InkManager>().StartStory(inkJsonAsset, "", false, "endDayEvent");
                    player.GetComponent<PlayerController>().canFinishScene = false;
                    Destroy(this);
                    //AQUI CAMBIO DE ESCENA
                    //SceneManager.LoadScene("Scene2");
                    
                    
                }
                else
                {
                    if(this.tag == "evento")
                    {
                        Debug.Log("Seguimos en escena");
                        player.GetComponent<PlayerController>().canMove = false;
                        inkManager.GetComponent<InkManager>().StartStory(inkJsonAsset, "", false, "evento");
                        Destroy(this);
                    }
                    else
                    {
                        Debug.Log("No se cumplen condiciones de escena");
                    }
                }
                //dialogueImage.enabled = false;
                
                //dialogueImage.enabled = true;
            }            

        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

}