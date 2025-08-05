using System;
using System.Collections;
using UnityEngine;

public class SwingController : MonoBehaviour
{
 

    public Action onStartSwing;
    public Action onEndSwing;

    Animator anim;
    bool isSwing;

    private void Start()
    {
        anim = GetComponent<Animator>();

        onStartSwing += SwingStart;
        onEndSwing += SwingEnd;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!isSwing)
                StartCoroutine(SwingRoutine(onStartSwing, onEndSwing));

        }
    }

    IEnumerator SwingRoutine(Action action1, Action action2)
    {
        isSwing = true;
        anim.SetTrigger("Swing");
        //SwingStart();
        action1?.Invoke();

        float animLength = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animLength);
        //SwingEnd();
        action2?.Invoke();
        isSwing = false;
    }

    void SwingStart()
    {
        Debug.Log("Ω∫¿Æ Ω√¿€");
    }
    void SwingEnd()
    {
        Debug.Log("Ω∫¿Æ ¡æ∑·");

    }
}
