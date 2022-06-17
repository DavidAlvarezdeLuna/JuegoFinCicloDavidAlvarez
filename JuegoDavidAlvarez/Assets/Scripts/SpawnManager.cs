using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    private GameObject decisionManager;
    private GameObject player;
    private float startDelay = 0;
    private float spawnInterval = 1.5f;

    private int targetDirection;
    private int numberTargets = 30;
    private int contTargets;
    public int destroyedTargets;
    public int targetHit;

    public AudioClip breakTargetSound;
    private AudioSource sou;
    // Start is called before the first frame update

    void Start()
    {
        sou = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        decisionManager = GameObject.FindWithTag("DecisionManager");
        InvokeRepeating("spawnRandomTarget", startDelay, spawnInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(destroyedTargets >= 30)
        {
            decisionManager.GetComponent<DecisionManager>().actualizarValor("targetHit",targetHit.ToString());
            destroyedTargets = 0;
            player.GetComponent<PlayerController>().canShoot = false;
            player.GetComponent<PlayerController>().canPlayShootGame = false;
            player.GetComponent<PlayerController>().endedShootGame = true;
            player.transform.position = new Vector3(15, 3, player.transform.position.z);
        }
    }

    void spawnRandomTarget(){

        if(contTargets < numberTargets)
        {
            targetDirection = Random.Range(0,4);
            Vector3 spawnPos;

            switch (targetDirection)
            {
                case 0:
                    spawnPos = new Vector3(120, 17 , -1);
                    Instantiate(target, spawnPos, target.transform.rotation);
                    break;

                case 1:
                    spawnPos = new Vector3(130, 2 , -1);
                    Instantiate(target, spawnPos, target.transform.rotation);
                    break;

                case 2:
                    spawnPos = new Vector3(109, -3, -1);
                    Instantiate(target, spawnPos, target.transform.rotation);
                    break;

                case 3:
                    spawnPos = new Vector3(99, 11 , -1);
                    Instantiate(target, spawnPos, target.transform.rotation);
                    break;
            }
            contTargets++;
        }
    }

    public void playBreakSound()
    {
        sou.PlayOneShot(breakTargetSound, 0.5f);
    }

}
