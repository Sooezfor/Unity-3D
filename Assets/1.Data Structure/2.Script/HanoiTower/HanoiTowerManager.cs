using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class HanoiTowerManager : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel = HanoiLevel.Lv1;

    public Button answerButton;

    public GameObject[] donutPrefabs; //���� �迭 �ޱ�
    public BoardBar[] bars; //left, center, right ������� ������

    public TextMeshProUGUI countText;

    public static GameObject selectDonut;
    public static bool isSelected;
    public static BoardBar nowBar;
    public static int moveCount;

    private void Awake()
    {
        answerButton.onClick.AddListener(HanoiAnswer);
    }

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

    void HanoiAnswer()
    {
        HanoiRoutine((int)hanoiLevel, 0, 1, 2); //���� ����, ��� 0,1,2 
    }
    void HanoiRoutine(int n, int from, int temp, int to)//����� ������� from, temp, to��
    {
        if (n == 0) //�ű� ������ ����. �� �ű�.
            return;

        if (n == 1) //1�� ������ ����. ���� ���� ���� 
            Debug.Log($"'{n}�� ������ {from}���� {to}�� �̵�");
        else
        {
            HanoiRoutine(n - 1, from, to, temp); //
            Debug.Log($"'{n}�� ������ {from}���� {to}�� �̵�");
            HanoiRoutine(n - 1, temp, from, to); //
        }
    }
}
