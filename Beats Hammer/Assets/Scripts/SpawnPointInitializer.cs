using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Valve.Newtonsoft.Json;
using System.IO;

public class SpawnPointInitializer : MonoBehaviour
{
    private List<PointData> notes = new List<PointData>();
    // 定义一个公共变量以便在Inspector中可以看到并修改
    [SerializeField]
    public Gameobiect spawnPoint;

    // 定义默认的SpawnPoint位置
    [SerializeField]
    private Vector3 defaultSpawnPointPosition;

   

    // Awake是在Start之前调用的方法
    void Awake()
    {
        // 在Awake方法中初始化defaultSpawnPointPosition
        defaultSpawnPointPosition = new Vector3(Random.Range(-1f, 1f), 1, 6);
    }

    void Start()
    {
        string path = Application.dataPath + "/Resources/notes.json";
        string dataAsJson = File.ReadAllText(path);
        notes = JsonConvert.DeserializeObject<List<PointData>>(dataAsJson);

        // 开始生成音符
        StartCoroutine(SpawnNotes());

        // 检查是否已经有spawnPoint被分配
       
    }
    IEnumerator SpawnNotes()
    {
        foreach (var note in notes)
        {
            // 等待延迟时间
            yield return new WaitForSeconds(note.delayBeforeStart);

            // 实例化音符
            GameObject instance = Instantiate(, note.position, Quaternion.identity);

            // 移动音符
            StartCoroutine(MoveNote(instance, note.targetPosition, note.speed));
        }
    }
}
public class PointData
{
    public float[] position;
  
    public float time;

    // 辅助方法，用于从数组创建Vector3
    public Vector3 GetPosition() => new Vector3(position[0], position[1], position[2]);
   
}
