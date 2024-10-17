using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Valve.Newtonsoft.Json;
using System.IO;

public class SpawnPointInitializer : MonoBehaviour
{
<<<<<<< HEAD
    private List<PointData> notes = new List<PointData>();
    // 定义一个公共变量以便在Inspector中可以看到并修改
    [SerializeField]
    public Gameobiect spawnPoint;

=======
>>>>>>> 63afa85f72939affb5e7fe2d32f4955a56a31f6a
    // 定义默认的SpawnPoint位置
    [SerializeField]
    private Vector3 defaultSpawnPointPosition = new Vector3(0f, 2f, 6f);

<<<<<<< HEAD
   
=======
    // 用于存储生成点的Transform
    public Transform spawnPoint;
>>>>>>> 63afa85f72939affb5e7fe2d32f4955a56a31f6a

    // Awake是在Start之前调用的方法
    void Awake()
    {
        // 在Awake方法中初始化defaultSpawnPointPosition
        defaultSpawnPointPosition = new Vector3(Random.Range(-1f, 1f), 2f, 6f);

<<<<<<< HEAD
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
=======
        // 检查是否已经有spawnPoint被分配
        if (spawnPoint == null)
        {
            // 如果没有，则创建一个新的空游戏对象作为SpawnPoint
            GameObject spawnPointObject = new GameObject("SpawnPoint");
            spawnPoint = spawnPointObject.transform;

            Debug.Log("SpawnPoint is not assigned. Creating a new one at: " + defaultSpawnPointPosition);
            // 设置SpawnPoint的位置
            spawnPoint.position = defaultSpawnPointPosition;
>>>>>>> 63afa85f72939affb5e7fe2d32f4955a56a31f6a
        }
    }

    void Start()
    {
        // 可以在这里添加其他初始化逻辑
    }
}
public class PointData
{
    public float[] position;
  
    public float time;

    // 辅助方法，用于从数组创建Vector3
    public Vector3 GetPosition() => new Vector3(position[0], position[1], position[2]);
   
}
