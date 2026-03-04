using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;

public class MagazineScript : MonoBehaviour
{
    public GameObject gunModel;
    public GameObject magazine;
    public GameObject grenadeMag;





    private GameObject magType;

    private float ejectTimer;
    private bool ejectStatus;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Randomise();
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

        Ray gunRay = new Ray(gunModel.transform.position, gunModel.transform.forward);
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

        magType.GetComponent<Rigidbody>().AddForce(direction.normalized * 50, ForceMode.Impulse); ;

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