using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool hasWrench, hasWelderMask;
    public int smallBeams, largeBeams;
    
    public int roomLocation = 1;

    private SoundFXManager soundFX;
    private UISetter ui;

    private int numberOfInteractions = 0;

    [Header("---------Audio Clips---------")]
    [SerializeField] private AudioClip beamPlace;
    [SerializeField] private AudioClip beamPickup;
    [SerializeField] private AudioClip toolPickup;
    [SerializeField] private AudioClip interactSound;
    [SerializeField] private AudioClip wrenchSound;

    void Awake()
    {
        ui = GameObject.Find("Canvas").GetComponent<UISetter>();
        soundFX = GameObject.Find("SoundFXManager").GetComponent<SoundFXManager>();
    }

    public void SetHasWrench(bool updateBool)
    {
        hasWrench = updateBool;
        if (hasWrench)
        { 
            ui.ShowToolUI(0);
            if (toolPickup != null && soundFX != null)
            {
                soundFX.PlaySoundFXFull(toolPickup, transform, 1.0f);
            }
        } 
    }

    public void SetHasWeldingMask(bool updateBool)
    {
        hasWelderMask = updateBool;
        if (hasWelderMask) 
        {
            ui.ShowToolUI(1);
            if (toolPickup != null && soundFX != null)
            {
                soundFX.PlaySoundFXFull(toolPickup, transform, 1.0f);
            }
        }
    }

    public bool HasWelderMask()
    {
        return hasWelderMask;
    }

    public bool HasWrench()
    {
        return hasWrench;
    }

    public int GetCurrentRoomSelection()
    {
        return roomLocation;
    }

    public void SetRoomLocation(int roomNum)
    {
        roomLocation = roomNum;
    }

public void AddSmallBeam()
    {
        smallBeams++;
        ui.UpdateBeamText(true, smallBeams);
        if (beamPickup != null && soundFX != null)
        {
            soundFX.PlaySoundFXFull(beamPickup, transform, 1.0f);
        }
    }
    public void RemoveSmallBeam()
    {
        if (smallBeams > 0)
        {
            smallBeams--;
            ui.UpdateBeamText(true, smallBeams);
            if (beamPlace != null && soundFX != null)
            {
                soundFX.PlaySoundFXFull(beamPlace, transform, 1.0f);
            }
        }
    }

    public int SmallBeamCount()
    {
        return smallBeams;
    }

    public bool HasSmallBeam() 
    {
        return (smallBeams > 0);
    }

    public void AddLargeBeam()
    {
        largeBeams++;
        ui.UpdateBeamText(false, largeBeams);
        if (beamPickup != null && soundFX != null)
        {
            soundFX.PlaySoundFXFull(beamPickup, transform, 1.0f);
        }
    }
    public void RemoveLargeBeam()
    {
        if (largeBeams > 0)
        {
            largeBeams--;
            ui.UpdateBeamText(false, largeBeams);
            if (beamPlace != null && soundFX != null)
            {
                soundFX.PlaySoundFXFull(beamPlace, transform, 1.0f);
            }
        }
    }

    public int LargeBeamCount()
    {
        return largeBeams;
    }

    public bool HasLargeBeam()
    {
        return (largeBeams > 0);
    }

    public void PlayInteractSound() 
    {
        if (interactSound != null && soundFX != null)
        {
            soundFX.PlaySoundFXFull(interactSound, transform, 1.0f);
        }
    }

    public void PlayWrenchSound()
    {
        if (soundFX != null)
        {
            if (wrenchSound != null)
            {
                soundFX.PlaySoundFXFull(wrenchSound, transform, 1.0f);
            }
            else if(interactSound != null)
            {
                soundFX.PlaySoundFXFull(interactSound, transform, 1.0f);
            }
        }
    }

    public int GetNPCInteractionCount()
    {
        return numberOfInteractions;
    }

    public void IncreaseInteractionCount()
    {
        numberOfInteractions++;
        Debug.Log(numberOfInteractions);
    }

}
