using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = System.Random;

public class WeaponCreation : MonoBehaviour
{
    public Gun gunScript;

    private GameObject stock;
    private GameObject body;
    private GameObject barrel;

    public SkinnedMeshRenderer gunMesh;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()    {

        stock = this.gameObject.transform.GetChild(0).gameObject;
        body = this.gameObject.transform.GetChild(1).gameObject;
        barrel = this.gameObject.transform.GetChild(2).gameObject;
        
        
        
        Randomise();
    
    
    }


    public void Randomise()
    {
        gunScript.shotgun = false;
        gunScript.isAutomatic = false;

        Random rnd = new Random();
        
        int morphIntensity = rnd.Next(1, 201);

        if (morphIntensity < 100)
        {
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 2"), morphIntensity);
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 1"), 0f);
        }
        else if (morphIntensity == 100)
        {
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 1"), 0f);
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 2"), 0f);
        }
        else if (morphIntensity > 100)
        {
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 1"), (morphIntensity - 100));
            gunMesh.SetBlendShapeWeight(gunMesh.sharedMesh.GetBlendShapeIndex("Key 2"), 0f);
        }

        if (morphIntensity < 66.6)
        {
            //shotgun


            gunScript.shotgun = true;
            gunScript.shotgunSpread = (morphIntensity / 10);
            gunScript.bulletRange = (100 - morphIntensity) / 10;

            if (morphIntensity <= 11)
            {
                gunScript.shotgunPellets = 2;
                gunScript.damage = 50;
            }
            else if (morphIntensity > 11 && morphIntensity <= 22)
            {
                gunScript.shotgunPellets = 3;
                gunScript.damage = 45;
            }
            else if (morphIntensity > 22 && morphIntensity <= 33)
            {
                gunScript.shotgunPellets = 4;
                gunScript.damage = 40;
            }
            else if (morphIntensity > 33 && morphIntensity <= 44)
            {
                gunScript.shotgunPellets = 5;
                gunScript.damage = 35;
            }
            else if (morphIntensity > 44 && morphIntensity <= 55)
            {
                gunScript.shotgunPellets = 6;
                gunScript.damage = 30;
            }
            else if (morphIntensity > 55 && morphIntensity <= 66)
            {
                gunScript.shotgunPellets = 7;
                gunScript.damage = 25;
            }
        }
        else if (morphIntensity >= 66.6 && morphIntensity <= 133.3) 
        {
            //Auto Rifle
            if(morphIntensity < 100)
            {
                gunScript.shotgun = true;
                gunScript.shotgunSpread = (morphIntensity / 10);
                gunScript.bulletRange = (100 - morphIntensity) / 20;
                gunScript.isAutomatic = true;

                if (morphIntensity <= 77)
                {
                    gunScript.shotgunPellets = 6;
                    gunScript.damage = 25;
                }
                else if (morphIntensity > 77 && morphIntensity <= 88)
                {
                    gunScript.shotgunPellets = 4;
                    gunScript.damage = 20;
                }
                else if (morphIntensity > 88 && morphIntensity < 100)
                {
                    gunScript.shotgunPellets = 2;
                    gunScript.damage = 15;
                }

            }
            else if(morphIntensity == 100)
            {
                gunScript.isAutomatic = true;
                gunScript.damage = 10;
            }
            else if(morphIntensity > 100)
            {
                gunScript.bulletRange = 100 - (morphIntensity / 2);

                if (morphIntensity > 100 && morphIntensity <= 111)
                {
                    gunScript.damage = 20;
                }
                else if (morphIntensity > 111 && morphIntensity <= 122)
                {
                    gunScript.damage = 30;
                }
                else if (morphIntensity > 122 && morphIntensity < 133)
                {
                    gunScript.damage = 40;
                }
            }


        }
        else if(morphIntensity >= 133)
        {
            //Sniper Rifle
            

            gunScript.bulletRange = 100 - morphIntensity;

            if (morphIntensity > 133 && morphIntensity <= 144)
            {
                gunScript.damage = 50;
            }
            else if (morphIntensity > 144 && morphIntensity <= 155)
            {
                gunScript.damage = 60;
            }
            else if (morphIntensity > 155 && morphIntensity < 166)
            {
                gunScript.damage = 70;
            }
            if (morphIntensity > 166 && morphIntensity <= 177)
            {
                gunScript.damage = 80;
            }
            else if (morphIntensity > 177 && morphIntensity <= 188)
            {
                gunScript.damage = 90;
            }
            else if (morphIntensity > 199 && morphIntensity <= 200)
            {
                gunScript.damage = 100;
            }
        }
        
        /*
        Creation(stock, 1);
        Creation(body, 2);
        Creation(barrel, 3);
        */
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Creation(GameObject part, int check)
    {


        List<Color> colorlist = new List<Color> { Color.red, Color.green, Color.purple };
        Random rnd = new();
        int listNum = rnd.Next(colorlist.Capacity - 1);
        part.GetComponent<Renderer>().material.color = colorlist[listNum];






        if (part.GetComponent<Renderer>().material.color == Color.red)
        {
            if (check == 1)
            {
                gunScript.verticalRecoil = (float)-0.01;
            }
            else if (check == 2)
            {
                gunScript.fireCooldown = (float)0.2;
            }
            else if (check == 3)
            {
                gunScript.bulletRange = 10;
            }
        }

        if (part.GetComponent<Renderer>().material.color == Color.green)
        {
            if (check == 1)
            {
                gunScript.verticalRecoil = (float)-0.015;
            }
            else if (check == 2)
            {
                gunScript.fireCooldown = (float)0.5;
            }
            else if (check == 3)
            {
                gunScript.bulletRange = 20;
            }
        }

        if (part.GetComponent<Renderer>().material.color == Color.purple)
        {
            if (check == 1)
            {
                gunScript.verticalRecoil = (float)-0.025;
            }
            else if (check == 2)
            {
                gunScript.fireCooldown = (float)0.8;
            }
            else if (check == 3)
            {
                gunScript.bulletRange = 30;
            }
        }

        gunScript.currentCooldown = gunScript.fireCooldown;



    }

}
