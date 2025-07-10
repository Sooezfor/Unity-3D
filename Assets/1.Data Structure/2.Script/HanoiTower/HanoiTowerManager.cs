using System.Collections;
using TMPro;
using UnityEngine;

public class HanoiTowerManager : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel;

    public GameObject[] donutPrefabs; //���� �迭 �ޱ�
    public BoardBar[] bars; //left, center, right ������� ������

    public TextMeshProUGUI countText;

    public static GameObject selectDonut;
    public static bool isSelected;
    public static BoardBar nowBar;
    public static int moveCount; 

    IEnumerator Start()
    {
        for(int i = (int)hanoiLevel - 1; i >= 0; i--) //�ݺ������� level��ŭ ���� �����ϰ� ������ ����
        {
            GameObject donut = Instantiate(donutPrefabs[i]); //�ε��� ū �������� ���� 
            donut.transform.position = new Vector3(-5f, 5f, 0); //���� ������� ������ ����

            bars[0].PushDonut(donut); //��� ������ ������ �ش� Bar�� ���ÿ� Ǫ��

            yield return new WaitForSeconds(1f);
        }
        moveCount = 0;
        countText.text = moveCount.ToString();

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            nowBar.barStack.Push(selectDonut); //��� ���� �ٸ� �ٽ� �����ͻ����� Ǫ��

            isSelected = false;
            selectDonut = null;
        }
        countText.text = moveCount.ToString(); // ������Ʈ���� �־ ����. ��ȿ�����̱� ��
    }
}

