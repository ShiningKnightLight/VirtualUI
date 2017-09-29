﻿using UnityEngine;
using System.Collections;

public class VirtualUIFadableText : MonoBehaviour {

	public TextMesh TextObject;
	public float FadeInTimer = 1f;
	public float FadeOutTimer = 1f;
	public bool FadeInStarted = false;
	public bool FadeOutStarted = false;
	public bool KillOnFadeOut = false;

	// Use this for initialization
	void Start () {
		Color col = TextObject.color;
		col.a = 0f;
		TextObject.color = col;
	}
	
	// Update is called once per frame
	void Update () {
		if (FadeInStarted) {
			if (FadeInTimer > 0f) {
				FadeInTimer -= Time.deltaTime;
				Color col = TextObject.color;
				col.a = 1f - FadeInTimer;
				TextObject.color = col;
			}
		}
		if (FadeOutStarted) {
			if (FadeOutTimer > 0f) {
				FadeOutTimer -= Time.deltaTime;
				Color col = TextObject.color;
				col.a = FadeOutTimer;
				TextObject.color = col;
			}
			else if (KillOnFadeOut) {
				DestroyImmediate (this.gameObject);
			}
		}
	}

	public void StartFadeOut() {
		FadeOutStarted = true;
	}

	public void StartFadeIn() {
		FadeInStarted = true;
	}
}
