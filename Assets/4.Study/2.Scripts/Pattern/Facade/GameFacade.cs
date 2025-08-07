
using UnityEngine;

public class GameFacade : SingleTon<GameFacade>
{
    InventorySystem invenSys;
    QuestSystem questSys;
    SoundSystem soundSys;

    private void Awake()
    {
        invenSys = GetComponent<InventorySystem>();
        questSys = GetComponent<QuestSystem>();
        soundSys = GetComponent<SoundSystem>();

        if(invenSys == null)        
            invenSys = gameObject.AddComponent<InventorySystem>();

        if (questSys == null)
            questSys = gameObject.AddComponent<QuestSystem>();

        if (soundSys == null)
            soundSys = gameObject.AddComponent<SoundSystem>();
    }

    public void ItemEvent(int index, string itemName)
    {
        if(index == 0)        
            invenSys.AddItem(itemName);
        
        else if(index == 1)       
            invenSys.AddItem(itemName);
        
        else if(index == 2)       
            invenSys.AddItem(itemName);        
    }
    public void QuestEvent(int index, string questName)
    {
        if (index == 0)
            questSys.StartQuest(questName);

        else if (index == 1)
            questSys.HasQuest(questName);

        else if (index == 2)
            questSys.CompleteQuest(questName);
    }

    public void SoundEvent(int index, string soundName)
    {
        if (index == 0)
            soundSys.StartSound(soundName);

        else if (index == 1)
            soundSys.PauseSound(soundName);

        else if (index == 2)
            soundSys.StopSound(soundName);
    }


}
