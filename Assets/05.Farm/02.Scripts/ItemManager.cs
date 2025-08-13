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
        // �� ������ �ִٸ� �� ���Կ� �ش� crop ������ ���� 
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

        return result; //������ ������ true ������ false
    }

    public void UseItem()
    {
        itemCount--;
    }
}
