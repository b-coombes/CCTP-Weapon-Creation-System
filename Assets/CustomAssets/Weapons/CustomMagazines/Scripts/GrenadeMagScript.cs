using System.Threading;
using UnityEngine;

public class GrenadeMagScript : MonoBehaviour
{
    //public MagazineScript MagazineScript;
    
    private float grenadeTimer;



    public GameObject Explosion;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("grenade GOOOO");
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name != "PlayerCharacter")
        {
            if (collision.transform.gameObject.name != "Gun W_ shape keys")
            {
                if (collision.transform.gameObject.name != "Magazine")
                {
                    Vector3 hitPoint = collision.contacts[0].point;
                    Instantiate(Explosion, this.gameObject.transform.position, Quaternion.identity);
                    //Debug.LogWarning(collision.transform.gameObject.name);
                    Destroy(this.gameObject);
                }
            }
        }
        
    }
 /*
    public void Explode()
    {
        Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        grenadeTimer = 0;
        Destroy(this.gameObject);
    }


   
    
    */
    















}