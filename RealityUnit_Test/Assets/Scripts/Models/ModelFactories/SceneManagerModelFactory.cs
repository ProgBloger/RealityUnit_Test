public interface ISceneManagerModelFactory
{
    ISceneManagerModel GetSceneManagerModel(GameScene scene);
}

public class SceneManagerModelFactory : ISceneManagerModelFactory
{
    public ISceneManagerModel GetSceneManagerModel(GameScene scene)
    {
        return new SceneManagerModel(scene);
    }
}