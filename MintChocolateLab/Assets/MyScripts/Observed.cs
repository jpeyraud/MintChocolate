using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Observed : MonoBehaviour
{
    public List<IObserver> observers = new List<IObserver>();

    public void notifyAll()
    {
        foreach (IObserver o in observers)
        {
            if (o != null)
            {
                o.NotifiedBy(this.gameObject);
            }
        }
    }
}
