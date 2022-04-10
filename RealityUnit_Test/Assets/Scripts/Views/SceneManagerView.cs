using UnityEngine.SceneManagement;
using UnityEngine;

public interface ISceneManagerView
{
    int CurrentScene { set; }
}

public class SceneManagerView : MonoBehaviour
{
    protected string labelTextPattern = string.Empty;
    public int CurrentScene 
    {
        set
        {
            SceneManager.LoadScene(value);
        }
    }
}