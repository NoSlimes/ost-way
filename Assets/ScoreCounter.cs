using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private TMP_Text text;
    private int score;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        score = 0;
        text.text = $"Score: {score}";
    }

    public void AddScore()
    {
        score++;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = $"Score: {score}";
    }
}
