using System;
using Components.Common.MonoLinks;
using UnityComponents.MonoLinks.Base;

namespace Components.UnityComponents.MonoLinks
{
    public class IsActiveMonoLink : MonoLink<IsActiveLink>
    {

#if UNITY_EDITOR

        private void OnDisable()
        {
            Value.Value = gameObject.activeSelf;
        }
        
        private void OnEnable()
        {
            Value.Value = gameObject.activeSelf;
        }
#endif
    }
}