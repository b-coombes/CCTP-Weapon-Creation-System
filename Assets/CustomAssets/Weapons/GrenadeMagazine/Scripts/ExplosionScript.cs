using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == Time.time)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.TryGetComponent(out Entity enemy))
        {
            enemy.Health -= 50;
        }
    }
}
