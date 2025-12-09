using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    [Header("References")]
    private Transform PlayerCamera;
    public GameObject impactObject;
    public Gun gun;



    [Header("Configurations")]
    [SerializeField]
    float damage;







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerCamera = Camera.main.transform;
        
    }

    public void Shoot()         //handles firing/ hit registration
    {
        Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);      //fires a raycast from camera object
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, gun.bulletRange))       
        {
            Instantiate(impactObject, hitInfo.point, Quaternion.identity);      //creates an instance of the impact object on impact location
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))  //runs if hit entity is a target
            {
                enemy.Health -= damage;                                         //deals damage to targets health
            }
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
