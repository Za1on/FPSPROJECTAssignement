using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody Rbd;
    public float m_Speed = 100f;
    [SerializeField]
    private float m_PlayerHp = 5f;
    [SerializeField]
    private int m_pushBack = 1;

    private void Start()
    {
        Rbd = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        Vector2 Xmove = new Vector2(Input.GetAxisRaw("Horizontal") * transform.right.x, Input.GetAxisRaw("Horizontal") * transform.right.z);
        Vector2 Zmove = new Vector2(Input.GetAxisRaw("Vertical") * transform.forward.x, Input.GetAxisRaw("Vertical") * transform.forward.z);

        Vector2 velocity = (Xmove + Zmove).normalized * m_Speed * Time.deltaTime;
        Rbd.velocity = new Vector3(velocity.x, Rbd.velocity.y, velocity.y);
        if(m_PlayerHp <= 0f)
        {
            Die();
        }
    }
    public void TkeDmg()
    {
        m_PlayerHp -= 1f;
        Rbd.AddForce(new Vector3(-m_pushBack, -m_pushBack, -m_pushBack));
    }
    void Die()
    {
        this.enabled = false;
        Time.timeScale = 0;
    }

}





