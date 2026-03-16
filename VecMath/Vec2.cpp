#include "pch.h"
#include "Vec2.h"

extern "C"
{
    __declspec(dllexport) void Vec2_Add(const Vec2 * a, const Vec2 * b, Vec2 * result){
        result->x = a->x + b->x;
        result->y = a->y + b->y;
    }

    __declspec(dllexport) void Vec2_Subtract(const Vec2 * a, const Vec2 * b, Vec2 * result){
        result->x = a->x - b->x;
        result->y = a->y - b->y;
    }

    __declspec(dllexport) void Vec2_Scale(const Vec2 * v, float scalar, Vec2 * result){
        result->x = v->x * scalar;
        result->y = v->y * scalar;
    }

    __declspec(dllexport) float Vec2_Magnitude(const Vec2 * v){
        return sqrtf(v->x * v->x + v->y * v->y);
    }

    __declspec(dllexport) float Vec2_MagnitudeSquared(const Vec2 * v){
        return v->x * v->x + v->y * v->y;
    }

    __declspec(dllexport) void Vec2_Normalize(const Vec2 * v, Vec2 * result){
        float mag = Vec2_Magnitude(v);
        if(mag > 0.000001f){
            result->x = v->x / mag;
            result->y = v->y / mag;
        } else{
            result->x = 0.0f;
            result->y = 0.0f;
        }
    }

    __declspec(dllexport) float Vec2_Dot(const Vec2 * a, const Vec2 * b){
        return a->x * b->x + a->y * b->y;
    }

    __declspec(dllexport) void Vec2_Reflect(const Vec2 * direction, const Vec2 * normal, Vec2 * result){
        float dot = Vec2_Dot(direction, normal);
        result->x = direction->x - 2.0f * dot * normal->x;
        result->y = direction->y - 2.0f * dot * normal->y;
    }

    __declspec(dllexport) float Vec2_Distance(const Vec2 * a, const Vec2 * b){
        float dx = a->x - b->x;
        float dy = a->y - b->y;
        return sqrtf(dx * dx + dy * dy);
    }

    __declspec(dllexport) float Vec2_DistanceSquared(const Vec2 * a, const Vec2 * b){
        float dx = a->x - b->x;
        float dy = a->y - b->y;
        return dx * dx + dy * dy;
    }

    __declspec(dllexport) void Vec2_Lerp(const Vec2 * start, const Vec2 * end, float t, Vec2 * result){
        t = std::max(0.0f, std::min(1.0f, t));

        result->x = start->x + (end->x - start->x) * t;
        result->y = start->y + (end->y - start->y) * t;
    }

    __declspec(dllexport) void Vec2_ClampMagnitude(const Vec2 * v, float maxLength, Vec2 * result){
        float mag = Vec2_Magnitude(v);
        if(mag > maxLength && mag > 0.000001f){
            float scale = maxLength / mag;
            result->x = v->x * scale;
            result->y = v->y * scale;
        } else{
            result->x = v->x;
            result->y = v->y;
        }
    }

    __declspec(dllexport) float Vec2_AngleBetween(const Vec2 * a, const Vec2 * b){
        float dot = Vec2_Dot(a, b);
        float magA = Vec2_Magnitude(a);
        float magB = Vec2_Magnitude(b);

        float mags = magA * magB;
        if(mags < 0.000001f) return 0.0f;

        float cosAngle = dot / mags;
        cosAngle = std::max(-1.0f, std::min(1.0f, cosAngle));

        return acosf(cosAngle);
    }
}