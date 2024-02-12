using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SpaceOutsideController : MonoBehaviour
{
    public XRLever lever;
    public XRKnob knob;

    public float forwardSpeed = 1.0f;
    public float sideSpeed = 1.0f;

    void Update()
    {
        var forwardVelocity = forwardSpeed * (lever.value ? 1 : 0);
        var sideVelocity = sideSpeed * (lever.value ? 1 : 0) * Mathf.Lerp(-1, 1, knob.value);
        Vector3 velocity = new Vector3(sideVelocity, 0, forwardVelocity);

        transform.position += velocity * Time.deltaTime;
    }
}
