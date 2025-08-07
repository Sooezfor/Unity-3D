using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public void StartQuest(string questName)
    {
        Debug.Log($"{questName} È¹µæ");
    }
    public void HasQuest(string questName)
    {
        Debug.Log($"{questName} À¯ºÎ");
    }
    public void CompleteQuest(string questName)
    {
        Debug.Log($"{questName} Æ÷±â");
    }
}
