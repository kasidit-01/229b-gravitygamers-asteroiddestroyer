using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float force;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force);
    }
 
}

