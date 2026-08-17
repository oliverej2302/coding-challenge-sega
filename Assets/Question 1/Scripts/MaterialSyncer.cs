using UnityEngine;

public class MaterialSyncer : MonoBehaviour
{
    [SerializeField] Material playerOneDefaultMaterial, playerTwoDefaultMaterial;
    [SerializeField] Material playerOneUIMaterial, playerTwoUIMaterial;

    void Start()
    {
        SyncMaterialColours();
    }

    public void SyncMaterialColours()
    {
        playerOneUIMaterial.color = playerOneDefaultMaterial.color;
        playerTwoUIMaterial.color = playerTwoDefaultMaterial.color;
    }
}
