using UnityEngine;

public class CarAI : MonoBehaviour
{
    public float speed;
    public float minSpeed = 10f;
    public float maxSpeed = 20f;
    
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
