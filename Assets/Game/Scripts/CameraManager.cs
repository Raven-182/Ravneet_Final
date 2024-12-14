using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraMachineController : MonoBehaviour
{
    [SerializeField] List<CinemachineVirtualCameraBase> cameras;
    [SerializeField] Transform worldCenter; 
    [SerializeField] Transform character; 
    [SerializeField] Transform finalTarget; 
    [SerializeField] float panSpeed = 20f; 
    [SerializeField] float panDuration = 10f; 
    [SerializeField] float zoomDuration = 4f;
    [SerializeField] int defaultCameraIndex = 0; 
     public bool cutsceneOver = false;

    void Start()
    {
       
        StartCoroutine(PlayCutscenes());
    }

    IEnumerator PlayCutscenes()
    {
        foreach (var camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }

        cameras[1].gameObject.SetActive(true);
        yield return StartCoroutine(PanAroundWorld());
        cameras[1].gameObject.SetActive(false);

        cameras[0].gameObject.SetActive(true); 
        yield return new WaitForSeconds(zoomDuration);
        cameras[0].gameObject.SetActive(false);


        cameras[3].gameObject.SetActive(true); 
        yield return new WaitForSeconds(zoomDuration);
        cameras[3].gameObject.SetActive(false);


        cameras[4].gameObject.SetActive(true); 
        yield return StartCoroutine(ZoomToFinalTarget());
        cameras[4].gameObject.SetActive(false);

        ActivateDefaultCamera();
    }


    IEnumerator PanAroundWorld()
    {
        float elapsedTime = 0f;

        while (elapsedTime < panDuration)
        {
            cameras[1].transform.RotateAround(worldCenter.position, Vector3.up, panSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator ZoomToFinalTarget()
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = cameras[1].transform.position;
        Vector3 targetPosition = finalTarget.position;

        while (elapsedTime < zoomDuration)
        {
            cameras[1].transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / zoomDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    void ActivateDefaultCamera()
    {
        foreach (var camera in cameras)
        {
            camera.gameObject.SetActive(false);
        }
        cameras[defaultCameraIndex].gameObject.SetActive(true);
        cutsceneOver = true;
    }
}
