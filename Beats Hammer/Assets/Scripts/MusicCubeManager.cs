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
    public GameObject musicCubePrefab; // 音乐方块预制件
    
    private GameObject currentMusicCube; // 当前的音乐方块

    // Start is called before the first frame update
    void Start()
    {
        // 初始化第一个音乐方块
        string path = Application.dataPath + "/Resources/notes.json";
        string dataAsJson = File.ReadAllText(path);
        notes = JsonConvert.DeserializeObject<List<NoteData>>(dataAsJson);

        // 开始生成音符
        StartCoroutine(SpawnNotes());
    }

    IEnumerator SpawnNotes()
    {
        foreach (var note in notes)
        {
            // 等待延迟时间
            yield return new WaitForSeconds(note.time);

            // 实例化音符
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