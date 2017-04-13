using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour {

    CharacterController cc;

    public AudioSource source;

   void start()
    {
        source = GetComponent<AudioSource>();
        cc = GetComponent<CharacterController>();
    }


    void Update()
    {
        if(cc.isGrounded == true && cc.velocity.magnitude > 2f && source.isPlaying == false)
        {
            source.volume = Random.Range(0.8f, 1);
            source.pitch = Random.Range(0.8f,1.1f);
            source.Play();
        }
        /*
        source.clip = Footsteps;
        source.Play();
        */
    }

	// Use this for initialization
}
