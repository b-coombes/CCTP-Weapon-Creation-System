using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private float startingHealth;
    private float health;

    public float displayHealth;
    
    
    
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            Debug.Log(health);

            displayHealth = value;

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
