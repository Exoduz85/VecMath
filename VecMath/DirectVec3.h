#pragma once

struct DirectVec3{
    float x;
    float y;
    float z;
};

extern "C"
{

    __declspec(dllexport) DirectVec3 * DirectVec3_Create(float x, float y, float z);
    __declspec(dllexport) void DirectVec3_Destroy(DirectVec3 * ptr);

    __declspec(dllexport) void DirectVec3_Add(DirectVec3 * a, const DirectVec3 * b);
    __declspec(dllexport) void DirectVec3_Subtract(DirectVec3 * a, const DirectVec3 * b);
    __declspec(dllexport) void DirectVec3_Scale(DirectVec3 * v, float scalar);
    __declspec(dllexport) float DirectVec3_Magnitude(const DirectVec3 * v);
    __declspec(dllexport) void DirectVec3_Normalize(DirectVec3 * v);
    __declspec(dllexport) float DirectVec3_Dot(const DirectVec3 * a, const DirectVec3 * b);
    __declspec(dllexport) void DirectVec3_Cross(DirectVec3 * result, const DirectVec3 * a, const DirectVec3 * b);
    __declspec(dllexport) void DirectVec3_Reflect(DirectVec3 * v, const DirectVec3 * normal);
    __declspec(dllexport) float DirectVec3_Distance(const DirectVec3 * a, const DirectVec3 * b);
}