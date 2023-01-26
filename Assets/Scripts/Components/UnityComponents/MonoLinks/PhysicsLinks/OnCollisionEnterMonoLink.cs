using System;
using Components.PhysicsEvents;
using Leopotam.Ecs;
using Unity.VisualScripting;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace Components.UnityComponents.MonoLinks.PhysicsLinks
{
    public class OnCollisionEnterMonoLink : PhysicsLinkBase
    {
        public void OnCollisionEnter(Collision other)
        {
            _entity.Get<OnCollisionEnterEvent>() = new OnCollisionEnterEvent
            {
                Collision = other,
                Sender = gameObject
            };
        }
    }
}