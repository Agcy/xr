using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HummerInteract: MonoBehaviour
{
    [SerializeField]
    private GameObject controllerGameObj;

    // 判断是否击中音乐方块的距离
    public float normalDistanceMax = 0.8f;
    public float perfectDistanceMax = 0.3f;

    // 分数计算
    private int perfectScore = 0;
    private int normalScore = 0;
    [SerializeField]
    private TextMeshPro perfectScoreMeshPro;
    [SerializeField]
    private TextMeshPro normalScoreMeshPro;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerGameObj != null)
        {
            transform.position = controllerGameObj.transform.position;
            transform.rotation = controllerGameObj.transform.rotation;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MusicCube"))
        {
            // 计算锤子与音乐方块之间的距离
            float distance = Vector3.Distance(transform.position, other.transform.position);
            Debug.Log("Distance between cube and hummer: " + distance);
            // 根据距离进行判定
            if (distance <= perfectDistanceMax)
            {
                Debug.Log("Perfect Hit!");
                // 处理Perfect命中
                perfectScore++;
                if (perfectScoreMeshPro != null)
                {
                    perfectScoreMeshPro.text = perfectScore.ToString();
                }
            }
            else if (distance <= normalDistanceMax)
            {
                Debug.Log("Normal Hit!");
                // 处理Normal命中
                normalScore++;
                if (normalScoreMeshPro != null)
                {
                    normalScoreMeshPro.text = normalScore.ToString();
                }
            }

            // 销毁音乐方块
            Debug.Log("Music Cube is destroyed");
            Destroy(other.gameObject);
        }
    }
}
