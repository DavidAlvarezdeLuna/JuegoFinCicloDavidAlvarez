using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMove : MonoBehaviour
{
    private float speed = 3;
    private string direction;
    private int targetHit;
    private GameObject spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.FindWithTag("spawnManager");

        if(this.transform.position.x > 110 && this.transform.position.y > 10)
        {
            direction = "down";
        }
        else
        {
            if(this.transform.position.x > 110 && this.transform.position.y < 10)
            {
                direction = "left";
            }
            else
            {
                if(this.transform.position.x < 110 && this.transform.position.y < 10)
                {
                    direction = "up";
                }
                else
                {
                    if(this.transform.position.x < 110 && this.transform.position.y > 10)
                    {
                        direction = "right";
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x > 132 || this.transform.position.x < 96 || this.transform.position.y > 18 || this.transform.position.y < -4)
        {
            Destroy(gameObject);
            spawnManager.GetComponent<SpawnManager>().destroyedTargets++;
        }
        
        if(this.direction == "down"){
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        if(this.direction == "left"){
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if(this.direction == "up"){
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if(this.direction == "right"){
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            transform.Translate(Vector3.right * Time.deltaTime * speed);            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("star")){
            Destroy(gameObject);
            Destroy(collision.gameObject);
            
            //Debug.Log("Impactoooo");

            spawnManager.GetComponent<SpawnManager>().destroyedTargets++;
            spawnManager.GetComponent<SpawnManager>().targetHit++;
        }

    }

}
