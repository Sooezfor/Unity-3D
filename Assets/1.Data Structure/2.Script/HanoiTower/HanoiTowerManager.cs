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

    public GameObject[] donutPrefabs; //도넛 배열 받기
    public BoardBar[] bars; //left, center, right 순서대로 넣을것

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
        for(int i = (int)hanoiLevel - 1; i >= 0; i--) //반복문으로 level만큼 도넛 생성하고 역으로 생성
        {
            GameObject donut = Instantiate(donutPrefabs[i]); //인덱스 큰 순서부터 생성 
            donut.transform.position = new Vector3(-5f, 5f, 0); //왼쪽 막대기의 위에서 생성

            bars[0].PushDonut(donut); //방금 생성한 도넛을 해당 Bar의 스택에 푸시

            yield return new WaitForSeconds(1f);
        }
        moveCount = 0;
        countText.text = moveCount.ToString();

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            nowBar.barStack.Push(selectDonut); //방금 뽑은 바를 다시 데이터상으로 푸시

            isSelected = false;
            selectDonut = null;
        }
        countText.text = moveCount.ToString(); // 업데이트문에 넣어서 갱신. 비효율적이긴 함
    }

    void HanoiAnswer()
    {
        HanoiRoutine((int)hanoiLevel, 0, 1, 2); //도넛 개수, 기둥 0,1,2 
    }
    void HanoiRoutine(int n, int from, int temp, int to)//기둥이 순서대로 from, temp, to임
    {
        if (n == 0) //옮길 도넛이 없다. 다 옮김.
            return;

        if (n == 1) //1번 도넛이 남음. 제일 작은 도넛 
            Debug.Log($"'{n}번 도넛을 {from}에서 {to}로 이동");
        else
        {
            HanoiRoutine(n - 1, from, to, temp); //
            Debug.Log($"'{n}번 도넛을 {from}에서 {to}로 이동");
            HanoiRoutine(n - 1, temp, from, to); //
        }
    }
}
