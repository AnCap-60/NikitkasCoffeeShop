using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	[SerializeField] GameObject menuPanel;
	[SerializeField] GameObject helpPanel;

	private void Awake()
	{
		menuPanel.SetActive(true);
		helpPanel.SetActive(false);
	}

	public void Play()
	{
		SceneManager.LoadScene("CoffeeShop1");
	}

	public void ShowHelp()
	{
		menuPanel.SetActive(false);
		helpPanel.SetActive(true);
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void HideHelp()
	{
		helpPanel.SetActive(false);
		menuPanel.SetActive(true);
	}
}
