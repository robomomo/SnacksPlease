using UnityEngine;
using System.Collections;

public class RemoveParticle : MonoBehaviour {

	private ParticleSystem particleSystemComponent;

	void Awake () {
		particleSystemComponent = GetComponent<ParticleSystem> ();
	}

	void Update () {
		if (!particleSystemComponent.IsAlive())
			Destroy (gameObject);
	}
}
