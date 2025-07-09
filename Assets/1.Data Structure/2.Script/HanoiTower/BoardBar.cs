using System.Collections.Generic;
using UnityEngine;

public class BoardBar : MonoBehaviour
{
    public enum BarType { Left,Center, Right }
    public BarType barType;

    public Stack<GameObject> barStack = new Stack<GameObject>();
     //�ϳ��� Ÿ�� ��ũ��Ʈ���� Ȱ��

    private void OnMouseDown()
    {
        if(!HanoiTowerManager.isSelected) //���� �ȵ��� ��
        {
            HanoiTowerManager.isSelected = true;
            HanoiTowerManager.selectDonut = PopDonut();
        }
        else //(true�϶�) 
        {
            HanoiTowerManager.isSelected = false;
            PushDonut(HanoiTowerManager.selectDonut);
        }
    }
    public bool CheckDonut(GameObject donut)
    {

        if(barStack.Count >0)
        {
            int pushNumber = donut.GetComponent<Donut>().donutNumber; //������ ��ũ��Ʈ�� �ѹ� ������ ����

            GameObject peekDonut = barStack.Peek();
            int peekNumber = peekDonut.GetComponent<Donut>().donutNumber;

            if(pushNumber < peekNumber)
            {
                return true;
            }
            else
            {
                Debug.Log($"���� �������� ������ {pushNumber} �̰�, �ش� ����� ���� ���� ������ {peekNumber}�Դϴ�. ");
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

        barStack.Push(donut); //������ �ٽ��ÿ� �ִ´�. 
    }
    public GameObject PopDonut()
    {
        GameObject donut = barStack.Pop(); // ���ÿ��� ���ӿ�����Ʈ ������ 
        return (donut); //���� ���� ��ȯ 
    }
}
