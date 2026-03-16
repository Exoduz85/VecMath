#pragma once

#include "Vec2.h"
#include <iostream>
#include <cmath>
#include <string>

class Vec2Tests{
private:
    int totalTests;
    int passedTests;

    bool ApproximatelyEqual(float a, float b, float epsilon = 0.0001f){
        return fabsf(a - b) < epsilon;
    }

    bool ApproximatelyEqual(const Vec2 & a, const Vec2 & b, float epsilon = 0.0001f){
        return ApproximatelyEqual(a.x, b.x, epsilon) &&
            ApproximatelyEqual(a.y, b.y, epsilon);
    }

    void LogTest(const std::string & testName, bool passed){
        totalTests++;
        if(passed){
            passedTests++;
            std::cout << "  [PASS] " << testName << std::endl;
        } else{
            std::cout << "  [FAIL] " << testName << std::endl;
        }
    }

    void Test_Add(){
        Vec2 a = {3.0f, 4.0f};
        Vec2 b = {1.0f, 2.0f};
        Vec2 expected = {4.0f, 6.0f};
        Vec2 result;

        Vec2_Add(&a, &b, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Add", passed);
    }

    void Test_Subtract(){
        Vec2 a = {5.0f, 7.0f};
        Vec2 b = {2.0f, 3.0f};
        Vec2 expected = {3.0f, 4.0f};
        Vec2 result;

        Vec2_Subtract(&a, &b, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Subtract", passed);
    }

    void Test_Scale(){
        Vec2 v = {3.0f, 4.0f};
        float scalar = 2.0f;
        Vec2 expected = {6.0f, 8.0f};
        Vec2 result;

        Vec2_Scale(&v, scalar, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Scale", passed);
    }

    void Test_Magnitude(){
        Vec2 v = {3.0f, 4.0f};
        float expected = 5.0f;

        float result = Vec2_Magnitude(&v);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Magnitude", passed);
    }

    void Test_MagnitudeSquared(){
        Vec2 v = {3.0f, 4.0f};
        float expected = 25.0f;

        float result = Vec2_MagnitudeSquared(&v);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("MagnitudeSquared", passed);
    }

    void Test_Normalize(){
        Vec2 v = {3.0f, 4.0f};
        Vec2 expected = {0.6f, 0.8f};
        Vec2 result;

        Vec2_Normalize(&v, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Normalize", passed);
    }

    void Test_Normalize_VerifyUnitLength(){
        Vec2 v = {3.0f, 4.0f};
        Vec2 result;
        float expectedMagnitude = 1.0f;

        Vec2_Normalize(&v, &result);
        float magnitude = Vec2_Magnitude(&result);

        bool passed = ApproximatelyEqual(magnitude, expectedMagnitude);
        LogTest("Normalize (Unit Length)", passed);
    }

    void Test_Dot(){
        Vec2 a = {3.0f, 4.0f};
        Vec2 b = {2.0f, 1.0f};
        float expected = 10.0f;

        float result = Vec2_Dot(&a, &b);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Dot", passed);
    }

    void Test_Dot_Perpendicular(){
        Vec2 a = {1.0f, 0.0f};
        Vec2 b = {0.0f, 1.0f};
        float expected = 0.0f;

        float result = Vec2_Dot(&a, &b);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Dot (Perpendicular)", passed);
    }

    void Test_Reflect_HorizontalSurface(){
        Vec2 incident = {1.0f, -1.0f};
        Vec2 normal = {0.0f, 1.0f};
        Vec2 expected = {1.0f, 1.0f};
        Vec2 result;

        Vec2_Reflect(&incident, &normal, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Reflect (Horizontal)", passed);
    }

    void Test_Reflect_VerticalSurface(){
        Vec2 incident = {1.0f, 1.0f};
        Vec2 normal = {-1.0f, 0.0f};
        Vec2 expected = {-1.0f, 1.0f};
        Vec2 result;

        Vec2_Reflect(&incident, &normal, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Reflect (Vertical)", passed);
    }

    void Test_Distance(){
        Vec2 a = {0.0f, 0.0f};
        Vec2 b = {3.0f, 4.0f};
        float expected = 5.0f;

        float result = Vec2_Distance(&a, &b);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Distance", passed);
    }

    void Test_DistanceSquared(){
        Vec2 a = {0.0f, 0.0f};
        Vec2 b = {3.0f, 4.0f};
        float expected = 25.0f;

        float result = Vec2_DistanceSquared(&a, &b);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("DistanceSquared", passed);
    }

    void Test_Lerp_Half(){
        Vec2 start = {0.0f, 0.0f};
        Vec2 end = {10.0f, 10.0f};
        float t = 0.5f;
        Vec2 expected = {5.0f, 5.0f};
        Vec2 result;

        Vec2_Lerp(&start, &end, t, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Lerp (t=0.5)", passed);
    }

    void Test_Lerp_Start(){
        Vec2 start = {2.0f, 3.0f};
        Vec2 end = {10.0f, 10.0f};
        float t = 0.0f;
        Vec2 expected = {2.0f, 3.0f};
        Vec2 result;

        Vec2_Lerp(&start, &end, t, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Lerp (t=0)", passed);
    }

    void Test_Lerp_End(){
        Vec2 start = {2.0f, 3.0f};
        Vec2 end = {10.0f, 10.0f};
        float t = 1.0f;
        Vec2 expected = {10.0f, 10.0f};
        Vec2 result;

        Vec2_Lerp(&start, &end, t, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Lerp (t=1)", passed);
    }

    void Test_Lerp_Clamped(){
        Vec2 start = {0.0f, 0.0f};
        Vec2 end = {10.0f, 10.0f};
        float t = 1.5f;
        Vec2 expected = {10.0f, 10.0f};
        Vec2 result;

        Vec2_Lerp(&start, &end, t, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Lerp (Clamped)", passed);
    }

    void Test_ClampMagnitude_NoChange(){
        Vec2 v = {3.0f, 4.0f};
        float maxLength = 10.0f;
        Vec2 expected = {3.0f, 4.0f};
        Vec2 result;

        Vec2_ClampMagnitude(&v, maxLength, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("ClampMagnitude (No Change)", passed);
    }

    void Test_ClampMagnitude_Clamped(){
        Vec2 v = {3.0f, 4.0f};
        float maxLength = 2.5f;
        Vec2 expected = {1.5f, 2.0f};
        Vec2 result;

        Vec2_ClampMagnitude(&v, maxLength, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("ClampMagnitude (Clamped)", passed);
    }

    void Test_AngleBetween_90Degrees(){
        Vec2 right = {1.0f, 0.0f};
        Vec2 up = {0.0f, 1.0f};
        float expectedRadians = 1.5708f;

        float result = Vec2_AngleBetween(&right, &up);

        bool passed = ApproximatelyEqual(result, expectedRadians, 0.001f);
        LogTest("AngleBetween (90°)", passed);
    }

    void Test_AngleBetween_180Degrees(){
        Vec2 right = {1.0f, 0.0f};
        Vec2 left = {-1.0f, 0.0f};
        float expectedRadians = 3.14159f;

        float result = Vec2_AngleBetween(&right, &left);

        bool passed = ApproximatelyEqual(result, expectedRadians, 0.001f);
        LogTest("AngleBetween (180°)", passed);
    }

public:
    Vec2Tests() : totalTests(0), passedTests(0){}

    void RunAllTests(){
        std::cout << "\n========================================" << std::endl;
        std::cout << "              Vec2 Tests " << std::endl;
        std::cout << "========================================\n" << std::endl;

        Test_Add();
        Test_Subtract();
        Test_Scale();
        Test_Magnitude();
        Test_MagnitudeSquared();
        Test_Normalize();
        Test_Normalize_VerifyUnitLength();
        Test_Dot();
        Test_Dot_Perpendicular();
        Test_Reflect_HorizontalSurface();
        Test_Reflect_VerticalSurface();
        Test_Distance();
        Test_DistanceSquared();
        Test_Lerp_Half();
        Test_Lerp_Start();
        Test_Lerp_End();
        Test_Lerp_Clamped();
        Test_ClampMagnitude_NoChange();
        Test_ClampMagnitude_Clamped();
        Test_AngleBetween_90Degrees();
        Test_AngleBetween_180Degrees();

        std::cout << "\n========================================" << std::endl;
        std::cout << "  Tests Passed: " << passedTests << "/" << totalTests << std::endl;
        float percentage = (totalTests > 0) ? (100.0f * passedTests / totalTests) : 0.0f;
        std::cout << "  Success Rate: " << percentage << "%" << std::endl;
        std::cout << "========================================\n" << std::endl;
    }
};