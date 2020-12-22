using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("List of items sold")]
    [SerializeField] private ShopItem[] shopItems;

    [Header("References")]
    [SerializeField] private Transform shopContainer;
    [SerializeField] private GameObject shopItemPrefab;

    private void Start() 
    {
        PopulateShop();
    }

    private void PopulateShop()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            ShopItem si = shopItems[i];
            GameObject itemObject = Instantiate(shopItemPrefab, shopContainer);

            itemObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnButtonClick(si));

            itemObject.GetComponent<Image>().color = si.backgroundColor; // This is where the background color is
            itemObject.GetComponent<TextMeshProUGUI>().text = si.name; // This is where the name/text place holder for name is
            itemObject.GetComponent<Image>().sprite = si.sprite; // This is where the image of the button is to show the character that the user will buy
        }
    }

    private void OnButtonClick(ShopItem item)
    {
        // Once the user clicks the button then get the coins from them
        // Then Unlock it for them
        // Automatically use the character
    }
}