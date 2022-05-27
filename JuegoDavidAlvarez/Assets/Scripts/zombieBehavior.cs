using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("star") || collision.gameObject.CompareTag("Player")){
            Destroy(gameObject);
            Destroy(collision.gameObject);

            if(collision.gameObject.CompareTag("star"))
            {
                //zombisDerrotados++
            }

            //spawnManager.GetComponent<SpawnManager>().destroyedTargets++;
            //spawnManager.GetComponent<SpawnManager>().targetHit++;
        }

    }

}
