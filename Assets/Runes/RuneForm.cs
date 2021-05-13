using SpellBuilderWithRune;
using UnityEngine;

namespace Runes
{
    public class RuneForm : MonoBehaviour, IRune
    {
        public RuneType Type => RuneType.Form;
        [SerializeField] public string Name { get; }
        [SerializeField] private GameObject[] Form;

        public RuneForm(string name)
        {
            Name = name;
        }

        public GameObject GetForm(int size)
        {
            var newForm = Instantiate(Form[size]);
            newForm.isStatic = false;
            return newForm;
        }
    }
}