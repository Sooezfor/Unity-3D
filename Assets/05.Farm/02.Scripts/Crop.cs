using UnityEngine;

public class Crop : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
