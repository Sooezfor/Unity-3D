using System.Collections;
using UnityEngine;

public class HanoiTowerManager : MonoBehaviour
{
    public enum HanoiLevel {  Lv1 =3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs; //도넛 배열 받기
    public BoardBar[] bars; //left, center, right 순서대로 넣을것

    public static GameObject selectDonut;
    public static bool isSelected;

    IEnumerator Start()
    {
        for(int i = (int)hanoiLevel; i >= 0; i--) //반복문으로 level만큼 도넛 생성하고 역으로 생성
        {
            GameObject donut = Instantiate(donutPrefabs[i]); //인덱스 큰 순서부터 생성 
            donut.transform.position = new Vector3(-5f, 5f, 0); //왼쪽 막대기의 위에서 생성

            bars[0].PushDonut(donut); //방금 생성한 도넛을 해당 Bar의 스택에 푸시

            yield return new WaitForSeconds(1f);
        }
    }    
}
