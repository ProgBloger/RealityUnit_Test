using System.Collections.Generic;
using UnityEngine;

public interface IGridFactory
{
    List<ICellView> InitializeGrid(List<Vector3> positions);
    List<ICellView> GetGrid();
}

public class GridFactory : IGridFactory
{
    private List<ICellView> cellViews = new List<ICellView>();
    private ICellViewFactory cellViewFactory;
    public GridFactory(ICellViewFactory cellViewFactory)
    {
        this.cellViewFactory = cellViewFactory;
    }

    public List<ICellView> InitializeGrid(List<Vector3> positions)
    {
        if(cellViews.Count == 0)
        {
            foreach(var pos in positions)
            {
                var cellView = cellViewFactory.GetView(pos);
                cellViews.Add(cellView);
            }
        }
        
        return cellViews;
    }

    public List<ICellView> GetGrid()
    {
        return new List<ICellView> (cellViews);
    }
}