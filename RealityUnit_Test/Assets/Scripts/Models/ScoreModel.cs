using System;
using System.Linq;

public class TotalScoreUpdatedEventArgs : EventArgs
{
    
}
public class CurrentScoreUpdatedEventArgs : EventArgs
{
    
}

public interface IScoreModel
{
    event EventHandler<TotalScoreUpdatedEventArgs> OnTotalScoreUpdated;
    event EventHandler<CurrentScoreUpdatedEventArgs> OnCurrentScoreUpdated;
    int TotalScore { get; set; }
    int CurrentScore { get; set; }
    int ScoreThreshold { get; }
    int [] PointsArray { get; }
}

public class ScoreModel : IScoreModel
{
    private int [] _pointsArray = new int[] {1,2,3,4,5,6,7,8,9,10,11};
    private int _totalScore;
    private int _currentScore;
    public event EventHandler<TotalScoreUpdatedEventArgs> OnTotalScoreUpdated  = (sender, e) => {};
    public event EventHandler<CurrentScoreUpdatedEventArgs> OnCurrentScoreUpdated  = (sender, e) => {};
    public int TotalScore 
    { 
        get {return _totalScore;} 
        set 
        {
            if (_totalScore != value)
            {
				_totalScore = value;
 
				var eventArgs = new TotalScoreUpdatedEventArgs();

				OnTotalScoreUpdated(this, eventArgs);
			}
        }
    }

    public int CurrentScore 
    { 
        get {return _currentScore;} 
        set 
        {
            if (_currentScore != value)
            {
				_currentScore = value;
 
				var eventArgs = new CurrentScoreUpdatedEventArgs();

				OnCurrentScoreUpdated(this, eventArgs);
			}
        }
    }

    public int ScoreThreshold { get {return 21;} }
    public int [] PointsArray {get {return _pointsArray.Select(p => p).ToArray();}}
}