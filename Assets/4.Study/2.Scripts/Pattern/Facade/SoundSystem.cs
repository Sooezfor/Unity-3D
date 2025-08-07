using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public void StartSound(string soundName)
    {
        Debug.Log($"{soundName} ���");
    }
    public void PauseSound(string soundName)
    {
        Debug.Log($"{soundName} ����");
    }
    public void StopSound(string soundName)
    {
        Debug.Log($"{soundName} ����");
    }
}
