using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR;

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
                TriggerVibration(0.1f, 0.5f); // ������
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
                TriggerVibration(0.1f, 0.5f); // ������
            }

            // �������ַ���
            Debug.Log("Music Cube is destroyed");
            Destroy(other.gameObject);
        }
    }

    // �����ֱ��𶯵ķ���
    private void TriggerVibration(float duration, float frequency)
    {
        // ��ȡ��ǰ�ֱ��Ķ����豸
        SteamVR_Input_Sources handType = GetHandType();

        if (handType == SteamVR_Input_Sources.LeftHand)
        {
            SteamVR_Actions._default.Haptic.Execute(0, duration, frequency, 0.5f, SteamVR_Input_Sources.LeftHand);
        }
        else if (handType == SteamVR_Input_Sources.RightHand)
        {
            SteamVR_Actions._default.Haptic.Execute(0, duration, frequency, 0.5f, SteamVR_Input_Sources.RightHand);
        }
    }
       
    // ���ݴ��ӵı�ǩȷ�������ֻ�������
    private SteamVR_Input_Sources GetHandType()
    {
        if (this.gameObject.CompareTag("LeftHammer"))
        {
            return SteamVR_Input_Sources.LeftHand;
        }
        else if (this.gameObject.CompareTag("RightHammer"))
        {
            return SteamVR_Input_Sources.RightHand;
        }
        else
        {
            Debug.LogWarning("Hammer tag not set correctly. Defaulting to LeftHand.");
            return SteamVR_Input_Sources.LeftHand; // Ĭ��Ϊ����
        }
    }
}
