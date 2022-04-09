
using System;
using System.Collections.Generic;
using System.Linq;

public interface IScoreController
{

}

public class ScoreController : IScoreController
{
    private List<ICellModel> cellModels;
    private IScoreView currentScoreView;
    private IScoreView totalScoreView;
    private IScoreModel scoreModel;
    private IGridModel gridModel;

    public ScoreController(IGridFactory gridFactory, IScoreViewFactory scoreViewFactory, IScoreModel scoreModel)
    {
        this.cellModels = gridFactory.GetCellModels();
        this.gridModel = gridFactory.GetGridModel();
        
        this.currentScoreView = scoreViewFactory.GetCurrentScoreView();
        this.totalScoreView = scoreViewFactory.GetTotalScoreView();

        this.scoreModel = scoreModel;
        
		scoreModel.OnCurrentScoreUpdated += HandleOnCurrentScoreUpdated;
		scoreModel.OnTotalScoreUpdated += HandleOnTotalScoreUpdated;

        InitScoreSystem();
    }

    public void SetCellScores()
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

    private void InitScoreSystem()
    {
        SetCellScores();
        this.scoreModel.TotalScore = 2;
        this.scoreModel.CurrentScore = 3;
    }

    private void SyncTotalScore()
    {
        totalScoreView.Value = this.scoreModel.TotalScore;
    }

    private void SyncCurrentScore()
    {
        currentScoreView.Value = this.scoreModel.CurrentScore;
    }
    
    private void HandleOnTotalScoreUpdated(object sender, TotalScoreUpdatedEventArgs OnClicked)
    {
        SyncTotalScore();
    }
    
    private void HandleOnCurrentScoreUpdated(object sender, CurrentScoreUpdatedEventArgs OnClicked)
    {
        SyncCurrentScore();
    }

    private List<int> Shuffle(List<int> availableScores)
    {
        System.Random rnd = new System.Random();
        return availableScores.OrderBy(x => rnd.Next()).ToList();  
    }
}