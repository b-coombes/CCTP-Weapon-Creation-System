using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;

public class WeaponCreation : MonoBehaviour
{
    public Gun gunScript;
    public SkinnedMeshRenderer gunMesh;
    private int lastType;
    public GameObject gun;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()    
    {
        Randomise();
    }


    public void Randomise()
    {
        gunScript.shotgun = false;
        gunScript.sniper = false;
        gunScript.isAutomatic = false;

        Random rnd = new Random();
        int type = rnd.Next(1, 6);
        
        while (type == lastType)
        {
            type = rnd.Next(1, 6);
        }
        lastType = type;


        if (type == 1)
        {
            //shotgun
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 1"), 0f);
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 2"), 100f);
            gunScript.shotgun = true;
            gunScript.fireCooldown = 1.5f;
            gunScript.verticalRecoil = -0.2f;

            gunScript.damage = 30;
            gunScript.shotgunPellets = 4;
            gunScript.shotgunSpread = 0.3f;
            gunScript.bulletRange = 20;
            gunScript.maxAmmo = 2;
            gunScript.currentAmmo = gunScript.maxAmmo;
        }
        if (type == 2)
        {
            //auto shotgun
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 1"), 0f);
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 2"), 50f);
            gunScript.shotgun = true;
            gunScript.isAutomatic = true;
            gunScript.fireCooldown = 0.5f;
            gunScript.verticalRecoil = -0.1f;

            gunScript.damage = 15;
            gunScript.shotgunPellets = 8;
            gunScript.shotgunSpread = 0.1f;
            gunScript.bulletRange = 15;
            gunScript.maxAmmo = 5;
            gunScript.currentAmmo = gunScript.maxAmmo;
        }

        if (type == 3)
        {
            //rifle
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 1"), 0f);
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 2"), 0f);
            gunScript.isAutomatic = true;
            gunScript.fireCooldown = 0.2f;
            gunScript.verticalRecoil = -0.05f;

            gunScript.damage = 20;
            gunScript.bulletRange = 300;
            gunScript.maxAmmo = 10;
            gunScript.currentAmmo = gunScript.maxAmmo;
        }

        if (type == 4)
        {
            //auto sniper
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 1"), 50f);
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 2"), 0f);
            gunScript.sniper = true;
            gunScript.isAutomatic = true;
            gunScript.fireCooldown = 0.5f;
            gunScript.verticalRecoil = -0.1f;

            gunScript.damage = 40;
            gunScript.bulletRange = 50;
            gunScript.maxAmmo = 5;
            gunScript.currentAmmo = gunScript.maxAmmo;
        }

        if (type == 5)
        {
            //sniper
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 1"), 100f);
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 2"), 0f);
            gunScript.sniper = true;
            gunScript.fireCooldown = 1.5f;
            gunScript.verticalRecoil = -0.2f;

            gunScript.damage = 60;
            gunScript.bulletRange = 70;
            gunScript.maxAmmo = 3;
            gunScript.currentAmmo = gunScript.maxAmmo;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

}
