using System;
using UnityEngine;
public class Crop : MonoBehaviour
{
    [SerializeField] string name;
    //[SerializeField] GameObject obj;
    public Sprite icon;
    public Action useAction;
    private void Start()
    {
        useAction += Use;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {            
            Get();
        }
    }
    void Get()
    {
        if (GameManager.Instance.item.CheckItemCount())
        {
            GameManager.Instance.item.GetItem(this);
            gameObject.SetActive(false);
            //�κ��丮�� �۹� �߰�

        }
        else
            Debug.Log("�κ��丮�� ���� á���ϴ�.");
    }
    public void Use()
    {
        //��θ� �߰�
        Debug.Log($"{name}�� ����߽��ϴ�.");
    }
}
