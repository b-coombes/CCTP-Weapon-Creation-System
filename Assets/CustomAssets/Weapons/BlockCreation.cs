using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class BlockCreation : MonoBehaviour
{
    [SerializeField]
    GameObject component1;
    [SerializeField]
    GameObject component2;
    [SerializeField]
    GameObject component3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        component1.GetComponent<Renderer>().material.color = Color.red;
        component2.GetComponent<Renderer>().material.color = Color.green;
        component3.GetComponent<Renderer>().material.color = Color.black;
        component1.GetComponent<Renderer>().enabled = false;
        component2.GetComponent<Renderer>().enabled = false;
        component3.GetComponent<Renderer>().enabled = false;


        List<GameObject> part_list = new List<GameObject> { component1, component2, component3 };
        Random rnd = new();
        int listNum = rnd.Next(part_list.Capacity - 1);
        part_list[listNum].GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }



}
