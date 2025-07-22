using UnityEngine;

public class MakePath : MonoBehaviour
{
    public Vector3 GetPoint(int index)
    {
        return points[index]; 
    }

    public Vector3[] points;
    public float radius = 2f;
    
    private void OnDrawGizmos()
    {
        for(int i = 0; i<points.Length; i++)
        {
            if(i+1 < points.Length)
            {
                Debug.DrawLine(points[i], points[i + 1], Color.blue); //점들을 파란색 선으로 이음
            }
        }
    }
}
