public interface IScoreViewFactory
{
    IScoreView GetCurrentScoreView();
    
    IScoreView GetTotalScoreView();
}

public class ScoreViewFactory : IScoreViewFactory
{
    private static IScoreView totalScore;
    private static IScoreView currentScore;

    public static void NotifyCurrentScoreViewInstantiation(IScoreView scoreView)
    {
        ScoreViewFactory.currentScore = scoreView;
    }

    public static void NotifyTotalScoreViewInstantiation(IScoreView scoreView)
    {
        ScoreViewFactory.totalScore = scoreView;
    }

    public IScoreView GetTotalScoreView()
    {
        return totalScore;
    }

    public IScoreView GetCurrentScoreView()
    {
        return currentScore;
    }
}