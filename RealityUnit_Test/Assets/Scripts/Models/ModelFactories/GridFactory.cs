using System.Collections.Generic;
using UnityEngine;

public interface IGridFactory
{
    public void InitializeGridFactory(List<Vector3> positions);
    List<ICellView> GetCellViews();
    List<ICellModel> GetCellModels();
    IGridModel GetGridModel();
}

public class GridFactory : IGridFactory
{
    private List<ICellView> cellViews = new List<ICellView>();
    private List<ICellModel> cellModels = new List<ICellModel>();
    private IGridModel gridModel;
    private ICellViewFactory cellViewFactory;
    private ICellModelFactory cellModelFactory;
    private IGridModelFactory gridModelFactory;
    public GridFactory(ICellViewFactory cellViewFactory, ICellModelFactory cellModelFactory, IGridModelFactory gridModelFactory)
    {
        this.cellViewFactory = cellViewFactory;
        this.cellModelFactory = cellModelFactory;
        this.gridModelFactory = gridModelFactory;
        
        GetGridModel();
    }

    public void InitializeGridFactory(List<Vector3> positions)
    {

        if(cellViews.Count == 0)
        {
            foreach(var pos in positions)
            {
                var cellView = cellViewFactory.GetView(pos);
                cellViews.Add(cellView);
            }
        }

        if(cellModels.Count == 0)
        {
            for(int i = 0; i < this.gridModel.CellsTotal; i++)
            {
                var cellModel = cellModelFactory.GetModel();
                cellModels.Add(cellModel);
            }
        }
    }

    public List<ICellView> GetCellViews()
    {
        return new List<ICellView> (cellViews);
    }

    public List<ICellModel> GetCellModels()
    {
        return new List<ICellModel> (cellModels);
    }

    public IGridModel GetGridModel()
    {
        if(this.gridModel == null)
        {
            gridModel = gridModelFactory.GetGridModel();
        }

        return this.gridModel;
    }
}