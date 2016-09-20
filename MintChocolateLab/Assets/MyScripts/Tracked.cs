using UnityEngine;
using System.Collections;

public class Tracked : MonoBehaviour
{
    public bool active = true;
	
    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.position);	
    }
}
