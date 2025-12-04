using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Impact : MonoBehaviour
{
    private float currentTime;
    public float despawnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        despawnTime += Time.time;
        Debug.Log("spawn");
        Debug.Log(despawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        if (currentTime >= despawnTime) 
        { 
            Destroy(gameObject);
            Debug.Log("despawn");
            
        }
        Debug.Log(currentTime);
    }
}
