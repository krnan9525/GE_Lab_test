using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GE_lab : MonoBehaviour {


	public string electronsPerShell;
	public string atom;
	public GameObject protonPrefab;
	public GameObject electronPrefab;
	public int [] per_orbit ;
	public float[] electron_distance ;
	public float[] electron_speed ;

	// Use this for initialization
	void Start () {

		electron_distance = new float[]{1.0f, 4.0f, 16.0f, 50.0f, 80.0f, 100.0f, 110.0f };
		electron_speed = new float[] { 10.0f, 20.0f, 25.0f, 30.0f, 40.0f, 40.0f, 40.0f };
		TextMesh textmash = GetComponentInChildren<TextMesh> ();
		textmash.text = atom + '\n' + electronsPerShell;
		string [] per_orbit_string = electronsPerShell.Split (',');
		per_orbit = new int[per_orbit_string.Length];
		for (int i = 0; i < per_orbit_string.Length; i++) {
			per_orbit[i] = int.Parse (per_orbit_string [i]);
		}

		GameObject pro_obj =  Instantiate (protonPrefab);
		pro_obj.transform.parent = transform;
		pro_obj.transform.position = transform.position;
		for (int i = 0; i < per_orbit.Length; i++) {
			for(int j = 0 ; j < per_orbit[i]; j++){
				float init_angle = 360.0f / per_orbit [i] * j;
				float distance = electron_distance [i];
				float speed = electron_speed [i];
				GameObject temp_obj = GameObject.Instantiate (electronPrefab);
				electron_action tmp_component = temp_obj.GetComponentInChildren<electron_action>();
				tmp_component.central_point = transform.position;
				tmp_component.current_angle = init_angle;
				tmp_component.radius = distance;
				tmp_component.angular_speed = speed;
				tmp_component.transform.rotation *= Quaternion.AngleAxis (init_angle, new Vector3 (0, 1, 0));
				tmp_component.transform.parent = transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
