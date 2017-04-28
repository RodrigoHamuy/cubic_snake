using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeWrapper : MonoBehaviour {
	public Transform player;
    public Transform camera;

    Transform from;
    Transform to;
    Vector3 originalForward;
    bool rotating = false;
    public float speed = 1.0f;

    void Start () {
        Player.OnRotate += Rotate;
        originalForward = transform.forward;
    }

	// Update is called once per frame
	void Update () {
        if (Vector3.Dot(camera.forward, player.forward) < 1) {
            if (!rotating) {
                from = transform;
                to = player;
            }
            //float angle = 90f;
            //transform.RotateAround(Vector3.zero, transform.up, 90);
            //transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, speed*Time.deltaTime);

        }
	}

    void Rotate() {
			// transform.forward = player.forward;
      // transform.RotateAround(Vector3.zero, transform.right, -90f);
    }
}
