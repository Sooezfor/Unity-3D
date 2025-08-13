using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Transform slotGroup;
    [SerializeField] Slot[] slots;
    [SerializeField] GameObject slotPrefab;

    [SerializeField] int slotAmount = 18;
    int itemCount = 0;

    private void Start()
    {
        for(int i = 0; i< slotAmount; i++)
        {
            Instantiate(slotPrefab, slotGroup);
        }
        slots = slotGroup.GetComponentsInChildren<Slot>();
    } 

    public void GetItem(Crop crop)
    {

        foreach(var slot in slots)
        {
        // 빈 슬롯이 있다면 그 슬롯에 해당 crop 데이터 저장 
            if(slot.isEmpty)
            {
                slot.AddCrop(crop);
                itemCount++;
                crop.useAction += UseItem;
                break;
            }
        }
    }
    public bool CheckItemCount()
    {
        bool result = itemCount < slotAmount;

        return result; //개수가 적으면 true 높으면 false
    }

    public void UseItem()
    {
        itemCount--;
    }
}
