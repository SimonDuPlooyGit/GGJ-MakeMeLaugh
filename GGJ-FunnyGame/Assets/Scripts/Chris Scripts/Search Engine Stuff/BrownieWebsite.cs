using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownieWebsite : MonoBehaviour
{
    public GameObject Recipe;
    public GameObject Window;

    public void RecipeTab()
    {
        Recipe.SetActive(true);
        Window.SetActive(true);
    }
}
