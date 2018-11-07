using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FourTeenVirtBttnAnim : Augmentation
{
   public AudioSource soundTarget;
   public AudioClip clipTarget;
   private AudioSource[] allAudioSources;

   //function to stop all sounds
   void StopAllAudio()
   {
      allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
      foreach (AudioSource audioS in allAudioSources)
      {
         audioS.Stop();
      }
   }

   //function to play sound
   void playSound(string ss)
   {
      clipTarget = (AudioClip)Resources.Load(ss);
      soundTarget.clip = clipTarget;
      soundTarget.loop = true;
      soundTarget.playOnAwake = false;
      soundTarget.Play();
   }

   #region PUBLIC_METHODS
   public override void Restore()
   {
      base.Restore();
   }

   public override void OnEnter()
   {
      base.OnEnter();
      IsAnimationOn = false;

      m_EvtOnEnter.Invoke();

      soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
   }

   public void ShowDetail()
   {
      IsAnimationOn = true;
   }

   public void HideDetail()
   {
      IsAnimationOn = false;
   }

   public void HandleVirtualButtonPressed()
   {
      ShowDetail();
      playSound("sounds/14 N Diamond.2");
   }

   public void HandleVirtualButtonReleased()
   {
      HideDetail();
      StopAllAudio();
   }
   #endregion // PUBLIC_METHODS


   #region PRIVATE_METHODS

   private void DoEnter()
   {
      animator.SetTrigger("DoEnter");
   }

   private bool IsAnimationOn
   {
      get { return animator.GetBool("IsAnimationOn"); }
      set { animator.SetBool("IsAnimationOn", value); }
   }
   #endregion // PRIVATE_METHODS
}




