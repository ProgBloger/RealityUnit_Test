using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentScoreView : ScoreView
{
    void Awake()
    {
        labelTextPattern = "Current Score: ";
        ScoreViewFactory.NotifyCurrentScoreViewInstantiation(this);
    }
}
