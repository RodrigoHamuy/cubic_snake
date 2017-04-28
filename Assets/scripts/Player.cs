using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public delegate void RotateAction();
  public static event RotateAction OnRotate;


	float speed = 0.5f;
	float limit = 0.55f;

	public Vector3 localPos;
	Transform parent;

	void Start () {
		parent = transform.parent.transform;
	}

	void Update () {
		if (Input.GetKeyDown("r")) {
			Application.LoadLevel(Application.loadedLevel);
		}

		Vector3 pos = transform.position;
		bool didRotate = false;
		localPos = transform.localPosition;

		for (int i=0; i<3; i++) {
			pos[i] = Mathf.Clamp(pos[i], -limit, limit);
		}

		if (localPos.x > limit) {
			parent.RotateAround(Vector3.zero, transform.up, -90f);
			didRotate = true;
		} else if (localPos.x < -limit) {
			parent.RotateAround(Vector3.zero, transform.up, 90f);
			didRotate = true;
		} else if (localPos.y > limit) {
			parent.RotateAround(Vector3.zero, transform.right, 90f);
			didRotate = true;
		} else if (localPos.y < -limit) {
			parent.RotateAround(Vector3.zero, transform.right, -90f);
			didRotate = true;
		}

		for (int i=0; i<3; i++) {
			localPos[i] = Mathf.Clamp(pos[i], -limit, limit);
		}
		transform.localPosition = localPos;

		transform.position = pos;
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		move *= Time.deltaTime;
		transform.localPosition += move;

		if ((didRotate) && (OnRotate != null) ) {
			OnRotate();
		}
	}
}
