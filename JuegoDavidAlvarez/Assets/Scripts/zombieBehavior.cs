using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieBehavior : MonoBehaviour
{
    private GameObject decisionManager;
    public GameObject player;
    private Rigidbody2D enemyRb;
    public float speed = 4;
    private Vector2 movement;
    private bool canFollowPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemyRb = GetComponent<Rigidbody2D>();
        decisionManager = GameObject.FindWithTag("DecisionManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(canFollowPlayer)
        {
            Vector3 lookDirection = player.transform.position - transform.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            enemyRb.rotation = angle;
            lookDirection.Normalize();
            movement = lookDirection;
            enemyRb.MovePosition(transform.position + (lookDirection * speed * Time.deltaTime));
            //enemyRb.AddForce(lookDirection * Time.deltaTime * speed);

        }

        float comparex = Math.Abs(this.transform.position.x - player.transform.position.x);
        float comparey = Math.Abs(transform.position.y - player.transform.position.y); 

        if (comparey < 5 && comparex < 25)
        {
            canFollowPlayer = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("star") || collision.gameObject.CompareTag("Player")){
            Destroy(gameObject);
            
            if(collision.gameObject.CompareTag("star"))
            {
                Destroy(collision.gameObject);
                decisionManager.GetComponent<DecisionManager>().zombiesCount++;
                player.GetComponent<PlayerController>().playZombieSound();
            }

        }

    }

}
