using System;

public class CellStateChangedEventArgs : EventArgs
{
    
}

public interface ICellModel
{
    event EventHandler<CellStateChangedEventArgs> OnCellStateChanged;
    bool Highlighted { get; set; }
    int Value { get; set; }
}

public class CellModel : ICellModel
{
    private bool _highlighted { get; set; }
    private int _value { get; set; }

    public event EventHandler<CellStateChangedEventArgs> OnCellStateChanged  = (sender, e) => {};

    public bool Highlighted 
    { 
        get {return _highlighted;} 
        set 
        {
            if (_highlighted != value)
            {
				_highlighted = value;
 
				var eventArgs = new CellStateChangedEventArgs();

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
 
				var eventArgs = new CellStateChangedEventArgs();
                
				OnCellStateChanged(this, eventArgs);
			}
        } 
    }
}
