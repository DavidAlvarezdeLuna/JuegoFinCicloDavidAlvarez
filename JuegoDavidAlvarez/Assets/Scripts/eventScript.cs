using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private GameObject decisionManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inkManager = GameObject.FindWithTag("InkManager");
        decisionManager = GameObject.FindWithTag("DecisionManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange)
        {
            if(player.GetComponent<PlayerController>().canMove)
            {
                dialogueImage.sprite = characterPortrait;

                if(SceneManager.GetActiveScene().name == "Scene5" && this.tag == "endDayEvent" && inkManager.GetComponent<InkManager>().peopleTalked >= 9)
                {
                    player.GetComponent<PlayerController>().canFinishScene = true;
                }

                if (this.tag == "endDayEvent" && player.GetComponent<PlayerController>().canFinishScene)
                {
                    player.GetComponent<PlayerController>().canMove = false;
                    inkManager.GetComponent<InkManager>().StartStory(inkJsonAsset, "", false, "endDayEvent");
                    player.GetComponent<PlayerController>().canFinishScene = false;
                    Destroy(this);                    
                }
                else
                {
                    if(this.tag == "evento")
                    {
                        player.GetComponent<PlayerController>().canMove = false;
                        inkManager.GetComponent<InkManager>().StartStory(inkJsonAsset, "", false, "evento");
                        Destroy(this);
                    }

                    if(this.tag == "caveEntry")
                    {
                        Vector3 playerPos;
                        playerPos = new Vector3(-140f, -18f , player.gameObject.transform.position.z);

                        player.gameObject.transform.position = playerPos;
                        Destroy(this);
                    }

                    if (this.tag == "crystalRoomEntry")
                    {
                        Vector3 playerPos;
                        playerPos = new Vector3(-142f, 83f, player.gameObject.transform.position.z);
                        player.GetComponent<PlayerController>().canShoot = false;
                        decisionManager.GetComponent<DecisionManager>().actualizarValor("zombiesHit", decisionManager.GetComponent<DecisionManager>().zombiesCount.ToString());

                        player.gameObject.transform.position = playerPos;
                        Destroy(this);
                    }

                }

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
