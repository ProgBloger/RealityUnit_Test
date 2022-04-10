using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    private const int screenWidth = 1080;
    private const int screenHeight = 1920;
    void Start()
    {
        Screen.SetResolution(screenWidth, screenHeight, true);
        
        // TODO: Use DI for registration and resolving hierarchy

        ICellViewFactory viewFactory = new CellViewFactory();
        ICellModelFactory modelFactory = new CellModelFactory();
        IGridModelFactory gridModelFactory = new GridModelFactory();

        // GridFactory uses CellFactory to produce CellViews
        IGridFactory gridFactory = new GridFactory(viewFactory, modelFactory, gridModelFactory);
        
        // GridController invokes the GridFactory with GridModel defined parameters
        // GridController extendable to hold logic for the grid dimension update
        IGridController gridController = new GridController(gridFactory);

        // CellControllerFactory includes GridFactory and creates CellControllers for
        // each created cell on the GridControllerStage
        ICellControllerFactory controllerFactory = new CellControllerFactory(gridFactory);
        var controllers = controllerFactory.GetControllers();
        
        IScoreModelFactory scoreModelFactory = new ScoreModelFactory();
        IScoreModel scoreModel = scoreModelFactory.GetScoreModel();

        ISceneManagerModelFactory sceneManagerModelFactory = new SceneManagerModelFactory();
        ISceneManagerModel sceneManagerModel = sceneManagerModelFactory.GetSceneManagerModel(GameScene.Game);

        IScoreViewFactory scoreViewFactory = new ScoreViewFactory();
        // ScoreController holds total score and win/loose logic
        IScoreControllerFactory scoreControllerFactory = new ScoreControllerFactory(gridFactory, scoreViewFactory);
        IScoreController scoreController = scoreControllerFactory.GetScoreController(scoreModel, sceneManagerModel);

        ISceneManagerViewFactory sceneManagerViewFactory = new SceneManagerViewFactory();
        ISceneManagerView sceneManagerView = sceneManagerViewFactory.GetSceneManagerView();

        ISceneManagerControllerFactory sceneManagerControllerFactory = new SceneManagerControllerFactory();
        ISceneManagerController sceneManagerController = sceneManagerControllerFactory.GetSceneManagerController(sceneManagerView, sceneManagerModel);
    }
}
