using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRotate : MonoBehaviour
{
    private float initialYAngle = 0f;
    private float appliedGyroYAngle = 0f;
    private float calibrationYAngle = 0f;
    void Update()
    {
        ApplyGyroRotation();
        ApplyCalibration();
    }
    void Start()
    {
        Input.gyro.enabled = true;
        Application.targetFrameRate = 60;
    }
    public void CalibrateYAngle()
    {
        calibrationYAngle = appliedGyroYAngle - initialYAngle; // Offsets y angle in case it wasn't
    }

    void ApplyGyroRotation()
    {
        transform.rotation = Input.gyro.attitude;
        transform.Rotate(0f, 0f, 180f, Space.Self); //Swap "handedness" ofquaternionfromgyro.
        transform.Rotate(90f, 180f, 0f, Space.World); //Rotate to make sense as a camera pointing out the back
        appliedGyroYAngle = transform.eulerAngles.y; // Save the angle around y axis for use in calibration.
    }
    void ApplyCalibration()
    {
        transform.Rotate(0f, -calibrationYAngle, 0f, Space.World); // Rotates y angle back however much it deviated
    }
}