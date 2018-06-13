using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour 
{
	private Rigidbody _rb;
	private float _floatStrength = 1f;
	void Start () 
	{
		_rb = GetComponent<Rigidbody>();
	}
	
	void Update () 
	{
		_rb.AddForce(Vector3.up * _floatStrength);
	}
}
