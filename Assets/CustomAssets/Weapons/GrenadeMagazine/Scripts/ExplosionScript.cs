using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
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
        if(timer >= 2)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Entity enemy))
        {
            enemy.Health -= 50;
            Debug.LogWarning("Target", enemy);
            
        }
        Debug.LogWarning("collision");
    }
}
