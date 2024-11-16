using Player;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
	public string localName;
	
	public GameObject player;
	public Transform playersHand;
	public GameObject textObject;
	private bool picked = false;
	
	private void Awake()
	{
		if (player)
			playersHand = player.GetComponent<PlayerMovement>().hand;
	}

	private void OnMouseOver()
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

	private void HideCanPickUp()
	{
		if (textObject)
			textObject.SetActive(false);
	}

	private void ShowCanPickUp()
	{
		textObject.SetActive(true);
	}

	public void PickUp()
	{
		playersHand = player.GetComponent<PlayerMovement>().hand;
		HideCanPickUp();
		var obj = Object.Instantiate(gameObject, playersHand.transform.position, playersHand.transform.rotation, playersHand);
		obj.GetComponent<PickupObject>().picked = true;
		Object.Destroy(gameObject);
	}

	public void ThrowAway()
	{
		picked = false;
		Object.Destroy(gameObject);
	}
}