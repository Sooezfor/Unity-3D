using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
public enum WeatherType { Sun, Rain, Snow }

public class WeatherSystem : MonoBehaviour
{
    [SerializeField] GameObject[] weatherParticles; 
    public WeatherType weatherType;

    public static event Action<WeatherType> weatherAction;  //모든 곳에서 접근 가능하도록 스태틱 
    IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(15f); //15초마다 바뀌기

            int weatherCount = Enum.GetValues(typeof(WeatherType)).Length;
            Debug.Log(weatherCount);

            int ranIndex = Random.Range(0, weatherCount);

            weatherType = (WeatherType)ranIndex;

            foreach (var particle in weatherParticles)
                particle.SetActive(false);

            weatherParticles[ranIndex].SetActive(true);
            //날씨가 바뀜에 따라 식물 설정 달라지거나....
            weatherAction?.Invoke(weatherType);
        }
    }
}
