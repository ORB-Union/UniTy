using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvent : MonoBehaviour
{

    public int Enemycount = 10;
    public float DestroyEnemyZpos = -20.0f;
    public int EnemyCreateMaxZpos = 900;
    public int EnemyCreateMinZpos = 600;
    public int EnemyCreateMaxXpos = 700;
    public int EnemyCreateMinXpos = 300;
    public GameObject Enemy = null;

    MemoryPool enemypool = new MemoryPool();
    GameObject[] enemy = null;


    private int Enemy_Death_Cnt_Check; // 죽은거 확인
    private bool enemy_state;


    void OnApplicationQuit()
    {
        enemypool.Dispose();
    }


    // Use this for initialization
    void Start()
    {
        enemypool.Create(Enemy, Enemycount);
        enemy = new GameObject[Enemycount];
        enemy_state = true;
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i] = null;
        }
        Enemy_Death_Cnt_Check = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_state)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i] == null)
                {
                    enemy[i] = enemypool.NewItem();
                    enemy[i].transform.position = new Vector3(Random.Range(EnemyCreateMinXpos, EnemyCreateMaxXpos), 8.5f, 800f);
                }
                enemy_state = false;
            }
        }

        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i])
            {
                if (enemy[i].transform.position.z < DestroyEnemyZpos)
                {
                    enemypool.RemoveItem(enemy[i]);
                    enemy[i] = null;
                    Enemy_Death_Cnt_Check++;
                }
                else if (enemy[i].GetComponent<Collider>().enabled == false)
                {
                    enemy[i].GetComponent<Collider>().enabled = true;
                    enemypool.RemoveItem(enemy[i]);
                    enemy[i] = null;
                    Enemy_Death_Cnt_Check++;
                }
            }

            if (Enemy_Death_Cnt_Check == Enemycount)
            {
                Enemy_Death_Cnt_Check = 0;
                enemy_state = true;
            }
        }
    }
}