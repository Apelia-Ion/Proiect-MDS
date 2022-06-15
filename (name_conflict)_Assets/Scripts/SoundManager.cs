using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        if(!PlayerPrefa.HasKey("musicVolume",1);
        {
        	PlayerPrefs.SetFloat("musicVolume", 1);
        	Load();
        }
        else 
        {
        	Load();
        }
        
        
    }

    void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    private void Load()
    {
    	volumeSlider.value=PlayerPrefs.GetFloat("musicVolume");
    
    }
    
    private void Save()
    {
    	PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    
    
}
