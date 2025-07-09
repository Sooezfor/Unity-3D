using System.Collections.Generic;
using UnityEngine;

public class BoardBar : MonoBehaviour
{
    public enum BarType { Left,Center, Right }
    public BarType barType;

    public Stack<GameObject> barStack = new Stack<GameObject>();
     //하노이 타워 스크립트에서 활동

    private void OnMouseDown()
    {
        if(!HanoiTowerManager.isSelected) //선택 안됐을 때
        {
            HanoiTowerManager.isSelected = true;
            HanoiTowerManager.selectDonut = PopDonut();
        }
        else //(true일때) 
        {
            HanoiTowerManager.isSelected = false;
            PushDonut(HanoiTowerManager.selectDonut);
        }
    }
    public bool CheckDonut(GameObject donut)
    {

        if(barStack.Count >0)
        {
            int pushNumber = donut.GetComponent<Donut>().donutNumber; //도넛의 스크립트와 넘버 변수에 접근

            GameObject peekDonut = barStack.Peek();
            int peekNumber = peekDonut.GetComponent<Donut>().donutNumber;

            if(pushNumber < peekNumber)
            {
                return true;
            }
            else
            {
                Debug.Log($"현재 넣으려는 도넛은 {pushNumber} 이고, 해당 기둥의 제일 위의 도넛은 {peekNumber}입니다. ");
                return false;
            }
        }
        return true;
    }

    public void PushDonut(GameObject donut)
    {
        if(!CheckDonut(donut))        
            return;

        HanoiTowerManager.isSelected = false;
        HanoiTowerManager.selectDonut = null;

        donut.transform.position = transform.position + Vector3.up * 5f; //Vector3. up = new Vector3(0,1,0)
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        barStack.Push(donut); //도넛을 바스택에 넣는다. 
    }
    public GameObject PopDonut()
    {
        GameObject donut = barStack.Pop(); // 스택에서 게임오브젝트 꺼내기 
        return (donut); //꺼낸 도넛 반환 
    }
}
