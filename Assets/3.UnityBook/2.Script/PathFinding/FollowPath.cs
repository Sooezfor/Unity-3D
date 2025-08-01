using System.Reflection;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    //�� ���󰡱� ���

    //public Algorithm.
    public MakePath path;
    public float speed = 5f;
    public float mass = 5f;
    public bool isLooping = true;

    Vector3 targetPoint;
    Vector3 velocity;

    float curSpeed;
    int curPathIndex;
    float pathLength;


    private void Start()
    {
        int ranInt = Random.Range(0, 10);

        pathLength = path.points.Length;
        curPathIndex = 0;

        velocity = transform.forward;
    }

    private void Update()
    {
        curSpeed = speed * Time.deltaTime;
        targetPoint = path.GetPoint(curPathIndex);

        //�������� ���� �����ϸ� ���� ������ �����ϴ� ���
        if(Vector3.Distance(transform.position, targetPoint) < path.radius) //���� �ݰ� ������ ���Դٸ�
        {
            if (curPathIndex < pathLength - 1)
                curPathIndex++;
            else if (isLooping)
                curPathIndex = 0;
            else
                return;            
        }
        if (curPathIndex >= pathLength)
            return;
        if (curPathIndex >= pathLength - 1 && !isLooping)
            velocity += Steer(targetPoint, true);  //���� ��ȯ 
        else
            velocity += Steer(targetPoint);

        transform.position += velocity;
        transform.rotation = Quaternion.LookRotation(velocity);
    }

    public Vector3 Steer(Vector3 target, bool isFinalPoint = false)
    {
        Vector3 targetDir = target - transform.position; //���� �������� ���� 
        float dist = targetDir.magnitude;
       
        targetDir.Normalize();

        if (isFinalPoint && dist < 10f)        
            targetDir *= curSpeed * (dist / 10f);        
        else
            targetDir *= curSpeed;

        Vector3 steeringForce = targetDir - velocity;
        Vector3 acceleration = steeringForce / mass;

        return acceleration;
    }
}
