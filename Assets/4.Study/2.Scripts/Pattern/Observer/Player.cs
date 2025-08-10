using System.Xml.Serialization;
using UnityEngine;

namespace Pattern
{
    public class Player : MonoBehaviour
    {
        int score;

        bool isQClear1 = false;
        //bool isQClear2 = false;
        //bool isQclear3 = false;

        public int GetScore()
        {
            return score;
        }

        public void AddScore(int score)
        {
            this.score += score;

            CheckQuest();
        }
        void CheckQuest()
        {
            if(score >= 100 && !isQClear1)
            {
                isQClear1 = true;
                Debug.Log("100Á¡ ´Þ¼º");

            }

        }
    }

}
