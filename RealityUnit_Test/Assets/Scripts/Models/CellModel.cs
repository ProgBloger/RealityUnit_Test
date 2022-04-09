using System;

public class CellStateChangedEventArgs : EventArgs
{
    public bool IsActive { get; set; }
    public int Value { get; set; }
}
public class CellValueChangedEventArgs : EventArgs
{
    
}

public interface ICellModel
{
    event EventHandler<CellStateChangedEventArgs> OnCellStateChanged;
    event EventHandler<CellValueChangedEventArgs> OnCellValueChanged;
    bool IsActive { get; set; }
    int Value { get; set; }
}

public class CellModel : ICellModel
{
    private bool _isActive { get; set; }
    private int _value { get; set; }

    public event EventHandler<CellStateChangedEventArgs> OnCellStateChanged  = (sender, e) => {};
    public event EventHandler<CellValueChangedEventArgs> OnCellValueChanged  = (sender, e) => {};

    public bool IsActive 
    { 
        get {return _isActive;} 
        set 
        {
            if (_isActive != value)
            {
				_isActive = value;
 
				var eventArgs = new CellStateChangedEventArgs 
                {
                    IsActive = value,
                    Value = this.Value,
                };
                
				OnCellStateChanged(this, eventArgs);
			}
        } 
    }

    public int Value 
    { 
        get {return _value;} 
        set 
        {
            if (_value != value)
            {
				_value = value;
 
				var eventArgs = new CellValueChangedEventArgs();
                
				OnCellValueChanged(this, eventArgs);
			}
        } 
    }
}
