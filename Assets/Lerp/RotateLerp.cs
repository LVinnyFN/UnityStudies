using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLerp : MonoBehaviour
{
    public Transform lerpObject;
    public float angle;
    public float duration = 1f;
    private float elapsedTime;
    private bool invert;

    public void Update()
    {
        float t = elapsedTime / duration;

        lerpObject.eulerAngles = Vector3.forward * Mathf.Lerp(angle, -angle, !invert ? t : 1 - t);
        elapsedTime += Time.deltaTime;
        if (elapsedTime > duration)
        {
            invert = !invert;
            elapsedTime = 0;
        }
    }
}
