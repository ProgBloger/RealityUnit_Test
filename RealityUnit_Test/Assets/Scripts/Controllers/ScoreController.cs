
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
    private ISceneManagerModel sceneManagerModel;
    private IGridModel gridModel;

    public ScoreController(IGridFactory gridFactory, IScoreViewFactory scoreViewFactory, IScoreModel scoreModel, ISceneManagerModel sceneManagerModel)
    {
        this.cellModels = gridFactory.GetCellModels();
        this.gridModel = gridFactory.GetGridModel();
        
        this.currentScoreView = scoreViewFactory.GetCurrentScoreView();
        this.totalScoreView = scoreViewFactory.GetTotalScoreView();
        this.scoreModel = scoreModel;
        this.sceneManagerModel = sceneManagerModel;
        
		scoreModel.OnCurrentScoreUpdated += HandleOnCurrentScoreUpdated;
		scoreModel.OnTotalScoreUpdated += HandleOnTotalScoreUpdated;

        SubscribeOnCellStateChanged();

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

    private void SubscribeOnCellStateChanged()
    {
        foreach(var cellModel in cellModels)
        {
            cellModel.OnCellStateChanged += HandleOnCellStateChanged;
        }
    }
    
    private void HandleOnTotalScoreUpdated(object sender, TotalScoreUpdatedEventArgs args)
    {
        SyncTotalScore();
        DecideWholeSetsResult();
    }
    
    private void HandleOnCurrentScoreUpdated(object sender, CurrentScoreUpdatedEventArgs args)
    {
        SyncCurrentScore();
        
        // When CurrentScore update event occures
        // Checks if it crosses the threshold
        DecideGameResult();
    }
    
    private void HandleOnCellStateChanged(object sender, CellStateChangedEventArgs args)
    {
        if(args.IsActive)
        {
            scoreModel.CurrentScore += args.Value;
        }
        else
        {
            scoreModel.CurrentScore -= args.Value;
        }
    }

    private void DecideWholeSetsResult()
    {
        if(scoreModel.TotalScore >= scoreModel.GameThreshold)
        {
            // Win case
            sceneManagerModel.CurrentScene = (int)GameScene.Win;
        }
        else if(scoreModel.TotalScore < 0)
        {
            // Lose case
            sceneManagerModel.CurrentScene = (int)GameScene.Lose;
        }
    }

    private void InitScoreSystem()
    {
        SetCellScores();
        this.scoreModel.TotalScore = this.scoreModel.TotalScore;
        this.scoreModel.CurrentScore = this.scoreModel.CurrentScore;
    }

    private void SyncTotalScore()
    {
        totalScoreView.Value = this.scoreModel.TotalScore;
    }

    private void SyncCurrentScore()
    {
        currentScoreView.Value = this.scoreModel.CurrentScore;
    }

    private void DecideGameResult()
    {
        if(scoreModel.CurrentScore > scoreModel.ScoreThreshold)
        {
            // Loose case
            scoreModel.TotalScore -= scoreModel.CurrentScore / 2;
            ResetTheGame();
        }
        else if(scoreModel.CurrentScore == scoreModel.ScoreThreshold)
        {
            // Win case
            scoreModel.TotalScore += scoreModel.CurrentScore;
            ResetTheGame();
        }
    }

    private List<int> Shuffle(List<int> availableScores)
    {
        System.Random rnd = new System.Random();
        return availableScores.OrderBy(x => rnd.Next()).ToList();  
    }

    private void ResetTheGame()
    {
        foreach(var cellModel in cellModels)
        {
            cellModel.IsActive = false;
        }

        SetCellScores();
        scoreModel.CurrentScore = 0;
    }
}