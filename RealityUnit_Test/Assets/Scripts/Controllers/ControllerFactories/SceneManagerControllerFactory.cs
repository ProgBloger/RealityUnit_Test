public interface ISceneManagerControllerFactory
{
    ISceneManagerController GetSceneManagerController(ISceneManagerView view, ISceneManagerModel model);
}

public class SceneManagerControllerFactory : ISceneManagerControllerFactory
{
    public ISceneManagerController GetSceneManagerController(ISceneManagerView view, ISceneManagerModel model)
    {
        return new SceneManagerController(view, model);
    }
}