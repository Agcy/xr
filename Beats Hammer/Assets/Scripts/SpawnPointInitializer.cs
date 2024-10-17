using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointInitializer : MonoBehaviour
{
    // 定义一个公共变量以便在Inspector中可以看到并修改
    [SerializeField]
    private Transform spawnPoint;

    // 定义默认的SpawnPoint位置
    [SerializeField]
    private Vector3 defaultSpawnPointPosition;

    // 定义SpawnPoint的旋转角度
    [SerializeField]
    private Vector3 spawnPointRotation = new Vector3(0, 0, 0);

    // Awake是在Start之前调用的方法
    void Awake()
    {
        // 在Awake方法中初始化defaultSpawnPointPosition
        defaultSpawnPointPosition = new Vector3(Random.Range(-1f, 1f), 1, 6);
    }

    void Start()
    {
        // 检查是否已经有spawnPoint被分配
        if (spawnPoint == null)
        {
            // 如果没有，则创建一个新的空游戏对象作为SpawnPoint
            GameObject spawnPointObject = new GameObject("SpawnPoint");
            spawnPoint = spawnPointObject.transform;

            // 设置SpawnPoint的位置和旋转角度
            spawnPoint.position = defaultSpawnPointPosition;
            spawnPoint.rotation = Quaternion.Euler(spawnPointRotation);
        }
    }
}
