using System.Collections.Generic;

public interface ICellControllerFactory
{
    List<ICellController> GetControllers();
}

public class CellControllerFactory : ICellControllerFactory
{
    private List<ICellController> controllersList = new List<ICellController>();
    private IGridFactory gridFactory;
    private ICellModelFactory cellModelFactory;
    IGridModel gridModel;
    public CellControllerFactory(IGridFactory gridFactory)
    {
        this.gridFactory = gridFactory;
        this.gridModel = gridFactory.GetGridModel();
    }

    public List<ICellController> GetControllers()
    {
        if(controllersList.Count == 0)
        {
            var cellViews = gridFactory.GetCellViews();
            var cellModels = gridFactory.GetCellModels();

            for(int i = 0; i < gridModel.CellsTotal; i++)
            {
                var controller = new CellController(cellModels[i], cellViews[i]);
                controllersList.Add(controller);
            }
        }
        
        return new List<ICellController>(controllersList);
    }
}