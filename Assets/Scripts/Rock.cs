using System;
using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticleSystem;
    CinemachineImpulseSource cinemachineImpulseSource;
    AudioSource audioSource;
    [SerializeField] float shakeModifier = 10f;
    [SerializeField] float collisionCooldown = 1f;
    const string playerString = "Player";
    float collisionTimer = 0f;
    void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        collisionTimer += Time.deltaTime;
        Debug.Log(collisionTimer);
    }

    void OnCollisionEnter(Collision other)
    {
        if (collisionTimer < collisionCooldown) return;
        FireImpulse();
        CollisionFX(other);
        collisionTimer = 0f;
    }

    private void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = 1f / distance;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f) * shakeModifier;
        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }
    void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;
        collisionParticleSystem.Play();
        audioSource.Play();
    }
}
