using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Representa una duración calculada (años, meses, días)
/// </summary>
public class DuracionCalculada
{
    public int Anios { get; set; }
    public int Meses { get; set; }
    public int Dias { get; set; }

    public override string ToString()
    {
        return string.Format("{0} años, {1} meses, {2} días", Anios, Meses, Dias);
    }
}

/// <summary>
/// Utilidad para calcular duración total de uno o más períodos
/// uniendo períodos solapados (para no contar doble si el candidato
/// trabajó en 2 lugares al mismo tiempo).
/// </summary>
public static class CalculadoraExperiencia
{
    public static DuracionCalculada Calcular(List<Tuple<DateTime, DateTime>> periodos)
    {
        if (periodos == null || periodos.Count == 0)
            return new DuracionCalculada();

        // 1. Ordenar por fecha de inicio
        var lista = periodos
            .Where(p => p.Item2 >= p.Item1)
            .OrderBy(p => p.Item1)
            .ToList();

        if (lista.Count == 0) return new DuracionCalculada();

        // 2. Unir períodos solapados
        var unidos = new List<Tuple<DateTime, DateTime>>();
        var actual = lista[0];
        for (int i = 1; i < lista.Count; i++)
        {
            if (lista[i].Item1 <= actual.Item2)
            {
                // Solapan → extender
                if (lista[i].Item2 > actual.Item2)
                    actual = Tuple.Create(actual.Item1, lista[i].Item2);
            }
            else
            {
                unidos.Add(actual);
                actual = lista[i];
            }
        }
        unidos.Add(actual);

        // 3. Sumar años/meses/días
        int anios = 0, meses = 0, dias = 0;
        foreach (var p in unidos)
        {
            int d = p.Item2.Day - p.Item1.Day;
            int m = p.Item2.Month - p.Item1.Month;
            int a = p.Item2.Year - p.Item1.Year;

            if (d < 0)
            {
                d += DateTime.DaysInMonth(p.Item1.Year, p.Item1.Month);
                m--;
            }
            if (m < 0)
            {
                m += 12;
                a--;
            }

            anios += a;
            meses += m;
            dias += d;
        }

        // 4. Normalizar (días → meses → años)
        if (dias >= 30)
        {
            meses += dias / 30;
            dias = dias % 30;
        }
        if (meses >= 12)
        {
            anios += meses / 12;
            meses = meses % 12;
        }

        return new DuracionCalculada
        {
            Anios = anios,
            Meses = meses,
            Dias = dias
        };
    }
}