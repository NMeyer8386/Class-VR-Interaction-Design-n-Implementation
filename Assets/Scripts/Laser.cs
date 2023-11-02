using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //Variable Declaration
    [SerializeField]
    private GameObject beam;

    [SerializeField]
    private AudioClip[] audioClips;     //index 0 is bzzzt, index 1 is hum, index 2 is lightsaber3

    private AudioSource beamSound;
    private bool beamEnabled = true;

    private void Start()
    {
        beamSound = beam.GetComponentInParent<AudioSource>();
    }

    //Deploys and retracts the saber
    public void DeployRetract()
    {
        beam.SetActive(beamEnabled);    //Set the beam to whatever the value of beamEnabled is
        SaberSounds();                  //Play the sounds corresponding to the deploying/retracting of the beam
        beamEnabled = !beamEnabled;     //Flip the boolean (prepare for when you want to turn it off)
    }

    //Plays sounds depending on which state the saber is in
    private void SaberSounds()
    {
        //If it aint enabled, play the enabling sounds
        if (beamEnabled)
        {
            beamSound.PlayOneShot(audioClips[0]);
            beamSound.PlayOneShot(audioClips[1]);
        }
        //If it *is* enabled, play the disabling sounds
        if (!beamEnabled)
        {
            if (beamSound.isPlaying) 
            { 
                beamSound.Stop();
            }
            beamSound.PlayOneShot(audioClips[2]);
        }

    }
}