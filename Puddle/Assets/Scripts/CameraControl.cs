using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public GameObject target;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = target.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime);

        Quaternion rotation = Quaternion.Euler(0, desiredAngle + 180, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }
}
