using System.Collections;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory(ActionCategory.Time)]
    [Tooltip("Waits until UAP stops using the talk system")]
    public class WaitForTalking : FsmStateAction
    {
        [RequiredField]
        public FsmEvent finishEvent;
        public UAP_AccessibilityManager Uap_Manager;

        public override void Reset()
        {
            finishEvent = null;
        }

        public override void OnEnter()
        {
            //Debug.Log("IS SPEAKING: " + WindowsTTS.IsSpeaking());
            //if (Uap_Manager.AudioQueueIsEmpty())
            //{
            //    Debug.Log("FINISHING IT");
            //    Fsm.Event(finishEvent);
            //    Finish();
            //    return;
            //}


            StartCoroutine(WaitForUapToStopSpeaking());
            
        }

       
        IEnumerator WaitForUapToStopSpeaking()
        {


            while (AndroidTTS.IsSpeaking() == true)
            {
                yield return null;
            }

            Finish();
            if (finishEvent != null)
            {
                Fsm.Event(finishEvent);
            }
        }

    }
}


