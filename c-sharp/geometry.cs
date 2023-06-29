/*
 * 2D Methods
 *
 */

bool isPointOnLine2D(Vector2 point, Vector2 lineStart, Vector2 lineEnd){
    float epsilon = 0.0001f;
    float dx = lineEnd.x - lineStart.x;
    float dy = lineEnd.y - lineStart.y;
    float len = Mathf.Sqrt(dx * dx + dy * dy);
    dx /= len;
    dy /= len;
    float t = (point.x - lineStart.x) * dx + (point.y - lineStart.y) * dy;
    return Mathf.Abs(t) < epsilon;
}




/*
 * 3D Methods
 *
 */


bool isPointOnLine3D(Vector3 point, Vector3 lineStart, Vector3 lineEnd){
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
