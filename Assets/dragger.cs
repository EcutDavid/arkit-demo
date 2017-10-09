using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class dragger : MonoBehaviour {
	public GameObject targetObject;
	bool isFirst = true;

	// Use this for initialization
	void OnEnable () {
		UnityARSessionNativeInterface.ARFrameUpdatedEvent += ARFrameUpdate;
	}
	Vector3 prePos;

	private void ARFrameUpdate(UnityARCamera arCamera) {
		Vector3 prefabPosition = GetCameraPos(arCamera) + Camera.main.transform.forward * 15;
//		if (isFirst || Vector3.Distance(prePos, GetCameraPos(arCamera)) > 0.25f) {
//			isFirst = false;
//			Instantiate (targetObject, prefabPosition, transform.rotation);
//			prePos = GetCameraPos (arCamera);
//		}
	}

	private Vector3 GetCameraPos(UnityARCamera camera) {
		Matrix4x4 matrix = new Matrix4x4 ();
		matrix.SetColumn (3, camera.worldTransform.column3);
		return UnityARMatrixOps.GetPosition(matrix);
	}
}
