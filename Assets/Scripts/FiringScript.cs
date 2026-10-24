using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FiringScript : MonoBehaviour
{
    [SerializeField] Transform originPos;
    [SerializeField] KeyCode shootKey = KeyCode.Mouse0;
    bool readyToShoot;
    public bool raycastShoot;

    [Header("Raycast Variables")]
    [SerializeField] float distance = 50f;
    [SerializeField] LayerMask enemies;

    [Header("Instantiate Variables")]
    [SerializeField] GameObject projectile;
    [SerializeField] float shootForce;
    [SerializeField] float shootUpwardforce;
    // Start is called before the first frame update
    void Start()
    {
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(originPos.position, originPos.forward * 10f, Color.yellow);
        if(Input.GetKeyDown(shootKey) && readyToShoot)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        if(raycastShoot)
        {
            RaycastShoot();
        }
        else
        {
            InstantiateShoot();
        }
    }

    void RaycastShoot()
    {
        readyToShoot = false;
        RaycastHit hit;
        if(Physics.Raycast(originPos.position, originPos.forward, out hit, distance, enemies))
        {
            Debug.Log("Hit Enemy");
            Vector3 hitPosition = hit.point;
            Destroy(hit.transform.gameObject);
        }
        else
        {
            Debug.Log("Miss");
        }
        readyToShoot = true;
    }

    void InstantiateShoot()
    {
        readyToShoot = false;
        GameObject projectileRef = Instantiate(projectile, originPos.position, Quaternion.identity);
        Rigidbody projectileRb = projectileRef.GetComponent<Rigidbody>();
        Vector3 forceDirection = originPos.transform.forward;
        Vector3 forceToAdd = forceDirection * shootForce + transform.up * shootUpwardforce;
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
        readyToShoot = true;
    }
}
