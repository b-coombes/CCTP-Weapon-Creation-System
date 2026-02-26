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

            gunScript.damage = 50;
            gunScript.shotgunPellets = 4;
            gunScript.shotgunSpread = 0.3f;
            gunScript.bulletRange = 20;
        }
        if (type == 2)
        {
            //auto shotgun
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 1"), 0f);
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 2"), 50f);
            gunScript.shotgun = true;
            gunScript.isAutomatic = true;
            gunScript.fireCooldown = 0.5f;

            gunScript.damage = 25;
            gunScript.shotgunPellets = 8;
            gunScript.shotgunSpread = 0.1f;
            gunScript.bulletRange = 15;
        }

        if (type == 3)
        {
            //rifle
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 1"), 0f);
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 2"), 0f);
            gunScript.isAutomatic = true;
            gunScript.fireCooldown = 0.3f;

            gunScript.damage = 50;
            gunScript.bulletRange = 300;
        }

        if (type == 4)
        {
            //auto sniper
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 1"), 50f);
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 2"), 0f);
            gunScript.sniper = true;
            gunScript.isAutomatic = true;
            gunScript.fireCooldown = 0.5f;

            gunScript.damage = 75;
            gunScript.bulletRange = 50;
        }

        if (type == 5)
        {
            //sniper
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 1"), 100f);
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 2"), 0f);
            gunScript.sniper = true;
            gunScript.fireCooldown = 1.5f;

            gunScript.damage = 120;
            gunScript.bulletRange = 70;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

}
