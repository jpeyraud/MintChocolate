using UnityEngine;
using System.Collections;

public class MCCollisionManager: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Split() {
		for (int i = 0; i < 2; ++i) {
			try {
				GameObject nSphere = (GameObject) Instantiate (this, transform.position, transform.rotation);
			} catch (System.InvalidCastException) {
				continue;
			}
//			nSphere.transform.localScale = this.transform.lossyScale/2.0f;
		}
		Destroy (this);
	}

	void OnCollisionEnter(Collision col) 
	{
		if (col.gameObject.tag == "Player") {
			Split ();
		}
	}
}
