using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_at_point : MonoBehaviour
{

    public Rigidbody bullet;
    public float force = 10f;
    public ForceMode forceMode;
    private bool allowFire = true;
    public float rate;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Fire()
    {
        allowFire = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation(ray.direction);

        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, GetComponent<Camera>().nearClipPlane));

        Rigidbody instance = Instantiate(bullet, transform.position, rotation) as Rigidbody;
        instance.AddForce(ray.direction * force, forceMode);

        StartCoroutine(Rate_of_Fire());
    }
    IEnumerator Rate_of_Fire()
    {
        yield return new WaitForSeconds(rate);
        allowFire = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && (allowFire)&& Input.GetMouseButton(1))
        {
            Fire();
        }
    }
}
