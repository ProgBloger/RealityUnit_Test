public interface ISceneManagerController
{
    
}

public class SceneManagerController : ISceneManagerController
{
    private ISceneManagerView view;
    private ISceneManagerModel model;
    public SceneManagerController(ISceneManagerView view, ISceneManagerModel model)
    {
        this.view = view;
        this.model = model;

        model.OnSceneManagerUpdated += HandleSceneManagerUpdated;
    }

    private void HandleSceneManagerUpdated(object sender, SceneManagerModelChangedEventArgs args)
    {
        ChangeScene();
    }

    private void ChangeScene()
    {
        view.CurrentScene = model.CurrentScene;
    }
}