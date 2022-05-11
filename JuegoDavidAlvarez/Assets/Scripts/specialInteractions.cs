using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialInteractions : MonoBehaviour
{
    private bool isPlayerInRange;
    private GameObject player;
    private GameObject spawnManager;
    private GameObject decisionManager;
    private GameObject duplicate;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawnManager = GameObject.FindWithTag("spawnManager");
        decisionManager = GameObject.FindWithTag("DecisionManager");
        duplicate = GameObject.FindWithTag("Duplicate");
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            if(player.GetComponent<PlayerController>().canMove)
            {
                //player.GetComponent<PlayerController>().canMove = false;
                //player.GetComponent<PlayerController>().canMove = true;
                if(this.tag == "standScene2" && player.GetComponent<PlayerController>().canPlayShootGame)
                {
                    player.GetComponent<PlayerController>().canShoot = true;
                    player.transform.position = new Vector3(113.5f, 6.5f, player.transform.position.z);
                    spawnManager.GetComponent<SpawnManager>().enabled = true;
                    Debug.Log("A disparar");
                }
                else
                {
                    Debug.Log("No puedes disparar");
                }

                if(this.tag == "standScene3" && player.GetComponent<PlayerController>().canPlayDuplicateGame)
                {
                    //player.GetComponent<PlayerController>().canShoot = true;
                    player.transform.position = new Vector3(114f, 57f, player.transform.position.z);
                    //spawnManager.GetComponent<SpawnManager>().enabled = true;
                    Debug.Log("A colaborar con el duplicado!");
                    duplicate.transform.position = new Vector3(120f, 57f, player.transform.position.z);
                    player.GetComponent<PlayerController>().playingDuplicateGame = true;
                }
                else
                {
                    Debug.Log("No puedes jugar a Duplicator");
                }

                if(this.tag == "conejito")
                {
                    //Hacer sonidito
                    decisionManager.GetComponent<DecisionManager>().conejitosEncontrados++;
                    decisionManager.GetComponent<DecisionManager>().actualizarValor("conejitosEncontrados", decisionManager.GetComponent<DecisionManager>().conejitosEncontrados.ToString());
                    Destroy(gameObject);
                }

            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Zona interaccion "+this.tag);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("No Zona interaccion");
        }
    }


}
