using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {
	public int gun_num;
	private const int GUN_MAX_NUM = 30;
	public GameObject bullet;
	public Transform muzzle;
	public float Bspeed = 1000;
	bool nofire = false;
	public AudioClip ReloadSE;
	private AudioSource audioSource;
	public GameObject Player;
	private RaycastHit hit;
	public GameObject RT;
	public Image RT2;
    
	void Start () {
		gun_num = GUN_MAX_NUM;
	}

	void Update () {
		fire ();
		reload();
	}

	void fire() {

        //残弾数が0だったら読みこまない
		if ( gun_num == 0 ) {
			return;
		}

        //左クリックしたら弾が飛ぶ
		if (Input.GetMouseButtonDown (0) && nofire == false ) {
			GameObject bullets = GameObject.Instantiate (bullet)as GameObject;
			Vector3 force;
			if (Physics.Raycast (Camera.main.transform.position,Camera.main.transform.forward,out hit )) {
				muzzle.transform.LookAt (hit.point);
				force = muzzle.transform.forward * Bspeed;
				bullets.GetComponent<Rigidbody> ().AddForce (force);
				bullets.transform.position = muzzle.position;
				gun_num--;
			}

            //残弾数が0になったらリロード
			if ( gun_num == 0 ) {
				StartCoroutine( "no_magazine_reload" );
			}
		}
	}

    //リロード
	void reload() {
		if(Input.GetKeyDown(KeyCode.R)){
			nofire = true;
			StartCoroutine( "no_magazine_reload" );
		}
	}

    //リロードUIや音
	IEnumerator no_magazine_reload() {
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip = ReloadSE;
		audioSource.Play ();
		RT.SetActive (true);
		for (int i = 0; 1 > RT2.fillAmount; RT2.fillAmount += Time.deltaTime / 2) {
			yield return null;
		}
		RT2.fillAmount = 0;
		gun_num = GUN_MAX_NUM;
		RT.SetActive (false);
		nofire = false;
	}
}
