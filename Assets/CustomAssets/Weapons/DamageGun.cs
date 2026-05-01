using UnityEngine;

public class DamageGun : MonoBehaviour
{
    [Header("References")]
    private Transform PlayerCamera;
    public GameObject impactObject;
    public GameObject explosiveObject;
    public Gun gun;



    







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerCamera = Camera.main.transform;
        
    }

    public void Shoot()         //handles firing/ hit registration
    {

        if (!gun.shotgun)
        {
            Ray gunRay = new Ray(PlayerCamera.position, PlayerCamera.forward);      //fires a raycast from camera object
            Debug.DrawRay(PlayerCamera.position, PlayerCamera.forward * 100, Color.red);
            if (Physics.Raycast(gunRay, out RaycastHit hitInfo, gun.bulletRange))
            {
                GameObject bullet = Instantiate(impactObject, hitInfo.point, Quaternion.identity);      //creates an instance of the impact object on impact location
                checks(bullet, hitInfo);
            }
        }
        if (gun.shotgun) 
        {
            for (int i = 0; i < gun.shotgunPellets; i++)
            {

                Vector2 randomPoint = Random.insideUnitCircle * gun.shotgunSpread;
                Vector3 spreadDirection = PlayerCamera.forward + 
                    PlayerCamera.right * randomPoint.x + PlayerCamera.up * (randomPoint.y / 2);
                spreadDirection.Normalize();

                Ray gunRay = new Ray(PlayerCamera.position, spreadDirection);      //fires a raycast from camera object
                Debug.DrawRay(PlayerCamera.position, PlayerCamera.forward * 100, Color.red);
                if (Physics.Raycast(gunRay, out RaycastHit hitInfo, gun.bulletRange))
                {
                    GameObject bullet = Instantiate(impactObject, hitInfo.point, Quaternion.identity);      //creates an instance of the impact object on impact location
                    checks(bullet, hitInfo);
                }
            }
        }
    }

    private void checks(GameObject checkObject, RaycastHit hitInfo)
    {
        if (gun.element == "acid")
        {
            checkObject.GetComponent<Renderer>().sharedMaterial.color = Color.lightGray;
        }
        else if (gun.element == "water")
        {
            checkObject.GetComponent<Renderer>().sharedMaterial.color = Color.lightGray;
        }
        else if (gun.element == "lead")
        {
            checkObject.GetComponent<Renderer>().sharedMaterial.color = Color.lightGray;
        }
        else if (gun.element == "explosive")
        {
            Instantiate(explosiveObject, checkObject.transform.position, Quaternion.identity);
            Debug.Log("should work");
        }
        
        
        if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))  //runs if hit entity is a target
        {
            if (enemy.weakness == gun.element)
            {
                enemy.Health -= gun.damage * 1.5f;                          //deals damage to targets health
                //Debug.Log("x1.5");
            }
            else if (gun.element == "explosive")
            {
                //this catches if enemy was hit by explosives and does nothing - damage handled in explosive script
            }
            else
            {
                enemy.Health -= gun.damage;
                //Debug.Log("x1");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
