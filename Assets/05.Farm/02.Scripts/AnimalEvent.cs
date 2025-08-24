using System;
using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalEvent : MonoBehaviour
{
    [SerializeField] GameObject followTarget;
    [SerializeField] CinemachineClearShot clearShot;
    [SerializeField] GameObject flag;
    [SerializeField] GameObject animalUi;
    [SerializeField] TextMeshProUGUI noticeText;
    [SerializeField] TextMeshProUGUI timerText;
    BoxCollider coll;

    float timer;
    bool isTimer;
    public static Action failAction;

    private void Start()
    {
        timerText.text = "";
        noticeText.text = "";
        failAction += SetRandomPosition;
        coll = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        if (!isTimer)
            return;

        timer += Time.deltaTime;
        timerText.text = $"time : {timer.ToString("F2")}";
    }  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTimer = true;
            SetRandomPosition();

            followTarget.SetActive(true);
            GameManager.Instance.SetcamerState(CameraState.Animal);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Notify());
            isTimer = false;
            timer = 0f;
            SetFlag(Vector3.zero, false);

            GameManager.Instance.SetcamerState(CameraState.Outside);
            followTarget.SetActive(false);
            
        }
    }
    void SetRandomPosition()
    {
        float randomX = Random.Range(coll.bounds.min.x, coll.bounds.max.x);
        float randomZ = Random.Range(coll.bounds.min.z, coll.bounds.max.z);

        var randomPos = new Vector3(randomX, 0f, randomZ);

        SetFlag(randomPos, true);

    }
    void SetFlag(Vector3 pos, bool isActive)
    {
        flag.transform.SetParent(transform);
        flag.transform.position = pos;
        flag.SetActive(isActive);
    }

    IEnumerator Notify()
    {        
        animalUi.SetActive(true);
        noticeText.text = $"깃발 찾는데 걸린 시간은 {timer:F1}초입니다.";
        yield return new WaitForSeconds(3f);

        animalUi.SetActive(false);
        timerText.text = "";
    }
}
