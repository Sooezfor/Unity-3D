using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
public enum WeatherType { Sun, Rain, Snow }

public class WeatherSystem : MonoBehaviour
{
    [SerializeField] GameObject[] weatherParticles; 
    public WeatherType weatherType;

    public static event Action<WeatherType> weatherAction;  //��� ������ ���� �����ϵ��� ����ƽ 
    IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(15f); //15�ʸ��� �ٲ��

            int weatherCount = Enum.GetValues(typeof(WeatherType)).Length;
            Debug.Log(weatherCount);

            int ranIndex = Random.Range(0, weatherCount);

            weatherType = (WeatherType)ranIndex;

            foreach (var particle in weatherParticles)
                particle.SetActive(false);

            weatherParticles[ranIndex].SetActive(true);
            //������ �ٲ� ���� �Ĺ� ���� �޶����ų�....
            weatherAction?.Invoke(weatherType);
        }
    }
}
