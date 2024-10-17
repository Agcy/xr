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
    // ����һ�����������Ա���Inspector�п��Կ������޸�
    [SerializeField]
    public Gameobiect spawnPoint;

=======
>>>>>>> 63afa85f72939affb5e7fe2d32f4955a56a31f6a
    // ����Ĭ�ϵ�SpawnPointλ��
    [SerializeField]
    private Vector3 defaultSpawnPointPosition = new Vector3(0f, 2f, 6f);

<<<<<<< HEAD
   
=======
    // ���ڴ洢���ɵ��Transform
    public Transform spawnPoint;
>>>>>>> 63afa85f72939affb5e7fe2d32f4955a56a31f6a

    // Awake����Start֮ǰ���õķ���
    void Awake()
    {
        // ��Awake�����г�ʼ��defaultSpawnPointPosition
        defaultSpawnPointPosition = new Vector3(Random.Range(-1f, 1f), 2f, 6f);

<<<<<<< HEAD
    void Start()
    {
        string path = Application.dataPath + "/Resources/notes.json";
        string dataAsJson = File.ReadAllText(path);
        notes = JsonConvert.DeserializeObject<List<PointData>>(dataAsJson);

        // ��ʼ��������
        StartCoroutine(SpawnNotes());

        // ����Ƿ��Ѿ���spawnPoint������
       
    }
    IEnumerator SpawnNotes()
    {
        foreach (var note in notes)
        {
            // �ȴ��ӳ�ʱ��
            yield return new WaitForSeconds(note.delayBeforeStart);

            // ʵ��������
            GameObject instance = Instantiate(, note.position, Quaternion.identity);

            // �ƶ�����
            StartCoroutine(MoveNote(instance, note.targetPosition, note.speed));
=======
        // ����Ƿ��Ѿ���spawnPoint������
        if (spawnPoint == null)
        {
            // ���û�У��򴴽�һ���µĿ���Ϸ������ΪSpawnPoint
            GameObject spawnPointObject = new GameObject("SpawnPoint");
            spawnPoint = spawnPointObject.transform;

            Debug.Log("SpawnPoint is not assigned. Creating a new one at: " + defaultSpawnPointPosition);
            // ����SpawnPoint��λ��
            spawnPoint.position = defaultSpawnPointPosition;
>>>>>>> 63afa85f72939affb5e7fe2d32f4955a56a31f6a
        }
    }

    void Start()
    {
        // �������������������ʼ���߼�
    }
}
public class PointData
{
    public float[] position;
  
    public float time;

    // �������������ڴ����鴴��Vector3
    public Vector3 GetPosition() => new Vector3(position[0], position[1], position[2]);
   
}
