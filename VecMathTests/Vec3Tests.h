#pragma once

#include "Vec3.h"
#include <iostream>
#include <cmath>
#include <string>

class Vec3Tests{
private:
    int totalTests;
    int passedTests;

    bool ApproximatelyEqual(float a, float b, float epsilon = 0.0001f){
        return fabsf(a - b) < epsilon;
    }

    bool ApproximatelyEqual(const Vec3 & a, const Vec3 & b, float epsilon = 0.0001f){
        return ApproximatelyEqual(a.x, b.x, epsilon) &&
            ApproximatelyEqual(a.y, b.y, epsilon) &&
            ApproximatelyEqual(a.z, b.z, epsilon);
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
        Vec3 a = {1.0f, 2.0f, 3.0f};
        Vec3 b = {4.0f, 5.0f, 6.0f};
        Vec3 expected = {5.0f, 7.0f, 9.0f};
        Vec3 result;

        Vec3_Add(&a, &b, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Add", passed);
    }

    void Test_Subtract(){
        Vec3 a = {10.0f, 8.0f, 6.0f};
        Vec3 b = {4.0f, 3.0f, 2.0f};
        Vec3 expected = {6.0f, 5.0f, 4.0f};
        Vec3 result;

        Vec3_Subtract(&a, &b, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Subtract", passed);
    }

    void Test_Scale(){
        Vec3 v = {1.0f, 2.0f, 3.0f};
        float scalar = 3.0f;
        Vec3 expected = {3.0f, 6.0f, 9.0f};
        Vec3 result;

        Vec3_Scale(&v, scalar, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Scale", passed);
    }

    void Test_Magnitude(){
        Vec3 v = {2.0f, 3.0f, 6.0f};
        float expected = 7.0f;

        float result = Vec3_Magnitude(&v);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Magnitude", passed);
    }

    void Test_MagnitudeSquared(){
        Vec3 v = {2.0f, 3.0f, 6.0f};
        float expected = 49.0f;

        float result = Vec3_MagnitudeSquared(&v);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("MagnitudeSquared", passed);
    }

    void Test_Normalize(){
        Vec3 v = {3.0f, 0.0f, 4.0f};
        Vec3 expected = {0.6f, 0.0f, 0.8f};
        Vec3 result;

        Vec3_Normalize(&v, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Normalize", passed);
    }

    void Test_Normalize_VerifyUnitLength(){
        Vec3 v = {3.0f, 0.0f, 4.0f};
        Vec3 result;
        float expectedMagnitude = 1.0f;

        Vec3_Normalize(&v, &result);
        float magnitude = Vec3_Magnitude(&result);

        bool passed = ApproximatelyEqual(magnitude, expectedMagnitude);
        LogTest("Normalize (Unit Length)", passed);
    }

    void Test_Dot(){
        Vec3 a = {1.0f, 2.0f, 3.0f};
        Vec3 b = {4.0f, 5.0f, 6.0f};
        float expected = 32.0f;

        float result = Vec3_Dot(&a, &b);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Dot", passed);
    }

    void Test_Dot_Perpendicular(){
        Vec3 a = {1.0f, 0.0f, 0.0f};
        Vec3 b = {0.0f, 1.0f, 0.0f};
        float expected = 0.0f;

        float result = Vec3_Dot(&a, &b);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Dot (Perpendicular)", passed);
    }

    void Test_Cross_XY(){
        Vec3 x = {1.0f, 0.0f, 0.0f};
        Vec3 y = {0.0f, 1.0f, 0.0f};
        Vec3 expected = {0.0f, 0.0f, 1.0f};
        Vec3 result;

        Vec3_Cross(&x, &y, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Cross (X × Y = Z)", passed);
    }

    void Test_Cross_YZ(){
        Vec3 y = {0.0f, 1.0f, 0.0f};
        Vec3 z = {0.0f, 0.0f, 1.0f};
        Vec3 expected = {1.0f, 0.0f, 0.0f};
        Vec3 result;

        Vec3_Cross(&y, &z, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Cross (Y × Z = X)", passed);
    }

    void Test_Cross_ZX(){
        Vec3 z = {0.0f, 0.0f, 1.0f};
        Vec3 x = {1.0f, 0.0f, 0.0f};
        Vec3 expected = {0.0f, 1.0f, 0.0f};
        Vec3 result;

        Vec3_Cross(&z, &x, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Cross (Z × X = Y)", passed);
    }

    void Test_Cross_Parallel(){
        Vec3 a = {1.0f, 2.0f, 3.0f};
        Vec3 b = {2.0f, 4.0f, 6.0f};
        Vec3 expected = {0.0f, 0.0f, 0.0f};
        Vec3 result;

        Vec3_Cross(&a, &b, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Cross (Parallel = Zero)", passed);
    }

    void Test_Reflect(){
        Vec3 incident = {1.0f, -1.0f, 0.0f};
        Vec3 normal = {0.0f, 1.0f, 0.0f};
        Vec3 expected = {1.0f, 1.0f, 0.0f};
        Vec3 result;

        Vec3_Reflect(&incident, &normal, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Reflect", passed);
    }

    void Test_Distance(){
        Vec3 a = {0.0f, 0.0f, 0.0f};
        Vec3 b = {3.0f, 0.0f, 4.0f};
        float expected = 5.0f;

        float result = Vec3_Distance(&a, &b);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Distance", passed);
    }

    void Test_DistanceSquared(){
        Vec3 a = {0.0f, 0.0f, 0.0f};
        Vec3 b = {3.0f, 0.0f, 4.0f};
        float expected = 25.0f;

        float result = Vec3_DistanceSquared(&a, &b);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("DistanceSquared", passed);
    }

    void Test_Lerp(){
        Vec3 start = {0.0f, 0.0f, 0.0f};
        Vec3 end = {10.0f, 20.0f, 30.0f};
        float t = 0.5f;
        Vec3 expected = {5.0f, 10.0f, 15.0f};
        Vec3 result;

        Vec3_Lerp(&start, &end, t, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("Lerp", passed);
    }

    void Test_Slerp(){
        Vec3 start = {1.0f, 0.0f, 0.0f};
        Vec3 end = {0.0f, 1.0f, 0.0f};
        float t = 0.5f;
        Vec3 result;
        float expectedMagnitude = 1.0f;

        Vec3_Slerp(&start, &end, t, &result);
        float magnitude = Vec3_Magnitude(&result);

        bool passed = ApproximatelyEqual(magnitude, expectedMagnitude, 0.01f);
        LogTest("Slerp (Normalized)", passed);
    }

    void Test_ClampMagnitude(){
        Vec3 v = {3.0f, 0.0f, 4.0f};
        float maxLength = 2.5f;
        Vec3 expected = {1.5f, 0.0f, 2.0f};
        Vec3 result;

        Vec3_ClampMagnitude(&v, maxLength, &result);

        bool passed = ApproximatelyEqual(result, expected);
        LogTest("ClampMagnitude", passed);
    }

    void Test_AngleBetween(){
        Vec3 x = {1.0f, 0.0f, 0.0f};
        Vec3 y = {0.0f, 1.0f, 0.0f};
        float expectedRadians = 1.5708f;

        float result = Vec3_AngleBetween(&x, &y);

        bool passed = ApproximatelyEqual(result, expectedRadians, 0.001f);
        LogTest("AngleBetween (90°)", passed);
    }

public:
    Vec3Tests() : totalTests(0), passedTests(0){}

    void RunAllTests(){
        std::cout << "\n========================================" << std::endl;
        std::cout << "              Vec3 Tests" << std::endl;
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
        Test_Cross_XY();
        Test_Cross_YZ();
        Test_Cross_ZX();
        Test_Cross_Parallel();
        Test_Reflect();
        Test_Distance();
        Test_DistanceSquared();
        Test_Lerp();
        Test_Slerp();
        Test_ClampMagnitude();
        Test_AngleBetween();

        std::cout << "\n========================================" << std::endl;
        std::cout << "  Tests Passed: " << passedTests << "/" << totalTests << std::endl;
        float percentage = (totalTests > 0) ? (100.0f * passedTests / totalTests) : 0.0f;
        std::cout << "  Success Rate: " << percentage << "%" << std::endl;
        std::cout << "========================================\n" << std::endl;
    }
};