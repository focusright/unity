using UnityEngine;
using System.Collections;

public class Zap : MonoBehaviour {
	private int texSizeX = 300;
	private int texSizeY = 50;
	private int lines = 2;
	private Texture2D tex;
	
	void Start () {
		tex = new Texture2D(texSizeX, texSizeY, TextureFormat.ARGB32, false);
		renderer.material.mainTexture = tex;
		clearBackground();
		//drawLines(Color.magenta);
	}
	
	void clearBackground() {
		for (int i=0; i<texSizeX; i++) {
			for (int j=0; j<texSizeY; j++) {
				tex.SetPixel (i, j, Color.clear);
			}
		}
	}
	
	void FixedUpdate () {
		AnimateLine();
	}

	private Color newColor() {
		return new Color(Random.Range(0.25f, 1.0f), Random.Range(0.25f, 1.0f), Random.Range(0.25f, 1.0f));
	}

	private float time = 0f;
	void AnimateLine() {
		time += Time.deltaTime;
		if (time > 0.07) {
			clearBackground();
			drawLines(Color.cyan);
			drawLines(Color.magenta);
			drawLines(Color.white);
			time = 0;
		}
	}
	
	private void drawLines(Color color) {
		int segments = 10;
		int x0=0, y0=0, x1=0, y1=0;
		for (int i = 1; i <= segments; i++) {
			x0 = x1;
			y0 = y1;
			x1 = (int)(((float)i / segments) * texSizeX);
			y1 = Random.Range(0, texSizeY);
			this.drawLine(tex, x0, y0, x1, y1, color);
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
