using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ammo : MonoBehaviour
{
    public Gun m_Gun;
    public GameObject m_Gunbody;


   
    private void Start()
    {
        m_Gun = GameObject.FindWithTag("Gun").GetComponent<Gun>();
        
    }
    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           m_Gun.NbAmmo += 15;
            Destroy(gameObject);
        }

    }
}
