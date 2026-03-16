using NUnit.Framework;
using UnityEngine;
using NativeVector;

public class Vec2Tests
{
    bool ApproximatelyEqual(float a, float b, float epsilon = 0.0001f)
    {
        return Mathf.Abs(a - b) < epsilon;
    }

    bool ApproximatelyEqual(Vec2 a, Vec2 b, float epsilon = 0.0001f)
    {
        return ApproximatelyEqual(a.x, b.x, epsilon) && 
               ApproximatelyEqual(a.y, b.y, epsilon);
    }
    
    [Test]
    public void Test_Vec2_Add()
    {
        var a = new Vec2(3, 4);
        var b = new Vec2(1, 2);
        var expected = new Vec2(4, 6);
        
        var result = VecHelper.Add(a, b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected), 
            $"Expected {expected}, got {result}");
    }
    
    [Test]
    public void Test_Vec2_Subtract()
    {
        var a = new Vec2(5, 7);
        var b = new Vec2(2, 3);
        var expected = new Vec2(3, 4);
        
        var result = VecHelper.Subtract(a, b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec2_Scale()
    {
        var v = new Vec2(3, 4);
        var scalar = 2.0f;
        var expected = new Vec2(6, 8);
        
        var result = VecHelper.Scale(v, scalar);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec2_Magnitude()
    {
        var v = new Vec2(3, 4);
        var expected = 5.0f;
        
        var result = VecHelper.Magnitude(v);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            $"Expected {expected}, got {result}");
    }
    
    [Test]
    public void Test_Vec2_MagnitudeSquared()
    {
        var v = new Vec2(3, 4);
        var expected = 25.0f;
        
        var result = VecHelper.MagnitudeSquared(v);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec2_Normalize()
    {
        var v = new Vec2(3, 4);
        var expected = new Vec2(0.6f, 0.8f);
        
        var result = VecHelper.Normalize(v);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
        
        var magnitude = VecHelper.Magnitude(result);
        Assert.IsTrue(ApproximatelyEqual(magnitude, 1.0f));
    }
    
    [Test]
    public void Test_Vec2_Dot()
    {
        var a = new Vec2(3, 4);
        var b = new Vec2(2, 1);
        var expected = 10.0f;
        
        var result = VecHelper.Dot(a, b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec2_Dot_Perpendicular()
    {
        var a = new Vec2(1, 0);
        var b = new Vec2(0, 1);
        var expected = 0.0f;
        
        var result = VecHelper.Dot(a, b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            "Perpendicular vectors should have dot product of 0");
    }
    
    [Test]
    public void Test_Vec2_Reflect_HorizontalSurface()
    {
        var incident = new Vec2(1, -1);
        var normal = new Vec2(0, 1);
        var expected = new Vec2(1, 1);
        
        var result = VecHelper.Reflect(incident, normal);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            "Ball should reflect off horizontal surface");
    }
    
    [Test]
    public void Test_Vec2_Reflect_VerticalSurface()
    {
        var incident = new Vec2(1, 1);
        var normal = new Vec2(-1, 0);
        var expected = new Vec2(-1, 1);
        
        var result = VecHelper.Reflect(incident, normal);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            "Ball should reflect off vertical surface");
    }
    
    [Test]
    public void Test_Vec2_Distance()
    {
        var a = new Vec2(0, 0);
        var b = new Vec2(3, 4);
        var expected = 5.0f;
        
        var result = VecHelper.Distance(a, b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec2_DistanceSquared()
    {
        var a = new Vec2(0, 0);
        var b = new Vec2(3, 4);
        var expected = 25.0f;
        
        var result = VecHelper.DistanceSquared(a, b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec2_Lerp_Half()
    {
        var start = new Vec2(0, 0);
        var end = new Vec2(10, 10);
        var t = 0.5f;
        var expected = new Vec2(5, 5);
        
        var result = VecHelper.Lerp(start, end, t);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec2_Lerp_Start()
    {
        var start = new Vec2(2, 3);
        var end = new Vec2(10, 10);
        var t = 0.0f;
        var expected = new Vec2(2, 3);
        
        var result = VecHelper.Lerp(start, end, t);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec2_Lerp_End()
    {
        var start = new Vec2(2, 3);
        var end = new Vec2(10, 10);
        var t = 1.0f;
        var expected = new Vec2(10, 10);
        
        var result = VecHelper.Lerp(start, end, t);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec2_ClampMagnitude_NoChange()
    {
        var v = new Vec2(3, 4);
        var maxLength = 10.0f;
        var expected = new Vec2(3, 4);
        
        var result = VecHelper.ClampMagnitude(v, maxLength);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
    }
    
    [Test]
    public void Test_Vec2_ClampMagnitude_Clamped()
    {
        var v = new Vec2(3, 4);
        var maxLength = 2.5f;
        var expected = new Vec2(1.5f, 2.0f);
        
        var result = VecHelper.ClampMagnitude(v, maxLength);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
        
        var magnitude = VecHelper.Magnitude(result);
        Assert.IsTrue(ApproximatelyEqual(magnitude, maxLength));
    }
    
    [Test]
    public void Test_Vec2_AngleBetween_90Degrees()
    {
        var right = new Vec2(1, 0);
        var up = new Vec2(0, 1);
        var expectedRadians = Mathf.PI / 2f;
        
        var result = VecHelper.AngleBetween(right, up);
        
        Assert.IsTrue(ApproximatelyEqual(result, expectedRadians, 0.001f),
            $"Expected {expectedRadians} radians, got {result}");
    }
    
    [Test]
    public void Test_Vec2_ConversionToUnity()
    {
        var native = new Vec2(3.5f, 7.2f);
        
        var unity = native.ToUnity();
        
        Assert.AreEqual(3.5f, unity.x, 0.0001f);
        Assert.AreEqual(7.2f, unity.y, 0.0001f);
    }
    
    [Test]
    public void Test_Vec2_ConversionFromUnity()
    {
        var unity = new Vector2(4.1f, 8.9f);
        
        var native = Vec2.FromUnity(unity);
        
        Assert.AreEqual(4.1f, native.x, 0.0001f);
        Assert.AreEqual(8.9f, native.y, 0.0001f);
    }
}
