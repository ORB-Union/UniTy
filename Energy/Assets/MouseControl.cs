using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour {

    public float sensabilityX = 15.0f;
    public float sensabilityY = 15.0f;
    public float rotationY = 0.0f;

    // Use this for initialization
    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
	// Update is called once per frame
	void Update () {
        //transform.Rotate(0, Input.GetAxis("Mouse X") * sensabilityX, 0);
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensabilityX;
        rotationY += Input.GetAxis("Mouse Y") * sensabilityY;
        rotationY = Mathf.Clamp(rotationY, -20.0f, 60.0f);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        
	}
}
