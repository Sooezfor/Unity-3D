using UnityEngine;

namespace Pattern
{
    public class ScoreController : MonoBehaviour
    {
        int score = 0;
        private void Update()
        {        
            if(Input.GetKeyDown(KeyCode.Space))
            {
                score ++;
                StudyEventBus.ScoreChanged(score); //버스 태우기
            }
        }
    }
}
