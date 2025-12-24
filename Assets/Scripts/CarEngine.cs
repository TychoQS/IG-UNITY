using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public float velocity = 10f;
    public float rotationSpeed = 100f;

    void Update()
    {
        // 1. INPUTS
        float verticalInput = Input.GetAxis("Vertical");   // W / S
        float horizontalInput = Input.GetAxis("Horizontal"); // A / D

        // 2. DESPLAZAMIENTO
        Vector3 movement = Vector3.forward * verticalInput * velocity * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        // 3. ROTACIÓN
        if (Mathf.Abs(verticalInput) > 0.1f)
        {
            // DETECTAR DIRECCIÓN (Si es hacia delante o hacia atrás)
            float direction = verticalInput > 0 ? 1 : -1;

            // Multiplicamos el giro por 'direction'.
            float turn = horizontalInput * rotationSpeed * Time.deltaTime * direction;
            
            transform.Rotate(0, turn, 0, Space.Self);
        }
    }
}