using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZetaControl : MonoBehaviour {

    protected Animator animator;
    private float directionX = 0;
    private float directionY = 0;
    private bool walking = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (animator)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            walking = true;
            if (h > 0)
            {
                directionX = 1;
                directionY = 0;
                GetComponent<AudioSource>().UnPause();
            }
            else if(h < 0) {
                directionX = -1;
                directionY = 0;
                GetComponent<AudioSource>().UnPause();
            } else if (v > 0) {
                directionX = 0;
                directionY = 1;
                GetComponent<AudioSource>().UnPause();
            } else if (v < 0) {
                directionX = 0;
                directionY = -1;
                GetComponent<AudioSource>().UnPause();
            } else {
                walking = false;
                GetComponent<AudioSource>().Pause();
            }
            if (walking)
            {
                transform.Translate(new Vector3(directionX, directionY, 0) * Time.deltaTime * 0.5f);
            }
            animator.SetFloat("DirectionX", directionX);
            animator.SetFloat("DirectionY", directionY);
            animator.SetBool("Walking", walking);
        }
    }
}