using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fontBehavior : MonoBehaviour
{
    private bool canBeMoved = true;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            this.gameObject.transform.Translate(Vector3.up * Time.deltaTime * 2);
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
        }

    }
}
