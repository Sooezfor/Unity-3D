using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : SingleTon<LoadSceneManager>
{
    int sceneIndex = 0;
    public int ccIndex = 0; //ĳ���� �ε���
    protected override void Awake()
    {
        if (instance == null) //�Ҵ��ؼ� �̱���ȭ
        {
            instance = this as LoadSceneManager; //��ӹ޴� Ÿ�� ��
            DontDestroyOnLoad(gameObject);
        }
        else //�ߺ� ����
            Destroy(gameObject);
    }

    //0�� ��Ʈ��, 1 ĳ���� ����, 2 ����
    public void OnLoadScene()
    {
        sceneIndex++;

        Fade.onFadeAction(2f, Color.black, true, () => SceneManager.LoadScene(sceneIndex));
        //��������Ʈ �̿��ؼ� ���̵� ���� �� �� �ε��ϴ� �Լ� ����
    }

    public void SetCharacterIndex(int index)
    {
        ccIndex = index;
    }
}
