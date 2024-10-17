using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCubeManager : MonoBehaviour
{
    [SerializeField]
    public GameObject musicCubePrefab; // ���ַ���Ԥ�Ƽ�
    [SerializeField]
    private Transform spawnPoint; // ���ɵ�
    private GameObject currentMusicCube; // ��ǰ�����ַ���

    // Start is called before the first frame update
    void Start()
    {
        // ��ʼ����һ�����ַ���
        SpawnMusicCube();
    }

    public void SpawnMusicCube()
    {
        // ���ٵ�ǰ���ڵ����ַ��飨����У�
        if (currentMusicCube != null)
        {
            Destroy(currentMusicCube);
        }
        // �����µ����ַ���
        currentMusicCube = Instantiate(musicCubePrefab, spawnPoint.position, spawnPoint.rotation);
        
        Debug.Log("Music Cube Spawned at: " + spawnPoint.position);

        // ������ٻص�
        var destroyListener = currentMusicCube.AddComponent<MusicCubeDestroyListener>();
        destroyListener.OnDestroyed += OnMusicCubeDestroyed;

    }

    public void OnMusicCubeDestroyed()
    {
        // �����������ַ���
        SpawnMusicCube();
    }

}

// ���ڼ������ַ������ٵ����
public class MusicCubeDestroyListener : MonoBehaviour
{
    public delegate void OnDestroyedDelegate();
    public event OnDestroyedDelegate OnDestroyed;

    private void OnDestroy()
    {
        // �����ַ��鱻����ʱ�����¼�
        OnDestroyed?.Invoke();
    }
}
