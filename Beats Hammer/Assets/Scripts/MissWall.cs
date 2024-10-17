using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissWall : MonoBehaviour
{
    private int missScore = 0;
    [SerializeField]
    private TextMeshPro missScoreMeshPro;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MusicCube"))
        {
            Debug.Log("Miss!");
            // ¥¶¿ÌMiss
            missScore++;
            Destroy(other.gameObject);
            if (missScoreMeshPro != null)
            {
                missScoreMeshPro.text = missScore.ToString();
            }
        }
    }
}
