using System;
using UnityEngine;

public static class HabilidadEvents
{
    // Se dispara cuando una habilidad es usada
    public static Action<Portador, int> OnHabilidadUsada;
}
