using System;
using UnityEngine;

public class StudyPredicate : MonoBehaviour
{
    //접근제한자 predicate<매개변수> 변수명 
    public Predicate<int> myPredicate;

    //매개변수 1개만 사용 가능 
    public int level = 10;

    private void Start()
    {
        myPredicate = lv => lv <= 10;
        string msg = myPredicate(level) ? "초보자 사냥터 입장 가능" : "초보자 사냥터 입장 불가능";

        Debug.Log(msg);
    }
}
