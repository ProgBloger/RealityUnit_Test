using UnityEngine.SceneManagement;
using UnityEngine;

public interface ISceneManagerView
{
    int CurrentScene { set; }
}

public class SceneManagerView : MonoBehaviour, ISceneManagerView
{
    protected string labelTextPattern = string.Empty;
    public int CurrentScene 
    {
        set
        {
            
            Debug.Log($"CurrentScene loading {value}");
            SceneManager.LoadScene(value);
        }
    }
}