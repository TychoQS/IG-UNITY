using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarEngine : MonoBehaviour
{
    [Header("Movement")]
    public float forwardSpeed = 70f;
    public float lateralSpeed = 10f;
    public float acceleration = 10f;
    public float brakeForce = 10f;
    
    private Rigidbody rb;
    private float currentSpeed = 10f;
    private float verticalInput;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.constraints = RigidbodyConstraints.FreezeRotationX | 
                        RigidbodyConstraints.FreezeRotationY |
                        RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if (verticalInput != 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 
                                            forwardSpeed * verticalInput, 
                                            acceleration * Time.fixedDeltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, 
                                            brakeForce * Time.fixedDeltaTime);
        }

        Vector3 forwardMovement = transform.forward * currentSpeed * Time.fixedDeltaTime;
        Vector3 lateralMovement = transform.right * horizontalInput * lateralSpeed * Time.fixedDeltaTime;
        
        rb.MovePosition(rb.position + forwardMovement + lateralMovement);
    }
}
