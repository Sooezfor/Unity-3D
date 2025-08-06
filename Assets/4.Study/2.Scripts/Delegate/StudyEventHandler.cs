using System;
using UnityEngine;

public class StudyEventHandler : MonoBehaviour
{
    public class ChracterData : EventArgs
    {
        public string name;
        public int level;
        public float hp;
        public float mp;
        public float damage;

        public ChracterData(string name, int level, float hp, float mp, float damage) //생성자
        {
            this.name = name;
            this.level = level;
            this.hp = hp;
            this.mp = mp;
            this.damage = damage;
        }
    }

    event EventHandler handler; 

    private void Start()
    {
        handler += CreateCharacter;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChracterData data = new ChracterData("A", 1, 2, 3, 4);
            handler?.Invoke(this, data);
        }

    }
    void CreateCharacter(object o, EventArgs e)
    {
        //GameObject chracter = Instantiate(chracterPrefab);
        var data = (ChracterData)e; //형변환
        Debug.Log($" {data.name} / {data.level} 데이터를 가진 캐릭터 생성");
    }
}
