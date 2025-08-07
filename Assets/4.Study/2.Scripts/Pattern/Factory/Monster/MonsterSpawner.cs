using Pattern.Factory;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    MonsterFactory currFactory;
    Monster currMonster;

    GoblinFactory goblinFactory;
    OrcFactory orcFactory;
    private void Awake()
    {
        goblinFactory = new GameObject("Goblin Factory").AddComponent<GoblinFactory>();
        orcFactory = new GameObject("Orc Factory").AddComponent<OrcFactory>();


    }
    private void Start()
    {
        currFactory = goblinFactory;
        currMonster = currFactory.CreateMonster("Normal");
        currMonster = currFactory.CreateMonster("Warrior");
        currMonster = currFactory.CreateMonster("Archer");

        currFactory = orcFactory;
        currMonster = currFactory.CreateMonster("Normal");
        currMonster = currFactory.CreateMonster("Warrior");
        currMonster = currFactory.CreateMonster("Archer");


    }
}
