using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

public class Quests : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    
    private GameObject buterContainer;
    
    private GameObject coffeeContainer;
    
    [SerializeField] private GameObject buterPrefab;
    [SerializeField] private GameObject coffeePrefab;

    [Flags]
    public enum Ingredients
    {
        Bread = 1,
        Cheese = 2,
        Sausage = 4,
        CoffeeBeans = 8,
        Milk = 16,
        Sugar = 32
    }

    public Dictionary<Ingredients, bool> buterIngridients =
        ((Ingredients[])Enum.GetValues(typeof(Ingredients))).Where(i => i <= Ingredients.Sausage)
        .ToDictionary(k => k, v => false);

    public Dictionary<Ingredients, bool> coffeeIngridients =
        ((Ingredients[])Enum.GetValues(typeof(Ingredients))).Where(i => i >= Ingredients.CoffeeBeans)
        .ToDictionary(k => k, v => false);

    private void Awake()
    {
        buterContainer = canvas.transform.Find("ButerProgress").gameObject;
        coffeeContainer = canvas.transform.Find("CoffeeProgress").gameObject;
        
        ActivateCoffeeQuest();
    }

    public void ActivateButerQuest()
    {
        coffeeContainer.SetActive(false);
        buterContainer.SetActive(true);
    }

    public void ActivateCoffeeQuest()
    {
        buterContainer.SetActive(false);
        coffeeContainer.SetActive(true);
    }

    public void CompleteButerQuest()
    {
        buterContainer.SetActive(false);

        var alreadyPicked = GetComponentInChildren<PickupObject>();
        if (alreadyPicked)
            alreadyPicked.ThrowAway();
        
        var buter = Object.Instantiate(buterPrefab).GetComponent<PickupButer>();
        buter.player = gameObject;
        buter.PickUp();
    }

    public void CompleteCoffeeQuest()
    {
        coffeeContainer.SetActive(false);

        var coffee = Object.Instantiate(coffeePrefab).GetComponent<PickupCoffee>();
        coffee.player = gameObject;
        coffee.PickUp();
        
        ActivateButerQuest();
    }

    public void PickupIngredient(Ingredients ingredient)
    {
        if (buterIngridients.ContainsKey(ingredient))
            buterIngridients[ingredient] = true;
        else
            coffeeIngridients[ingredient] = true;
        
        if (buterIngridients.Values.All(i => i))
            CompleteButerQuest();
        else if (coffeeIngridients.Values.All(i => i))
            CompleteCoffeeQuest();
        
        var ingr = canvas.transform.Find((ingredient < Ingredients.CoffeeBeans ? "Buter" : "Coffee")
            + "Progress/" + ingredient.ToString());
        ingr.gameObject.SetActive(false);
    }
}