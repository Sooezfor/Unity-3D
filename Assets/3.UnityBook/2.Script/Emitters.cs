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
        pd.playableGraph.GetRootPlayable(0).SetSpeed(speed); //���ǵ� ����
    }
    
    //�ñ׳ο� �̺�Ʈ�� ����ϴ� �Լ� 
    public void SetSignalEvent()
    {
        UnityEvent eventContainer = new UnityEvent(); //�̺�Ʈ�� ��� ���� 
        eventContainer.AddListener(() => OnTimeLineSpeed(0.2f)); //���� �̺�Ʈ �Ҵ��� �� �Ǳ� ������ ������ �Լ� ���

        receiver.AddReaction(signal, eventContainer); //�ñ׳ο� �Լ� ��ϵ� ���� ����
    }
}
