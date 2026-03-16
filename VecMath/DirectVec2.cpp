#include "pch.h"
#include "DirectVec2.h"

extern "C"
{
    __declspec(dllexport) DirectVec2 * DirectVec2_Create(float x, float y){
        DirectVec2 * v = new DirectVec2();
        v->x = x;
        v->y = y;
        return v;
    }

    __declspec(dllexport) void DirectVec2_Destroy(DirectVec2 * ptr){
        if(ptr){
            delete ptr;
        }
    }

    __declspec(dllexport) void DirectVec2_Add(DirectVec2 * a, const DirectVec2 * b){
        a->x += b->x;
        a->y += b->y;
    }

    __declspec(dllexport) void DirectVec2_Subtract(DirectVec2 * a, const DirectVec2 * b){
        a->x -= b->x;
        a->y -= b->y;
    }

    __declspec(dllexport) void DirectVec2_Scale(DirectVec2 * v, float scalar){
        v->x *= scalar;
        v->y *= scalar;
    }

    __declspec(dllexport) float DirectVec2_Magnitude(const DirectVec2 * v){
        return sqrtf(v->x * v->x + v->y * v->y);
    }

    __declspec(dllexport) void DirectVec2_Normalize(DirectVec2 * v){
        float mag = DirectVec2_Magnitude(v);
        if(mag > 0.000001f){
            v->x /= mag;
            v->y /= mag;
        }
    }

    __declspec(dllexport) float DirectVec2_Dot(const DirectVec2 * a, const DirectVec2 * b){
        return a->x * b->x + a->y * b->y;
    }

    __declspec(dllexport) void DirectVec2_Reflect(DirectVec2 * v, const DirectVec2 * normal){
        float dot = DirectVec2_Dot(v, normal);
        v->x = v->x - 2.0f * dot * normal->x;
        v->y = v->y - 2.0f * dot * normal->y;
    }

    __declspec(dllexport) float DirectVec2_Distance(const DirectVec2 * a, const DirectVec2 * b){
        float dx = a->x - b->x;
        float dy = a->y - b->y;
        return sqrtf(dx * dx + dy * dy);
    }
}