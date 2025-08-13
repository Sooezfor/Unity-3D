using System;
using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    enum PlantState { Lv1, Lv2, Lv3 }
    PlantState plantState;

    DateTime startTime, growthTime, harvestTime; //������ ���ϴ� �ð� ���� 

    public int plantIndex;
    public bool isHarvest = false;

    private void Awake()
    {
        startTime = DateTime.Now;
        growthTime = startTime.AddSeconds(5);
        harvestTime = startTime.AddSeconds(10);

        //DateTime.Now : ���� ���� �ð��� Ȱ���� ���. ���� ���� �ð� ����
        //Time.time ���� �ð� ���� �ð��� Ȯ�� 
        //time.delatTime. �ð� ����
    }

    IEnumerator Start()
    {
        SetState(PlantState.Lv1);

        while(plantState != PlantState.Lv3)
        {
            if(DateTime.Now >= harvestTime) //�߼� �ð� ���� Ȯ�� 
            {
                SetState(PlantState.Lv3);
                isHarvest = true;
            }
            else if(DateTime.Now >= growthTime) //�߼� �ð� �ɸ� �ֵ� �����ϰ� ��
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
            transform.GetChild((int)plantState).gameObject.SetActive(true); //���� �Ĺ� �ܰ� Ű��

        }
        
    }

}
