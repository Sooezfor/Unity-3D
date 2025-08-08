using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int score;
}

public class SaveDataFile : MonoBehaviour
{
    int score;
    string savePath;

    void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "saveDataFile.json");
        //dataPath 는 유니티 Assets 경로이고 persisten는 데이터가 안전하게 저장되는 경로 

        Load();
        Debug.Log("Load Score : " + score);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            //Save
            Debug.Log($"Score:" + score);

            Save();
        }
    }
    void Save()
    {
        SaveData data = new SaveData();
        data.score = this.score;
       
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(savePath, json);

        Debug.Log("Data save to : " + savePath);
    }

    private void Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            this.score = data.score;
        }
        else
            score = 0;
    }
    private void OnApplicationQuit()
    {
        Save(); //게임 끌 때 자동저장
    }
}
