using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;


public class ApiPokemon : MonoBehaviour
{
    private const string BaseURL = "https://pokeapi.co/api/v2/pokemon/";
    private const string UrlApi2 = "https://pokebuildapi.fr/api/v1/pokemon/";
    private const string BaseUrlPng = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/";

    private string UrlType;

    public PokeDatabase database;

    public Sprite ImageApi;
    public Sprite ImageType;


    public IEnumerator AddApiPoke(int pokemonNum)
    {
        string url = BaseURL + pokemonNum.ToString();
        string urlApi2 = UrlApi2 + pokemonNum.ToString();
        string urlPng = BaseUrlPng + pokemonNum.ToString() + ".png";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        using (UnityWebRequest webRequestApi2 = UnityWebRequest.Get(urlApi2))
        using (UnityWebRequest webRequestPng = UnityWebRequestTexture.GetTexture(urlPng))
        {
            yield return webRequest.SendWebRequest();
            yield return webRequestApi2.SendWebRequest();
            yield return webRequestPng.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success && webRequestPng.result == UnityWebRequest.Result.Success && webRequestApi2.result == UnityWebRequest.Result.Success)
            {
                string jsonResult = webRequest.downloadHandler.text;
                PokeData pokemon = JsonUtility.FromJson<PokeData>(jsonResult);

                //Récuperer l'image à l'adresse et la transfomer un sprite
                Texture2D texture = ((DownloadHandlerTexture)webRequestPng.downloadHandler).texture;
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());
                ImageApi = sprite;

                //"sauvarge" des données taille et poids
                float taille = pokemon.weight;
                float poids = pokemon.height;

                string jsonResultApi2 = webRequestApi2.downloadHandler.text;
                pokemon = JsonUtility.FromJson<PokeData>(jsonResultApi2);

                //Ré-attribuer les données sauvargé avant
                pokemon.weight = taille;
                pokemon.height = poids;
                pokemon.icon = ImageApi;


                UrlType = pokemon.apiTypes[0].image;
                StartCoroutine(LoadImgType(UrlType));
                pokemon.apiTypes[0].icon = ImageType;

                //Ajouter le pokemon à la base de données
                database.data.Add(pokemon);

            }
            else
            {
                Debug.LogError("Erreur lors de la requête : " + webRequest.error);
            }
        }
    }

    public IEnumerator LoadImgType(string url)
    {
        using (UnityWebRequest webRequestImgType = UnityWebRequestTexture.GetTexture(url))
        {
            yield return webRequestImgType.SendWebRequest();

            if (webRequestImgType.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Erreur de téléchargement de l'image: " + webRequestImgType.error);
            }
            else
            {
                Texture2D texture = ((DownloadHandlerTexture)webRequestImgType.downloadHandler).texture;
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());
                ImageType = sprite;
            }
        }
    }
}
