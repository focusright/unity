#pragma strict
//http://wiki.unity3d.com/index.php?title=TextureDrawCircle

var texSize = 256;
var circles = 10;

function Start () {
	var tex = new Texture2D(texSize, texSize);
	for (var i = 0; i < circles; i++) {
		TextureDraw.Circle(tex, Random.Range(0, texSize), Random.Range(0, texSize), Random.Range(1, texSize/4),
			Color(Random.Range(0.25, 1.0), Random.Range(0.25, 1.0), Random.Range(0.25, 1.0)) );
	}
	tex.Apply();
	renderer.material.mainTexture = tex;
}