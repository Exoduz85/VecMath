#include "pch.h"
#include "Vec3.h"

extern "C"
{
    __declspec(dllexport) void Vec3_Add(const Vec3 * a, const Vec3 * b, Vec3 * result){
        result->x = a->x + b->x;
        result->y = a->y + b->y;
        result->z = a->z + b->z;
    }

    __declspec(dllexport) void Vec3_Subtract(const Vec3 * a, const Vec3 * b, Vec3 * result){
        result->x = a->x - b->x;
        result->y = a->y - b->y;
        result->z = a->z - b->z;
    }

    __declspec(dllexport) void Vec3_Scale(const Vec3 * v, float scalar, Vec3 * result){
        result->x = v->x * scalar;
        result->y = v->y * scalar;
        result->z = v->z * scalar;
    }

    __declspec(dllexport) float Vec3_Magnitude(const Vec3 * v){
        return sqrtf(v->x * v->x + v->y * v->y + v->z * v->z);
    }

    __declspec(dllexport) float Vec3_MagnitudeSquared(const Vec3 * v){
        return v->x * v->x + v->y * v->y + v->z * v->z;
    }

    __declspec(dllexport) void Vec3_Normalize(const Vec3 * v, Vec3 * result){
        float mag = Vec3_Magnitude(v);
        if(mag > 0.000001f){
            result->x = v->x / mag;
            result->y = v->y / mag;
            result->z = v->z / mag;
        } else{
            result->x = 0.0f;
            result->y = 0.0f;
            result->z = 0.0f;
        }
    }

    __declspec(dllexport) float Vec3_Dot(const Vec3 * a, const Vec3 * b){
        return a->x * b->x + a->y * b->y + a->z * b->z;
    }

    __declspec(dllexport) void Vec3_Cross(const Vec3 * a, const Vec3 * b, Vec3 * result){
        result->x = a->y * b->z - a->z * b->y;
        result->y = a->z * b->x - a->x * b->z;
        result->z = a->x * b->y - a->y * b->x;
    }

    __declspec(dllexport) void Vec3_Reflect(const Vec3 * direction, const Vec3 * normal, Vec3 * result){
        float dot = Vec3_Dot(direction, normal);
        result->x = direction->x - 2.0f * dot * normal->x;
        result->y = direction->y - 2.0f * dot * normal->y;
        result->z = direction->z - 2.0f * dot * normal->z;
    }

    __declspec(dllexport) float Vec3_Distance(const Vec3 * a, const Vec3 * b){
        float dx = a->x - b->x;
        float dy = a->y - b->y;
        float dz = a->z - b->z;
        return sqrtf(dx * dx + dy * dy + dz * dz);
    }

    __declspec(dllexport) float Vec3_DistanceSquared(const Vec3 * a, const Vec3 * b){
        float dx = a->x - b->x;
        float dy = a->y - b->y;
        float dz = a->z - b->z;
        return dx * dx + dy * dy + dz * dz;
    }

    __declspec(dllexport) void Vec3_Lerp(const Vec3 * start, const Vec3 * end, float t, Vec3 * result){
        t = std::max(0.0f, std::min(1.0f, t));

        result->x = start->x + (end->x - start->x) * t;
        result->y = start->y + (end->y - start->y) * t;
        result->z = start->z + (end->z - start->z) * t;
    }

    __declspec(dllexport) void Vec3_Slerp(const Vec3 * start, const Vec3 * end, float t, Vec3 * result){
        t = std::max(0.0f, std::min(1.0f, t));

        float dot = Vec3_Dot(start, end);
        dot = std::max(-1.0f, std::min(1.0f, dot));

        float theta = acosf(dot) * t;

        Vec3 relative;
        relative.x = end->x - start->x * dot;
        relative.y = end->y - start->y * dot;
        relative.z = end->z - start->z * dot;

        Vec3 normalizedRelative;
        Vec3_Normalize(&relative, &normalizedRelative);

        float cosTheta = cosf(theta);
        float sinTheta = sinf(theta);

        result->x = start->x * cosTheta + normalizedRelative.x * sinTheta;
        result->y = start->y * cosTheta + normalizedRelative.y * sinTheta;
        result->z = start->z * cosTheta + normalizedRelative.z * sinTheta;
    }

    __declspec(dllexport) void Vec3_ClampMagnitude(const Vec3 * v, float maxLength, Vec3 * result){
        float mag = Vec3_Magnitude(v);
        if(mag > maxLength && mag > 0.000001f){
            float scale = maxLength / mag;
            result->x = v->x * scale;
            result->y = v->y * scale;
            result->z = v->z * scale;
        } else{
            result->x = v->x;
            result->y = v->y;
            result->z = v->z;
        }
    }

    __declspec(dllexport) float Vec3_AngleBetween(const Vec3 * a, const Vec3 * b){
        float dot = Vec3_Dot(a, b);
        float magA = Vec3_Magnitude(a);
        float magB = Vec3_Magnitude(b);

        float mags = magA * magB;
        if(mags < 0.000001f) return 0.0f;

        float cosAngle = dot / mags;
        cosAngle = std::max(-1.0f, std::min(1.0f, cosAngle));

        return acosf(cosAngle);
    }
}