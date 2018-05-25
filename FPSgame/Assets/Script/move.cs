using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
	
	public float speed;
	public float dashspeed;
    
	void Update () {
        Move();
	}
    
	void Move( ){

        //プレイヤーの高さが4以上だと移動できない
        if (this.transform.position.y < 4.0f) {
          float angleDir = this.transform.eulerAngles.y * (Mathf.PI / 180.0f);
          Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
          Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));
          
          //Wで前、SHIFT＋Wで前ダッシュ
          if (Input.GetKey(KeyCode.W))  {
                    this.transform.position += dir1 * speed * Time.deltaTime;
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        this.transform.position += dir1 * dashspeed * Time.deltaTime;
                    }
                }

            //Aで左、SHIFT＋Aで左ダッシュ
            if (Input.GetKey(KeyCode.A))
                {
                    this.transform.position += dir2 * speed * Time.deltaTime;
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        this.transform.position += dir2 * dashspeed * Time.deltaTime;
                    }
                }

            //Dで右、SHIFT＋Dで右ダッシュ
            if (Input.GetKey(KeyCode.D))
                {
                    this.transform.position += -dir2 * speed * Time.deltaTime;
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        this.transform.position += -dir2 * dashspeed * Time.deltaTime;
                    }
                }

            //Sで後ろ、SHIFT＋Sで後ろダッシュ
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
