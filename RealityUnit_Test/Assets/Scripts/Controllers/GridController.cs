using UnityEngine;
using System.Collections.Generic;

public interface IGridController
{

}

public class GridController : IGridController
{
    private IGridModel gridModel;
    private IGridFactory gridFactory;
    public GridController(IGridFactory gridFactory)
    {
        this.gridFactory = gridFactory;
        this.gridModel = gridFactory.GetGridModel();

        InitializeGrid();
    }
    
    Vector3 GetNextPosition(int i)
    {
        // Get grid coord by devision
        int x = 0, y = 0;
        x = i / gridModel.Dimension;
        y = i % gridModel.Dimension;

        // Get global position by multiplying 
        // grid position by shift distance
        x *= gridModel.ShiftDistance;
        y *= gridModel.ShiftDistance;

        return new Vector3(x, gridModel.DefaultY, y);
    }

    public void InitializeGrid()
    {
        var positionList = new List<Vector3>();
        for(int i = 0; i < gridModel.CellsTotal; i++)
        {
            var position = GetNextPosition(i);
            positionList.Add(position);
        }

        gridFactory.InitializeGridFactory(positionList);
    }
}