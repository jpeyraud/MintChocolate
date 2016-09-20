using UnityEngine;
using System.Collections;

public class OpaqueOnGaze : MonoBehaviour, IGvrGazeResponder
{
    public float opacity = 1.0f;

    void Start()
    {
        SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt)
    {
        Color c = GetComponent<Renderer>().material.color;
        c.a = gazedAt ? opacity : 0.0f;
        GetComponent<Renderer>().material.color = c;
    }

    #region IGvrGazeResponder implementation

    void IGvrGazeResponder.OnGazeEnter()
    {
        Debug.Log("Gaze entered " + this);
        SetGazedAt(true);
    }

    void IGvrGazeResponder.OnGazeExit()
    {
        Debug.Log("Gaze exited " + this);
        SetGazedAt(false);
    }

    void IGvrGazeResponder.OnGazeTrigger()
    {
        Debug.Log("Not implemented yet.");
        // Get camera reticle and add a message to it ? 
        // Event system ? 
    }

    #endregion
}
