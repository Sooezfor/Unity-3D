using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData1
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
        //dataPath �� ����Ƽ Assets ����̰� persisten�� �����Ͱ� �����ϰ� ����Ǵ� ��� 

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
        SaveData1 data = new SaveData1();
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
            SaveData1 data = JsonUtility.FromJson<SaveData1>(json);
            this.score = data.score;
        }
        else
            score = 0;
    }
    private void OnApplicationQuit()
    {
        Save(); //���� �� �� �ڵ�����
    }
}
