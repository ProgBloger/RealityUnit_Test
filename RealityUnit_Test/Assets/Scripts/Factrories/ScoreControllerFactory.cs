public interface IScoreControllerFactory
{
    ScoreController GetScoreController(IScoreView scoreView, IScoreModel scoreModel);
}

public class ScoreControllerFactory : IScoreControllerFactory
{
    IGridFactory gridFactory;
    public ScoreControllerFactory(IGridFactory gridFactory)
    {
        this.gridFactory = gridFactory;
    }

    public ScoreController GetScoreController(IScoreView scoreView, IScoreModel scoreModel)
    {
        return new ScoreController(gridFactory, scoreView, scoreModel);
    }
}