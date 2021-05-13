using System.Net;
using UnityEngine;

public class FinishBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject finishMenu;
    private Renderer finishMenuRenderer;

    private void Awake()
    {
        finishMenuRenderer = finishMenu.GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        Time.timeScale = 0;
        //gameObject.SendMessage("Pause");
        finishMenu.SetActive(true);
    }
}