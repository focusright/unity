#pragma strict
//http://wiki.unity3d.com/index.php?title=TextureDrawLine

var texSize = 256;
var lines = 20;

function Start () {
	var tex = new Texture2D(texSize, texSize);
	for (var i = 0; i < lines; i++) {
		TextureDraw.Line(tex, Random.Range(0, texSize), Random.Range(0, texSize), Random.Range(0, texSize), Random.Range(0, texSize),
			Color(Random.Range(0.25, 1.0), Random.Range(0.25, 1.0), Random.Range(0.25, 1.0)) );
	}
	tex.Apply();
	renderer.material.mainTexture = tex;
}