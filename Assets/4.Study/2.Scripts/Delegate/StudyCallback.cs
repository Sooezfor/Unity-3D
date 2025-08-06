using System;
using System.Collections;
using UnityEngine;

public class StudyCallback : MonoBehaviour
{
    public Action bombAction;

    private void OnEnable()
    {
        bombAction += () =>
        {
            BombExplosion();
            BombDamaged();
            BombEffect();
        };
    }
    IEnumerator Start()
    {
        Debug.Log("��ź Ÿ�̸� ����");
        yield return new WaitForSeconds(5f);

        bombAction?.Invoke();
    }
    void BombExplosion()
    {
        Debug.Log("����");
    }

    void BombDamaged()
    {
        Debug.Log("���� ������ ����");
    }
    void BombEffect()
    {
        Debug.Log("���� �̺�Ʈ ����");
    }
}
