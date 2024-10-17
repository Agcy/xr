using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointInitializer : MonoBehaviour
{
    // ����һ�����������Ա���Inspector�п��Կ������޸�
    [SerializeField]
    private Transform spawnPoint;

    // ����Ĭ�ϵ�SpawnPointλ��
    [SerializeField]
    private Vector3 defaultSpawnPointPosition;

    // ����SpawnPoint����ת�Ƕ�
    [SerializeField]
    private Vector3 spawnPointRotation = new Vector3(0, 0, 0);

    // Awake����Start֮ǰ���õķ���
    void Awake()
    {
        // ��Awake�����г�ʼ��defaultSpawnPointPosition
        defaultSpawnPointPosition = new Vector3(Random.Range(-1f, 1f), 1, 6);
    }

    void Start()
    {
        // ����Ƿ��Ѿ���spawnPoint������
        if (spawnPoint == null)
        {
            // ���û�У��򴴽�һ���µĿ���Ϸ������ΪSpawnPoint
            GameObject spawnPointObject = new GameObject("SpawnPoint");
            spawnPoint = spawnPointObject.transform;

            // ����SpawnPoint��λ�ú���ת�Ƕ�
            spawnPoint.position = defaultSpawnPointPosition;
            spawnPoint.rotation = Quaternion.Euler(spawnPointRotation);
        }
    }
}
