using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    public string URL;

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL); //웹상으로 요청전달
        yield return www.SendWebRequest();

        WWWForm form = new WWWForm();
        form.AddField("value", "123");

        UnityWebRequest www2 = UnityWebRequest.Post(URL,form); //요청 전달
        yield return www2.SendWebRequest();

        string data = www.downloadHandler.text;        

        Debug.Log(data);       
    }
}
