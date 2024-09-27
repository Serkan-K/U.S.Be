using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class Camera : MonoBehaviour
{
    // Camera Follow
    [SerializeField] private Vector3 offset = new (0f, 0f, -10f);
    [SerializeField] private float followSmoothTime = 0.25f;
    [SerializeField] private Vector3 followVelocity = Vector3.zero;

    [SerializeField] private Transform player_;

    // Camera Zoom
    private float zoom;
    [SerializeField] private float zoomMultiplier = 4f;
    [SerializeField] private float minZoom = 2f;
    [SerializeField] private float maxZoom = 8f;
    [SerializeField] private float zoomVelocity = 0f;
    [SerializeField] private float zoomSmoothTime = 0.25f;

    [SerializeField] private UnityEngine.Camera cam;



    //Shake

    [SerializeField] private float shakeDuration = 0.5f;
    [SerializeField] private float shakeMagnitude = 0.2f;
    [SerializeField] private float rotationAmount = 3f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;






    private void Start()
    {
        zoom = cam.orthographicSize;
        //zoom = cam.fieldOfView;
    }

    private void Update()
    {
        Vector3 targetPosition = player_.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref followVelocity, followSmoothTime);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref zoomVelocity, zoomSmoothTime);

        //
        //cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, zoom, ref zoomVelocity, zoomSmoothTime);





        //shake


        if (Input.GetKeyDown(KeyCode.U))
        {
            Shake_pos();

            StartCoroutine(ShakeAndRotate());

        }



    }





    private IEnumerator ShakeAndRotate()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            //Shake effect
            Vector3 newPosition = originalPosition + Random.insideUnitSphere * shakeMagnitude;
            transform.position = newPosition;

            //Rotation effect

            Quaternion newRotation = originalRotation * Quaternion.Euler(0f, 0f, Mathf.Sin(elapsedTime * rotationAmount) * rotationAmount);
            transform.rotation = originalRotation;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        this.transform.position = originalPosition;
        this.transform.rotation = originalRotation;

    }







    private void Shake_pos()
    {
        originalPosition = player_.transform.position;
        originalRotation = player_.transform.rotation;
    }

}