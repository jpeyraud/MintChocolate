using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class CharacterBehavior : MonoBehaviour {

	/* -----------------------------------------------------------------------------------------*/
	/* Members */
	/* -----------------------------------------------------------------------------------------*/

	public string pullKey = "p";

	/* -----------------------------------------------------------------------------------------*/
	/* Behavior utils */
	/* -----------------------------------------------------------------------------------------*/

	// Use this for initialization
	void Start () 
	{
		Debug.Log (SetDefaultSkybox () ? "Successfully assigned default skybox" : "Failed to assign default skybox");
		Debug.Log (SelectControllerInstance () ? "Success" : "Failed");
	}

	// Update is called once per frame
	void Update () {
		// Check for pull
		if (Input.GetKey(pullKey)) {
			this.PullTargets ();
		}
	}

	/* -----------------------------------------------------------------------------------------*/
	/* Initialization utils */
	/* -----------------------------------------------------------------------------------------*/

	bool SetDefaultSkybox() {
		Skybox sky = this.GetComponent<Skybox> ();
		if (!sky) return false;
		
		RenderSettings.skybox = sky.material;
		return true;
	}

	bool SelectControllerInstance() 
	{
		// Find relevant objects
		GameObject vr_camera = transform.Find("[CameraRig]").gameObject;
		GameObject main_camera = transform.Find("MainCamera").gameObject;

		if (vr_camera == null || main_camera == null) {
			Debug.Log ("At least one camera was not found. You little dipshit fuck!");
			return false;
		}

		if (SteamVR.instance == null) 
		{
			Destroy (vr_camera);
			SteamVR.SafeDispose ();
		} 
		else 
		{
			Destroy (main_camera);

			// Get script component to change Cam variable
			RigidbodyFirstPersonController thiz = this.GetComponent<RigidbodyFirstPersonController> ();
			if (thiz) {
				thiz.cam = Object.FindObjectOfType<SteamVR_Camera> ().gameObject.GetComponent<Camera> ();
			}
		}
		return true;
	}

	/* Specific behavior --------------------------------------------------------------------*/
	void PullTargets()
	{
		// Get the target(s)
		Pullable[] targets = FindObjectsOfType<Pullable>() as Pullable[];

		// Apply pull force on everyone of them
		foreach (Pullable t in targets) {
			// Calculate new direction
			Debug.Log(this.transform.position);
			Vector3 nDir = this.transform.position - t.gameObject.transform.position;

			// Get target body
			Rigidbody rTarget = t.gameObject.GetComponent<Rigidbody> ();
			if (rTarget == null) continue;

			// Apply new velocity
			rTarget.velocity = nDir;			
		}
	}

}
