﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magazine : MonoBehaviour {
	public Text Magagine;
	public GameObject gun;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		int st = gun.GetComponent<Shoot>().gun_num;
		this.GetComponent<Text>().text = st + "/30";
	}
}
