using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI textMesh;
    private int goalCount = 0;
    public void ApplyGoal()
    {
        goalCount++;
        textMesh.text = goalCount.ToString();
    }
}
