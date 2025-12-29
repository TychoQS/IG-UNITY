using UnityEngine;

public class TeleportByTag : MonoBehaviour
{
    [Header("Tag Settings")]
    public string tagToTeleport = "Vehicle";
    public string reverseTag = "RVehicle";
    
    [Header("Teleport Settings")]
    public float endPosition = 650;
    public float startPosition = -900f;
    
    private GameObject[] objectsToTeleport;
    private GameObject[] reverseObjects;
    
    void Start()
    {
        objectsToTeleport = GameObject.FindGameObjectsWithTag(tagToTeleport);
        reverseObjects = GameObject.FindGameObjectsWithTag(reverseTag);
    }
    
    void Update()
    {
        // Vehículos normales
        foreach (GameObject obj in objectsToTeleport)
        {
            if (obj == null) continue;
            
            if (obj.transform.position.z > endPosition)
            {                
                Vector3 newPos = obj.transform.position;
                // Mantiene X e Y originales, solo cambia Z
                newPos.z = startPosition;
                obj.transform.position = newPos;
            }
        }
        
        // RVehicles (sentido contrario)
        foreach (GameObject obj in reverseObjects)
        {
            if (obj == null) continue;
            
            if (obj.transform.position.z < startPosition)
            {                
                Vector3 newPos = obj.transform.position;
                // Mantiene X e Y originales, solo cambia Z
                newPos.z = endPosition;
                obj.transform.position = newPos;
            }
        }
    }
}
