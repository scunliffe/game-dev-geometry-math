/*
 * 2D Methods
 *
 */

public static bool distance(Vector2 point1, Vector2 point2){
	return Vector2.Distance(point1, point2);
}

public static Vector2 getNormalOfLine(Vector2 point1, Vector2 point2){
	Vector2 direction = point2 - point1;
	return new Vector2(-direction.y, direction.x).normalized;
}

public static bool isPointInsideCircle(Vector2 point, Vector2 center, float radius){
	return Vector2.Distance(point, center) < radius;
}


public static bool isPointOnLine2D(Vector2 point, Vector2 lineStart, Vector2 lineEnd){
	float epsilon = 0.0001f;
	float dx = lineEnd.x - lineStart.x;
	float dy = lineEnd.y - lineStart.y;
	float len = Mathf.Sqrt(dx * dx + dy * dy);
	dx /= len;
	dy /= len;
	float t = (point.x - lineStart.x) * dx + (point.y - lineStart.y) * dy;
	return Mathf.Abs(t) < epsilon;
}




public enum SideOfLine{
	Right = -1,
	OnTheLine = 0,
	Left = 1
}

public static SideOfLine getPointSideOfLine2D(Vector2 point, Vector2 lineStart, Vector2 lineEnd){
	float epsilon = 0.0001f;
	float dx = lineEnd.x - lineStart.x;
	float dy = lineEnd.y - lineStart.y;
	float t = (point.x - lineStart.x) * dy - (point.y - lineStart.y) * dx;
	if(Mathf.Abs(t) < epsilon){
		return SideOfLine.OnTheLine;
	} else if (t > 0){
		return SideOfLine.Left;
	} else {
		return SideOfLine.Right;
	}
}


public static bool isPointInsideRect(Vector2 point, Rect rect){
	return rect.Contains(point);
}









/*
 * 3D Methods
 *
 */

public static float distance(Vector3 point1, Vector3 point2){
	return Vector3.Distance(point1, point2);
}


public static bool isPointOnLine3D(Vector3 point, Vector3 lineStart, Vector3 lineEnd){
	float epsilon = 0.0001f;
	float dx = lineEnd.x - lineStart.x;
	float dy = lineEnd.y - lineStart.y;
	float dz = lineEnd.z - lineStart.z;
	float len = Mathf.Sqrt(dx * dx + dy * dy + dz * dz);
	dx /= len;
	dy /= len;
	dz /= len;
	float t1 = (point.x - lineStart.x) * dx + (point.y - lineStart.y) * dy + (point.z - lineStart.z) * dz;
	float t2 = (lineEnd.x - point.x) * dx + (lineEnd.y - point.y) * dy + (lineEnd.z - point.z) * dz;
	return Mathf.Abs(t1 + t2 - len) < epsilon;
}
