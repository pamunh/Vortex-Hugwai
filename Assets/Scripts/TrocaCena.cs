using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour
{
    public string MN2; // Nome da cena para mudar

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(MN2);
        }
    }

    public void Trocar()
    {
        SceneManager.LoadScene(MN2);
    }
    public void StartBotao()
    {
        SceneManager.LoadScene(MN2);
    }
}