using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ChangeVirtualCamera : MonoBehaviour
{
    private BasicMovement player;
    public Transform followingObject;
    public CinemachineVirtualCamera virtualCamera;

    private void Start() {
        player = FindObjectOfType<BasicMovement>();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        Debug.Log("VIRTUAL CAM IS ATTACHED TO " + virtualCamera.Name);
        Debug.Log("VIRTUAL CAM IS FOLLOWING " + virtualCamera.Follow.name);
    }

    private void Update() {
        virtualCamera.Follow = followingObject;
    }

    public void SetVirtualCameraFollow(Transform gameObjectToFollow) {
        followingObject = gameObjectToFollow;

        Debug.Log("Virtual Camera is now following " + virtualCamera.Follow.name);

        // Debug.Log("Virtual Camera is now following " + gameObjectToFollow.name);
    }

    public void ResetVirutalCameraFollow() {
        followingObject = player.transform;
        Debug.Log("Virtual Camera is now following " + virtualCamera.Follow.name);
    }
}
