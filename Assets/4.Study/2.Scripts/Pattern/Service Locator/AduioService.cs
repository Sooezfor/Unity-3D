using UnityEngine;

public class AduioService : MonoBehaviour, IAudioService
{
    public void PlaySound()
    {
        Debug.Log("Play Sound");
    }

    public void StopSound()
    {
        Debug.Log("Stop Sound");

    }
}
