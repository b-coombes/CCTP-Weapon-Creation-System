using UnityEngine;

public class ButtonSpawn : MonoBehaviour
{
    public GameObject gunPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject newGun = Instantiate(gunPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
