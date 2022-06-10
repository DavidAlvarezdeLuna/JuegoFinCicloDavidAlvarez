using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickSound : MonoBehaviour
{
    public AudioClip click;
    private AudioSource sou;

    // Start is called before the first frame update
    void Start()
    {
        sou = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playClickSound()
    {
        sou.PlayOneShot(click, 1f);
    }
}
