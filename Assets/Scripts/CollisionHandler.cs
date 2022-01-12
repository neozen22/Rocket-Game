using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
        Movement mv;
        AudioSource audioSource;

        [SerializeField] AudioClip successSound;
        [SerializeField] AudioClip crashSound;

        [SerializeField] ParticleSystem successParticle;
        [SerializeField] ParticleSystem crashParticle;
        public bool isAlive = true;
        public bool collisionEnabled = true;
        void Start()
        {
            mv = GetComponent<Movement>();
            audioSource = GetComponent<AudioSource>();

        }
        void OnCollisionEnter(Collision collision)
            {
            if (isAlive && collisionEnabled)
                {        
                switch (collision.gameObject.tag) 
                        {
                        case "Finish":

                            SuccessSequence();

                            break;
                        case "Fuel":

                            Destroy(collision.gameObject);
                            break;
                        case "Launch":

                            break;

                        default:

                            CrashSequence();
                        break;
                        }
                }
            }

    private void SuccessSequence()
    {
        successParticle.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(successSound);
        mv.enabled = false;
        isAlive = false;
        Invoke("LoadNextLevel", 2f);
        
    }

    void CrashSequence() 
        {   

            crashParticle.Play();
            audioSource.Stop();
            audioSource.PlayOneShot(crashSound);
            mv.enabled = false;
            isAlive = false;
            Invoke("ReloadLevel", 2f);
        }

        void ReloadLevel() {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        void LoadNextLevel() {
            
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextScene == SceneManager.sceneCountInBuildSettings) {
                nextScene = 0;
                                }
        SceneManager.LoadScene(nextScene);
        }
    }
