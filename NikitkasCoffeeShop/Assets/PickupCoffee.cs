using TMPro;
using UnityEngine;
using Player;

public class PickupCoffee : MonoBehaviour
{
	[SerializeField] GameObject player;
	Transform playersHand;

	[SerializeField] GameObject textObject;

	bool picked = false;

	private void Awake()
	{
		playersHand = player.GetComponent<PlayerMovement>().hand;
	}

	void OnMouseOver()
	{
		if (player)
		{
			float dist = Vector3.Distance(player.transform.position, transform.position);
			if (dist < 5)
			{
				if (picked == false)
				{
					ShowCanPickUp();
					if (Input.GetMouseButtonDown(0))
						PickUp();
				}
			}
		}
	}

	private void OnMouseExit()
	{
		HideCanPickUp();
	}

	void HideCanPickUp()
	{
		textObject.SetActive(false);
	}

	void ShowCanPickUp()
	{
		textObject.SetActive(true);
	}

	void PickUp()
	{
		HideCanPickUp();
		Instantiate(gameObject, playersHand.transform.position, playersHand.transform.rotation, playersHand).GetComponent<PickupCoffee>().picked = true;
		Destroy(gameObject);
	}

	public void ThrowAway()
	{
		picked = false;
		Destroy(gameObject);
	}
}
