//PlayerController.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject Player;
	public GameObject Camera;
	public float speed;
	public float dashspeed;
	private Transform PlayerTransform;
	private Transform CameraTransform;
	private float ii;
	public GameObject ray;
    
	void Start () {

		PlayerTransform = transform.parent;
		CameraTransform = GetComponent<Transform>();

        //マウスカーソルを消す
		Cursor.visible = false;

        //マウスカーソルをロックする
		Cursor.lockState = CursorLockMode.Locked;
	}
    
    //マウスで視点移動
	void Update () {

		float X_Rotation = Input.GetAxis ("Mouse X");
		float Y_Rotation = Input.GetAxis ("Mouse Y");
		PlayerTransform.transform.Rotate (0, X_Rotation, 0);

		ii = Camera.transform.localEulerAngles.x;
		if (ii > 310 && ii < 360 || ii > 0 && 79 > ii) {
			CameraTransform.transform.Rotate (-Y_Rotation, 0, 0);
			float kk = Y_Rotation;
		} else {
			if (ii > 300) {
				if (Input.GetAxis ("Mouse Y") < 0) {
					CameraTransform.transform.Rotate (-Y_Rotation, 0, 0);
				}
			} else {
				if (Input.GetAxis ("Mouse Y") > 0) {
					CameraTransform.transform.Rotate (-Y_Rotation, 0, 0);
				}
			}
		}
	}
}