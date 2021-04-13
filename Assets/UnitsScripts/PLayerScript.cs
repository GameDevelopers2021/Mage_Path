using UnitsClasses;
using UnityEngine;

namespace UnitsScripts
{
    public class PLayerScript : MonoBehaviour
    {
        [SerializeField] private int health = 100;
        [SerializeField] private int mana = 100;
        private Player playerModel;

        private void Start()
        {
            playerModel = new Player(health, mana);
        }
    }
}