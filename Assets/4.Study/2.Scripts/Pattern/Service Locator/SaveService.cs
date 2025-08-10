using UnityEngine;

public class SaveService : MonoBehaviour, ISaveService
{
    public void LoadData()
    {
        Debug.Log("Save Data");

    }

    public void SaveData()
    {
        Debug.Log("Load Data");
    }
}
 