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
    public bool canFinishScene = false;
    public bool endedShootGame = false;
    public bool canPlayShootGame = false;
    public bool canShoot = false;

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
            if(Input.GetKey(KeyCode.LeftShift))
            {
                playerSpeed = 8;
            }
            else
            {
                playerSpeed = 5;
            }

            forwardInput = Input.GetAxis("Vertical");
            this.transform.Translate(Vector3.up * playerSpeed * Time.deltaTime * forwardInput);

            horizontalInput = Input.GetAxis("Horizontal");
            this.transform.Translate(Vector3.right * playerSpeed * Time.deltaTime * horizontalInput);
        
            moveInput = new Vector2(horizontalInput,forwardInput).normalized;
        
            anim.SetFloat("Horizontal",horizontalInput);
            anim.SetFloat("Vertical",forwardInput);
            anim.SetFloat("Speed",moveInput.sqrMagnitude);


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
