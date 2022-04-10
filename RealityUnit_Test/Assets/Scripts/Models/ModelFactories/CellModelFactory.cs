using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICellModelFactory
{
    ICellModel GetModel();
}

public class CellModelFactory : ICellModelFactory
{
    public ICellModel GetModel()
    {
        return new CellModel();
    }
}


