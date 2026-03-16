using NUnit.Framework;
using UnityEngine;
using NativeVector;

public class Vec3Tests
{
    bool ApproximatelyEqual(float a, float b, float epsilon = 0.0001f)
    {
        return Mathf.Abs(a - b) < epsilon;
    }

    bool ApproximatelyEqual(Vec3 a, Vec3 b, float epsilon = 0.0001f)
    {
        return ApproximatelyEqual(a.x, b.x, epsilon) && 
               ApproximatelyEqual(a.y, b.y, epsilon) &&
               ApproximatelyEqual(a.z, b.z, epsilon);
    }
    
    [Test]
    public void Test_Vec3_Add()
    {
        var a = new Vec3(1, 2, 3);
        var b = new Vec3(4, 5, 6);
        var expected = new Vec3(5, 7, 9);
        
        var result = VecHelper.Add(a, b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec3_Subtract()
    {
        var a = new Vec3(10, 8, 6);
        var b = new Vec3(4, 3, 2);
        var expected = new Vec3(6, 5, 4);
        
        var result = VecHelper.Subtract(a, b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec3_Scale()
    {
        var v = new Vec3(1, 2, 3);
        var scalar = 3.0f;
        var expected = new Vec3(3, 6, 9);
        
        var result = VecHelper.Scale(v, scalar);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec3_Magnitude()
    {
        var v = new Vec3(2, 3, 6);
        var expected = 7.0f;
        
        var result = VecHelper.Magnitude(v);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec3_MagnitudeSquared()
    {
        var v = new Vec3(2, 3, 6);
        var expected = 49.0f;
        
        var result = VecHelper.MagnitudeSquared(v);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec3_Normalize()
    {
        var v = new Vec3(3, 0, 4);
        var expected = new Vec3(0.6f, 0.0f, 0.8f);
        
        var result = VecHelper.Normalize(v);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
        
        // Verify magnitude is 1
        var magnitude = VecHelper.Magnitude(result);
        Assert.IsTrue(ApproximatelyEqual(magnitude, 1.0f));
    }
    
    [Test]
    public void Test_Vec3_Dot()
    {
        var a = new Vec3(1, 2, 3);
        var b = new Vec3(4, 5, 6);
        var expected = 32.0f;
        
        var result = VecHelper.Dot(a, b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec3_Dot_Perpendicular()
    {
        var a = new Vec3(1, 0, 0);
        var b = new Vec3(0, 1, 0);
        var expected = 0.0f;
        
        var result = VecHelper.Dot(a, b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec3_Cross_XY()
    {
        var x = new Vec3(1, 0, 0);
        var y = new Vec3(0, 1, 0);
        var expected = new Vec3(0, 0, 1);
        
        var result = VecHelper.Cross(x, y);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            "X × Y should equal Z (right-hand rule)");
    }
    
    [Test]
    public void Test_Vec3_Cross_YZ()
    {
        var y = new Vec3(0, 1, 0);
        var z = new Vec3(0, 0, 1);
        var expected = new Vec3(1, 0, 0);
        
        var result = VecHelper.Cross(y, z);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            "Y × Z should equal X");
    }
    
    [Test]
    public void Test_Vec3_Cross_ZX()
    {
        var z = new Vec3(0, 0, 1);
        var x = new Vec3(1, 0, 0);
        var expected = new Vec3(0, 1, 0);
        
        var result = VecHelper.Cross(z, x);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            "Z × X should equal Y");
    }
    
    [Test]
    public void Test_Vec3_Cross_Parallel()
    {
        var a = new Vec3(1, 2, 3);
        var b = new Vec3(2, 4, 6);
        var expected = new Vec3(0, 0, 0);
        
        var result = VecHelper.Cross(a, b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            "Parallel vectors should have cross product of zero");
    }
    
    [Test]
    public void Test_Vec3_Reflect()
    {
        var incident = new Vec3(1, -1, 0);
        var normal = new Vec3(0, 1, 0);
        var expected = new Vec3(1, 1, 0);
        
        var result = VecHelper.Reflect(incident, normal);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec3_Distance()
    {
        var a = new Vec3(0, 0, 0);
        var b = new Vec3(3, 0, 4);
        var expected = 5.0f;
        
        var result = VecHelper.Distance(a, b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec3_DistanceSquared()
    {
        var a = new Vec3(0, 0, 0);
        var b = new Vec3(3, 0, 4);
        var expected = 25.0f;
        
        var result = VecHelper.DistanceSquared(a, b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec3_Lerp()
    {
        var start = new Vec3(0, 0, 0);
        var end = new Vec3(10, 20, 30);
        var t = 0.5f;
        var expected = new Vec3(5, 10, 15);
        
        var result = VecHelper.Lerp(start, end, t);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec3_Slerp()
    {
        var start = new Vec3(1, 0, 0);
        var end = new Vec3(0, 1, 0);
        var t = 0.5f;
        
        var result = VecHelper.Slerp(start, end, t);
        
        var magnitude = VecHelper.Magnitude(result);
        Assert.IsTrue(ApproximatelyEqual(magnitude, 1.0f, 0.01f),
            "Slerp result should be normalized");
    }
    
    [Test]
    public void Test_Vec3_ClampMagnitude()
    {
        var v = new Vec3(3, 0, 4);
        var maxLength = 2.5f;
        var expected = new Vec3(1.5f, 0.0f, 2.0f);
        
        var result = VecHelper.ClampMagnitude(v, maxLength);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
        
        var magnitude = VecHelper.Magnitude(result);
        Assert.IsTrue(ApproximatelyEqual(magnitude, maxLength));
    }
    
    [Test]
    public void Test_Vec3_AngleBetween()
    {
        var x = new Vec3(1, 0, 0);
        var y = new Vec3(0, 1, 0);
        var expectedRadians = Mathf.PI / 2f;
        
        var result = VecHelper.AngleBetween(x, y);
        
        Assert.IsTrue(ApproximatelyEqual(result, expectedRadians, 0.001f));
    }
    
    [Test]
    public void Test_Vec3_ConversionToUnity()
    {
        var native = new Vec3(1.5f, 2.5f, 3.5f);
        
        var unity = native.ToUnity();
        
        Assert.AreEqual(1.5f, unity.x, 0.0001f);
        Assert.AreEqual(2.5f, unity.y, 0.0001f);
        Assert.AreEqual(3.5f, unity.z, 0.0001f);
    }
    
    [Test]
    public void Test_Vec3_ConversionFromUnity()
    {
        var unity = new Vector3(4.2f, 5.3f, 6.4f);
        
        var native = Vec3.FromUnity(unity);
        
        Assert.AreEqual(4.2f, native.x, 0.0001f);
        Assert.AreEqual(5.3f, native.y, 0.0001f);
        Assert.AreEqual(6.4f, native.z, 0.0001f);
    }
}
