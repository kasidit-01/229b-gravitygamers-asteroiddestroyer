using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float upperBound = 30;
    private float lowerBound = -30;
    void Update()
    {
        if (transform.position.z > upperBound)
        {
            Destroy(gameObject);       
        }

        if (transform.position.z < lowerBound)
        { 
            Destroy(gameObject);
        }
    }

}
