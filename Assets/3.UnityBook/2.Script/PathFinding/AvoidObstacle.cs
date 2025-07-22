using UnityEngine;

public class AvoidObstacle : MonoBehaviour
{
    public float speed = 10f;
    public float mass = 5f;
    public float force = 50f;
    public float minDistToAvoid = 5f;

    float curSpeed;
    Vector3 targetPoint;
    public float steeringForce = 10f;
    private void Start()
    {
        targetPoint = Vector3.zero;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                targetPoint = hit.point; //���콺 Ŭ���� ���� ��ǥ �������� ����
            }
        }

        Vector3 dir = targetPoint - transform.position;
        dir.Normalize();

        dir = GetAvoidanceDirection(dir); //��ֹ� ������ ���� �״��, ������ �޶���

        if (Vector3.Distance(targetPoint, transform.position) < 1f) //��Ȯ�� 0�� �� Ȯ���� ���� ��� �˳��ϰ� 1�� ����
            return;

        curSpeed = speed * Time.deltaTime;
        transform.position += transform.forward * curSpeed;

        Quaternion rot = Quaternion.LookRotation(dir); //������ �˷��ִ� ���͸� ������ �� ���� ���� ���� ����
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, steeringForce * Time.deltaTime);
            // ���� ȸ������ ��ǥ ȸ������ ������ŭ �ε巴�� ȸ���Ѵ�.
    }

    //�̵� ���⿡ ��ֹ��� ���� ��� �̵��Ϸ��� ������ �ٲٴ� ���
    public Vector3 GetAvoidanceDirection(Vector3 dir)
    {
        RaycastHit hit;
        int layerMask = 1 << 15;
        if(Physics.Raycast(transform.position, transform.forward, out hit, minDistToAvoid, layerMask))
        {
            Vector3 hitNormal = hit.normal;
            hitNormal.y = 0f;

            dir = transform.forward + hitNormal * force;
            dir.Normalize();
        }
        return dir;
    }
}
