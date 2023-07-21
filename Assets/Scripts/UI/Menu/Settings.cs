using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
	[SerializeField] private Scrollbar volume;
	[SerializeField] private Toggle music;
	[SerializeField] private Toggle sounds;
	[SerializeField] private AudioMixerGroup audioMixer;
	[SerializeField] private GameObject settings;
	public static Settings Instance;
	public string musicPrefsName = "Music";
	public string volumePrefsName = "Volume";
	public string soundsPrefsName = "Sounds";

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

	}

	private void Start()
	{
		LoadSettings();
	}

	public void ChangeVolume()
	{
		Debug.Log("ChangeVolume");
		audioMixer.audioMixer.SetFloat("Volume", (1 - volume.value) * -80);
		SaveSettings();

	}
	public void ToggleMusic()
	{
		Debug.Log("ToggleMusic");
		if (music.isOn)
		{
			audioMixer.audioMixer.SetFloat("Music", 0);
		}
		else
		{
			audioMixer.audioMixer.SetFloat("Music", -80);
		}

		SaveSettings();
	}
	public void ToggleSounds()
	{
		

		if (sounds.isOn)
		{
			audioMixer.audioMixer.SetFloat("Sounds", 0);
		}
		else
		{
			audioMixer.audioMixer.SetFloat("Sounds", -80);
		}
		SaveSettings();
	}

	public void SaveSettings()
	{
		float volume, music, sounds;
		volume = (this.volume.value * -80 + 80) * -1;
		music = this.music.isOn ? 0 : -80;
		sounds = this.sounds.isOn ? 0 : -80;
		Debug.Log(sounds + "Save");
		PlayerPrefs.SetFloat(musicPrefsName, music);
		PlayerPrefs.SetFloat(soundsPrefsName, sounds);
		PlayerPrefs.SetFloat(volumePrefsName, volume);
	}
	public void LoadSettings()
	{
		float volume, music, sounds;
		volume = PlayerPrefs.GetFloat(volumePrefsName);
		music = PlayerPrefs.GetFloat(musicPrefsName);
		sounds = PlayerPrefs.GetFloat(soundsPrefsName);

		audioMixer.audioMixer.SetFloat("Volume", volume);
		audioMixer.audioMixer.SetFloat("Music", music);
		audioMixer.audioMixer.SetFloat("Sounds", sounds);
	}

	public void SetSettingsMenu()
	{
		Debug.Log("ACTIVE");
		float volume, music, sounds; 
		volume = PlayerPrefs.GetFloat(volumePrefsName);
		music = PlayerPrefs.GetFloat(musicPrefsName);
		sounds = PlayerPrefs.GetFloat(soundsPrefsName);

		this.volume.value = 1 - volume / -80;
		this.music.isOn = music <= -1 ? false : true;
		this.sounds.isOn = sounds <= -1 ? false : true;
	}
}
