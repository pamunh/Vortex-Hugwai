using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena2 : MonoBehaviour
{
    public string MN1; // Nome da cena para mudar

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(MN1);
        }
    }

    public void Trocar()
    {
        SceneManager.LoadScene(MN1);
    }
    public void StartBotao()
    {
        SceneManager.LoadScene(MN1);
    }
}

