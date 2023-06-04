using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public Level[] levels;
    public Transform spawnPosition;
    public Transform targetObject;

    public List<GameObject> enemys = new List<GameObject>();
    public bool isInFight = false;
    public bool isBossFightting = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //if(levels == null || levels.Length == 0)
        //{
        //    Debug.Log("Not levels in game");
        //}    
        //else
        //{
        //    Debug.Log("Loading level 01");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(isInFight)
        {
            if (enemys.Count <= 0)
            {
                if(isBossFightting)
                {
                    isInFight = false;
                    ScreenManager.instance.LevelGameComplete();
                    isBossFightting = false;
                }
                else
                {
                    isInFight = false;
                    StartCoroutine(ScreenManager.instance.BossAppear());
                    isBossFightting = true;
                }
            }
        }
    }

    public void createEnemies(int level)
    {
        Level currentLevel = Array.Find(levels, x=> x.level == level);
        if (currentLevel == null)
        {
            UnityEngine.Debug.Log("Not have Level "+ level);
        }
        else
        {
            foreach(EnemyInLevel go in currentLevel.enemyInLevels)
            {
                for(int i = 0; i < go.count; i++)
                {
                    GameObject enemy = Instantiate(go.gameObjectFrefabs, spawnPosition.position, Quaternion.identity);
                    enemy.GetComponent<EnemyMovements>().attackTarget = targetObject;
                    enemy.GetComponent<EnemyMovements>().TimeToAttack = UnityEngine.Random.Range(0.0f, 120.0f);

                    enemys.Add(enemy);
                }
            }
            UnityEngine.Debug.Log("Create enemies successfully in level " + HubManager.instance.currentlevel);
        }
    }

    public void createBoss(int level)
    {
        Level currentLevel = Array.Find(levels, x => x.level == level);
        if (currentLevel == null)
        {
            UnityEngine.Debug.Log("Not have Level " + level);
        }
        else
        {
            foreach (EnemyInLevel go in currentLevel.Boss)
            {
                for (int i = 0; i < go.count; i++)
                {
                    GameObject boss = Instantiate(go.gameObjectFrefabs, spawnPosition.position, Quaternion.identity);
                    boss.GetComponent<EnemyMovements>().attackTarget = targetObject;
                    boss.GetComponent<Attacks>().attackTarget = targetObject;
                    boss.GetComponent<EnemyMovements>().TimeToAttack = 1.0f;

                    ScreenManager.instance.playScreen.transform.Find("heathbarBoss").gameObject.SetActive(true);
                    boss.GetComponent<BosHealth>().SetHealthBar(ScreenManager.instance.playScreen.transform.Find("heathbarBoss").GetComponent<Slider>());
                    enemys.Add(boss); 
                }
            }
            UnityEngine.Debug.Log("Create Boss successfully in level " + HubManager.instance.currentlevel);
        }
    }

    public void addEnemy(GameObject frefabs, int count, Vector3 position, float timeAttackMin = 0f, float timeAttackMax = 120f)
    {
        for(int i =0; i < count; i++)
        {
            GameObject enemy = Instantiate(frefabs, position, Quaternion.identity);
            enemy.GetComponent<EnemyMovements>().attackTarget = targetObject;
            enemy.GetComponent<EnemyMovements>().TimeToAttack = UnityEngine.Random.Range(timeAttackMin, timeAttackMax);

            enemys.Add(enemy);
        } 
    }

    public void Clear()
    {
        foreach(GameObject game in enemys)
        {
            Destroy(game);  
        }
        enemys.Clear();
    }
}
