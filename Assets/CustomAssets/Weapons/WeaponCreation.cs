using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class WeaponCreation : MonoBehaviour
{
    public Gun gunScript;

    private GameObject stock;
    private GameObject body;
    private GameObject barrel;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()    {

        stock = this.gameObject.transform.GetChild(0).gameObject;
        body = this.gameObject.transform.GetChild(1).gameObject;
        barrel = this.gameObject.transform.GetChild(2).gameObject;

        Randomise();
    
    
    }


    public void Randomise()
    {
        Creation(stock, 1);
        Creation(body, 2);
        Creation(barrel, 3);
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
                gunScript.verticalRecoil = (float)-0.07;
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
                gunScript.verticalRecoil = (float)-1.2;
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
                gunScript.verticalRecoil = (float)-2;
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
