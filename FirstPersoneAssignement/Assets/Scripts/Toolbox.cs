using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{

    public EnemySpawner m_EnemySpawner;

    public Player m_Player;




    private static Toolbox m_instance;

    public static Toolbox instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = GameObject.FindObjectOfType<Toolbox>();
                if (m_instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<Toolbox>();
                    singleton.name = " (Singleton Toolbox )";
                }
            }
            return m_instance;
        }

    }

    private void Awake()
    {
        m_instance = this;
    }


}
