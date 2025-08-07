using System;
using UnityEngine;

public class ScriptMananger : SingleTon<ScriptMananger>
{
    public static Action action;

    private void Awake()
    {
        //action += MethodA
    }
}
