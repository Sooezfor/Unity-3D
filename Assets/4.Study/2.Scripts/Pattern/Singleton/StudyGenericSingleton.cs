using UnityEngine;

public class StudyGenericSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
               instance = FindFirstObjectByType<T>();

                if (instance == null)//教臂畔 按眉 积己 矫档 
                {
                    var newObject = new GameObject(typeof(T).ToString());
                    instance = newObject.AddComponent<T>();
                }
            }            
            return instance;
        }
        
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
            Destroy(gameObject);
    }

}
