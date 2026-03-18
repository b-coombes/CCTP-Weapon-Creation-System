using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using Random = System.Random;

public class Entity : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField]
    public float startingHealth;
    public TMP_Text healthText;
    public TMP_Text weaknessText;


    [Header("Display Variables")]
    [SerializeField]
    public float health;

    public string weakness;
    
    
    
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            //Debug.Log(health);
            healthText.text = health.ToString();

            if (health <= 0f)
            {
                Destroy(gameObject);
            }
        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = startingHealth;
        Random rnd = new Random();
        int rand = rnd.Next(1, 4);
        if(rand == 1)
        {
            weakness = "acid";
        }
        else if (rand == 2)
        {
            weakness = "water";
        }
        else if (rand == 3)
        {
            weakness = "lead";
        }
        weaknessText.text = weakness.ToUpper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
