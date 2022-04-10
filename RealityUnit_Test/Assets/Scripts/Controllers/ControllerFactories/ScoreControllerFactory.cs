public interface IScoreControllerFactory
{
    ScoreController GetScoreController(IScoreModel scoreModel, ISceneManagerModel sceneManagerModel);
}

public class ScoreControllerFactory : IScoreControllerFactory
{
    IGridFactory gridFactory;
    IScoreViewFactory scoreViewFactory;
    public ScoreControllerFactory(IGridFactory gridFactory, IScoreViewFactory scoreViewFactory)
    {
        this.gridFactory = gridFactory;
        this.scoreViewFactory = scoreViewFactory;
        
    }

    public ScoreController GetScoreController(IScoreModel scoreModel, ISceneManagerModel sceneManagerModel)
    {
        return new ScoreController(gridFactory, scoreViewFactory, scoreModel, sceneManagerModel);
    }
}