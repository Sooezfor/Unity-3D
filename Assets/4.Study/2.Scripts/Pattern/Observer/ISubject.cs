using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    List<IObserver> Observers
    {
        get;
        set;
    }    

    public void AddObserver(IObserver observer);

    public void RemoveObserver(IObserver observer);
    public void NotifyObservers();
    
}
