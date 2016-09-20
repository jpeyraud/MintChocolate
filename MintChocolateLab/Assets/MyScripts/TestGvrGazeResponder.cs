using UnityEngine;
using System.Collections;

public class TestGvrGazeResponder : MonoBehaviour, IGvrGazeResponder
{
    public GvrGaze gazeSrc = null;
    public int force = 3;
    private int hits = 0;

    public int Hits
    {
        get
        {
            return hits;
        }
    }

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    #region IGvrGazeResponder implementation

    public void OnGazeEnter()
    {
        Debug.Log("Gaze entered.");
    }

    public void OnGazeExit()
    {
        Debug.Log("Gaze exited.");
    }

    public void OnGazeTrigger()
    {
        /* Get useful elements */

        // User
        if (gazeSrc == null)
        {
            Debug.Log("Warning: No GazeSrc was set for " + this + ". Hit direction will not be computed.");
            return;
        }

        // Target Transform
        Transform t = this.GetComponent<Transform>();
        if (t == null)
            return;

        // Target Rigidbody 
        Rigidbody rBody = this.GetComponent<Rigidbody>();
                
        // Useful vectors
        Vector3 gazePos = gazeSrc.GetComponent<Transform>().position;
        Vector3 thisPos = t.position;

        // Derive a direction
        Vector3 hitDir = thisPos - gazePos;
        hitDir.Normalize();

        // Add the force
        rBody.AddForce(hitDir * this.force, ForceMode.Impulse);
        hits++;

        if (this.GetComponent<Observed>() != null)
            this.GetComponent<Observed>().notifyAll();


    }

    #endregion
}
