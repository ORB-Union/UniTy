using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public float MissileSpeed;
    public float DestroyMissileZpos;

	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.forward * MissileSpeed * Time.deltaTime);
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Enemy")
        {
            this.GetComponent<Collider>().enabled = false;

        }
    }
}
