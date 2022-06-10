using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fontBehavior : MonoBehaviour
{
    private bool canBeMoved = true;
    private bool isMoving = false;

    public AudioClip quakeSound;
    private AudioSource sou;

    // Start is called before the first frame update
    void Start()
    {
        sou = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            this.gameObject.transform.Translate(Vector3.up * Time.deltaTime * 0.7f);
        }

        if (this.gameObject.transform.position.y >= 22f)
        {
            canBeMoved = false;
            isMoving = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("star") && canBeMoved)
        {
            isMoving = true;
            sou.PlayOneShot(quakeSound, 0.5f);
        }

    }
}
