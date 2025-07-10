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

        //parentRect.SetAsFirstSibling(); //아래로 가려지도록 설정
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        parentRect.SetAsLastSibling(); //위에 그려지도록 설정

        basePos = parentRect.anchoredPosition; //기존 UI의 위치 
        startPos = eventData.position; //시작점 
    }
    public void OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - startPos; //관련 방향 나옴 
        parentRect.anchoredPosition = basePos + moveOffset;
    }
}
