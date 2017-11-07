using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System;

public class SceneControl : MonoBehaviour
{
    /// <summary>
    /// Canvas del Screen Saver
    /// </summary>
    public Canvas _canvasScreenSaver;

    /// <summary>
    /// Canvas de la pantalla principal
    /// </summary>
    public Canvas _canvasMain;

    /// <summary>
    /// Canvas de la pantalla de recetas
    /// </summary>
    public Canvas _canvasRecetas;

    /// <summary>
    /// Canvas de la pantalla de recetas
    /// </summary>
    public Canvas _canvasBeneficios;

    /// <summary>
    /// Canvas de la pantalla de recetas
    /// </summary>
    public Canvas _canvasRazones;

    /// <summary>
    /// Referencia al swipe de la escena recetas
    /// </summary>
    public RectTransform _SwipeRecetas;

    /// <summary>
    /// El objeto que reproduce el video
    /// </summary>
    public GameObject videoPlayer;

    /// <summary>
    /// Referencia al video de beneficios
    /// </summary>
    public VideoClip videoBeneficios;

    /// <summary>
    /// Referencia al video de 9 razones
    /// </summary>
    public VideoClip videoRazones;

    /// <summary>
    /// Referencia al video de screen saver
    /// </summary>
    public VideoClip[] videoScreenSaver;

    /// <summary>
    /// Posición minima del swipe, esto para que cuando cambien de escena y regresen a productos el swipe resetie su posición
    /// </summary>
    Vector2 offsetMaxRecetas;

    /// <summary>
    /// Posición maxima del swipe, esto para que cuando cambien de escena y regresen a productos el swipe resetie su posición
    /// </summary>
    Vector2 offsetMinRecetas;

    /// <summary>
    /// Tiempo que tarda en regresar al screen saver cuando no hay ninguna acción
    /// </summary>
    float regresarScreenSaver = 90.0f;

    /// <summary>
    /// Almacena el año y el mes en el que estamos
    /// </summary>
    int month, year;

    private void Start()
    {
        month = int.Parse(DateTime.Now.ToString("MM"));
        year = int.Parse(DateTime.Now.ToString("yyyy"));
        if ((month >= 9 && year == 2018) || (month >= 1 && year > 2018))
            videoPlayer.GetComponent<VideoPlayer>().clip = videoScreenSaver[1];
        else
            videoPlayer.GetComponent<VideoPlayer>().clip = videoScreenSaver[0];

        videoPlayer.GetComponent<VideoPlayer>().Play();

        offsetMinRecetas = _SwipeRecetas.offsetMin;
        offsetMaxRecetas = _SwipeRecetas.offsetMax;
        InvokeRepeating("backScreenSaver", 0, 1);
    }

    private void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
                regresarScreenSaver = 90.0f;
        }
    }

    /// <summary>
    /// Botón para cambiar el canvas a beneficios
    /// </summary>
    public void btnBeneficios()
    {
        videoPlayer.transform.localPosition = new Vector3(0.0f, -0.85f, 0.0f);
        videoPlayer.transform.localScale = new Vector3(1.34f, 1.0f, 1.0f);
        videoPlayer.SetActive(true);
        videoPlayer.GetComponent<VideoPlayer>().clip = videoBeneficios;

        _canvasRecetas.transform.GetChild(0).gameObject.SetActive(true);
        for (int i = 0; i < _canvasRecetas.transform.GetChild(1).childCount; i++)
            _canvasRecetas.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);

        _canvasMain.gameObject.SetActive(false);
        _canvasScreenSaver.gameObject.SetActive(false);
        _canvasRecetas.gameObject.SetActive(false);
        _canvasRazones.gameObject.SetActive(false);
        _canvasBeneficios.gameObject.SetActive(true);
        regresarScreenSaver = 90.0f;
    }

    /// <summary>
    /// Botón para cambiar el canvas a 9 razones
    /// </summary>
    public void btnRazones()
    {
        videoPlayer.transform.localPosition = new Vector3(0.0f, -0.4f, 0.0f);
        videoPlayer.transform.localScale = new Vector3(1.34f, 1.0f, 1.0f);
        videoPlayer.SetActive(true);
        videoPlayer.GetComponent<VideoPlayer>().clip = videoRazones;

        _canvasRecetas.transform.GetChild(0).gameObject.SetActive(true);
        for (int i = 0; i < _canvasRecetas.transform.GetChild(1).childCount; i++)
            _canvasRecetas.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);

        _canvasMain.gameObject.SetActive(false);
        _canvasScreenSaver.gameObject.SetActive(false);
        _canvasRecetas.gameObject.SetActive(false);
        _canvasBeneficios.gameObject.SetActive(false);
        _canvasRazones.gameObject.SetActive(true);
        regresarScreenSaver = 90.0f;
    }

    /// <summary>
    /// Botón para cambiar el canvas a recetas
    /// </summary>
    public void btnRecetas()
    {
        _SwipeRecetas.offsetMin = offsetMinRecetas;
        _SwipeRecetas.offsetMax = offsetMaxRecetas;

        videoPlayer.SetActive(false);
        _canvasMain.gameObject.SetActive(false);
        _canvasScreenSaver.gameObject.SetActive(false);
        _canvasRecetas.gameObject.SetActive(true);
        _canvasBeneficios.gameObject.SetActive(false);
        _canvasRazones.gameObject.SetActive(false);
        regresarScreenSaver = 90.0f;
    }

    /// <summary>
    /// Botón para cambiar el canvas a main
    /// </summary>
    public void btnMain()
    {
        _canvasRecetas.transform.GetChild(0).gameObject.SetActive(true);
        for (int i = 0; i < _canvasRecetas.transform.GetChild(1).childCount; i++)
            _canvasRecetas.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);

        videoPlayer.SetActive(false);
        _canvasMain.gameObject.SetActive(true);
        _canvasScreenSaver.gameObject.SetActive(false);
        _canvasRecetas.gameObject.SetActive(false);
        _canvasBeneficios.gameObject.SetActive(false);
        _canvasRazones.gameObject.SetActive(false);
        regresarScreenSaver = 90.0f;
    }

    /// <summary>
    /// Regresa al screen saver
    /// </summary>
    void screenSaver()
    {
        _canvasRecetas.transform.GetChild(0).gameObject.SetActive(true);
        for (int i = 0; i < _canvasRecetas.transform.GetChild(1).childCount; i++)
            _canvasRecetas.transform.GetChild(1).GetChild(i).gameObject.SetActive(false);

        videoPlayer.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        videoPlayer.transform.localScale = new Vector3(1.34f, 1, 1);
        videoPlayer.SetActive(true);

        if (month >= 9 && year >= 2018 || (month >= 1 && year > 2018))
            videoPlayer.GetComponent<VideoPlayer>().clip = videoScreenSaver[1];
        else
            videoPlayer.GetComponent<VideoPlayer>().clip = videoScreenSaver[0];

        _canvasMain.gameObject.SetActive(false);
        _canvasScreenSaver.gameObject.SetActive(true);
        _canvasRecetas.gameObject.SetActive(false);
        _canvasBeneficios.gameObject.SetActive(false);
        _canvasRazones.gameObject.SetActive(false);
    }

    void backScreenSaver()
    {
        if (regresarScreenSaver > 0 && !_canvasScreenSaver.isActiveAndEnabled)
            regresarScreenSaver--;
        else if (!_canvasScreenSaver.isActiveAndEnabled)
            screenSaver();
    }
}
