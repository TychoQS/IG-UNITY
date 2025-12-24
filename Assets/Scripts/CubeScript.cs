using UnityEngine;

public class CubeScript : MonoBehaviour
{
public Transform cubeTransform;
public float velocity = 4f;
private Vector3 position;
// Start is called before the first frame update
void Start()
{
cubeTransform = GetComponent<Transform>();
position = cubeTransform.position;
}
// Update is called once per frame
void Update()
{
position = cubeTransform.position;
position.x += velocity * Time.deltaTime * Input.GetAxis("Horizontal");
position.z += velocity * Time.deltaTime * Input.GetAxis("Vertical");
cubeTransform.position = position;
}
}