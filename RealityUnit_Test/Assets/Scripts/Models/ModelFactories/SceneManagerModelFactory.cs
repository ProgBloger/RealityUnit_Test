public interface ISceneManagerModelFactory
{
    ISceneManagerModel GetSceneManagerModel();
}

public class SceneManagerModelFactory : ISceneManagerModelFactory
{
    public ISceneManagerModel GetSceneManagerModel()
    {
        return new SceneManagerModel();
    }
}