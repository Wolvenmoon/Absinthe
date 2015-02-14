using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour {

	public Transform target;
	public float damping = 1;
	public float lookAheadFactor = 3f;
	public float lookAheadReturnSpeed = 0.1f;
	public float lookAheadMoveThreshold = 0.1f;

	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;

	void Start() {
		lastTargetPosition = target.position;
		offsetZ = (transform.position - target.position).x;
		transform.parent = null;
	}

	void Update() {
			
		float xMoveDelta = (target.position - lastTargetPosition).x;
		bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;

		if (updateLookAheadTarget) {
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
		}
	
		Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

		transform.position = newPos;
		lastTargetPosition = target.position;
	}

}