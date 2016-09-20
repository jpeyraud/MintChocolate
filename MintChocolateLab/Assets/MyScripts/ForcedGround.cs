using UnityEngine;
using System.Collections;

public class ForcedGround : MonoBehaviour
{
    public GameObject ground = null;
    public float yoffset = 0.0f;

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform != null
            && ground != null
            && ground.transform != null
            && transform.position.y < ground.transform.position.y)
        {
            transform.position.Set(
                transform.position.x,
                ground.transform.position.y + yoffset,
                transform.position.z
            );
        }
    }
}
