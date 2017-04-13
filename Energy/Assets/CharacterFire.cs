using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFire : MonoBehaviour {

    public GameObject Moon_Missile = null;
    public Transform MissileLocation = null;
    public float FireTime = 0.3f;
    public int MissilePoolCount = 30;
    public float DestroyMissileZpos = 1000;
    

    MemoryPool pool = new MemoryPool();


    GameObject[] missile;

    bool Missile_Fire_State = true;

    void FireSpeedController()
    {
        Missile_Fire_State = true;

    }
    //프로그램 종료시 메모리 비움
    void OnApplicationQuit()
    {
        pool.Dispose();
    }

    void Start()
    {
        pool.Create(Moon_Missile, MissilePoolCount);
        missile = new GameObject[MissilePoolCount];
        for (int i = 0; i < missile.Length; i++)
        {
            missile[i] = null;
        }

    }

    // Update is called once per frame
    void Update ()
    {

        if(Missile_Fire_State)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Invoke("FireSpeedController", FireTime);
                for (int i = 0; i < missile.Length; i++)
                {
                    if (missile[i] == null)
                    {
                        missile[i] = pool.NewItem();
                        missile[i].transform.position = MissileLocation.transform.position;
                        break;
                    }
                }
                Debug.Log("미사일이 발사됨");
                //Instantiate(Moon_Missile, MissileLocation.position, MissileLocation.rotation);
                Missile_Fire_State = false;
            }
        }

        for (int i = 0; i < missile.Length; i++)
        {

            if (missile[i])
            {
                if (missile[i].transform.position.z > DestroyMissileZpos)
                {
                    pool.RemoveItem(missile[i]);
                    missile[i] = null;
                    Debug.Log("미사일이 반환됨");
                }
                else if (missile[i].GetComponent<Collider>().enabled == false)
                {
                    missile[i].GetComponent<Collider>().enabled = true;
                    pool.RemoveItem(missile[i]);
                    missile[i] = null;
                }
            }

        }
    }
}
