using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components.InvokeEvent
{
    public abstract class InvokeEventColliderComponent : MonoBehaviour
    {
        [SerializeField] public TagEvent[] TagEvents;
        
        [Serializable]
        public class TagEvent
        {
            public string Tag;
            public UnityEvent<GameObject> Event;
            public float? PlayerCollisionRelativeCollisionY;
        }
        
    }
}