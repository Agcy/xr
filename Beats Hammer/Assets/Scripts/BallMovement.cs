using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 0.3f; // С���� z ���ƶ����ٶ�
    private Vector3 targetPosition; // Ŀ��λ��
    private bool isMoving = true; // �����Ƿ�����ƶ�

    private void Start()
    {
        // ��ʼ��Ŀ��λ�ã�x �� y ���ֲ��䣬ֻ�� z �ı�
        targetPosition = new Vector3(transform.position.x, transform.position.y, -6f);
    }

    void Update()
    {
        if (isMoving)
        {
            // �����µ� z λ��
            float newZPosition = transform.position.z + (-speed * Time.deltaTime);

            // ����λ�ã������� z ����
            transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

            // ����Ƿ񵽴�Ŀ��λ��
            if (transform.position.z <= targetPosition.z)
            {
                isMoving = false;
            }
        }
    }
}
