using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour // CameraTarget için oluşturulabilecek scripten biri bu diğerlerini araştır!
{
    public Transform cameraTarget;
    public float sSpeed = 10f;
    public Vector3 dist;
    public Transform lookTarget;

    private void LateUpdate()
    {
        Vector3 dPos = cameraTarget.position + dist;   // kamera belli bir uzaklıktan takip edecek. (distance)
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed*Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);

    }

}
