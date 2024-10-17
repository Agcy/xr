using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR;

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
                TriggerVibration(0.1f, 0.5f); // 触发震动
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
                TriggerVibration(0.1f, 0.5f); // 触发震动
            }

            // 销毁音乐方块
            Debug.Log("Music Cube is destroyed");
            Destroy(other.gameObject);
        }
    }

    // 触发手柄震动的方法
    private void TriggerVibration(float duration, float frequency)
    {
        // 获取当前手柄的动作设备
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
       
    // 根据锤子的标签确定是左手还是右手
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
            return SteamVR_Input_Sources.LeftHand; // 默认为左手
        }
    }
}
