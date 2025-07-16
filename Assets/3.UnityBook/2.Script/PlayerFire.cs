using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    GameObject bulletFactory;
    public GameObject firePosition;

    private void Start()
    {
        bulletFactory = Resources.Load<GameObject>("bullet"); //리소스 폴더에서 총알 프리팹 로드
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position; //위치 설정 
            bullet.transform.rotation = firePosition.transform.rotation;//회전 설정

            //bullet.transform.SetPositionAndRotation(위치,회전); // 위치와 회전 한번에 적용하는 기능 
            //bullet.transform.SetParent(부모); //부모 오브젝트 설정 
        }                    
    }
}
