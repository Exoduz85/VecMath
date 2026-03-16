#include "pch.h"
#include "DirectVec3.h"

extern "C"
{
    __declspec(dllexport) DirectVec3 * DirectVec3_Create(float x, float y, float z){
        DirectVec3 * v = new DirectVec3();
        v->x = x;
        v->y = y;
        v->z = z;
        return v;
    }

    __declspec(dllexport) void DirectVec3_Destroy(DirectVec3 * ptr){
        if(ptr){
            delete ptr;
        }
    }

    __declspec(dllexport) void DirectVec3_Add(DirectVec3 * a, const DirectVec3 * b){
        a->x += b->x;
        a->y += b->y;
        a->z += b->z;
    }

    __declspec(dllexport) void DirectVec3_Subtract(DirectVec3 * a, const DirectVec3 * b){
        a->x -= b->x;
        a->y -= b->y;
        a->z -= b->z;
    }

    __declspec(dllexport) void DirectVec3_Scale(DirectVec3 * v, float scalar){
        v->x *= scalar;
        v->y *= scalar;
        v->z *= scalar;
    }

    __declspec(dllexport) float DirectVec3_Magnitude(const DirectVec3 * v){
        return sqrtf(v->x * v->x + v->y * v->y + v->z * v->z);
    }

    __declspec(dllexport) void DirectVec3_Normalize(DirectVec3 * v){
        float mag = DirectVec3_Magnitude(v);
        if(mag > 0.000001f){
            v->x /= mag;
            v->y /= mag;
            v->z /= mag;
        }
    }

    __declspec(dllexport) float DirectVec3_Dot(const DirectVec3 * a, const DirectVec3 * b){
        return a->x * b->x + a->y * b->y + a->z * b->z;
    }

    __declspec(dllexport) void DirectVec3_Cross(DirectVec3 * result, const DirectVec3 * a, const DirectVec3 * b){
        result->x = a->y * b->z - a->z * b->y;
        result->y = a->z * b->x - a->x * b->z;
        result->z = a->x * b->y - a->y * b->x;
    }

    __declspec(dllexport) void DirectVec3_Reflect(DirectVec3 * v, const DirectVec3 * normal){
        float dot = DirectVec3_Dot(v, normal);
        v->x = v->x - 2.0f * dot * normal->x;
        v->y = v->y - 2.0f * dot * normal->y;
        v->z = v->z - 2.0f * dot * normal->z;
    }

    __declspec(dllexport) float DirectVec3_Distance(const DirectVec3 * a, const DirectVec3 * b){
        float dx = a->x - b->x;
        float dy = a->y - b->y;
        float dz = a->z - b->z;
        return sqrtf(dx * dx + dy * dy + dz * dz);
    }
}