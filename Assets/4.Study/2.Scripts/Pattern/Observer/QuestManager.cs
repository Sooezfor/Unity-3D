using UnityEngine;

namespace Pattern
{
    public class QuestManager : MonoBehaviour, IObserver
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
            Debug.Log("Äù½ºÆ® ¿Ï·á");
        }
    }

}
