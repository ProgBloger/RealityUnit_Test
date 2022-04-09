
using System;
using System.Collections.Generic;
using System.Linq;

public interface IScoreController
{

}

public class ScoreController : IScoreController
{
    private List<ICellModel> cellModels;
    private IScoreView scoreView;
    private IScoreModel scoreModel;
    private IGridModel gridModel;

    public ScoreController(IGridFactory gridFactory, IScoreView scoreView, IScoreModel scoreModel)
    {
        this.cellModels = gridFactory.GetCellModels();
        this.gridModel = gridFactory.GetGridModel();
        this.scoreView = scoreView;
        this.scoreModel = scoreModel;

        SetScores();
    }

    public void SetScores()
    {
        var availableScores = scoreModel.PointsArray;
        var scoresList = new List<int>(availableScores);
        while(scoresList.Count < gridModel.CellsTotal)
        {
            scoresList.AddRange(availableScores);
        }

        scoresList = Shuffle(scoresList);

        for(int i = 0; i < gridModel.CellsTotal; i++)
        {
            cellModels[i].Value = scoresList[i];
        }
    }

    private List<int> Shuffle(List<int> availableScores)
    {
        Random rnd=new Random();
        return availableScores.OrderBy(x => rnd.Next()).ToList();  
    }
}