using NUnit.Framework;
using UnityEngine;
using DirectVector;

public class DirectVec2Tests
{
    bool ApproximatelyEqual(float a, float b, float epsilon = 0.0001f)
    {
        return Mathf.Abs(a - b) < epsilon;
    }

    bool ApproximatelyEqual(DirectVec2 a, DirectVec2 b, float epsilon = 0.0001f)
    {
        return ApproximatelyEqual(a.x, b.x, epsilon) && 
               ApproximatelyEqual(a.y, b.y, epsilon);
    }
    
    [Test]
    public void Test_DirectVec2_Add()
    {
        var a = new DirectVec2(3, 4);
        var b = new DirectVec2(1, 2);
        var expected = new DirectVec2(4, 6);
        
        a.Add(b);
        
        Assert.IsTrue(ApproximatelyEqual(a, expected), 
            $"Expected {expected}, got {a}");
        
        a.Dispose();
        b.Dispose();
        expected.Dispose();
    }
    
    [Test]
    public void Test_DirectVec2_Subtract()
    {
        var a = new DirectVec2(5, 7);
        var b = new DirectVec2(2, 3);
        var expected = new DirectVec2(3, 4);
        
        a.Subtract(b);
        
        Assert.IsTrue(ApproximatelyEqual(a, expected));
        
        a.Dispose();
        b.Dispose();
        expected.Dispose();
    }
    
    [Test]
    public void Test_DirectVec2_Scale()
    {
        var v = new DirectVec2(3, 4);
        var scalar = 2.0f;
        var expected = new DirectVec2(6, 8);
        
        v.Scale(scalar);
        
        Assert.IsTrue(ApproximatelyEqual(v, expected));
        
        v.Dispose();
        expected.Dispose();
    }
    
    [Test]
    public void Test_DirectVec2_Magnitude()
    {
        var v = new DirectVec2(3, 4);
        var expected = 5.0f;
        
        var result = v.Magnitude();
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            $"Expected {expected}, got {result}");
        
        v.Dispose();
    }
    
    [Test]
    public void Test_DirectVec2_Normalize()
    {
        var v = new DirectVec2(3, 4);
        var expected = new DirectVec2(0.6f, 0.8f);
        
        v.Normalize();
        
        Assert.IsTrue(ApproximatelyEqual(v, expected));
        
        var magnitude = v.Magnitude();
        Assert.IsTrue(ApproximatelyEqual(magnitude, 1.0f));
        
        v.Dispose();
        expected.Dispose();
    }
    
    [Test]
    public void Test_DirectVec2_Dot()
    {
        var a = new DirectVec2(3, 4);
        var b = new DirectVec2(2, 1);
        var expected = 10.0f;
        
        var result = a.Dot(b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
        
        a.Dispose();
        b.Dispose();
    }
    
    [Test]
    public void Test_DirectVec2_Dot_Perpendicular()
    {
        var a = new DirectVec2(1, 0);
        var b = new DirectVec2(0, 1);
        var expected = 0.0f;
        
        var result = a.Dot(b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            "Perpendicular vectors should have dot product of 0");
        
        a.Dispose();
        b.Dispose();
    }
    
    [Test]
    public void Test_DirectVec2_Reflect_HorizontalSurface()
    {
        var incident = new DirectVec2(1, -1);
        var normal = new DirectVec2(0, 1);
        var expected = new DirectVec2(1, 1);
        
        incident.Reflect(normal);
        
        Assert.IsTrue(ApproximatelyEqual(incident, expected),
            "Ball should reflect off horizontal surface");
        
        incident.Dispose();
        normal.Dispose();
        expected.Dispose();
    }
    
    [Test]
    public void Test_DirectVec2_Reflect_VerticalSurface()
    {
        var incident = new DirectVec2(1, 1);
        var normal = new DirectVec2(-1, 0);
        var expected = new DirectVec2(-1, 1);
        
        incident.Reflect(normal);
        
        Assert.IsTrue(ApproximatelyEqual(incident, expected),
            "Ball should reflect off vertical surface");
        
        incident.Dispose();
        normal.Dispose();
        expected.Dispose();
    }
    
    [Test]
    public void Test_DirectVec2_Distance()
    {
        var a = new DirectVec2(0, 0);
        var b = new DirectVec2(3, 4);
        var expected = 5.0f;
        
        var result = a.Distance(b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
        
        a.Dispose();
        b.Dispose();
    }
    
    [Test]
    public void Test_DirectVec2_ConversionToUnity()
    {
        var native = new DirectVec2(3.5f, 7.2f);
        
        var unity = native.ToUnity();
        
        Assert.AreEqual(3.5f, unity.x, 0.0001f);
        Assert.AreEqual(7.2f, unity.y, 0.0001f);
        
        native.Dispose();
    }
    
    [Test]
    public void Test_DirectVec2_ConversionFromUnity()
    {
        var unity = new Vector2(4.1f, 8.9f);
        
        var native = DirectVec2.FromUnity(unity);
        
        Assert.AreEqual(4.1f, native.x, 0.0001f);
        Assert.AreEqual(8.9f, native.y, 0.0001f);
        
        native.Dispose();
    }
}
