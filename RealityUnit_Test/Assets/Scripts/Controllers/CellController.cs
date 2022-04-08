using UnityEngine;

public interface ICellController
{
    
}

public class CellController : ICellController
{
    private readonly ICellModel model;
    private readonly ICellView cellView;

    public CellController(ICellModel model, ICellView view)
    {
        this.model = model;
        this.cellView = view;
 
		view.OnClicked += HandleClicked;
 
		model.OnCellStateChanged += HandleOnCellStateChanged;
 
		SyncDisplayNumber();
    }
    
    private void HandleClicked(object sender, CellClickEventArgs OnClicked)
    {
        
    }
    
    private void HandleOnCellStateChanged(object sender, CellStateChangedEventArgs OnClicked)
    {
        SyncDisplayNumber();
    }

    private void SyncDisplayNumber()
    {
        cellView.Value = model.Value;
    }
}
