using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public abstract class AudioController : MonoBehaviour {
	
	public float volumeFadeSpeed = 5f, 
				 volumeMax = 1f;
	
	protected AudioSource audioBackground;
	
	private AudioClip lastBackgroundAudio;
	private float audioFadeDirection, 
				  volume;
	private bool audioBackgroundFadeActive = false;	
	
	private static bool backgroundMute = false, 
						effectMute = false;
	
	protected virtual void Start (){
		
		// for it always clamp between 0 and 1
		this.volumeMax = Mathf.Clamp01(this.volumeMax);
		
		GameObject _audioBackgroundGO = GameObject.Find("AudioBackground");
		
		if(_audioBackgroundGO != null){
			
			this.audioBackground =_audioBackgroundGO.GetComponent<AudioSource>();	
			
			// for it always starts with volume 0 and it never starts normal and then it does fade in
			this.audioBackground.volume = 0f;
			
			this.audioBackground.loop = true;
			
			this.audioBackground.Play();
			
			this.audioFadeIn();
			
		}
		
		this.refreshSounds();
		
	}
	
	protected void Update (){
		
		if (this.audioBackgroundFadeActive){
			
			this.volume += audioFadeDirection * volumeFadeSpeed * Time.deltaTime;
			
			this.volume = Mathf.Clamp(volume, 0, this.volumeMax);
			
			audioBackground.volume = this.volume;
			
			if(volume == 0 || volume == this.volumeMax){
				
				this.audioBackgroundFadeActive = false;
				
				if(volume == 0){
					
					audioBackground.Stop();
					
				}
				
			}
			
		}
		
	}
	
	private void audioFadeIn() {

		this.playAudioBackground();
		this.audioBackgroundFadeActive = true;
		this.volume = 0.0f;
		this.audioFadeDirection = 1f;	
		
	}
	
	private void audioFadeOut() {
		
		this.audioBackgroundFadeActive = true;
		this.volume = this.volumeMax;
		this.audioFadeDirection = -1f;
		
	}

	public void playAudioBackground(){
		
		this.audioBackground.Play();
		
	}
	
	public void playEffect(AudioClip effectClip){
		
		this.audio.PlayOneShot(effectClip);
		
	}
	
	public void muteAudioBackground(){
		
		backgroundMute = !backgroundMute;
		
		this.refreshSounds();
		
	}
	
	public void muteAudioEffects(){
		
		effectMute = !effectMute;
		
		this.refreshSounds();
		
	}
	
	public bool isAudioBackgroundMute(){
		
		return backgroundMute;
		
	}
	
	public bool isAudioEffectsMute(){
		
		return effectMute;
		
	}
	
	private void refreshSounds(){
		
		if(audioBackground != null){
			
			this.audioBackground.mute = backgroundMute;
			
		}
		
		this.audio.mute = effectMute;
		
		//ButtonSoundController.checkButtons();
		
	}
	
	public void changeBackgroundAudio(AudioClip newBackgroundAudio){
		
		this.lastBackgroundAudio = audioBackground.clip;
		
		this.audioBackground.clip = newBackgroundAudio;
		
		this.audioBackground.Play();
		
	}
	
	public void restoreLastBackgroundAudio(){
		
		this.audioBackground.clip = lastBackgroundAudio;
		
		this.audioBackground.Play();
		
	}
	
}