using System;
using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    CinemachineImpulseSource cinemachineImpulseSource;
    [SerializeField] float shakeModifier = 10f;
    const string playerString = "Player";
    void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = 1f / distance;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f) * shakeModifier;
        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }
}
