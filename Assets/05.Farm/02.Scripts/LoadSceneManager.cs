using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : SingleTon<LoadSceneManager>
{
    int sceneIndex = 0;
    public int ccIndex = 0; //캐릭터 인덱스
    protected override void Awake()
    {
        if (instance == null) //할당해서 싱글톤화
        {
            instance = this as LoadSceneManager; //상속받는 타입 뱉어냄
            DontDestroyOnLoad(gameObject);
        }
        else //중복 제거
            Destroy(gameObject);
    }

    //0은 인트로, 1 캐릭터 선택, 2 메인
    public void OnLoadScene()
    {
        sceneIndex++;

        Fade.onFadeAction(2f, Color.black, true, () => SceneManager.LoadScene(sceneIndex));
        //델리게이트 이용해서 페이드 끝날 때 씬 로딩하는 함수 연결
    }

    public void SetCharacterIndex(int index)
    {
        ccIndex = index;
    }
}
