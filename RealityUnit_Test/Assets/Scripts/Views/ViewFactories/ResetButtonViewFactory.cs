using UnityEngine;
using System;

public interface IResetButtonViewFactory
{
    IResetButtonView GetResetButtonView();
}

public class ResetButtonViewFactory : IResetButtonViewFactory
{
    private static IResetButtonView button;

    public static void NotifyResetButtonCreated(IResetButtonView button)
    {
        ResetButtonViewFactory.button = button;
    }

    public IResetButtonView GetResetButtonView()
    {
        return button;
    }

    public void Listener()
    {
        
    }
}