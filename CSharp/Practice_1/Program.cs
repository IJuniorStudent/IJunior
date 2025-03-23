namespace Practice_1;

class Program
{
    static void Main(string[] args)
    {
        byte byteValueUnit, byteValueZero;
        byteValueUnit = 1;
        byteValueZero = 0;
 
        ushort unsignedShortValueMax;
        unsignedShortValueMax = ushort.MaxValue;
 
        short shortValueNegative;
        shortValueNegative = -359;
 
        float floatValueSinglePrecision;
        floatValueSinglePrecision = 0.123456f;
 
        double floatValueDoublePrecision;
        floatValueDoublePrecision = 0.123456789;
 
        char singleCharValue;
        singleCharValue = 'X';
 
        string stringValue;
        stringValue = "here is a string. Hello!";
 
        bool boolValue;
        boolValue = true;
 
        bool isUnitLessThanZero = byteValueUnit < byteValueZero;
    }
}