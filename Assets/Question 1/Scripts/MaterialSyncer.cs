using UnityEngine;

public class MaterialSyncer : MonoBehaviour
{
    [SerializeField] Material playerOneDefaultMaterial, playerTwoDefaultMaterial;
    Color playerOneDefaultMaterialColor = Color.red;
    Color playerTwoDefaultMaterialColor = Color.blue;
    [SerializeField] Material playerOneUIMaterial, playerTwoUIMaterial;

    void Start()
    {
        playerOneDefaultMaterial.SetColor("_Color", playerOneDefaultMaterialColor);
        playerTwoDefaultMaterial.SetColor("_Color", playerTwoDefaultMaterialColor);
        SyncMaterialColours();
    }

    public void SyncMaterialColours()
    {
        playerOneUIMaterial.SetColor("_Color", playerOneDefaultMaterial.color);
        playerTwoUIMaterial.SetColor("_Color", playerTwoDefaultMaterial.color);
    }

    public void ChangeMaterialColour(Team teamColourToChange, Color newColour)
    {
        switch (teamColourToChange)
        {
            case Team.One:
                playerOneDefaultMaterial.SetColor("_Color", newColour);
                break;
            case Team.Two:
                playerTwoDefaultMaterial.SetColor("_Color", newColour);
                break;
            default:
                break;
        }
        SyncMaterialColours();
    }
}
