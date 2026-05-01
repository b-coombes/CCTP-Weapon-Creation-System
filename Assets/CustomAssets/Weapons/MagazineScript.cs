using System.Threading;
using UnityEngine;
using Random = System.Random;

public class MagazineScript : MonoBehaviour
{
    public GameObject gunModel;
    public Gun gunScript;
    public GameObject magazine;
    public GameObject grenadeMag;
    public GameObject bluntMag;
    public GameObject normalMag;



    public string magTypeString;
    public float magCount;



    private GameObject magType;
    private Transform PlayerCamera;

    private float invisTimer;


    private float ejectTimer;
    private bool ejectStatus;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Randomise();
        PlayerCamera = Camera.main.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gunScript.equiped)
        {
            if (!ejectStatus)
            {


                if (Input.GetKey(KeyCode.R))
                {
                    if (!ejectStatus && magCount != 0)
                    {
                        EjectMag();
                    }

                }
            }
            if (ejectStatus)
            {
                if (ejectTimer <= Time.time && magCount != 0)
                {
                    ejectTimer = 0;
                    magazine.GetComponent<Renderer>().enabled = true;
                    ejectStatus = false;
                    gunScript.currentAmmo = gunScript.maxAmmo;
                }

            }
            /*
            if (Input.GetKey(KeyCode.T))
            {
                if (gunScript.randCooldown < Time.time)
                {
                    gunScript.randCooldown = Time.time + 2;
                    Randomise();
                }
            }
            */

        }
    }


    public void EjectMag()
    {
        gunScript.currentAmmo = 0;
        if (magType != normalMag)
        {
            GameObject ejectedMag = Instantiate(magType, magazine.gameObject.transform.position, Quaternion.identity);

            Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
            Debug.DrawRay(PlayerCamera.position, PlayerCamera.forward * 100, Color.red);
            Vector3 targetPoint;
            if (Physics.Raycast(gunRay, out RaycastHit hitInfo))
            {
                targetPoint = hitInfo.point;
            }
            else
            {
                targetPoint = gunRay.GetPoint(75);
            }
            Vector3 direction = targetPoint - gunModel.transform.position;

            ejectedMag.transform.forward = direction.normalized;

            ejectedMag.GetComponent<Rigidbody>().AddForce(direction.normalized * 20, ForceMode.Impulse);
        }
        else
        {
            GameObject ejectedMag = Instantiate(magType, magazine.gameObject.transform.position, Quaternion.identity);
        }

        magCount -= 1;

        magazine.GetComponent<Renderer>().enabled = false;
        ejectStatus = true;
        ejectTimer = Time.time + 2;
    }

    public void Randomise() 
    {
        magType = null;
        Random rnd = new Random();
        int rand = rnd.Next(2, 5);

        magCount = rand;

        //Magazine type----------------------------------------

        rand = rnd.Next(1, 4);

        if (rand == 1)
        {
            magType = grenadeMag;
            magTypeString = "Grenade";
        }
        else if(rand == 2)
        {
            magType = bluntMag;
            magTypeString = "Blunt";
        }
        else if(rand == 3)
        {
            magType = normalMag;
            magTypeString = "Normal";
        }
        
        //Element type----------------------------------------
        rand = rnd.Next(1, 5);
        if (rand == 1) 
        {
            gunScript.element = "acid";
            Debug.Log("Element type: Acid");
            
        }
        else if (rand == 2)
        {
            gunScript.element = "water";
            Debug.Log("Element type: Water");
            
        }
        else if (rand == 3)
        {
            gunScript.element = "lead";
            Debug.Log("Element type: Lead");
            
        }
        else if (rand == 4)
        {
            gunScript.element = "explosive";
            Debug.Log("Element type: Explosive");

        }
    }



    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(active)
        {
            if (collision.transform.gameObject.name != "Player")
            {
                if (collision.transform.gameObject.name != "Gun W_ shape keys")
                {
                    Explode();
                    Debug.LogWarning("Collision non player run");
                }
            }
        }
    }
    */
















}