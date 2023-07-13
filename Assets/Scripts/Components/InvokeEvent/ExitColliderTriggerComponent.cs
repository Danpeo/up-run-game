using System;
using UnityEngine;

namespace Components.InvokeEvent
{
    public class ExitColliderTriggerComponent : InvokeEventColliderComponent
    { 
        private void OnTriggerExit2D(Collider2D other)
        {
            foreach (var tagEvent in TagEvents)
            {
                if (other.gameObject.CompareTag(tagEvent.Tag))
                {
                    tagEvent.Event?.Invoke(other.gameObject);
                }
            }
        }
        
    }
}