using UnityEngine;
using System.Collections;

public class AnimateLine : MonoBehaviour {
	private int texSize = 256;
	private int lines = 20;
	private Texture2D tex;

	void Start () {
		tex = new Texture2D(texSize, texSize, TextureFormat.ARGB32, false);
		renderer.material.mainTexture = tex;
		clearBackground();
		//drawLines();
	}

	void clearBackground() {
		for (int i=0; i<texSize; i++) {
			for (int j=0; j<texSize; j++) {
				tex.SetPixel (i, j, Color.clear);
			}
		}
	}

	void FixedUpdate () {
		AnimateLines();
	}

	private float time = 0f;
	void AnimateLines() {
		time += Time.deltaTime;
		if (time > 0.5) {
			drawLines();
			time = 0;
		}
	}

	private void drawLines() {
		for (int i = 0; i < lines; i++) {
			Color color = new Color(Random.Range(0.25f, 1.0f), Random.Range(0.25f, 1.0f), Random.Range(0.25f, 1.0f));
			this.drawLine(tex, Random.Range(0, texSize), Random.Range(0, texSize), Random.Range(0, texSize), Random.Range(0, texSize), color);
		}
		tex.Apply();
	}

	private void drawLine (Texture2D tex, int x0, int y0, int x1, int y1, Color col) {
		var dy = y1-y0;
		var dx = x1-x0;
		int stepy, stepx;

		if (dy < 0) {dy = -dy; stepy = -1;}
		else {stepy = 1;}
		if (dx < 0) {dx = -dx; stepx = -1;}
		else {stepx = 1;}
		dy <<= 1;
		dx <<= 1;
		
		tex.SetPixel(x0, y0, col);
		int fraction;
		if (dx > dy) {
			fraction = dy - (dx >> 1);
			while (x0 != x1) {
				if (fraction >= 0) {
					y0 += stepy;
					fraction -= dx;
				}
				x0 += stepx;
				fraction += dy;
				tex.SetPixel(x0, y0, col);
			}
		}
		else {
			fraction = dx - (dy >> 1);
			while (y0 != y1) {
				if (fraction >= 0) {
					x0 += stepx;
					fraction -= dy;
				}
				y0 += stepy;
				fraction += dx;
				tex.SetPixel(x0, y0, col);
			}
		}
	}
}
