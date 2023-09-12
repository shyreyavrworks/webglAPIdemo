using UnityEngine;
using UnityEngine.UI;

public class myCameraControl1 : MonoBehaviour
{
	[SerializeField]
	public Camera camera;
	public float wsadSpeed = .15f; // WSAD Movement
	public float mouseSensitivity = 0.15f;   // Mouse Rotation Speed

	//Define variable to store previous mouse pos:
	private Vector3 mousePositionPrevious = Vector3.zero;
	private float totalRun = 1.0f;

	void Update()
	{
		//Move around scene with WSAD keyboard input:
		float xAxisValue = Input.GetAxis("Horizontal") * wsadSpeed;
		float zAxisValue = Input.GetAxis("Vertical") * wsadSpeed;

		transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y, transform.position.z + zAxisValue);


		//Update camera orientation if mouse button is down:
		if (Input.GetMouseButton(0))
		{
			//Calculate mouse movement and scale it by camSens:
			Vector3 mouseTranslationScaled = (Input.mousePosition - mousePositionPrevious) * mouseSensitivity;

			//
			transform.eulerAngles = new Vector3(transform.eulerAngles.x + mouseTranslationScaled.y,
				transform.eulerAngles.y - mouseTranslationScaled.x, 0); ;
		}
		mousePositionPrevious = Input.mousePosition;
	}
}

