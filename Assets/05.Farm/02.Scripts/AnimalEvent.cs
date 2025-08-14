using System;
using Unity.Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalEvent : MonoBehaviour
{
    [SerializeField] GameObject followTarget;
    [SerializeField] CinemachineClearShot clearShot;
    [SerializeField] GameObject flag;
    BoxCollider coll;

    float timer;
    bool isTimer;
    public static Action failAction;

    private void Start()
    {
        failAction += SetRandomPosition;
        coll = GetComponent<BoxCollider>();
    }
    private void Update()
    {
        if (!isTimer)
            return;

        timer += Time.deltaTime;
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
            Debug.Log($"깃발 찾는데 걸린 시간은 {timer:F1}초입니다.");
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
}
