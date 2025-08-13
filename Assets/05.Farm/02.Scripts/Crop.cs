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
            //인벤토리에 작물 추가

        }
        else
            Debug.Log("인벤토리가 가득 찼습니다.");
    }
    public void Use()
    {
        //배부름 추가
        Debug.Log($"{name}을 사용했습니다.");
    }
}
