using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour {

	//何かに当たったら弾を消す
	private void OnTriggerEnter(Collider other ) {
		Destroy (this.gameObject);
	}
}
