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
    public CellControllerFactory(IGridFactory gridFactory, ICellModelFactory cellModelFactory)
    {
        this.gridFactory = gridFactory;
        this.cellModelFactory = cellModelFactory;
    }

    public List<ICellController> GetControllers()
    {
        if(controllersList.Count == 0)
        {
            var cellViews = gridFactory.GetGrid();

            foreach(var cellView in cellViews)
            {
                var model = cellModelFactory.GetModel();

                var controller = new CellController(model, cellView);
                controllersList.Add(controller);
            }
        }
        
        return new List<ICellController>(controllersList);
    }
}