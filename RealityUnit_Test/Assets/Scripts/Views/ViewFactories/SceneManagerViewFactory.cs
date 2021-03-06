using UnityEngine;

public interface ISceneManagerViewFactory
{
    ISceneManagerView GetSceneManagerView();
}

public class SceneManagerViewFactory : ISceneManagerViewFactory
{
    public ISceneManagerView GetSceneManagerView()
    {
        var prefab = Resources.Load<GameObject>("SceneManager");
        var instance = UnityEngine.Object.Instantiate(prefab);
        var sceneManagerView = instance.GetComponent<ISceneManagerView>();
        Debug.Log($"Tnstantiated sceneManager i null {sceneManagerView == null}");
        return sceneManagerView;
    }
}