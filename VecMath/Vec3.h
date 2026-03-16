#pragma once

extern "C"
{
    typedef struct Vec3{
        float x;
        float y;
        float z;
    } Vec3;

    __declspec(dllexport) void Vec3_Add(const Vec3 * a, const Vec3 * b, Vec3 * result);
    __declspec(dllexport) void Vec3_Subtract(const Vec3 * a, const Vec3 * b, Vec3 * result);
    __declspec(dllexport) void Vec3_Scale(const Vec3 * v, float scalar, Vec3 * result);
    __declspec(dllexport) float Vec3_Magnitude(const Vec3 * v);
    __declspec(dllexport) float Vec3_MagnitudeSquared(const Vec3 * v);
    __declspec(dllexport) void Vec3_Normalize(const Vec3 * v, Vec3 * result);
    __declspec(dllexport) float Vec3_Dot(const Vec3 * a, const Vec3 * b);
    __declspec(dllexport) void Vec3_Cross(const Vec3 * a, const Vec3 * b, Vec3 * result);
    __declspec(dllexport) void Vec3_Reflect(const Vec3 * direction, const Vec3 * normal, Vec3 * result);
    __declspec(dllexport) float Vec3_Distance(const Vec3 * a, const Vec3 * b);
    __declspec(dllexport) float Vec3_DistanceSquared(const Vec3 * a, const Vec3 * b);
    __declspec(dllexport) void Vec3_Lerp(const Vec3 * start, const Vec3 * end, float t, Vec3 * result);
    __declspec(dllexport) void Vec3_Slerp(const Vec3 * start, const Vec3 * end, float t, Vec3 * result);
    __declspec(dllexport) void Vec3_ClampMagnitude(const Vec3 * v, float maxLength, Vec3 * result);
    __declspec(dllexport) float Vec3_AngleBetween(const Vec3 * a, const Vec3 * b);
}