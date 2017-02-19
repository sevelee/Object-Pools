using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stuff : MonoBehaviour {

	public Rigidbody Body { get; private set; }

	MeshRenderer[] meshRenderers;

	public void SetMaterial(Material m)
	{
		for (int i = 0; i < meshRenderers.Length; ++i)
		{
			meshRenderers [i].material = m;
		}
	}

	void Awake()
	{
		Body = GetComponent<Rigidbody> ();
		meshRenderers = GetComponentsInChildren<MeshRenderer> ();
	}

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter (Collider enteredCollider)
	{
		if (enteredCollider.CompareTag("Kill Zone"))
		{
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
