using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIstackManager : MonoBehaviour
{
    public Stack<GameObject> uiStack = new Stack<GameObject>();

    public Button[] buttons;
    public GameObject[] popupUis;

    private void Start()
    {
        buttons[0].onClick.AddListener(PopupOn1);
        buttons[1].onClick.AddListener(PopupOn2);
        buttons[2].onClick.AddListener(PopupOn3);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject currUI = uiStack.Pop();
            currUI.SetActive(false);
        }
    }

    void PopupOn1()
    {
        popupUis[0].SetActive(true);
        uiStack.Push(popupUis[0]);
    }
    void PopupOn2()
    {
        popupUis[1].SetActive(true);
        uiStack.Push(popupUis[1]);
    }
    void PopupOn3()
    {
        popupUis[2].SetActive(true);
        uiStack.Push(popupUis[2]);
    }

}
