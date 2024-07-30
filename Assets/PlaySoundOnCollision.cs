using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioSource strikeAudioSource;
    public AudioSource playAudioSource;
    private GameObject Striker;
    

    private bool isStroking = false;
    private Vector3 strikerPosition;
    private Vector3 bowlPosition;
    private float distanceFromCenter;
    
    // Start is called before the first frame update
    void Start()
    {
        if (strikeAudioSource == null || playAudioSource == null)
        {
            AudioSource[] audioSources = GetComponents<AudioSource>();
            strikeAudioSource = audioSources[0];
            playAudioSource = audioSources[1];
            
            
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Striker"))
        {
            Striker = collision.gameObject;
            bowlPosition = transform.position;
            strikerPosition = Striker.transform.position;
            distanceFromCenter = Vector3.Distance(bowlPosition, strikerPosition);
            float bowlWidth = transform.localScale.x / 2;
            
            Debug.Log("Striker to Bowl Distance: " + distanceFromCenter);
            
            if (distanceFromCenter < bowlWidth)
            {
                isStroking = true;
            }
            else
            {
                if (strikeAudioSource.isPlaying)
                { 
                    strikeAudioSource.Stop(); 
                    strikeAudioSource.Play();
                }
                else 
                { 
                    strikeAudioSource.Play();
                }
            }
            
            

        }
    }

    private void OnCollisionExit(Collision other)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStroking)
        {
            Vector3 currentStrikerPosition = Striker.transform.position;
            float movementDistance = Vector3.Distance(currentStrikerPosition, strikerPosition);
            distanceFromCenter = Vector3.Distance(currentStrikerPosition, bowlPosition);
            //Debug.Log("Stroking detected, measuring gesture, movement distance is: " + movementDistance);
            
            if (distanceFromCenter < 0.2f && movementDistance > 0.1f)
            {

                if (!playAudioSource.isPlaying)
                {
                    playAudioSource.Play();
                }
            }
            else
            {
                //Debug.Log("STOPPING STROKING");
                isStroking = false;
                playAudioSource.Stop();
            }
        }
    }
    
    
}
