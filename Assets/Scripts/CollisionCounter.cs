using UnityEngine;
using TMPro;

public class CollisionCounter : MonoBehaviour
{
    public TMP_Text counterText;
    private static int totalImpacts = 0;

    void Start()
    {
        if (counterText != null)
        {
            counterText.text = "Crashes: " + totalImpacts;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Floor"))
        {
            totalImpacts++;
            
            if (counterText != null)
            {
                counterText.text = "Crashes: " + totalImpacts;
            }
        }
    }
}