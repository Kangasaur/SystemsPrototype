using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform followTransform;
    public BoxCollider2D worldBounds;

    float xMin, xMax, yMin, yMax;
    float camY, camX, camSize, camRatio;

    Camera mainCam;

    Vector3 smoothPos;

    public float smoothRate;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
        xMin = worldBounds.bounds.min.x;
        xMax = worldBounds.bounds.max.x;
        yMin = worldBounds.bounds.min.y;
        yMax = worldBounds.bounds.max.y;

        camSize = mainCam.orthographicSize;
        camRatio = 8f / 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin + camSize, yMax - camSize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + (camSize * camRatio), xMax - (camSize * camRatio));

        smoothPos = Vector3.Lerp(transform.position, new Vector3(camX, camY, -10f), smoothRate);
        gameObject.transform.position = smoothPos;
    }
}
