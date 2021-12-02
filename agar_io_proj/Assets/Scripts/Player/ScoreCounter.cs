using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    //счетчик игрока

    [SerializeField] TMP_Text text;

    public void ChangeScore(float score)
    {
        text.text = "Score: " + (score * 10).ToString();
    }
}
