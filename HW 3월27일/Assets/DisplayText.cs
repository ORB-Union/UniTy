using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour {

    public string text;
    public bool display = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "unitychan")
        {
            display = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "unitychan")
        {
            display = false;
        }
    }

    void OnGUI()
    {
        if (display == true)
        {
            GUI.Box(new Rect(0, 50, Screen.width, Screen.height - 50), text);
        }
    }

}
