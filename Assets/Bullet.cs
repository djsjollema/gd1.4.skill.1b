using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 velocity;
    Vector3 direction = Vector3.right;
    float speed = 15.0f;

    void Start()
    {
        
    }

    void Update()
    {
        velocity = direction * speed * Time.deltaTime;
        transform.position += velocity;
        
    }
}
