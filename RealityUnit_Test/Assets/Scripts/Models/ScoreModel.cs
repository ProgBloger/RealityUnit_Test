using System;
using System.Linq;

public class TotalScoreUpdatedEventArgs : EventArgs
{
    
}

public interface IScoreModel
{
    event EventHandler<TotalScoreUpdatedEventArgs> OnTotalScoreUpdated;
    int TotalScore { get; set; }
    int ScoreThreshold { get; }
    int [] PointsArray { get; }
}

public class ScoreModel : IScoreModel
{
    private int [] _pointsArray = new int[] {1,2,3,4,5,6,7,8,9,10,11};
    private int _totalScore { get; set; }
    public event EventHandler<TotalScoreUpdatedEventArgs> OnTotalScoreUpdated  = (sender, e) => {};
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

    public int ScoreThreshold { get {return 21;} }
    public int [] PointsArray {get {return _pointsArray.Select(p => p).ToArray();}}
}