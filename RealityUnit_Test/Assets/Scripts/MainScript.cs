using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    void Awake()
    {
        ICellViewFactory viewFactory = new CellViewFactory();

        // GridFactory uses CellFactory to produce CellViews
        IGridFactory gridFactory = new GridFactory(viewFactory);
        IGridModelFactory gridModelFactory = new GridModelFactory();
        IGridModel gridModel = gridModelFactory.GetGridModel();
        
        // GridController invokes the GridFactory with GridModel defined parameters
        // GridController extendable to hold logic for the grid dimension update
        IGridController gridController = new GridController(gridFactory, gridModel);

        // CellControllerFactory includes GridFactory and creates CellControllers for
        // each created cell on the GridControllerStage
        ICellModelFactory modelFactory = new CellModelFactory();
        ICellControllerFactory controllerFactory = new CellControllerFactory(gridFactory, modelFactory);
        var controllers = controllerFactory.GetControllers();
        
        // ScoreController holds total score and win/loose logic
        
    }
}
