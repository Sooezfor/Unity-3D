using System;
using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    enum PlantState { Lv1, Lv2, Lv3 }
    PlantState plantState;

    DateTime startTime, growthTime, harvestTime; //레벨이 변하는 시간 설정 

    public int plantIndex;
    public bool isHarvest = false;

    private void Awake()
    {
        startTime = DateTime.Now;
        growthTime = startTime.AddSeconds(5);
        harvestTime = startTime.AddSeconds(10);

        //DateTime.Now : 현재 현실 시간을 활용한 방법. 게임 꺼도 시간 지남
        //Time.time 게임 시간 실행 시간만 확인 
        //time.delatTime. 시간 조각
    }

    IEnumerator Start()
    {
        SetState(PlantState.Lv1);

        while(plantState != PlantState.Lv3)
        {
            if(DateTime.Now >= harvestTime) //추수 시간 먼저 확인 
            {
                SetState(PlantState.Lv3);
                isHarvest = true;
            }
            else if(DateTime.Now >= growthTime) //추수 시간 걸린 애들 제외하고 봄
            {
                SetState(PlantState.Lv2);
            }
            yield return new WaitForSeconds(1f);
        }
    }
    void SetState(PlantState newState)
    {
        if (plantState != newState || plantState == PlantState.Lv1)
        {
           plantState = newState;

            for (int i = 0; i < 3; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            transform.GetChild((int)plantState).gameObject.SetActive(true); //현재 식물 단계 키기

        }
        
    }

}
