using System.Collections;
using UnityEngine;

public class StudyCorotuine : MonoBehaviour
{
    IEnumerator enumerator;
    private void Start()
    {
        enumerator = Numbers();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //�ڷ�ƾ ���� ����
        {
            enumerator.MoveNext();
            var result = enumerator.Current;
            Debug.Log(result);
        }
    }

    IEnumerator Numbers()
    {
        yield return 3;
        yield return 5;
        yield return 7;
    }
}
