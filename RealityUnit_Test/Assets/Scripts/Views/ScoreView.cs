using System;
using UnityEngine;
using TMPro;

public interface IScoreView
{
    int Value { set; }
}

public class ScoreView : MonoBehaviour, IScoreView
{
    public int Value 
    {
        set
        {
            string score = value.ToString();
            
            TextMeshPro label = gameObject.GetComponent<TextMeshPro>();
            label.text = score;
        }
    }

    void Awake()
    {
        ScoreViewFactory.NotifyInstantiation(this);
    }
}