using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float forwardInput;
    public float horizontalInput;
    public Vector2 moveInput;
    public GameObject star;

    private Animator anim;

    public Joystick joystick;
    private GameObject joyButtonB;
    private GameObject joyButtonPause;

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

    [SerializeField] private GameObject panelPausa;

    public AudioClip starSound;
    public AudioClip zombieSound;
    public AudioClip rabbitSound;
    private AudioSource sou;

    // Start is called before the first frame update
    void Start()
    {
        sou = GetComponent<AudioSource>();
        playerSpeed = 7;
        anim = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        joyButtonB = GameObject.FindWithTag("buttonB");
        joyButtonPause = GameObject.FindWithTag("buttonPause");
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody2D>();
        if(canMove)
        {
            forwardInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
            if(joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                if(!isWalking)
                {
                    isWalking = true;
                    anim.SetBool("isWalking",true);
                }
                anim.SetFloat("Horizontal", joystick.Horizontal);
                anim.SetFloat("Vertical", joystick.Vertical);   
                this.transform.Translate(Vector3.up * playerSpeed * Time.deltaTime * joystick.Vertical);
                this.transform.Translate(Vector3.right * playerSpeed * Time.deltaTime * joystick.Horizontal);
            }
            else
            {
                isWalking = false;
                anim.SetBool("isWalking",false);
            }        

            if (joyButtonB.GetComponent<joystickController>().pressed || Input.GetKey(KeyCode.Space))
            {
                if(canShoot)
                {
                    joyButtonB.GetComponent<joystickController>().pressed = false;
                    Vector3 v3 = new Vector3(this.transform.position.x,this.transform.position.y,-1);        
                    Instantiate(star, v3, this.transform.rotation);
                    sou.PlayOneShot(starSound, 0.5f);
                }               
            }

            if (joyButtonPause.GetComponent<joystickController>().pressed)
            {
                if (!canShoot)
                {
                    panelPausa.SetActive(true);
                }        
            }
        }     
    }

    public void playZombieSound()
    {
        sou.PlayOneShot(zombieSound, 1f);
    }

    public void playRabbitSound()
    {
        sou.PlayOneShot(rabbitSound, 0.5f);
    }

    public void playStarSound()
    {
        sou.PlayOneShot(starSound, 0.5f);
    }

}
