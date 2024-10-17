using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicCubeManager : MonoBehaviour
{
    [SerializeField]
    public GameObject musicCubePrefab; // 音乐方块预制件
    [SerializeField]
    private Transform spawnPoint; // 生成点
    private GameObject currentMusicCube; // 当前的音乐方块

    // Start is called before the first frame update
    void Start()
    {
        // 初始化第一个音乐方块
        SpawnMusicCube();
    }

    public void SpawnMusicCube()
    {
        // 销毁当前存在的音乐方块（如果有）
        if (currentMusicCube != null)
        {
            Destroy(currentMusicCube);
        }
        // 生成新的音乐方块
        currentMusicCube = Instantiate(musicCubePrefab, spawnPoint.position, spawnPoint.rotation);
        
        Debug.Log("Music Cube Spawned at: " + spawnPoint.position);

        // 添加销毁回调
        var destroyListener = currentMusicCube.AddComponent<MusicCubeDestroyListener>();
        destroyListener.OnDestroyed += OnMusicCubeDestroyed;

    }

    public void OnMusicCubeDestroyed()
    {

        // 检查 spawnPoint 是否为 null 或已被销毁
        if (spawnPoint == null)
        {
            Debug.LogError("Spawn Point is null or destroyed. Cannot spawn new Music Cube.");
            return;
        }
        // 重新生成音乐方块
        SpawnMusicCube();
    }

}

public class MusicCubeDestroyListener : MonoBehaviour
{
    public delegate void OnDestroyedDelegate();
    public event OnDestroyedDelegate OnDestroyed;

    private void OnDestroy()
    {
        // 当音乐方块被销毁时触发事件
        OnDestroyed?.Invoke();
    }
}