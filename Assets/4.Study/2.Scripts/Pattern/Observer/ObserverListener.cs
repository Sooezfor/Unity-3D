using UnityEngine;
    public class ObserverListener : MonoBehaviour, IObserver
    {

        public Subject subject;

        void OnEnable()
        {
            subject.AddObserver(this);
        }
        void OnDisable()
        {
            subject.RemoveObserver(this);
        }

        public void Notify()
        {
            Debug.Log("���� ���� óġ");
        }
    }



