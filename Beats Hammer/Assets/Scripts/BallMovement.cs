using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 0.3f; // 小球沿 z 轴移动的速度
    private Vector3 targetPosition; // 目标位置
    private bool isMoving = true; // 控制是否继续移动

    private void Start()
    {
        // 初始化目标位置，x 和 y 保持不变，只有 z 改变
        targetPosition = new Vector3(transform.position.x, transform.position.y, -6f);
    }

    void Update()
    {
        if (isMoving)
        {
            // 计算新的 z 位置
            float newZPosition = transform.position.z + (-speed * Time.deltaTime);

            // 更新位置，仅更新 z 坐标
            transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

            // 检查是否到达目标位置
            if (transform.position.z <= targetPosition.z)
            {
                isMoving = false;
            }
        }
    }
}
