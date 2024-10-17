using System;
using System.Collections.Generic;
using UnityEngine;

public class OrbitToPositionMapper : MonoBehaviour
{
    // 定义轨道到位置的映射
    private Dictionary<int, Vector3> orbitToPositionMap = new Dictionary<int, Vector3>
    {
        { 0, new Vector3(0, 0, -1) },
        { 1, new Vector3(1, 0, -1) },
        { 2, new Vector3(-1, 0, -1) },
        { 4, new Vector3(0, 1, -1) }
    };

    // 通过轨道编号获取位置
    public Vector3 GetPositionForOrbit(int orbit)
    {
        if (orbitToPositionMap.TryGetValue(orbit, out Vector3 position))
        {
            return position;
        }
        else
        {
            Debug.LogError($"No position defined for orbit: {orbit}");
            // 如果轨道编号不存在，返回默认位置或抛出异常
            return Vector3.zero; // 或者抛出异常：throw new ArgumentException("Invalid orbit number");
        }
    }

    // 示例方法：生成音乐方块
    public void SpawnMusicCube(int orbit)
    {
        Vector3 spawnPosition = GetPositionForOrbit(orbit);
        GameObject musicCubePrefab = Resources.Load<GameObject>("Prefabs/MusicCube"); // 假设预制件在 Resources/Prefabs 文件夹中
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