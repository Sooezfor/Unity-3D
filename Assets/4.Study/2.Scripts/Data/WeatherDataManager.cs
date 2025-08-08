using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherDataManager : MonoBehaviour
{
    public enum WeatherType {  Sun, Cloud, Rain, Snow }
    public WeatherType weatherType;

    string URL = "http://apis.data.go.kr/1360000/VilageFcstInfoService_2.0/getVilageFcst?";

    public string key;
    public string numOfRows;
    public string pageNo;
    public string dataType;
    public string base_date;
    public string base_time;
    public string nx;
    public string ny;

    public WeatherData.Root weatherData;
    int currPTY;
    int currSKY; 

    IEnumerator Start()
    {
        URL += $"serviceKey={key}&numOfRows={numOfRows}&pageNo={pageNo}&dataType={dataType}&base_date={base_date}" +
               $"&base_time={base_time}&nx={nx}&ny={ny}";

        Debug.Log(URL);
        UnityWebRequest www = UnityWebRequest.Get(URL);

        yield return www.SendWebRequest(); //요청 보내는 것을 대기

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Failed data : " + www.error);
        }
        else
        {
            string data = www.downloadHandler.text;
            Debug.Log(data); //JSON 파일

            weatherData = JsonUtility.FromJson<WeatherData.Root>(data);

            foreach(var item in weatherData.response.body.items.item)
            {
                if(item.category == "PTY")
                {
                    currPTY = int.Parse(item.fcstValue);                    
                }
                else if (item.category == "SKY")
                {
                    currSKY = int.Parse(item.fcstValue);                    
                }
            }
            SetWeatherType();
        }        
    }
    void SetWeatherType()
    {
        if(currSKY == 1 && currPTY == 0)
        {
            weatherType = WeatherType.Sun;
        }
        else if(currSKY == 3 || currSKY == 4)
        {
            weatherType = WeatherType.Cloud;
        }
        else if(currPTY == 1|| currPTY == 2|| currPTY == 4)
        {
            weatherType = WeatherType.Rain;
        }
        else if(currPTY == 3)
        {
            weatherType = WeatherType.Snow;
        }
        Debug.Log($"현재 날씨는 {weatherType}입니다.");
    }
}
