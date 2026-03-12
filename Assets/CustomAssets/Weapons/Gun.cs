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

    public bool sniper;

    public float bulletRange;

    public float fireCooldown;

    public float verticalRecoil;

    public float shotgunSpread;

    public float shotgunPellets;

    public float damage;

    public float ammo;

    public string type;

    [Header("Display Variables")]
    [SerializeField] 
    float verticalRecoilCount;
 
    public float currentCooldown;

    [SerializeField]
    bool randCooldown;

    [SerializeField]
    float randCooldownStart;

    [SerializeField]
    float randCooldownEnd;



    private bool fired;
    private float timeCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))        //on mouse HOLD specifically
        {
            shooting();
        }
        if (Input.GetMouseButtonUp(0) && isAutomatic) 
        {
            RevertRecoil(2);
        }
        if (fired)      //doesnt affect fire rate - makes it so after 0.5 seconds recoil goes down instead of instant
        {
            if (Time.time >= timeCheck)     //if 0.5 seconds has passed from firing
            {
                RevertRecoil(2);            //recoil will reduce by how many fired during time
                fired = false;
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

        if (Input.GetKey(KeyCode.T))
        {
            if (!randCooldown)
            {
                creation.Randomise();
                randCooldown = true;
                randCooldownStart = Time.deltaTime;
                randCooldownEnd = randCooldownStart + 1;
            }
        }
        if (randCooldown)
        {
            randCooldownStart += Time.deltaTime;
            if (randCooldownStart >= randCooldownEnd)
            {
                randCooldown = false;
            }
        }
    }


    private void shooting()
    {
        if(isAutomatic || !fired) {
            if (currentCooldown <= 0f)
            {
                OnGunShoot?.Invoke();       //uses the shoot command in DamageGun.cs
                currentCooldown = fireCooldown;         //activates cooldown timer
                Recoil(new Vector3(verticalRecoil, 0, 0));      //activates recoil determined by variable edited in inspector
                if (!isAutomatic)
                {
                    fired = true;
                    if (Time.time >= timeCheck)
                    {
                        timeCheck = (float)Time.time + (float)0.5;      //gets time 0.5 seconds after code is run
                    }
                }

            }
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
