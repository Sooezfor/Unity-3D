using UnityEngine;
using UnityEngine.EventSystems;

public class UIHandler : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public RectTransform parentRect; // 

    Vector2 basePos;
    Vector2 startPos;
    Vector2 moveOffset; 

    void Awake()
    {
        parentRect = transform.parent.GetComponent<RectTransform>();

        //parentRect.SetAsFirstSibling(); //�Ʒ��� ���������� ����
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        parentRect.SetAsLastSibling(); //���� �׷������� ����

        basePos = parentRect.anchoredPosition; //���� UI�� ��ġ 
        startPos = eventData.position; //������ 
    }
    public void OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - startPos; //���� ���� ���� 
        parentRect.anchoredPosition = basePos + moveOffset;
    }
}
