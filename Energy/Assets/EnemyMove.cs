using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public float EnemySpeed = 5f;

    public GameObject enemy;

    // Use this for initialization


    void Update()
    {
        this.transform.Translate(new Vector3(0, 0, -1) * EnemySpeed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Missile")
        { 
        Destroy(other.gameObject);
        Destroy(this.gameObject);
        }
    }

	// Update is called once per frame

}
