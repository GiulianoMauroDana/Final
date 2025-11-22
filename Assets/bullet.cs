using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float bulletSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position,spawnPoint.rotation);
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            rb.AddForce(spawnPoint.forward*bulletSpeed);
            Destroy(newBullet, 2f);
        }
    }
    
}
