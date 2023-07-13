using UnityEngine;
using UnityEngine.Serialization;

namespace Components.InvokeEvent
{
    public class EnterColliderComponent : InvokeEventColliderComponent
    {
        [SerializeField] private bool _checkPlayerCollisionVelocityY;
        
        [FormerlySerializedAs("_playerCollisionRelativeCollisionY")]
        [Tooltip("(Optional) this applies only if 'Check Player Collision Velocity Y' equals 'true'")]
        [SerializeField] private float _playerRelativeCollisionY;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            foreach (var tagEvent in TagEvents)
            {
                if (col.gameObject.CompareTag(tagEvent.Tag) && CheckPlayerCollisionVelocityY(col, _playerRelativeCollisionY))
                {
                    tagEvent.Event?.Invoke(col.gameObject);
                }
            }        
        }
        
        private bool CheckPlayerCollisionVelocityY(Collision2D col, float playerCollisionRelativeCollisionY)
        {
            if (!_checkPlayerCollisionVelocityY) return true;
            
            if (col != null)
            {
                return col.relativeVelocity.y < playerCollisionRelativeCollisionY;
            }

            return false;
        }
    }
}
