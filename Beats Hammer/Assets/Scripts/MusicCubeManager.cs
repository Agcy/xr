using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Valve.Newtonsoft.Json;
using System.IO;

public class MusicCubeManager : MonoBehaviour
{
     private List<NoteData> notes = new List<NoteData>();
    [SerializeField]
    public GameObject musicCubePrefab; // ���ַ���Ԥ�Ƽ�
    
    private GameObject currentMusicCube; // ��ǰ�����ַ���

    // Start is called before the first frame update
    void Start()
    {
        // ��ʼ����һ�����ַ���
        string path = Application.dataPath + "/Resources/notes.json";
        string dataAsJson = File.ReadAllText(path);
        notes = JsonConvert.DeserializeObject<List<NoteData>>(dataAsJson);

        // ��ʼ��������
        StartCoroutine(SpawnNotes());
    }

    IEnumerator SpawnNotes()
    {
        foreach (var note in notes)
        {
            // �ȴ��ӳ�ʱ��
            yield return new WaitForSeconds(note.time);

            // ʵ��������
            GameObject instance = Instantiate(musicCubePrefab, note.position, Quaternion.identity);

      
        }
    }

}

[System.Serializable]
public class NoteData
{  
    public Vector3 position;
    public float speed;
    public float time;

   
  
}