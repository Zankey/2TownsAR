using UnityEngine;

public class Robot : Augmentation
{
   #region PUBLIC_METHODS
   public override void Restore()
   {
      base.Restore();
   }

   public override void OnEnter()
   {
      base.OnEnter();
      IsRobotDetailOn = false;

      m_EvtOnEnter.Invoke();
   }

   public void ShowDetail()
   {
      IsRobotDetailOn = true;
   }

   public void HideDetail()
   {
      IsRobotDetailOn = false;
   }

   public void HandleVirtualButtonPressed()
   {
      ShowDetail();
   }

   public void HandleVirtualButtonReleased()
   {
      HideDetail();
   }
   #endregion // PUBLIC_METHODS


   #region PRIVATE_METHODS

   private void DoEnter()
   {
      animator.SetTrigger("DoEnter");
   }

   private bool IsRobotDetailOn
   {
      get { return animator.GetBool("IsRobotDetailOn"); }
      set { animator.SetBool("IsRobotDetailOn", value); }
   }
   #endregion // PRIVATE_METHODS
}




