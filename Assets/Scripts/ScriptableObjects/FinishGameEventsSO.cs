using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName ="EventFinishGameScriptableObject",menuName ="Scriptable Objects/Event Finish Game",order =0)]
public class FinishGameEventsSO : ScriptableObject
{
    public Action eventoDeTerminar;



    private void TerminarJuego()
    {
        SceneManager.LoadScene(5);
    }

}
