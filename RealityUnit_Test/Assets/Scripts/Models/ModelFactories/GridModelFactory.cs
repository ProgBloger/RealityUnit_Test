using System.Collections.Generic;
using UnityEngine;

public interface IGridModelFactory
{
    IGridModel GetGridModel();
}

public class GridModelFactory : IGridModelFactory
{
    public IGridModel GetGridModel()
    {
        return new GridModel();
    }
}