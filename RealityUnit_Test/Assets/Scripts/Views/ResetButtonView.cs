    using System;
using UnityEngine;
using UnityEngine.UI;

public class ResetButtonClickedEventArgs : EventArgs
{
    
}

public interface IResetButtonView
{
    event EventHandler<ResetButtonClickedEventArgs> OnClicked;
}

public class ResetButtonView : MonoBehaviour, IResetButtonView
{
    public event EventHandler<ResetButtonClickedEventArgs> OnClicked = (sender, e) => {};

    void Awake()
    {
        var btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(HandlerButtonClicked);

        ResetButtonViewFactory.NotifyResetButtonCreated(this);
    }

    public void HandlerButtonClicked()
    {
        OnClicked(this, new ResetButtonClickedEventArgs());
    }
}
