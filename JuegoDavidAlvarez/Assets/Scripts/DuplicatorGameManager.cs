using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicatorGameManager : MonoBehaviour
{
    private GameObject log1;
    private GameObject log2;
    private GameObject player;
    private GameObject decisionManager;
    private GameObject joyButtonB;
    private int phase;
    private bool phaseDone;
    private int interval = 10;
    // Start is called before the first frame update
    void Start()
    {
        log1 = GameObject.FindWithTag("logDuplicate1");
        log2 = GameObject.FindWithTag("logDuplicate2");
        player = GameObject.FindWithTag("Player");
        decisionManager = GameObject.FindWithTag("DecisionManager");
        joyButtonB = GameObject.FindWithTag("buttonB");
        
        phase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % interval == 0)
        {
            if(log1.GetComponent<LogBehavior>().isPlayerInRange && log2.GetComponent<LogBehavior>().isPlayerInRange && !phaseDone)
            {
                phaseDone = true;
                switch (phase)
                {
                    case 0:
                        phase=1;
                        translateLog(log1, 121, 68);
                        translateLog(log2, 125, 63);
                        phaseDone = false;
                        break;

                    case 1:
                        phase=2;
                        translateLog(log1, 110, 74);
                        translateLog(log2, 122, 78);
                        phaseDone = false;
                        break;

                    case 2:
                        phase=3;
                        translateLog(log1, 167, 63);
                        translateLog(log2, 167, 70);
                        phaseDone = false;
                        break;

                    case 3:
                        phase=4;
                        translateLog(log1, 142, 88);
                        translateLog(log2, 135, 88);
                        phaseDone = false;
                        break;

                    case 4:
                        phase=5;
                        phaseDone = false;
                        decisionManager.GetComponent<DecisionManager>().actualizarValor("superadasDuplicator", phase.ToString());
                        Vector3 protaPos;
                        protaPos = new Vector3(7, 3, player.transform.position.z);
                        player.transform.position = protaPos;
                        player.GetComponent<PlayerController>().canPlayDuplicateGame = false;
                        player.GetComponent<PlayerController>().playingDuplicateGame = false; 
                        player.GetComponent<PlayerController>().endedDuplicateGame = true;
                        break;

                    default:
                        Debug.Log("fase "+phase+" completada");
                        break;                    
                }
            }
        }

        if (joyButtonB.GetComponent<joystickController>().pressed)
        {
            if(player.GetComponent<PlayerController>().playingDuplicateGame)
            {
                decisionManager.GetComponent<DecisionManager>().actualizarValor("superadasDuplicator", phase.ToString());
                Vector3 protaPos;
                protaPos = new Vector3(7, 3, player.transform.position.z);
                player.transform.position = protaPos;
                player.GetComponent<PlayerController>().canPlayDuplicateGame = false;
                player.GetComponent<PlayerController>().playingDuplicateGame = false;  
                player.GetComponent<PlayerController>().endedDuplicateGame = true;                

            }
                        
        }
        
    }

    public void translateLog(GameObject log, float pos_x, float pos_y)
    {
        Vector3 logPos;
        logPos = new Vector3(pos_x, pos_y , -0.5f);
        log.transform.position = logPos;
    }
}
