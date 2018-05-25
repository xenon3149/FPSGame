using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
	
	public float speed;
	public float dashspeed;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

	void Move( ){
        if (this.transform.position.y < 4.0f) {
          float angleDir = this.transform.eulerAngles.y * (Mathf.PI / 180.0f);
          Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
          Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));

          if (Input.GetKey(KeyCode.W))  {
                    this.transform.position += dir1 * speed * Time.deltaTime;
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        this.transform.position += dir1 * dashspeed * Time.deltaTime;
                    }
                }

                if (Input.GetKey(KeyCode.A))
                {
                    this.transform.position += dir2 * speed * Time.deltaTime;
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        this.transform.position += dir2 * dashspeed * Time.deltaTime;
                    }
                }

                if (Input.GetKey(KeyCode.D))
                {
                    this.transform.position += -dir2 * speed * Time.deltaTime;
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        this.transform.position += -dir2 * dashspeed * Time.deltaTime;
                    }
                }

                if (Input.GetKey(KeyCode.S))
                {
                    this.transform.position += -dir1 * speed * Time.deltaTime;
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        this.transform.position += -dir1 * dashspeed * Time.deltaTime;
                    }
                }
            }
        }
	}
