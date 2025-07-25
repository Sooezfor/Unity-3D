using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingNextScene : MonoBehaviour
{
    public int sceneNumber = 2;
    public Slider loadingSlider;
    public TextMeshProUGUI loadingText;

    private void Start()
    {
        StartCoroutine(TransitionNextScene(sceneNumber));
    }

    IEnumerator TransitionNextScene(int num)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(num);

        ao.allowSceneActivation = false; //�ε尡 �Ϸ� �ŵ� �ε� ���� 

        while(!ao.isDone) //�ϴ� �۾��� �������� �ƴ��� Ȯ�� 
        {
            loadingSlider.value = ao.progress; //0~1�� 
            loadingText.text = $"{ao.progress * 100f}%"; //������� ������� 100 ����

            if(ao.progress >= 0.9f)           
                ao.allowSceneActivation = true;
            
            yield return null; 
        }
    }
}
