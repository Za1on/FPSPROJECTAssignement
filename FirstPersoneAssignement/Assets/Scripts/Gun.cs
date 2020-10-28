using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private float Dmg = 10f;
    [SerializeField]
    private float Range = 100f;
    [SerializeField]
    public int NbAmmo;
    [SerializeField]
    private int MaxAmmo;
    [SerializeField]
    private int MaxAmmoInMagasine;
    [SerializeField]
    private int NbAmmoInMagasine;
    [SerializeField]
    private float CoolDownTime;
    [SerializeField]
    private bool IsShootingAvaible;
    [SerializeField]
    private bool IsReload;
    [SerializeField]
    private float LastShootingTime;
    [SerializeField]
    public Text AmmoClip;
    [SerializeField]
    public Text AmmoDisplay;
    [SerializeField]
    public Camera cmr;

    void Start()
    {
        IsReload = false;
        IsShootingAvaible = true;
    }
    void Update()
    {

        if (NbAmmo >= MaxAmmo)
        {
            NbAmmo = MaxAmmo;
        }
        if (!IsShootingAvaible)
        {
            if (Time.time - LastShootingTime >= CoolDownTime)
            {
                IsShootingAvaible = true;
            }
        }
        AmmoDisplay.text = "" + NbAmmo;
        AmmoClip.text = "" + NbAmmoInMagasine + "/";

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("R"))
        {
            Reload();
        }
    }
    public void Shoot()
    {
        if (IsShootingAvaible && NbAmmoInMagasine > 0)
        {           
                NbAmmoInMagasine--;
                IsShootingAvaible = false;
                LastShootingTime = Time.time;
            RaycastHit hit;
            if (Physics.Raycast(cmr.transform.position, cmr.transform.forward, out hit, Range))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if(enemy !=null)
                {
                    enemy.TakeDamage(Dmg);
                }
            }

        }
        else if (NbAmmoInMagasine <= 0)
        {
            return;
        }
    }
    public void Reload()
    {
        if (!IsReload && NbAmmoInMagasine != MaxAmmoInMagasine && Input.GetButtonDown("R"))
        {
            IsReload = true;
            int nbAmmoEmptySlot = MaxAmmoInMagasine - NbAmmoInMagasine;
            int nbAmmoToLoad = Mathf.Min(nbAmmoEmptySlot, NbAmmo);
            NbAmmo -= nbAmmoToLoad;
            NbAmmoInMagasine += nbAmmoToLoad;
            Invoke("Reloading", 1f);
        }
    }

    void Reloading()
    {
        IsReload = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            NbAmmo += 5;
            Destroy(gameObject, 0.5f);
        }

    }
}
