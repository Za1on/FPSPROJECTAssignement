using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
   
    public GameObject m_bulletPrefab;   
    public Transform m_AmmoSpawn;   
    public float m_MoveSpeed = 15f;   
    public float m_health = 30f;

    [SerializeField]
    private Renderer m_rend;

    public Transform m_Target;
    public Transform m_player;
    public bool m_goToTarget;
    public bool m_goToPlayer;
    public Player m_playerHP;
   

    void Start()
    {
        m_goToTarget = true;

        //Target = GameObject.FindWithTag("Target").GetComponent<Transform>();
        //player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //playerHP = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_goToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_Target.position, m_MoveSpeed * Time.deltaTime);
        }
        if (m_goToPlayer)
        {
            m_goToTarget = false;
            transform.position = Vector3.MoveTowards(transform.position, m_player.position, m_MoveSpeed * Time.deltaTime);
        }
    }
    public void TakeDamage (float amount)
    {
        m_health -= amount;
        if(m_health <= 0)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Target"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            //playertake damage
            m_playerHP.TkeDmg();
            
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            m_goToPlayer = true;
        }
    }
    public void Die()
    {
        SpawnBullet();
        RespawnEnemy();
        transform.DOScale(new Vector3(-1f, -1f, -1f), 0.2f);
        m_rend.material.DOColor(Color.white, 0.2f);
        transform.DOPunchScale(Vector3.one, 0.7f);
        Destroy(gameObject, 1f);
    }
    public void RespawnEnemy()
    {
        EnemySpawner.instance.SpawnEnemy();
    }
    public void SpawnBullet()
    {
        Instantiate(m_bulletPrefab, m_AmmoSpawn.transform.position, Quaternion.identity);
    }
}
