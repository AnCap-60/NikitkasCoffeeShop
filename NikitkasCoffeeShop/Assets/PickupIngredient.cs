using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;

public class PickupIngredient : MonoBehaviour
{
    public string localName;
    public Quests.Ingredients ingredient;
    
    [SerializeField] GameObject player;
    private Quests quests;

    [SerializeField] GameObject textObject;
    TMP_Text textMesh;

    bool picked = false;

    private void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        //textObject = GameObject.Find("PickUpIngredientHint");
        if (textObject)
            textMesh = textObject.GetComponent<TMP_Text>();
        quests = player.GetComponent<Quests>();
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
        textMesh.text = $"Нажмите ЛКМ чтобы взять {localName}";
        textObject.SetActive(true);
    }

    void PickUp()
    {
        picked = true;
        HideCanPickUp();
        quests.PickupIngredient(ingredient);
        Destroy(gameObject);
    }
}
