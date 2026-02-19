using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{


    [Header("References")]
    public WeaponCreation creation;
    public PlayerController playerController;

    [Header("Configurations")]
    [SerializeField]
    UnityEvent OnGunShoot;
    
    [SerializeField]
    public bool isAutomatic;

    public bool shotgun;

    public float bulletRange;

    public float fireCooldown;

    public float verticalRecoil;

    public float shotgunSpread;

    public float shotgunPellets;

    public float damage;

    [Header("Display Variables")]
    [SerializeField] 
    float verticalRecoilCount;
 
    public float currentCooldown;




    private bool fired;
    private float timeCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (isAutomatic)    //weapon is set to automatic using boolean in inspector
        {
            if (Input.GetMouseButton(0))        //on mouse HOLD specifically
            {
                if (currentCooldown <= 0f)      //if not on cooldown
                {
                    OnGunShoot?.Invoke();       //uses the shoot command in DamageGun.cs
                    currentCooldown = fireCooldown;         //activates cooldown timer
                    Recoil(new Vector3(verticalRecoil, 0, 0));      //activates recoil determined by variable edited in inspector
                }
            }
            if (Input.GetMouseButtonUp(0))  //on release of mouse button
            {
                RevertRecoil(2);            //initiates recoil reversal to normalise camera
            }
        }
        else         //activates if weapon is not set to automatic via boolean
        {
            if (Input.GetMouseButtonDown(0))    //only triggers once instead of hold
            {
                if (currentCooldown <= 0f)
                {

                    OnGunShoot?.Invoke();
                    currentCooldown = fireCooldown;
                    Recoil(new Vector3(verticalRecoil, 0, 0));
                    fired = true;
                    if (Time.time >= timeCheck)
                    {
                        timeCheck = (float)Time.time + (float)0.5;      //gets time 0.5 seconds after code is run
                    }
                }
            }
            if (fired)
            {
                if (Time.time >= timeCheck)     //if 0.5 seconds has passed from firing
                {
                    RevertRecoil(2);            //recoil will reduce by how many fired during time
                    fired = false;
                }
            }
        }
        if (currentCooldown <= 0f)
        {
            currentCooldown = 0f;       //prevents cooldown from going bellow zero, not needed but nice to have
        }
        else
        {
            currentCooldown -= Time.deltaTime;      //reduces cooldown by a second every second
        }

        if (Input.GetKey(KeyCode.R))
        {
            creation.Randomise();
        }



    }


    public void Recoil(Vector3 recoilAmount)
    {
        if (playerController.recoil != verticalRecoil)
        {
            playerController.recoil += verticalRecoil;
        }
        
        /*
        Camera.main.transform.Rotate(recoilAmount);     //rotates camera by however much is specified
        verticalRecoilCount += verticalRecoil;          //tracks how many times recoil code is run
        */
        
    }
    public void RevertRecoil(int divideReduction)
    {
        playerController.recoil = 0;
        /*
        verticalRecoilCount = (verticalRecoilCount/divideReduction)*-1;         //converts how many times recoil is run into how much it needs to change rotation back
        Camera.main.transform.Rotate(new Vector3(verticalRecoilCount, 0, 0));
        verticalRecoilCount = 0;
        */
    }



}
