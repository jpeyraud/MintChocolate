using UnityEngine;
using System.Collections;

public interface IObserver
{
    void NotifiedBy(GameObject source);
}
