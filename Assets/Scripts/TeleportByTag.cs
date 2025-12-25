using UnityEngine;

public class TeleportByTag : MonoBehaviour
{
    [Header("Tag Settings")]
    public string tagToTeleport = "Vehicle";
    
    [Header("Teleport Settings")]
    public float endPosition = 650;
    public float startPosition = -900f;
    
    [Header("Debug")]
    public bool showDebugMessages = true;
    
    private GameObject[] objectsToTeleport;
    
    void Start()
    {
        objectsToTeleport = GameObject.FindGameObjectsWithTag(tagToTeleport);
        if (showDebugMessages)
        {
            Debug.Log($"=== OBJETOS ENCONTRADOS CON TAG '{tagToTeleport}' ===");
            for (int i = 0; i < objectsToTeleport.Length; i++)
            {
                Debug.Log($"[{i}] {objectsToTeleport[i].name} - Posición: {objectsToTeleport[i].transform.position}");
            }
            Debug.Log($"Total encontrados: {objectsToTeleport.Length}");
        }
    }
    
    void Update()
    {
        foreach (GameObject obj in objectsToTeleport)
        {
            if (obj == null) continue;
            if (obj.transform.position.z > endPosition)
            {                
                Vector3 newPos = obj.transform.position;
                newPos.z = startPosition;
                obj.transform.position = newPos;
            }
        }
    }
}