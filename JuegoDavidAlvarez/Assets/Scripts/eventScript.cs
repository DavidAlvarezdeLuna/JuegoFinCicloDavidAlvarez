using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class eventScript : MonoBehaviour
{

    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image dialogueImage;
    [SerializeField] private TextAsset inkJsonAsset;

    private bool isPlayerInRange;

    private GameObject player;

    private GameObject inkManager;


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
                //dialogueImage.enabled = false;
                player.GetComponent<PlayerController>().canMove = false;
                inkManager.GetComponent<InkManager>().StartStory(inkJsonAsset, "", false, "evento");
                Destroy(this);
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
