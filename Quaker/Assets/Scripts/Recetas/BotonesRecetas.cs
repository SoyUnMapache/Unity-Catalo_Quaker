using UnityEngine;
using UnityEngine.UI;

public class BotonesRecetas : MonoBehaviour
{
    /// <summary>
    /// El poup que se mostrará al darle click a alguna receta
    /// </summary>
    public GameObject PopUp;

    /// <summary>
    /// Referencia al objeto que contiene las recetas, para poder ocultar las recetas cuando aprece el popup o mostrar cuando se cierra el mismo
    /// </summary>
    public RectTransform _Recetas;

    /// <summary>
    /// Muestra la receta a la que se dio click
    /// </summary>
    public void MostrarReceta()
    {
        _Recetas.gameObject.SetActive(false);
        PopUp.SetActive(true);
    }

    /// <summary>
    /// Oculta la receta que se está mostrando en ese momento
    /// </summary>
    public void OcultarReceta()
    {
        _Recetas.gameObject.SetActive(true);
        PopUp.SetActive(false);
    }
}
