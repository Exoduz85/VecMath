#include <iostream>
#include "Vec2Tests.h"
#include "Vec3Tests.h"

using namespace std;

int main(){
    cout << "\n ==================================================" << endl;
    cout << "|   Vector Math Library - Complete Test Suite      |" << endl;
    cout << "|         AAA Pattern Tests (Struct-Based)         |" << endl;
    cout << " ==================================================" << endl;

    Vec2Tests vec2Tests;
    vec2Tests.RunAllTests();

    Vec3Tests vec3Tests;
    vec3Tests.RunAllTests();

    cout << "\n ==================================================" << endl;
    cout << "|              All Tests Completed!                |" << endl;
    cout << " ==================================================\n" << endl;

    cout << "Press Enter to exit...";
    cin.get();

    return 0;
}