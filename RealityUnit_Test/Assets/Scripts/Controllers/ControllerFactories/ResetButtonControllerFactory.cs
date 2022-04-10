public interface IResetButtonControllerFactory
{
    IResetButtonController GetResetButtonController(IResetButtonView view, ISceneManagerModel sceneManagerModel);
}

public class ResetButtonControllerFactory : IResetButtonControllerFactory
{
    public IResetButtonController GetResetButtonController(IResetButtonView view, ISceneManagerModel sceneManagerModel)
    {
        return new ResetButtonController(view, sceneManagerModel);
    }
}