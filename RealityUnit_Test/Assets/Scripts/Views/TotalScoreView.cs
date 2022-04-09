using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalScoreView : ScoreView
{

    void Awake()
    {
        labelTextPattern = "Total Score: ";
        ScoreViewFactory.NotifyTotalScoreViewInstantiation(this);
    }
}
