using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveStar : MonoBehaviour
{
    public float speed = 8;
    private GameObject player;
    private Animator anim;
    public Joystick joystick;
    private string direccion;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindWithTag("Player");
        anim = player.GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();

        Debug.Log(joystick.Horizontal.ToString()+" "+joystick.Vertical.ToString());

        if(joystick.Horizontal > 0f && joystick.Horizontal > joystick.Vertical)
        {
            direccion = "der";
        }
        if(joystick.Horizontal < 0f &&  joystick.Horizontal < joystick.Vertical)
        {
            direccion = "izq";
        }
        if(joystick.Vertical > 0f &&  joystick.Horizontal < joystick.Vertical)
        {
            direccion = "arr";
        }
        if(joystick.Vertical < 0f &&  joystick.Horizontal > joystick.Vertical)
        {
            direccion = "aba";
        }
        if(joystick.Vertical == 0f && joystick.Horizontal == 0f)
        {
            direccion = "arr";
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

        if (comparex > 15 || comparey > 5)
        {
            Destroy(gameObject);
        }
    }

}
