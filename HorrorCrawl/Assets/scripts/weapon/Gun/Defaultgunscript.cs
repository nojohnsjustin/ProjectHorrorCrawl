using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defaultgunscript : MonoBehaviour
{
    public float minDamage;
    public float maxDamage;
    public float reload;
    public float fire_rate;
    private bool ready;
    private float currentAmmo;
    public float Ammo;
    public float DamageRoll()
    {
        return (int)Random.Range(minDamage, maxDamage);
    }
    public float fired()
    {
        if (ready && checkEmpty())
        {
            ready = false;
            StartCoroutine("ReadyGun");
            currentAmmo  --;
            return DamageRoll();
        }
        return 0;
    }
    IEnumerator ReadyGun()
    {
        yield return new WaitForSeconds(fire_rate);
        ready = true;

    }
    bool checkEmpty()
    {
        if (currentAmmo <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
   
    IEnumerator Reloading()
    {
        Debug.Log("reloading");
        yield return new WaitForSeconds(reload);
        ready = true;
        Debug.Log("filled");
    }
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = Ammo;
        ready = true;
    }
    public void missed()
    {
        currentAmmo--;
    }

// Update is called once per frame
void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && (currentAmmo != Ammo)) {
            ready = false;
            currentAmmo = Ammo;
            StartCoroutine("Reloading");

        }
    }
   
}
