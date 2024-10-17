using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Valve.Newtonsoft.Json;
using System.IO;

public class SpawnPointInitializer : MonoBehaviour
{
    private List<PointData> notes = new List<PointData>();
    // ����һ�����������Ա���Inspector�п��Կ������޸�
    [SerializeField]
    public Gameobiect spawnPoint;

    // ����Ĭ�ϵ�SpawnPointλ��
    [SerializeField]
    private Vector3 defaultSpawnPointPosition;

   

    // Awake����Start֮ǰ���õķ���
    void Awake()
    {
        // ��Awake�����г�ʼ��defaultSpawnPointPosition
        defaultSpawnPointPosition = new Vector3(Random.Range(-1f, 1f), 1, 6);
    }

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
        }
    }
}
public class PointData
{
    public float[] position;
  
    public float time;

    // �������������ڴ����鴴��Vector3
    public Vector3 GetPosition() => new Vector3(position[0], position[1], position[2]);
   
}
