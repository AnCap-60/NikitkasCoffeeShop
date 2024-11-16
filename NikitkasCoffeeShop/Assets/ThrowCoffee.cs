using UnityEngine;

public class ThrowCoffee : MonoBehaviour
{
	[SerializeField] GameObject player;

	[SerializeField] GameObject textObject;

	private void OnMouseOver()
	{
		if (player)
		{
			float dist = Vector3.Distance(player.transform.position, transform.position);
			if (dist < 5)
			{
				var cup = player.GetComponentInChildren<PickupObject>();
				if (cup != null)
				{
					ShowCanThrow();
					if (Input.GetMouseButtonDown(0))
						ThrowCupFromPlayer(cup);
				}
			}
		}
	}

	private void OnMouseExit()
	{
		HideCanThrow();
	}

	void HideCanThrow()
	{
		textObject.SetActive(false);
	}

	void ShowCanThrow()
	{
		textObject.SetActive(true);
	}

	void ThrowCupFromPlayer(PickupObject cup)
	{
		cup.ThrowAway();
	}
}
