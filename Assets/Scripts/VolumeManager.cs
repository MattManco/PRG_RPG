using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Timeline;

public class VolumeManager : MonoBehaviour
{
     [SerializeField] private AudioMixer am;

    //Possibility 1 
    public void SetVolume(string groupName, float volume)
    {
        am.SetFloat(groupName+"Volume", volume);
    }

    //Possibility 2
    public void SetAmbienteVolume(float volume)
    {
        am.SetFloat("AmbienteVolume", volume);
    }

    public void SetMasterVolume(float volume)
    {
        am.SetFloat("MasterVolume", volume);
    }

    //Possibility 3 <- Best Practice
    public void SetVolume(VolumeGroupType groupType, float volume)
    {
        string groupName = "";
        switch (groupType)
        {
            case (VolumeGroupType.Master):
                groupName = "Master";
                break;
            case (VolumeGroupType.BattleMusic):
                groupName = "BattleMusic";
                break;
            case (VolumeGroupType.Ambience):
                groupName = "Ambience";
                break;
            case (VolumeGroupType.Music):
                groupName = "Music";
                break;
            case (VolumeGroupType.SFX):
                groupName = "SFX";
                break;
        }
        am.SetFloat(groupName + "Volume", volume);
    }
}

public enum VolumeGroupType
{
    Master,
    BattleMusic,
    Ambience,
    Music,
    SFX
}
