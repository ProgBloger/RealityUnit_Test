using System;

public interface IGridModel
{
    int Dimension { get; }
    int CellsTotal { get; }
    int ShiftDistance { get; }
    int DefaultY { get; }
}

public class GridModel : IGridModel
{
    public int Dimension { get {return 4;} }
    public int CellsTotal { get {return Dimension * Dimension;} }
    public int ShiftDistance { get {return 10;} }
    public int DefaultY { get {return 1;} }
}
