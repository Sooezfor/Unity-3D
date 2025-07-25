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

        ao.allowSceneActivation = false; //로드가 완료 돼도 로드 방지 

        while(!ao.isDone) //하던 작업이 끝났는지 아닌지 확인 
        {
            loadingSlider.value = ao.progress; //0~1값 
            loadingText.text = $"{ao.progress * 100f}%"; //백분율로 만들려고 100 곱함

            if(ao.progress >= 0.9f)           
                ao.allowSceneActivation = true;
            
            yield return null; 
        }
    }
}
