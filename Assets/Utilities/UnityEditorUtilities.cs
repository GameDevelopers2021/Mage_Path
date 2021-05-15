using System;
using UnityEngine;

namespace Utilities
{
    public static class UnityEditorHelper
    {
        public static void InvokeForEveryChild(Transform objectTransform, Action<Transform> action)
        {
            for (var i = 0; i < objectTransform.childCount; i++)
            {
                var current = objectTransform.GetChild(i);
                action(current);
            }
        }
    }
}