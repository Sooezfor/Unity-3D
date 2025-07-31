using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Emitters : MonoBehaviour
{
    public PlayableDirector pd;
    public SignalReceiver receiver;
    public SignalAsset signal;

    public void OnTimeLineSpeed(float speed)
    {
        pd.playableGraph.GetRootPlayable(0).SetSpeed(speed); //스피드 제어
    }
    
    //시그널에 이벤트를 등록하는 함수 
    public void SetSignalEvent()
    {
        UnityEvent eventContainer = new UnityEvent(); //이벤트를 담는 변수 
        eventContainer.AddListener(() => OnTimeLineSpeed(0.2f)); //직접 이벤트 할당이 안 되기 때문에 변수에 함수 등록

        receiver.AddReaction(signal, eventContainer); //시그널에 함수 등록된 변수 전달
    }
}
