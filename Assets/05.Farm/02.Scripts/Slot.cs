using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Crop crop; //���Կ� ���� ������
    [SerializeField] Image slotImage;
    [SerializeField] Button slotButton;

    public bool isEmpty = true; //ó���� �� ����־ Ʈ�� 

    private void Awake()
    {
        slotButton.onClick.AddListener(UseCrop);
    }

    private void OnEnable()
    {
        slotImage.gameObject.SetActive(!isEmpty);
        slotButton.interactable = true;       
    }
    public void AddCrop(Crop crop)
    {
        isEmpty = false;
        this.crop = crop;
        slotImage.sprite = crop.icon;
    }

    void UseCrop()
    {
        if(crop != null)
        {
            crop.Use();
            isEmpty = true;
            slotButton.interactable = false;
            slotImage.gameObject.SetActive(false);
            crop.useAction?.Invoke();
        }
    }
}
