using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] Vector3 offsetPos;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            this.transform.SetParent(other.transform);
            transform.localPosition = offsetPos ;
            transform.localRotation = Quaternion.identity;
        }
    }
}
