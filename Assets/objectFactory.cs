using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.EventSystems;

public class objectFactory : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public GameObject targetObject;
	bool isDragging = false;
	GameObject draggingObj;

	void OnEnable() {
//		UnityARSessionNativeInterface.ARFrameUpdatedEvent += ARFrameUpdate;
//		Vector3 initialPoint = new Vector3(Screen.width / 2f, -Screen.height / 2f, transform.position.z);
//		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width, 0f, 0f));
//		var plane = new Plane (Vector3.forward, Vector3.zero);
//		plane.Translate (transform.position);
//		float distance;
//		plane.Raycast (ray, out distance);
//		Debug.Log(ray.GetPoint (distance));
//		RaycastHit hitInfo;
//		Physics.Raycast(ray, out hitInfo, 1000, LayerMask.GetMask("UILayer"));
//		Debug.Log (hitInfo.point);

//		var point = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 100, 100f, transform.position.z));
//		transform.position = point;

		UnityARSessionNativeInterface.ARFrameUpdatedEvent += ARFrameUpdate;

	}

	public void OnPointerDown(PointerEventData ped) 
	{
		Debug.Log (Input.mousePosition);
		isDragging = true;
		draggingObj = Instantiate (gameObject);
		draggingObj.transform.parent = this.transform.parent;
	}

	public void OnPointerUp(PointerEventData ped) 
	{
		isDragging = false;
		Destroy (draggingObj);
		var point = Camera.main.ScreenToWorldPoint(
			new Vector3(Input.mousePosition.x, Input.mousePosition.y, 25.0f));
		Instantiate (targetObject, point, transform.rotation);
	}

	void onMouseDown() {
		Debug.Log (Input.mousePosition);
	}

	void Update() {
		if (isDragging) {
			draggingObj.transform.position = new Vector3(
				Input.mousePosition.x,
				Input.mousePosition.y,
				transform.position.z
			);
		}
//		var point = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 200, 200f, transform.position.z));
//		transform.position = point;
	}

	private void ARFrameUpdate(UnityARCamera arCamera) {
		Debug.Log (arCamera);
	}
}
