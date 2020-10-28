using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] m_SpwnPoint;
    public GameObject m_EnnemyPrefab;

    public Player m_Player;
    public Transform m_Target;
    

    private static EnemySpawner m_instance;

    public static EnemySpawner instance
    {
        get
        {
            if(m_instance == null)
           {
                m_instance = GameObject.FindObjectOfType<EnemySpawner>();
                if(m_instance == null)
                {
                GameObject singleton = new GameObject();
                singleton.AddComponent<EnemySpawner>();
                singleton.name = " (Singleton EnemySpawner)";
                }
           }
          return m_instance;
        }

    }

    private void Awake()
    {
        m_instance = this;
    }


    void Start()
    {
        SpawnEnemy();
    }

    
    public void SpawnEnemy()
    {
        int MisteryNumber = Random.Range(0, 3);

        GameObject enemyGO = Instantiate(m_EnnemyPrefab, m_SpwnPoint[MisteryNumber].transform.position, Quaternion.identity);
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.m_Target = m_Target;
        enemy.m_player = m_Player.transform;
        enemy.m_playerHP = m_Player;
        enemy.m_goToTarget = true;
    }

   
}
