using UnitsInterfaces;
using UnityEngine;

namespace SpellBuilderWithRune
{
    public class RuneForm : MonoBehaviour, IRune
    {
        [SerializeField] public string Name { get; set; }
        [SerializeField] public GameObject[] Form;

        public RuneType type => RuneType.Form;

        public GameObject GetForm(int size)
        {
            var newForm = Instantiate(Form[size]);
            newForm.isStatic = false;
            return newForm;
        }
        
        public void Use(IUnit usingUnit) // add to inventory TODO
        {
            
        }
    }
}