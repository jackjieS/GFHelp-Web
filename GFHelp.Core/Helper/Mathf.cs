using System;
using System.Collections.Generic;
using System.Text;


public class Mathf
{
    public static int CeilToIntTest(float f)
    {

        double value = Math.Ceiling((double)f);
        double num = Math.Floor((double)f);
        if ((double)f - num < 0.0001)
        {
            return Convert.ToInt32(num);
        }
        return Convert.ToInt32(value);
    }


    // Token: 0x060047E0 RID: 18400 RVA: 0x001BF65C File Offset: 0x001BD85C
    public static float Sqrt(float f)
    {
        return UnityEngine.Mathf.Sqrt(f);
    }

    // Token: 0x060047E1 RID: 18401 RVA: 0x001BF664 File Offset: 0x001BD864
    public static float Tan(float f)
    {
        return UnityEngine.Mathf.Tan(f);
    }

    // Token: 0x060047E2 RID: 18402 RVA: 0x001BF66C File Offset: 0x001BD86C
    public static float Atan(float f)
    {
        return UnityEngine.Mathf.Atan(f);
    }

    // Token: 0x060047E3 RID: 18403 RVA: 0x001BF674 File Offset: 0x001BD874
    public static float Atan2(float y, float x)
    {
        return UnityEngine.Mathf.Atan2(y, x);
    }

    // Token: 0x060047E4 RID: 18404 RVA: 0x001BF680 File Offset: 0x001BD880
    public static float Abs(float f)
    {
        return UnityEngine.Mathf.Abs(f);
    }

    // Token: 0x060047E5 RID: 18405 RVA: 0x001BF688 File Offset: 0x001BD888
    public static int Abs(int f)
    {
        return UnityEngine.Mathf.Abs(f);
    }

    // Token: 0x060047E6 RID: 18406 RVA: 0x001BF690 File Offset: 0x001BD890
    public static float Sin(float f)
    {
        return UnityEngine.Mathf.Sin(f);
    }

    // Token: 0x060047E7 RID: 18407 RVA: 0x001BF698 File Offset: 0x001BD898
    public static float Asin(float f)
    {
        return UnityEngine.Mathf.Asin(f);
    }

    // Token: 0x060047E8 RID: 18408 RVA: 0x001BF6A0 File Offset: 0x001BD8A0
    public static int ClosestPowerOfTwo(int value)
    {
        return UnityEngine.Mathf.ClosestPowerOfTwo(value);
    }

    // Token: 0x060047E9 RID: 18409 RVA: 0x001BF6A8 File Offset: 0x001BD8A8
    public static float Cos(float f)
    {
        return UnityEngine.Mathf.Cos(f);
    }

    // Token: 0x060047EA RID: 18410 RVA: 0x001BF6B0 File Offset: 0x001BD8B0
    public static float DeltaAngle(float current, float target)
    {
        return UnityEngine.Mathf.DeltaAngle(current, target);
    }

    // Token: 0x060047EB RID: 18411 RVA: 0x001BF6BC File Offset: 0x001BD8BC
    public static bool Approximately(float a, float b)
    {
        return UnityEngine.Mathf.Approximately(a, b);
    }

    // Token: 0x060047EC RID: 18412 RVA: 0x001BF6C8 File Offset: 0x001BD8C8
    public static float Pow(float f, float p)
    {
        return UnityEngine.Mathf.Pow(f, p);
    }

    // Token: 0x060047ED RID: 18413 RVA: 0x001BF6D4 File Offset: 0x001BD8D4
    public static float Min(params float[] values)
    {
        return UnityEngine.Mathf.Min(values);
    }

    // Token: 0x060047EE RID: 18414 RVA: 0x001BF6DC File Offset: 0x001BD8DC
    public static int Min(params int[] values)
    {
        return UnityEngine.Mathf.Min(values);
    }

    // Token: 0x060047EF RID: 18415 RVA: 0x001BF6E4 File Offset: 0x001BD8E4
    public static int Max(params int[] values)
    {
        return UnityEngine.Mathf.Max(values);
    }

    // Token: 0x060047F0 RID: 18416 RVA: 0x001BF6EC File Offset: 0x001BD8EC
    public static float Max(params float[] values)
    {
        return UnityEngine.Mathf.Max(values);
    }

    // Token: 0x060047F1 RID: 18417 RVA: 0x001BF6F4 File Offset: 0x001BD8F4
    public static float Sign(float f)
    {
        return UnityEngine.Mathf.Sign(f);
    }

    // Token: 0x060047F2 RID: 18418 RVA: 0x001BF6FC File Offset: 0x001BD8FC
    public static float Lerp(float a, float b, float t)
    {
        return UnityEngine.Mathf.Lerp(a, b, t);
    }

    // Token: 0x060047F3 RID: 18419 RVA: 0x001BF708 File Offset: 0x001BD908
    public static float LerpAngle(float a, float b, float t)
    {
        return UnityEngine.Mathf.LerpAngle(a, b, t);
    }

    // Token: 0x060047F4 RID: 18420 RVA: 0x001BF714 File Offset: 0x001BD914
    public static float InverseLerp(float a, float b, float t)
    {
        return UnityEngine.Mathf.InverseLerp(a, b, t);
    }

    // Token: 0x060047F5 RID: 18421 RVA: 0x001BF720 File Offset: 0x001BD920
    public static float MoveTowards(float current, float target, float maxDelta)
    {
        return UnityEngine.Mathf.MoveTowards(current, target, maxDelta);
    }

    // Token: 0x060047F6 RID: 18422 RVA: 0x001BF72C File Offset: 0x001BD92C
    public static float SmoothStep(float from, float to, float t)
    {
        return UnityEngine.Mathf.SmoothStep(from, to, t);
    }

    // Token: 0x060047F7 RID: 18423 RVA: 0x001BF738 File Offset: 0x001BD938
    public static float Clamp(float value, float min, float max)
    {
        return UnityEngine.Mathf.Clamp(value, min, max);
    }

    // Token: 0x060047F8 RID: 18424 RVA: 0x001BF744 File Offset: 0x001BD944
    public static int Clamp(int value, int min, int max)
    {
        return UnityEngine.Mathf.Clamp(value, min, max);
    }

    // Token: 0x060047F9 RID: 18425 RVA: 0x001BF750 File Offset: 0x001BD950
    public static float Clamp01(float value)
    {
        return UnityEngine.Mathf.Clamp01(value);
    }

    // Token: 0x060047FA RID: 18426 RVA: 0x001BF758 File Offset: 0x001BD958
    public static float Ceil(float f)
    {
        return UnityEngine.Mathf.Ceil(f);
    }

    // Token: 0x060047FB RID: 18427 RVA: 0x001BF760 File Offset: 0x001BD960
    public static float Floor(float f)
    {
        return UnityEngine.Mathf.Floor(f);
    }

    // Token: 0x060047FC RID: 18428 RVA: 0x001BF768 File Offset: 0x001BD968
    public static int RoundToInt(float f)
    {
        return (int)Math.Round((double)f, MidpointRounding.AwayFromZero);
    }

    // Token: 0x060047FD RID: 18429 RVA: 0x001BF774 File Offset: 0x001BD974
    public static int CeilToInt(float f)
    {
        return UnityEngine.Mathf.CeilToInt(f);
    }

    // Token: 0x060047FE RID: 18430 RVA: 0x001BF77C File Offset: 0x001BD97C
    public static int FloorToInt(float f)
    {
        return UnityEngine.Mathf.FloorToInt(f);
    }

    // Token: 0x04004689 RID: 18057
    public const float Deg2Rad = 0.0174532924f;

    // Token: 0x0400468A RID: 18058
    public const float Infinity = float.PositiveInfinity;

    // Token: 0x0400468B RID: 18059
    public const float NegativeInfinity = float.NegativeInfinity;

    // Token: 0x0400468C RID: 18060
    public const float PI = 3.14159274f;

    // Token: 0x0400468D RID: 18061
    public const float Rad2Deg = 57.29578f;

    // Token: 0x0400468E RID: 18062
    public static readonly float Epsilon;
}

