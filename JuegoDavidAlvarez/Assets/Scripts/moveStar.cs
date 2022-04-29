using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveStar : MonoBehaviour
{
    public float speed = 8;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        float comparex = Math.Abs(this.transform.position.x - player.transform.position.x);
        float comparey = Math.Abs(this.transform.position.y - player.transform.position.y);

        if (comparex > 15 || comparey > 15){
            Destroy(gameObject);
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("target")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("Impactoooo");
        }

    }*/

}
