using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public Player player;
    Vector3 planeNormal = Vector3.back;
    Quaternion targetRotation;
    bool isMoving = false;
    Transform parent;

	void Start () {
        Player.OnRotate += Rotate; // Listen to player changes
        parent = transform.parent;
	}

	void Rotate(){
		print("Rotate");
        targetRotation = Quaternion.LookRotation(player.transform.forward, player.transform.up);
        planeNormal = -player.transform.forward;
        isMoving = true;
    }

	void Update () {
        if (isMoving) {
            if (Vector3.Dot(parent.transform.forward, planeNormal) != 0) {

                float strength = 5.5f;
                float str = Mathf.Min(strength * Time.deltaTime, 1);
                parent.transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);

            }
        }
	}
}
