using UnityEngine;
public class LinksIcon : MonoBehaviour
{
    public void URL(string enlace)
    {
        Application.OpenURL(enlace);
    }
}