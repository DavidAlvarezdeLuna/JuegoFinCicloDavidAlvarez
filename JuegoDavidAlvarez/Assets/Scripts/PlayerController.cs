using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5;
    public float forwardInput;
    public float horizontalInput;
    public Vector2 moveInput;
    public GameObject star;

    private Animator anim;

    public bool canMove = true;
    public bool isWalking = false;
    public bool canFinishScene = false;

    //variables del juego de disparos
    public bool endedShootGame = false;
    public bool canPlayShootGame = false;
    public bool canShoot = false;

    //variables del juego de duplicarse
    public bool endedDuplicateGame = false;
    public bool canPlayDuplicateGame = false;
    public bool playingDuplicateGame = false;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {

            forwardInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            if(horizontalInput != 0 || forwardInput != 0)
            {
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    playerSpeed = 8;
                }
                else
                {
                    playerSpeed = 5;
                }

                if(!isWalking)
                {
                    isWalking = true;
                    anim.SetBool("isWalking",true);
                }

                anim.SetFloat("Horizontal",horizontalInput);
                anim.SetFloat("Vertical",forwardInput);

                this.transform.Translate(Vector3.up * playerSpeed * Time.deltaTime * forwardInput);
                this.transform.Translate(Vector3.right * playerSpeed * Time.deltaTime * horizontalInput);
            }
            else
            {
                isWalking = false;
                anim.SetBool("isWalking",false);
            }

            

            if (Input.GetKeyDown(KeyCode.Space)){
                if(canShoot)
                {
                    Vector3 v3 = new Vector3(this.transform.position.x,this.transform.position.y,-1);        
                    Instantiate(star, v3, this.transform.rotation);
                }
                            
            }
        
        }
        
    }
}
