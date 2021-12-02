using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public void ChangeScore(int score)
    {
        text.text = "Score: " + (score * 10).ToString();
    }
}
