using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;

public class MagazineScript : MonoBehaviour
{
    public GameObject gunModel;
    public GameObject magazine;
    public GameObject grenadeMag;
    




    private GameObject magType;
    private Transform PlayerCamera;

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
            ejectTimer += Time.deltaTime;
        }
    }


    public void EjectMag()
    {
        Instantiate(magType, magazine.gameObject.transform.position, Quaternion.identity);

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

        magType.transform.forward = direction.normalized;

        grenadeMag.GetComponent<Rigidbody>().AddForce(direction * 5, ForceMode.Impulse); ;
        print(direction);
        print(direction.normalized);
        
        ejectStatus = true;
        


    }

    public void Randomise() 
    {
        magType = grenadeMag;
  

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