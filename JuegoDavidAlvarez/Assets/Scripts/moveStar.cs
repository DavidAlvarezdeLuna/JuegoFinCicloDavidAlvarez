using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveStar : MonoBehaviour
{
    public float speed = 8;
    private GameObject player;
    private Animator anim;
    private string direccion;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        anim = player.GetComponent<Animator>();
        if(anim.GetFloat("Horizontal") > 0)
        {
            direccion = "der";
        }
        if(anim.GetFloat("Horizontal") < 0)
        {
            direccion = "izq";
        }
        if(anim.GetFloat("Vertical") > 0)
        {
            direccion = "arr";
        }
        if(anim.GetFloat("Vertical") < 0)
        {
            direccion = "aba";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(direccion == "der")
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if(direccion == "izq")
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(direccion == "arr")
        {
            this.transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if(direccion == "aba")
        {
            this.transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        

        float comparex = Math.Abs(this.transform.position.x - player.transform.position.x);
        float comparey = Math.Abs(this.transform.position.y - player.transform.position.y);

        if (comparex > 15 || comparey > 15)
        {
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
