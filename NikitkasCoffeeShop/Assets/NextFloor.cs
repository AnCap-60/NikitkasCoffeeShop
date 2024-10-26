using UnityEngine;
using UnityEngine.SceneManagement;

public class NextFloor : MonoBehaviour
{
	[SerializeField] GameObject player;

	[SerializeField] GameObject textObject;

	[SerializeField] string nextSceneName;

	void OnMouseOver()
	{
		if (player)
		{
			float dist = Vector3.Distance(player.transform.position, transform.position);
			if (dist < 5)
			{
				ShowCanGo();
				if (Input.GetMouseButtonDown(0))
					Go();
			}
		}
	}

	private void OnMouseExit()
	{
		HideCanGo();
	}

	void HideCanGo()
	{
		textObject.SetActive(false);
	}

	void ShowCanGo()
	{
		textObject.SetActive(true);
	}

	void Go()
	{
		SceneManager.LoadScene(nextSceneName);
	}
}
