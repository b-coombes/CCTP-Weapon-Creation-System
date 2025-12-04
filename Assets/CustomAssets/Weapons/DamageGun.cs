using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public float damage;
    public float bulletRange;
    private Transform PlayerCamera;
    public GameObject impactObject;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerCamera = Camera.main.transform;
        
    }

    public void Shoot()
    {
        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange))
        {
            Instantiate(impactObject, hitInfo.point, Quaternion.identity);
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= damage;
            }
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
