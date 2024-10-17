using System;
using System.Collections.Generic;
using UnityEngine;

public class OrbitToPositionMapper : MonoBehaviour
{
    // ��������λ�õ�ӳ��
    private Dictionary<int, Vector3> orbitToPositionMap = new Dictionary<int, Vector3>
    {
        { 0, new Vector3(0, 0, -1) },
        { 1, new Vector3(1, 0, -1) },
        { 2, new Vector3(-1, 0, -1) },
        { 4, new Vector3(0, 1, -1) }
    };

    // ͨ�������Ż�ȡλ��
    public Vector3 GetPositionForOrbit(int orbit)
    {
        if (orbitToPositionMap.TryGetValue(orbit, out Vector3 position))
        {
            return position;
        }
        else
        {
            Debug.LogError($"No position defined for orbit: {orbit}");
            // ��������Ų����ڣ�����Ĭ��λ�û��׳��쳣
            return Vector3.zero; // �����׳��쳣��throw new ArgumentException("Invalid orbit number");
        }
    }

    // ʾ���������������ַ���
    public void SpawnMusicCube(int orbit)
    {
        Vector3 spawnPosition = GetPositionForOrbit(orbit);
        GameObject musicCubePrefab = Resources.Load<GameObject>("Prefabs/MusicCube"); // ����Ԥ�Ƽ��� Resources/Prefabs �ļ�����
        if (musicCubePrefab != null)
        {
            Instantiate(musicCubePrefab, spawnPosition, Quaternion.identity);
            Debug.Log($"Music Cube Spawned at: {spawnPosition}");
        }
        else
        {
            Debug.LogError("MusicCube prefab not found.");
        }
    }
}