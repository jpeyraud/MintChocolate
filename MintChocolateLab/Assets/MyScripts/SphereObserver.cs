using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SphereObserver : MonoBehaviour, IObserver
{
    #region implemented abstract members of Observer

    public Observed target = null;

    void Start()
    {
        if (target != null)
        {
            target.observers.Add(this);
            Debug.Log(target.observers.Count);
        }
    }

    public void NotifiedBy(GameObject source)
    {
        Debug.Log(this + " was notified by " + source);

        TestGvrGazeResponder src = source.GetComponent<TestGvrGazeResponder>();
        if (src != null
            && transform != null
            && transform.FindChild("MessageText") != null
            && transform.FindChild("MessageText").GetComponent<Text>() != null)
        {
            Debug.Log("It works: " + src.Hits);
            transform.FindChild("MessageText").GetComponent<Text>().text = "" + src.Hits + " hit" + (src.Hits > 1 ? "s":"");
        }
    }

    #endregion
}
