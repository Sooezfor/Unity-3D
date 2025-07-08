using UnityEngine;

public class StaticArray : MonoBehaviour
{
    public int[] array1; //크기 정하지 않음 유니티 에디터에서 만들어서 쓸 수 있음. 
    int[] array2 = { 10, 20, 30, 40, 50 };
    int[] array3 = new int[5]; //공간 할당
    int[] array4 = new int[5] { 10, 20, 30, 40, 50 }; //공간 할당 후 초기화

    NewData[] data = new NewData[5]; 

    private void Start()
    {
        array1 = new int[5]; //이거랑 array3 이랑 같은 것. 이렇게 안 써도 쓸수잇는이유는 유니티 에디터에서 쓸수잇어서.
        int number = array2[3]; //인덱서 뜻하는 거라 40 을 number 에 넣겠다는 것.
    }
}
public class NewData
{

}