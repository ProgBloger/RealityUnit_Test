using System;

public class SceneManagerModelChangedEventArgs : EventArgs
{
    
}


public interface ISceneManagerModel
{
    int CurrentScene { get; set; }
    event EventHandler<SceneManagerModelChangedEventArgs> OnSceneManagerUpdated;
}

public class SceneManagerModel : ISceneManagerModel
{
    private int _currentScene;
    public event EventHandler<SceneManagerModelChangedEventArgs> OnSceneManagerUpdated  = (sender, e) => {};
    public int CurrentScene 
    { 
        get {return _currentScene;} 
        set 
        {
            if (_currentScene != value)
            {
				_currentScene = value;
 
				var eventArgs = new SceneManagerModelChangedEventArgs();

				OnSceneManagerUpdated(this, eventArgs);
			}
        }
    }
}