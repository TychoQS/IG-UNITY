using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Color oldColor;

    public void Start()
    {
        oldColor = GetComponent<MeshRenderer>().material.color;
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision detected with " + other.gameObject.name);

        // Generar color aleatorio
        Color randomColor = new Color(
            Random.value,  // R
            Random.value,  // G
            Random.value   // B
        );

        GetComponent<MeshRenderer>().material.color = randomColor;
    }

    public void OnCollisionExit(Collision other)
    {
            GetComponent<MeshRenderer>().material.color = oldColor;
    }
}
