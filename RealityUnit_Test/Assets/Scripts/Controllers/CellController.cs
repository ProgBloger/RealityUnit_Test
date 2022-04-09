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
 
		model.OnCellValueChanged += HandleOnCellValueChanged;
 
		SyncDisplayNumber();
 
		SyncState();
    }
    
    private void HandleClicked(object sender, CellClickEventArgs OnClicked)
    {
        ChangeCellModelState();
    }
    
    private void HandleOnCellStateChanged(object sender, CellStateChangedEventArgs OnClicked)
    {
        SyncState();
    }
    
    private void HandleOnCellValueChanged(object sender, CellValueChangedEventArgs OnClicked)
    {
        SyncDisplayNumber();
    }

    private void ChangeCellModelState()
    {
        model.IsActive = !model.IsActive;
    }

    private void SyncState()
    {
        cellView.IsActive = model.IsActive;
    }

    private void SyncDisplayNumber()
    {
        cellView.Value = model.Value;
        Debug.Log($"cellView.Value changed {model.Value}");
    }
}
