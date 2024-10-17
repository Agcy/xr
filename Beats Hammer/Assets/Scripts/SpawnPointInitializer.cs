using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointInitializer : MonoBehaviour
{
    // ����Ĭ�ϵ�SpawnPointλ��
    [SerializeField]
    private Vector3 defaultSpawnPointPosition = new Vector3(0f, 2f, 6f);

    // ���ڴ洢���ɵ��Transform
    public Transform spawnPoint;

    // Awake����Start֮ǰ���õķ���
    void Awake()
    {
        // ��Awake�����г�ʼ��defaultSpawnPointPosition
        defaultSpawnPointPosition = new Vector3(Random.Range(-1f, 1f), 2f, 6f);

        // ����Ƿ��Ѿ���spawnPoint������
        if (spawnPoint == null)
        {
            // ���û�У��򴴽�һ���µĿ���Ϸ������ΪSpawnPoint
            GameObject spawnPointObject = new GameObject("SpawnPoint");
            spawnPoint = spawnPointObject.transform;

            Debug.Log("SpawnPoint is not assigned. Creating a new one at: " + defaultSpawnPointPosition);
            // ����SpawnPoint��λ��
            spawnPoint.position = defaultSpawnPointPosition;
        }
    }

    void Start()
    {
        // �������������������ʼ���߼�
    }
}
