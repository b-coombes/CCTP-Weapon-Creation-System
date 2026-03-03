using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;

public class GrenadeMagScript : MonoBehaviour
{
    private Transform PlayerCamera;
    private GameObject freshGrenadeMag;
    private GameObject spentGrenadeMag;


    private float grenadeTimer;
    private bool active;

    public GameObject GrenadeMagProjectile;
    public GameObject Explosion;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            gameObject.transform.parent = null;
            if (grenadeTimer == Time.time)
            {
                Explode();
            }
        }
        else
        {
            gameObject.transform.SetParent(gameObject.transform, true);
        }



        if (Input.GetKey(KeyCode.R))
        {
            if (!active)
            {
                EjectMag();
            }
        }
    }

    public void EjectMag()
    {
        if (grenadeTimer == 0)
        {
            Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
            Vector3 targetPoint;
            if (Physics.Raycast(gunRay, out RaycastHit hitInfo))
            {
                targetPoint = hitInfo.point;
            }
            else
            {
                targetPoint = gunRay.GetPoint(75);
            }
            Vector3 direction = targetPoint - PlayerCamera.transform.position;

            spentGrenadeMag = Instantiate(GrenadeMagProjectile, PlayerCamera.position, Quaternion.identity);

            spentGrenadeMag.transform.forward = direction.normalized;

            spentGrenadeMag.GetComponent<Rigidbody>().AddForce(direction.normalized * 5, ForceMode.Impulse); ;

            grenadeTimer = Time.time + 3f;
            active = true;
        }
    }

    public void Explode()
    {
        Instantiate(Explosion, spentGrenadeMag.transform.position, Quaternion.identity);
        Destroy(spentGrenadeMag);
        grenadeTimer = 0;
        active = false;
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