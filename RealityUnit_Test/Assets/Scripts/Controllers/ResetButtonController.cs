using UnityEngine;

public interface IResetButtonController
{
    
}

public class ResetButtonController : IResetButtonController
{
    IResetButtonView view;
    ISceneManagerModel model;

    public ResetButtonController(IResetButtonView view, ISceneManagerModel model)
    {
        this.view = view;
        this.model = model;
        
        view.OnClicked += HandlerButtonClicked;
    }

    private void HandlerButtonClicked(object sender, ResetButtonClickedEventArgs a)
    {
        Debug.Log("Controller HandlerButtonClicked");
        model.CurrentScene = (int)GameScene.Game;
    }
}