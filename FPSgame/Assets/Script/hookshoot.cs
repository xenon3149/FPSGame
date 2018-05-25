using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hookshoot : MonoBehaviour {
	public GameObject HookShootTip;
	public GameObject Player;
	private RaycastHit hit;
	public float Hspeed;
	public GameObject hook;
	bool judg_hook = true;
	public Image image;
	public float RayLong = 50f;
	public GameObject Reticle;
	public GameObject chain;
	public GameObject Shot;
	Vector3 force;
	Rigidbody rg;


	void Start () {
		rg = Player.GetComponent<Rigidbody>();
		Image image = GetComponent<Image>();
	}
	
    
	void Update () {
		hook_throw ();
		Debug.DrawRay (transform.position,transform.forward* RayLong,Color.red);

        //Rayがオブジェクトに当たったらレティクルの色を青に変える
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, RayLong)){
			Reticle.GetComponent<RawImage>().color =  new Color(0.0f, 0.0f, 1.0f);
		}

        ////Rayがオブジェクトに当たったらレティクルの色を赤に変える
        else
        {
			Reticle.GetComponent<RawImage>().color = new Color(1.0f, 0.0f, 0.0f);
		}
	}

    //フックショットのリキャスト
	void hook_throw() {
		if (Input.GetKeyDown (KeyCode.E) && judg_hook == true) {
			if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, RayLong)) {
				image.fillAmount = 0;
				StartCoroutine(hook_transport(hit));
				StartCoroutine (wait_hook());
			}
		}
	}

    //フックショットのリキャストUIの動き
	IEnumerator wait_hook() {
		judg_hook = false;
		for (int i = 0; 1 > image.fillAmount; image.fillAmount += Time.deltaTime / 2) {
			yield return null;
		}
		judg_hook = true;
	}

	IEnumerator hook_transport( RaycastHit a ){	
		 float dis = Vector3.Distance(hook.transform.position, a.point);
		GameObject _chain = Instantiate(chain);
		GameObject _shot = Instantiate( Shot);
		_shot.transform.position = hook.transform.position;
		Vector3 rad = hook.transform.forward;
		Shot.SetActive(false);

        //ヒットポイントにフックショットを飛ばす
		while( 1 < Vector3.Distance(a.point, _shot.transform.position)){
			chain.SetActive (true);
			chain.transform.LookAt (a.point);
			_shot.transform.LookAt(a.point);
			_shot.transform.position += _shot.transform.forward * Time.deltaTime * 50;
			float shotdis = Vector3.Distance(hook.transform.position, _shot.transform.position);
			_chain.transform.localScale = new Vector3(0.3f, 0.3f, shotdis);
			_chain.transform.position = hook.transform.position + rad * shotdis / 2;
			_chain.transform.LookAt(a.point);
			yield return null;
		}

        //ヒットポイントにプレイヤーを移動させる
		while (10 < Vector3.Distance(a.point, Player.transform.position)) {
			Vector3 t = a.point - Player.transform.position;
			t.Normalize();
			rg.AddForce(t * 200);
			float shotdis = Vector3.Distance(hook.transform.position, _shot.transform.position);
			_chain.transform.localScale = new Vector3(0.3f, 0.3f, shotdis);
			_chain.transform.position = hook.transform.position + rad * shotdis / 2;
			_chain.transform.LookAt(a.point);
			yield return null;
		}
		chain.SetActive (false);
		rg.velocity = Vector3.zero;
		Destroy( _shot );
		Destroy(_chain);
		Shot.SetActive(true);
	}
}
