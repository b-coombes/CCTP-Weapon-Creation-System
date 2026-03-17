using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;
using Random = System.Random;

public class MagazineScript : MonoBehaviour
{
    public GameObject gunModel;
    public GameObject magazine;
    public GameObject grenadeMag;
    public GameObject bluntMag;
    public GameObject normalMag;





    private GameObject magType;
    private Transform PlayerCamera;

    private float invisTimer;

    private float randCooldown;

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
        if (invisTimer < Time.time)
        {
            magazine.GetComponent<Renderer>().enabled = true;

            if (Input.GetKey(KeyCode.R))
            {
                if (!ejectStatus)
                {
                    EjectMag();
                }

            }
            if (ejectTimer >= 1.5f)
            {
                ejectStatus = false;
                ejectTimer = 0;
            }
            else
            {
                ejectTimer += Time.time;
            }
            if (Input.GetKey(KeyCode.T))
            {
                if (randCooldown < Time.time)
                {
                    randCooldown = Time.time + 1;
                    Randomise();
                }
            }
        }
    }


    public void EjectMag()
    {
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

        magazine.GetComponent<Renderer>().enabled = false;
        invisTimer = Time.time + 2;
        ejectStatus = true;
    }

    public void Randomise() 
    {
        magType = null;
        Random rnd = new Random();
        int rand = rnd.Next(1, 4);
        if (rand == 1)
        {
            magType = grenadeMag;
            Debug.Log("Grenade");
        }
        else if(rand == 2)
        {
            magType = bluntMag;
            Debug.Log("blunt");
        }
        else if(rand == 3)
        {
            magType = normalMag;
            Debug.Log("Normal");
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