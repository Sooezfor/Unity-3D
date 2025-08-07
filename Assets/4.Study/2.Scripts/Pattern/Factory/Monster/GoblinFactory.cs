using Pattern.Factory;
using UnityEngine;

public class GoblinFactory : MonsterFactory
{
    public override Monster CreateMonster(string type)
    {
        switch (type)
        {
            case "Normal":
                return new GameObject("Goblin").AddComponent<Goblin>();
                break;
            case "Warrior":
                return new GameObject("Goblin Warrior").AddComponent<GoblinWarrior>();
                break;
            case "Archer":
                return new GameObject("Goblin Archer").AddComponent<GoblinArcher>();
                break;
            default:
                Debug.LogError($"Unknonw Monster Type : {type}");
                break;
        }
        return null;        
    }
}
