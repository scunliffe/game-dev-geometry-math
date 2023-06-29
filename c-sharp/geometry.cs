/*
 * 2D Methods
 *
 */

public static bool distance(Vector2 point1, Vector2 point2){
	return Vector2.Distance(point1, point2);
}

public static float getAngleBetweenLines(Vector2 line1Start, Vector2 line1End, Vector2 line2Start, Vector2 line2End){
	Vector2 line1Dir = (line1End - line1Start).normalized;
	Vector2 line2Dir = (line2End - line2Start).normalized;
	float angle = Mathf.Atan2(line2Dir.y, line2Dir.x) - Mathf.Atan2(line1Dir.y, line1Dir.x);
	angle *= Mathf.Rad2Deg;
	if(angle < 0){
		angle += 360;
	}
	return angle;
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

public static Vector3 getNormalOfPlane(Vector3 point1, Vector3 point2, Vector3 point3){
	Vector3 side1 = point2 - point1;
	Vector3 side2 = point3 - point1;
	return Vector3.Cross(side1, side2).normalized;
}

public static Vector2 getLineIntersection(Vector2 line1Start, Vector2 line1End, Vector2 line2Start, Vector2 line2End){
	Vector2 intersection = null;

	Vector2 dir1 = line1End - line1Start;
	Vector2 dir2 = line2End - line2Start;

	float a1 = -dir1.y;
	float b1 = +dir1.x;
	float d1 = -(a1 * line1Start.x + b1 * line1Start.y);

	float a2 = -dir2.y;
	float b2 = +dir2.x;
	float d2 = -(a2 * line2Start.x + b2 * line2Start.y);

	float seg1_line2_start = a2 * line1Start.x + b2 * line1Start.y + d2;
	float seg1_line2_end = a2 * line1End.x + b2 * line1End.y + d2;

	float seg2_line1_start = a1 * line2Start.x + b1 * line2Start.y + d1;
	float seg2_line1_end = a1 * line2End.x + b1 * line2End.y + d1;

	// If segments intersect, calculate intersection point
	if((seg1_line2_start > 0 && seg1_line2_end < 0) || (seg1_line2_start < 0 && seg1_line2_end > 0)){
		if((seg2_line1_start > 0 && seg2_line1_end < 0) || (seg2_line1_start < 0 && seg2_line1_end > 0)){
			float u = seg1_line2_start / (seg1_line2_start - seg1_line2_end);
			intersection = line1Start + u * dir1;
		}
	}
	return intersection;
}

public static bool doLinesIntersect(Vector2 line1Start, Vector2 line1End, Vector2 line2Start, Vector2 line2End){
	return (getLineIntersection(line1Start, line1End, line2Start, line2End) != null);
}

public static Plane createPlaneFromPoints(Vector3 point1, Vector3 point2, Vector3 point3){
	Vector3 side1 = point2 - point1;
	Vector3 side2 = point3 - point1;
	Vector3 normal = Vector3.Cross(side1, side2).normalized;

	return new Plane(normal, point1);
}

public static bool isPointOnPlane(Vector3 point, Vector3 planeNormal, Vector3 planePoint){
	float distance = Vector3.Dot(planeNormal, (point - planePoint));
	return Mathf.Approximately(distance, 0);
}

public static bool isPointOnPlane(Vector3 point, Vector3 planePoint1, Vector3 planePoint2, Vector3 planePoint3){
	Plane plane = createPlaneFromPoints(Vector3 point1, Vector3 point2, Vector3 point3);
	return isPointOnPlane(point, plane.normal, plane.ClosestPointOnPlane(Vector3.zero));
}
