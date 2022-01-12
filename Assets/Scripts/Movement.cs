using System.Security.Cryptography;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    AudioSource audioSource;
    CapsuleCollider capsuleCollider;
    
    CollisionHandler collisionHandler; 
    // Start is called before the first frame update
    [SerializeField] float RotationThrust = 100f;
    [SerializeField] float MainThrust = 1500f;
    [SerializeField] AudioClip engineThrust;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem rightSideEngineParticles;

    [SerializeField] ParticleSystem leftSideEngineParticles;

    void Start()
    {
        collisionHandler = GetComponent<CollisionHandler>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();


    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        
    }
    void ProcessInput(){
        audioSource.clip = engineThrust;
        if (Input.GetKey(KeyCode.Space) )
        {
            if (!audioSource.isPlaying) {
                audioSource.Play();
            }
            if (!mainEngineParticles.isPlaying) {
            mainEngineParticles.Play();
            }

            rb.AddRelativeForce(Vector3.up * MainThrust * Time.deltaTime);
            

        }

        else {
            mainEngineParticles.Stop();
            audioSource.Stop();
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (!leftSideEngineParticles.isPlaying) {leftSideEngineParticles.Play();}
            ApplyRotation(RotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!rightSideEngineParticles.isPlaying) {rightSideEngineParticles.Play();}
            ApplyRotation(-RotationThrust);
        }
        else 
        {
            leftSideEngineParticles.Stop();
            rightSideEngineParticles.Stop();
        }
    }

    private void ApplyRotation(float Thrust)
    {
        rb.freezeRotation = true;
        rb.transform.Rotate(Vector3.right* Thrust * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
