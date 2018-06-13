using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BurstParticles : MonoBehaviour 
{
	private ParticleSystem ps;
	ParticleSystem.Particle[] _particles;
	int numParticlesAlive;
	private Vector3 particleVelocity;
	void Start()
	{
		ps = GetComponent<ParticleSystem>();
	}

	void Update () 
	{
		_particles = new ParticleSystem.Particle[ps.main.maxParticles];
		numParticlesAlive = ps.GetParticles(_particles);

		for (int i = 0; i < numParticlesAlive; i++) 
		{
			if (_particles[i].velocity.y > 0)
			{
				Vector3 newVel = new Vector3(_particles[i].velocity.x, 0, _particles[i].velocity.z);
				_particles[i].velocity = newVel.normalized * (_particles[i].velocity.magnitude);
			}
		}
		ps.SetParticles(_particles, numParticlesAlive);
	}
}