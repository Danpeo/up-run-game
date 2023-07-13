using UnityEngine;

namespace Components.InvokeEvent
{
    public class EnterTriggerColliderComponent : InvokeEventColliderComponent
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            foreach (var tagEvent in TagEvents)
            {
                if (col.gameObject.CompareTag(tagEvent.Tag))
                {
                    tagEvent.Event?.Invoke(col.gameObject);
                }
            }
        }
    }
}