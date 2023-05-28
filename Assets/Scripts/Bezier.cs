using UnityEngine;

public static class Bezier
{
	public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
	{
		Vector3 point1 = Vector3.Lerp(p0, p1, t);
		Vector3 point2 = Vector3.Lerp(p1, p2, t);
		Vector3 point3 = Vector3.Lerp(p2, p3, t);

		Vector3 point01 = Vector3.Lerp(point1, point2, t);
		Vector3 point02 = Vector3.Lerp(point2, point3, t);

		return Vector3.Lerp(point01, point02, t);
	}
}
