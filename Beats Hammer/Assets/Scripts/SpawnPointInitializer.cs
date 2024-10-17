using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointInitializer : MonoBehaviour
{
    // 定义默认的SpawnPoint位置
    [SerializeField]
    private Vector3 defaultSpawnPointPosition = new Vector3(0f, 2f, 6f);

    // 用于存储生成点的Transform
    public Transform spawnPoint;

    // Awake是在Start之前调用的方法
    void Awake()
    {
        // 在Awake方法中初始化defaultSpawnPointPosition
        defaultSpawnPointPosition = new Vector3(Random.Range(-1f, 1f), 2f, 6f);

        // 检查是否已经有spawnPoint被分配
        if (spawnPoint == null)
        {
            // 如果没有，则创建一个新的空游戏对象作为SpawnPoint
            GameObject spawnPointObject = new GameObject("SpawnPoint");
            spawnPoint = spawnPointObject.transform;

            Debug.Log("SpawnPoint is not assigned. Creating a new one at: " + defaultSpawnPointPosition);
            // 设置SpawnPoint的位置
            spawnPoint.position = defaultSpawnPointPosition;
        }
    }

    void Start()
    {
        // 可以在这里添加其他初始化逻辑
    }
}
