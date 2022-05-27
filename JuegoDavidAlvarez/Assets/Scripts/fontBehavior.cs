using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fontBehavior : MonoBehaviour
{
    private bool canBeMoved = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("star") && canBeMoved)
        {
            Vector3 fontPos;
            fontPos = new Vector3(gameObject.transform.position.x, 21f , -1.5f);
            gameObject.transform.position = fontPos;
            canBeMoved = false;
        }

    }
}
