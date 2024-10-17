using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HummerInteract: MonoBehaviour
{
    [SerializeField]
    private GameObject controllerGameObj;

    // �ж��Ƿ�������ַ���ľ���
    public float normalDistanceMax = 0.8f;
    public float perfectDistanceMax = 0.3f;

    // ��������
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
            // ���㴸�������ַ���֮��ľ���
            float distance = Vector3.Distance(transform.position, other.transform.position);
            Debug.Log("Distance between cube and hummer: " + distance);
            // ���ݾ�������ж�
            if (distance <= perfectDistanceMax)
            {
                Debug.Log("Perfect Hit!");
                // ����Perfect����
                perfectScore++;
                if (perfectScoreMeshPro != null)
                {
                    perfectScoreMeshPro.text = perfectScore.ToString();
                }
            }
            else if (distance <= normalDistanceMax)
            {
                Debug.Log("Normal Hit!");
                // ����Normal����
                normalScore++;
                if (normalScoreMeshPro != null)
                {
                    normalScoreMeshPro.text = normalScore.ToString();
                }
            }

            // �������ַ���
            Debug.Log("Music Cube is destroyed");
            Destroy(other.gameObject);
        }
    }
}
