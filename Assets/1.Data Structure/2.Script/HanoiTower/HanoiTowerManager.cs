using System.Collections;
using UnityEngine;

public class HanoiTowerManager : MonoBehaviour
{
    public enum HanoiLevel {  Lv1 =3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs; //���� �迭 �ޱ�
    public BoardBar[] bars; //left, center, right ������� ������

    public static GameObject selectDonut;
    public static bool isSelected;

    IEnumerator Start()
    {
        for(int i = (int)hanoiLevel; i >= 0; i--) //�ݺ������� level��ŭ ���� �����ϰ� ������ ����
        {
            GameObject donut = Instantiate(donutPrefabs[i]); //�ε��� ū �������� ���� 
            donut.transform.position = new Vector3(-5f, 5f, 0); //���� ������� ������ ����

            bars[0].PushDonut(donut); //��� ������ ������ �ش� Bar�� ���ÿ� Ǫ��

            yield return new WaitForSeconds(1f);
        }
    }    
}
