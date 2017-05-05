using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electron_action : MonoBehaviour {

	// Use this for initialization

	public Vector3 central_point;
	[Range (1.0f, 300.0f)]
	public float angular_speed;
	public float radius = 0.0f;

	[HideInInspector]
	public float current_angle = 0.0f;

	//[HideInInspector]
	public Vector3 wander_vector;

	public float wander_angle = 8.0f;

	public float wander_radius = 0.8f;

	void Start () {
		wander_vector = new Vector3 (1,0,0);
	}

	public void onDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawLine (transform.position, transform.position + wander_vector * 10.0f);
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (Mathf.Sin (Mathf.Deg2Rad * current_angle), 0, Mathf.Cos (Mathf.Deg2Rad * current_angle)) * radius + central_point;
		transform.rotation *= Quaternion.AngleAxis (Time.deltaTime * angular_speed, new Vector3 (0, 1, 0));
		wander_vector = Quaternion.AngleAxis(Random.Range(-wander_angle,wander_angle), new Vector3(0,1,0)) * wander_vector;
		wander_vector = Quaternion.AngleAxis(Random.Range(-wander_angle,wander_angle), new Vector3(1,0,0)) * wander_vector;
		wander_vector = Quaternion.AngleAxis(Random.Range(-wander_angle,wander_angle), new Vector3(0,0,1)) * wander_vector;
		transform.position += transform.TransformVector (wander_vector);

		current_angle += Time.deltaTime * angular_speed;

	}

	/*public override Vector3 Calculate(){
		Vector3 past_pos = new Vector3 (Mathf.Sin (Mathf.Deg2Rad * current_angle), 0, Mathf.Cos (Mathf.Deg2Rad * current_angle)) * radius + central_point;
		current_angle += Time.deltaTime * angular_speed;
		Vector3 t_force = (new Vector3 (Mathf.Sin (Mathf.Deg2Rad * current_angle), 0, Mathf.Cos (Mathf.Deg2Rad * current_angle)) * radius + central_point) - past_pos;
		return t_force;
	}*/
}
