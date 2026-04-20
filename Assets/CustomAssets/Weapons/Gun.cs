using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Unity.VisualScripting;

public class Gun : MonoBehaviour
{


    [Header("References")]
    public WeaponCreation creation;

    private PlayerController playerController;

    private TMP_Text gunInfo;

    public MagazineScript mag;

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

    public float maxAmmo;
    public float currentAmmo;

    public string element;

    public string type;

    [Header("Display Variables")]
    [SerializeField] 
    float verticalRecoilCount;
 
    public float currentCooldown;

    [SerializeField]
    public float randCooldown;

    public bool equiped;


    private bool fired;
    private float timeCheck;
    private float holdTime = 0f;
    private float holdDuration = 0.5f;
    private bool proxCheck;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gunInfo = GameObject.FindGameObjectWithTag("GunInfo").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (equiped)
        {
            if (Input.GetMouseButton(0) && currentAmmo > 0 && isAutomatic)        //on mouse HOLD specifically
            {
                shooting();
            }
            if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && !isAutomatic)
            {
                shooting();
            }

            /*
            if (Input.GetMouseButtonUp(0) )//&& isAutomatic)
            {
                RevertRecoil(2);
            }
            */

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
            /*
            if (Input.GetKey(KeyCode.T))
            {
                if (Time.time > randCooldown)
                {
                    creation.Randomise();
                    randCooldown =Time.deltaTime + 2;

                }
            }
            */
            gunInfo.text = (element.FirstCharacterToUpper() + " " + type + " - " + mag.magCount + "x Magazines(" + mag.magTypeString + ") - Ammo: " + currentAmmo.ToString());
            Vector3 newPosition = playerController.transform.position + playerController.transform.right * 0.7f;
            this.transform.position = newPosition;

            Quaternion correction = Quaternion.Euler(-90, 0, 180);
            this.transform.rotation = playerController.transform.GetChild(0).GetChild(0).rotation * correction;





            if (Input.GetKeyDown(KeyCode.F))
            {
                holdTime = Time.time;
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                float heldTime = Time.time - holdTime;
                if (heldTime >= holdDuration)
                {
                    equiped = false;
                    Vector3 newPos = playerController.gameObject.transform.GetChild(0).GetChild(0).transform.position + 
                        playerController.gameObject.transform.GetChild(0).GetChild(0).transform.forward * 1f - 
                        playerController.gameObject.transform.GetChild(0).GetChild(0).transform.right * 0.6f;
                    this.transform.position = newPos;
                    this.transform.rotation = Quaternion.Euler(0, 0, 270);
                    this.transform.SetParent(null);
                    this.GetComponent<BoxCollider>().enabled = true;
                    this.GetComponent<Rigidbody>().useGravity = true;
                }
            }
        }
        else
        {
            gunInfo.text = ("No gun active");
            
            if (proxCheck)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    holdTime = Time.time;

                }
                if (Input.GetKeyUp(KeyCode.F))
                {

                    float heldTime = Time.time - holdTime;
                    if (heldTime >= holdDuration)
                    {
                        equiped = true;
                        this.transform.SetParent(playerController.gameObject.transform.GetChild(0).GetChild(0));
                        this.GetComponent<BoxCollider>().enabled = false;
                        this.GetComponent<Rigidbody>().useGravity = false;
                    }
                }
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            proxCheck = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            proxCheck = false;
        }
    }

    private void shooting()
    {
        if (currentCooldown <= 0f)
        {
            OnGunShoot?.Invoke();       //uses the shoot command in DamageGun.cs
            currentAmmo -= 1;
            currentCooldown = fireCooldown;         //activates cooldown timer
            Recoil(new Vector3(verticalRecoil, 0, 0));      //activates recoil determined by variable edited in inspector

            fired = true;
            timeCheck = (float)Time.time + (float)0.5;      //gets time 0.5 seconds after code is run
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
