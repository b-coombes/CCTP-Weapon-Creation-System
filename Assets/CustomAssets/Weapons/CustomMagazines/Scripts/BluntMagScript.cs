using UnityEngine;

public class BluntMagScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("blunt GOOOO");
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
                    if (collision.gameObject.tag == "Target")
                    {
                        collision.gameObject.GetComponent<Entity>().Health -= 100;
                        //Debug.LogWarning("Target hit");

                    }
                    //Debug.LogWarning(collision.transform.gameObject.name);
                }
            }
        }

    }


}
