using UnityEngine;

public class ButtonSpawn : MonoBehaviour
{
    public GameObject gunPrefab;

    Vector3 spawnPos;
    Quaternion spawnRot;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPos = this.gameObject.transform.position;
        spawnPos.y += 0.2f;
        spawnPos.x -= 0.6f;
        spawnPos.z -= 0.3f;
        spawnRot = Quaternion.Euler(0, 0, 270);
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
                GameObject newGun = Instantiate(gunPrefab, spawnPos, spawnRot);
            }
        }
    }
}
