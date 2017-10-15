using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class BallMaker : MonoBehaviour {

	public GameObject ballPrefab;
	public GameObject ballPrefab2;
	public GameObject ballPrefab3;
	public GameObject ballPrefab4;
	public float createHeight;
	private int counter = 0;
	private MaterialPropertyBlock props;
	private List<GameObject> prefabList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		prefabList.Add (ballPrefab);
		prefabList.Add (ballPrefab2);
		prefabList.Add (ballPrefab3);
		prefabList.Add (ballPrefab4);
		props = new MaterialPropertyBlock ();
	}

	void CreateBall(Vector3 atPosition)
	{
		GameObject ballGO = Instantiate (prefabList[counter++], atPosition, Quaternion.identity);
		if(counter == prefabList.Count) {
			counter = 0;
		}
		
		float r = Random.Range(0.0f, 1.0f);
		float g = Random.Range(0.0f, 1.0f);
		float b = Random.Range(0.0f, 1.0f);

		props.SetColor("_InstanceColor", new Color(r, g, b));

		MeshRenderer renderer = ballGO.GetComponent<MeshRenderer>();
		renderer.SetPropertyBlock(props);

	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 )
		{
			var touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
				ARPoint point = new ARPoint {
					x = screenPosition.x,
					y = screenPosition.y
				};
						
				List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, 
					ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent);
				if (hitResults.Count > 0) {
					foreach (var hitResult in hitResults) {
						Vector3 position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
						CreateBall (new Vector3 (position.x, position.y + createHeight, position.z));
						break;
					}
				}

			}
		}

	}

}
