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
        targetRotation = Quaternion.LookRotation(player.transform.forward, player.transform.up);
        planeNormal = -player.transform.forward;
        isMoving = true;
    }

	void Update () {
        if (isMoving) {
            if (Mathf.Abs(Vector3.Dot(parent.transform.forward, planeNormal)) < 0.999999f) {

                float strength = 5.5f;
                float str = Mathf.Min(strength * Time.deltaTime, 1);
                parent.transform.rotation = Quaternion.Lerp(parent.transform.rotation, targetRotation, str);

            }else {
                print("Rotated");
                parent.transform.rotation = targetRotation;
                isMoving = false;
            }
        }
	}
}
