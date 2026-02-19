using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.PackageManager;
using JetBrains.Annotations;

public class DamageGun : MonoBehaviour
{
    [Header("References")]
    private Transform PlayerCamera;
    public GameObject impactObject;
    public Gun gun;



    







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerCamera = Camera.main.transform;
        
    }

    public void Shoot()         //handles firing/ hit registration
    {

        if (!gun.shotgun)
        {
            Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);      //fires a raycast from camera object
            Debug.DrawRay(PlayerCamera.position, PlayerCamera.forward * 100, Color.red);
            if (Physics.Raycast(gunRay, out RaycastHit hitInfo, gun.bulletRange))
            {
                Instantiate(impactObject, hitInfo.point, Quaternion.identity);      //creates an instance of the impact object on impact location
                if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))  //runs if hit entity is a target
                {
                    enemy.Health -= gun.damage;                                         //deals damage to targets health
                }
            }
        }
        if (gun.shotgun) 
        {
            for (int i = 0; i < gun.shotgunPellets; i++)
            {

                Vector2 randomPoint = Random.insideUnitCircle * gun.shotgunSpread;
                Vector3 spreadDirection = PlayerCamera.forward + 
                    PlayerCamera.right * randomPoint.x + PlayerCamera.up * (randomPoint.y / 2);
                spreadDirection.Normalize();

                Ray gunRay = new Ray(PlayerCamera.position, spreadDirection);      //fires a raycast from camera object
                Debug.DrawRay(PlayerCamera.position, PlayerCamera.forward * 100, Color.red);
                if (Physics.Raycast(gunRay, out RaycastHit hitInfo, gun.bulletRange))
                {
                    Instantiate(impactObject, hitInfo.point, Quaternion.identity);      //creates an instance of the impact object on impact location
                    if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))  //runs if hit entity is a target
                    {
                        enemy.Health -= gun.damage;                                         //deals damage to targets health
                    }
                }
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
