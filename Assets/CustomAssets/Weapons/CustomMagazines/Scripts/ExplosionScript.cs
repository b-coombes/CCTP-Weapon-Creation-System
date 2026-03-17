using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public Vector3 direction;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1.5f)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Target"))
        {
            collision.GetComponent<Entity>().Health -= 100;
            Debug.LogWarning("Target hit");
            
        }
        Debug.LogWarning("explosion");
    }
}
