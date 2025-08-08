using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetCSVParser : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public string charID;
        public string name;
        public int hp;
        public int attack;

        public CharacterData(string charID, string name, int hp, int attack)
        {
            this.charID = charID;
            this.name = name;
            this.hp = hp;
            this.attack = attack;
        }
    }
    public string URL;
    public List<CharacterData> characters = new List<CharacterData>();

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);

        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        //Debug.Log(data);
        ParsingCharacterData(data);
    }

    void ParsingCharacterData(string data)
    {
        Debug.Log(data);

        string[] rows = data.Split('\n');

        for(int i =1; i<rows.Length; i++)
        {
            string[] cols = rows[i].Split(',');

            CharacterData chracterData = new CharacterData(cols[0], cols[1], int.Parse(cols[2]), int.Parse(cols[3]));

            characters.Add(chracterData);
        }
    }
}
