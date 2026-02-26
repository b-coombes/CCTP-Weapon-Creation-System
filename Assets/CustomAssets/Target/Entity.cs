using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField]
    public float startingHealth;
    public TMP_Text healthText;
    


    [Header("Display Variables")]
    [SerializeField]
    public float health;


    
    
    
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
