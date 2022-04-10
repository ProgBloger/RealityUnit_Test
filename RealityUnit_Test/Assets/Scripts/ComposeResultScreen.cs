public class ComposeResultScreen
{
    public void Compose(GameScene scene)
    {
        ISceneManagerModelFactory sceneManagerModelFactory = new SceneManagerModelFactory();
        ISceneManagerModel sceneManagerModel = sceneManagerModelFactory.GetSceneManagerModel(scene);

        ISceneManagerViewFactory sceneManagerViewFactory = new SceneManagerViewFactory();
        ISceneManagerView sceneManagerView = sceneManagerViewFactory.GetSceneManagerView();

        ISceneManagerControllerFactory sceneManagerControllerFactory = new SceneManagerControllerFactory();
        ISceneManagerController sceneManagerController = sceneManagerControllerFactory.GetSceneManagerController(sceneManagerView, sceneManagerModel);

        IResetButtonViewFactory resetButtonViewFactory = new ResetButtonViewFactory();
        IResetButtonView view = resetButtonViewFactory.GetResetButtonView();

        IResetButtonControllerFactory resetButtonControllerFactory = new ResetButtonControllerFactory();
        IResetButtonController resetButtonController = resetButtonControllerFactory.GetResetButtonController(view, sceneManagerModel);

    }
}