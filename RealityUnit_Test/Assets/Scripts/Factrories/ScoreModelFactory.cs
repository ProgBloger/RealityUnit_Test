public interface IScoreModelFactory
{
    ScoreModel GetScoreModel();
}

public class ScoreModelFactory : IScoreModelFactory
{
    public ScoreModel GetScoreModel()
    {
        return new ScoreModel();
    }
}