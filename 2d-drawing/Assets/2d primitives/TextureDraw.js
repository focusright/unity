static function Line (tex : Texture2D, x0 : int, y0 : int, x1 : int, y1 : int, col : Color) {
	var dy = y1-y0;
	var dx = x1-x0;
 
	if (dy < 0) {dy = -dy; var stepy = -1;}
	else {stepy = 1;}
	if (dx < 0) {dx = -dx; var stepx = -1;}
	else {stepx = 1;}
	dy <<= 1;
	dx <<= 1;
 
	tex.SetPixel(x0, y0, col);
	if (dx > dy) {
		var fraction = dy - (dx >> 1);
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


static function Circle (tex : Texture2D, cx : int, cy : int, r : int, col : Color) {
	var y = r;
	var d = 1/4 - r;
	var end = Mathf.Ceil(r/Mathf.Sqrt(2));
 
	for (x = 0; x <= end; x++) {
		tex.SetPixel(cx+x, cy+y, col);
		tex.SetPixel(cx+x, cy-y, col);
		tex.SetPixel(cx-x, cy+y, col);
		tex.SetPixel(cx-x, cy-y, col);
		tex.SetPixel(cx+y, cy+x, col);
		tex.SetPixel(cx-y, cy+x, col);
		tex.SetPixel(cx+y, cy-x, col);
		tex.SetPixel(cx-y, cy-x, col);
 
		d += 2*x+1;
		if (d > 0) {
			d += 2 - 2*y--;
		}
	}
}