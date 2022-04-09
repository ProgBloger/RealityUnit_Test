using System;
using UnityEngine;
using TMPro;

public interface IScoreView
{
    int Value { set; }
}

public abstract class ScoreView : MonoBehaviour, IScoreView
{
    protected string labelTextPattern = string.Empty;
    public int Value 
    {
        set
        {
            string score = $"{labelTextPattern}{value}";
            
            TMP_Text label = GetComponent<TMP_Text>();
            label.SetText(score);
        }
    }
}