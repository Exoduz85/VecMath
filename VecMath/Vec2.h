#pragma once

extern "C"
{
    typedef struct Vec2{
        float x;
        float y;
    } Vec2;

    __declspec(dllexport) void Vec2_Add(const Vec2 * a, const Vec2 * b, Vec2 * result);
    __declspec(dllexport) void Vec2_Subtract(const Vec2 * a, const Vec2 * b, Vec2 * result);
    __declspec(dllexport) void Vec2_Scale(const Vec2 * v, float scalar, Vec2 * result);
    __declspec(dllexport) float Vec2_Magnitude(const Vec2 * v);
    __declspec(dllexport) float Vec2_MagnitudeSquared(const Vec2 * v);
    __declspec(dllexport) void Vec2_Normalize(const Vec2 * v, Vec2 * result);
    __declspec(dllexport) float Vec2_Dot(const Vec2 * a, const Vec2 * b);
    __declspec(dllexport) void Vec2_Reflect(const Vec2 * direction, const Vec2 * normal, Vec2 * result);
    __declspec(dllexport) float Vec2_Distance(const Vec2 * a, const Vec2 * b);
    __declspec(dllexport) float Vec2_DistanceSquared(const Vec2 * a, const Vec2 * b);
    __declspec(dllexport) void Vec2_Lerp(const Vec2 * start, const Vec2 * end, float t, Vec2 * result);
    __declspec(dllexport) void Vec2_ClampMagnitude(const Vec2 * v, float maxLength, Vec2 * result);
    __declspec(dllexport) float Vec2_AngleBetween(const Vec2 * a, const Vec2 * b);
}
