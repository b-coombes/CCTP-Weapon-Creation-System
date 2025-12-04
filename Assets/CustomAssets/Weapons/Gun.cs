using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{


    public UnityEvent OnGunShoot;
    public float fireCooldown;
    public bool isAutomatic;

    private float currentCooldown;
    public float displayCooldown;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCooldown = fireCooldown / 1000000000000;
        
    }

    // Update is called once per frame
    void Update()
    {
        displayCooldown = currentCooldown;
        if (isAutomatic)
        {
            if (Input.GetMouseButton(0))
            {
                if (currentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    currentCooldown = fireCooldown;

                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    currentCooldown = fireCooldown;
                }
            }
        }
        if (currentCooldown <= 0f)
        {
            currentCooldown = 0f;
        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
    }
}
