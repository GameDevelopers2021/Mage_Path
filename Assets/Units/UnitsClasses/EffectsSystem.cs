using System.Collections;
using UnitsClasses;

namespace Units.UnitsClasses
{
    public class EffectsSystem : UnitComponent
    {
        public void Coroutine(IEnumerator enumerator)
        {
            StartCoroutine(enumerator);
        }
    }
}