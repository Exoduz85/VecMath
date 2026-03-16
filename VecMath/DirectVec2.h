#pragma once

struct DirectVec2{ 
	float x; 
	float y;
};

extern "C" 
{
	__declspec(dllexport) DirectVec2 * DirectVec2_Create(float x, float y);
	__declspec(dllexport) void DirectVec2_Destroy(DirectVec2 * ptr);

	__declspec(dllexport) void DirectVec2_Add(DirectVec2 * a, const DirectVec2 * b);
	__declspec(dllexport) void DirectVec2_Subtract(DirectVec2 * a, const DirectVec2 * b);
	__declspec(dllexport) void DirectVec2_Scale(DirectVec2 * v, float scalar);
	__declspec(dllexport) float DirectVec2_Magnitude(const DirectVec2 * v);
	__declspec(dllexport) void DirectVec2_Normalize(DirectVec2 * v);
	__declspec(dllexport) float DirectVec2_Dot(const DirectVec2 * a, const DirectVec2 * b);
	__declspec(dllexport) void DirectVec2_Reflect(DirectVec2 * v, const DirectVec2 * normal);
	__declspec(dllexport) float DirectVec2_Distance(const DirectVec2 * a, const DirectVec2 * b);
}