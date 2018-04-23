using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMouseLook : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothVertical;

    public float sensitivity = 5f;
    public float smoothing = 2f;

    GameObject character;

	// Use this for initialization
	void Start () {
        character = transform.parent.gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDirection = Vector2.Scale(mouseDirection, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothVertical.x = Mathf.Lerp(smoothVertical.x, mouseDirection.x, 1f / smoothing);
        smoothVertical.y = Mathf.Lerp(smoothVertical.y, mouseDirection.y, 1f / smoothing);
        mouseLook += smoothVertical;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);        
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
		
	}
}
