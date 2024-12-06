using System.Collections;
using UnityEngine;

public class CarSoundManager : MonoBehaviour
{
    public AudioClip engineStartClip; // Engine start sound
    public AudioClip collisionClip;   // Collision sound
    public AudioClip malfunctionClip; // Malfunction sound

    private AudioSource audioSource;
    private int collisionCount = 0; // To count the number of collisions

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Play the engine start sound when the game starts
        if (engineStartClip != null)
        {
            audioSource.PlayOneShot(engineStartClip);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Play collision sound when the car hits an obstacle
        if (collisionClip != null)
        {
            audioSource.PlayOneShot(collisionClip);
        }

        collisionCount++;

        // If the car has hit more than five things, play the malfunction sound
        if (collisionCount > 5 && malfunctionClip != null)
        {
            audioSource.PlayOneShot(malfunctionClip);
            // Optionally, you can reset the count or add more logic here
            collisionCount = 0; // Resetting for repeated behavior if needed
        }
    }
}