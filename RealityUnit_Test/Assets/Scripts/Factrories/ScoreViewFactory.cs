public interface IScoreViewFactory
{
    IScoreView GetScoreView();
}

public class ScoreViewFactory : IScoreViewFactory
{
    private static IScoreView scoreView;

    public static void NotifyInstantiation(IScoreView scoreView)
    {
        ScoreViewFactory.scoreView = scoreView;
    }

    public IScoreView GetScoreView()
    {
        return scoreView;
    }
}