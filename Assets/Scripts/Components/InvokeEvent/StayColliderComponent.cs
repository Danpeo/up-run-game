using UnityEngine;

namespace Components.InvokeEvent
{
    public class StayColliderComponent : InvokeEventColliderComponent
    {
        private void OnCollisionStay2D(Collision2D collision)
        {
            foreach (var tagEvent in TagEvents)
            {
                if (collision.gameObject.CompareTag(tagEvent.Tag))
                {
                    tagEvent.Event?.Invoke(collision.gameObject);
                }
            }      
        }
    }
}
