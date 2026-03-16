using NUnit.Framework;
using UnityEngine;
using DirectVector;

public class DirectVec3Tests
{
    bool ApproximatelyEqual(float a, float b, float epsilon = 0.0001f)
    {
        return Mathf.Abs(a - b) < epsilon;
    }

    bool ApproximatelyEqual(DirectVec3 a, DirectVec3 b, float epsilon = 0.0001f)
    {
        return ApproximatelyEqual(a.x, b.x, epsilon) && 
               ApproximatelyEqual(a.y, b.y, epsilon) &&
               ApproximatelyEqual(a.z, b.z, epsilon);
    }
    
    [Test]
    public void Test_Vec3_Add()
    {
        var a = new DirectVec3(1, 2, 3);
        var b = new DirectVec3(4, 5, 6);
        var expected = new DirectVec3(5, 7, 9);
        
        a.Add(b);
        
        Assert.IsTrue(ApproximatelyEqual(a, expected));
        
        a.Dispose();
        b.Dispose();
        expected.Dispose();
    }
    
    [Test]
    public void Test_Vec3_Subtract()
    {
        var a = new DirectVec3(10, 8, 6);
        var b = new DirectVec3(4, 3, 2);
        var expected = new DirectVec3(6, 5, 4);
        
        a.Subtract(b);
        
        Assert.IsTrue(ApproximatelyEqual(a, expected));
        
        a.Dispose();
        b.Dispose();
        expected.Dispose();
    }
    
    [Test]
    public void Test_Vec3_Scale()
    {
        var v = new DirectVec3(1, 2, 3);
        var scalar = 3.0f;
        var expected = new DirectVec3(3, 6, 9);
        
        v.Scale(scalar);
        
        Assert.IsTrue(ApproximatelyEqual(v, expected));
        
        v.Dispose();
        expected.Dispose();
    }
    
    [Test]
    public void Test_Vec3_Magnitude()
    {
        var v = new DirectVec3(2, 3, 6);
        var expected = 7.0f;
        
        var result = v.Magnitude();
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
        
        v.Dispose();
    }
    
    [Test]
    public void Test_Vec3_Normalize()
    {
        var v = new DirectVec3(3, 0, 4);
        var expected = new DirectVec3(0.6f, 0.0f, 0.8f);
        
        v.Normalize();
        
        Assert.IsTrue(ApproximatelyEqual(v, expected));
        
        // Verify magnitude is 1
        var magnitude = v.Magnitude();
        Assert.IsTrue(ApproximatelyEqual(magnitude, 1.0f));
        
        v.Dispose();
        expected.Dispose();
    }
    
    [Test]
    public void Test_Vec3_Dot()
    {
        var a = new DirectVec3(1, 2, 3);
        var b = new DirectVec3(4, 5, 6);
        var expected = 32.0f;
        
        var result = a.Dot(b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
        
        a.Dispose();
        b.Dispose();
    }
    
    [Test]
    public void Test_Vec3_Dot_Perpendicular()
    {
        var a = new DirectVec3(1, 0, 0);
        var b = new DirectVec3(0, 1, 0);
        var expected = 0.0f;
        
        var result = a.Dot(b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
        
        a.Dispose();
        b.Dispose();
    }
    
    [Test]
    public void Test_Vec3_Cross_XY()
    {
        var x = new DirectVec3(1, 0, 0);
        var y = new DirectVec3(0, 1, 0);
        var expected = new DirectVec3(0, 0, 1);
        
        var result = x.Cross(y);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            "X × Y should equal Z (right-hand rule)");
        
        x.Dispose();
        y.Dispose();
        expected.Dispose();
        result.Dispose();
    }
    
    [Test]
    public void Test_Vec3_Cross_YZ()
    {
        var y = new DirectVec3(0, 1, 0);
        var z = new DirectVec3(0, 0, 1);
        var expected = new DirectVec3(1, 0, 0);
        
        var result = y.Cross(z);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            "Y × Z should equal X");
        
        y.Dispose();
        z.Dispose();
        expected.Dispose();
        result.Dispose();
    }
    
    [Test]
    public void Test_Vec3_Cross_ZX()
    {
        var z = new DirectVec3(0, 0, 1);
        var x = new DirectVec3(1, 0, 0);
        var expected = new DirectVec3(0, 1, 0);
        
        var result = z.Cross(x);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            "Z × X should equal Y");
        
        x.Dispose();
        z.Dispose();
        expected.Dispose();
        result.Dispose();
    }
    
    [Test]
    public void Test_Vec3_Cross_Parallel()
    {
        var a = new DirectVec3(1, 2, 3);
        var b = new DirectVec3(2, 4, 6);
        var expected = new DirectVec3(0, 0, 0);
        
        var result = a.Cross(b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected),
            "Parallel vectors should have cross product of zero");
        
        a.Dispose();
        b.Dispose();
        expected.Dispose();
        result.Dispose();
    }
    
    [Test]
    public void Test_Vec3_Reflect()
    {
        var incident = new DirectVec3(1, -1, 0);
        var normal = new DirectVec3(0, 1, 0);
        var expected = new DirectVec3(1, 1, 0);
        
        incident.Reflect(normal);
        
        Assert.IsTrue(ApproximatelyEqual(incident, expected));
        
        incident.Dispose();
        normal.Dispose();
        expected.Dispose();
    }
    
    [Test]
    public void Test_Vec3_Distance()
    {
        var a = new DirectVec3(0, 0, 0);
        var b = new DirectVec3(3, 0, 4);
        var expected = 5.0f;
        
        var result = a.Distance(b);
        
        Assert.IsTrue(ApproximatelyEqual(result, expected));
        
        a.Dispose();
        b.Dispose();
    }
    
    [Test]
    public void Test_Vec3_ConversionToUnity()
    {
        var native = new DirectVec3(1.5f, 2.5f, 3.5f);
        
        var unity = native.ToUnity();
        
        Assert.AreEqual(1.5f, unity.x, 0.0001f);
        Assert.AreEqual(2.5f, unity.y, 0.0001f);
        Assert.AreEqual(3.5f, unity.z, 0.0001f);
        
        native.Dispose();
    }
    
    [Test]
    public void Test_Vec3_ConversionFromUnity()
    {
        var unity = new Vector3(4.2f, 5.3f, 6.4f);
        
        var native = DirectVec3.FromUnity(unity);
        
        Assert.AreEqual(4.2f, native.x, 0.0001f);
        Assert.AreEqual(5.3f, native.y, 0.0001f);
        Assert.AreEqual(6.4f, native.z, 0.0001f);
        
        native.Dispose();
    }
}
