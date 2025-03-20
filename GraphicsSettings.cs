using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;



public class GraphicsSettings : MonoBehaviour
{
    public Material Road;
    public Material Grove;
    public Material Tree;
    public Material Tree_1;
    public Material Player;
    public Material New_Material;
    public Material New_Material_1;
    public Material Gold;
    public Material Enemy;
    public Material Photoroom;
    public Material Home;

    public GameObject[] objectsToDisable;
    public void SetLowGraphics()
    {
        QualitySettings.globalTextureMipmapLimit = 2;
        QualitySettings.shadows = ShadowQuality.Disable;
        QualitySettings.antiAliasing = 0;

        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }

        Road.SetFloat("_Glossiness", 0.0f);
        Grove.SetFloat("_Glossiness", 0.0f);
        Tree.SetFloat("_Glossiness", 0.0f);
        Tree_1.SetFloat("_Glossiness", 0.0f);
        Player.SetFloat("_Glossiness", 0.0f);
        New_Material.SetFloat("_Glossiness", 0.0f);
        New_Material_1.SetFloat("_Glossiness", 0.0f);
        Gold.SetFloat("_Glossiness", 0.0f);
        Enemy.SetFloat("_Glossiness", 0.0f);
        Photoroom.SetFloat("_Glossiness", 0.0f);
        Home.SetFloat("_Glossiness", 0.0f);

    }

    public void SetMediumGraphics()
    {
        QualitySettings.globalTextureMipmapLimit = 1;
        QualitySettings.shadows = ShadowQuality.All;
        QualitySettings.shadowResolution = ShadowResolution.Medium;
        QualitySettings.antiAliasing = 2;

        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(true);
            // obj.GameObject.shadows = ShadowQuality.Off;
        }

        Road.SetFloat("_Glossiness", 0.6f);
        Grove.SetFloat("_Glossiness", 0.6f);
        Tree.SetFloat("_Glossiness", 0.6f);
        Tree_1.SetFloat("_Glossiness", 0.6f);
        Player.SetFloat("_Glossiness", 0.6f);
        New_Material.SetFloat("_Glossiness", 0.6f);
        New_Material_1.SetFloat("_Glossiness", 0.6f);
        Gold.SetFloat("_Glossiness", 0.6f);
        Enemy.SetFloat("_Glossiness", 0.6f);
        Photoroom.SetFloat("_Glossiness", 0.6f);
        Home.SetFloat("_Glossiness", 0.6f);

    }
    public void SetHighGraphics()
    {
        QualitySettings.globalTextureMipmapLimit = 0;
        QualitySettings.shadows = ShadowQuality.All;
        QualitySettings.shadowResolution = ShadowResolution.High;
        QualitySettings.antiAliasing = 4;


        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(true);
        }

        Road.SetFloat("_Glossiness", 0.6f);
        Grove.SetFloat("_Glossiness", 0.6f);
        Tree.SetFloat("_Glossiness", 0.6f);
        Tree_1.SetFloat("_Glossiness", 0.6f);
        Player.SetFloat("_Glossiness", 0.6f);
        New_Material.SetFloat("_Glossiness", 0.6f);
        New_Material_1.SetFloat("_Glossiness", 0.6f);
        Gold.SetFloat("_Glossiness", 0.6f);
        Enemy.SetFloat("_Glossiness", 0.6f);
        Photoroom.SetFloat("_Glossiness", 0.6f);
        Home.SetFloat("_Glossiness", 0.6f);

    }
}