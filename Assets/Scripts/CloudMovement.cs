/* TODO: 
 * while holding down space cloud animation charges down 
 * jump sound fx variations and small + long jump
 * burst particles for small and large jump
 * Maya hat model that always lands face up
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour 
{
	[SerializeField] private float _movementSpeed = 4;
	[SerializeField] private float _jumpVelocity = 5;
	[SerializeField] private float _fallMultiplyer = 1.5f;
	[SerializeField] private float _lowJumpMultiplyer = 1.0f;
	[SerializeField] private GameObject _burst;
	private Rigidbody _rb;
	void Start () 
	{
		_rb = GetComponent<Rigidbody>();
	}
	
	void Update () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        transform.Translate(
			moveHorizontal * _movementSpeed * Time.deltaTime,
			moveVertical * _movementSpeed * Time.deltaTime,
			0.0f);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			_rb.velocity = Vector2.up * _jumpVelocity;
			Instantiate(_burst, new Vector3(transform.position.x, 0.1f, transform.position.z), transform.rotation);
		}

		if (_rb.velocity.y < 0)
		{
			_rb.velocity += Vector3.up * Physics.gravity.y * (_fallMultiplyer - 1) * Time.deltaTime;
		}
		else if(_rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
		{
			_rb.velocity += Vector3.up * Physics.gravity.y * (_lowJumpMultiplyer - 1) * Time.deltaTime;
		}
	}
}
