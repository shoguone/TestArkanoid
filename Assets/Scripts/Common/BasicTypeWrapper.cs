using System;
using System.Reflection;

public class BasicTypeWrapper
{
    public class BasicBoolean
    {
        public Boolean value;
    }

    public class BasicByte
    {
        public Byte value;
    }

    public class BasicSByte
    {
        public SByte value;
    }

    public class BasicInt16
    {
        public Int16 value;
    }

    public class BasicUInt16
    {
        public UInt16 value;
    }

    public class BasicInt32
    {
        public Int32 value;
    }

    public class BasicUInt32
    {
        public UInt32 value;
    }

    public class BasicInt64
    {
        public Int64 value;
    }

    public class BasicUInt64
    {
        public UInt64 value;
    }

    public class BasicIntPtr
    {
        public IntPtr value;
    }

    public class BasicUIntPtr
    {
        public UIntPtr value;
    }

    public class BasicChar
    {
        public Char value;
    }

    public class BasicDouble
    {
        public Double value;
    }

    public class BasicSingle
    {
        public Single value;
    }

    public class BasicEnum
    {
        public Enum value;
    }

    public class BasicDateTime
    {
        public DateTime value;
    }

    public class BasicTimeSpan
    {
        public TimeSpan value;
    }

    public class BasicGuid
    {
        public Guid value;
    }

    public class BasicDecimal
    {
        public Decimal value;
    }

    public class BasicString
    {
        public String value;
    }


    public static object FromEntry(object entry)
    {
        switch (entry.GetType().FullName)
        {
            case "System.Boolean":
                return new BasicBoolean(){ value = (Boolean)entry };
            case "System.Byte":
                return new BasicByte(){ value = (Byte)entry };
            case "System.SByte":
                return new BasicSByte(){ value = (SByte)entry };
            case "System.Int16":
                return new BasicInt16(){ value = (Int16)entry };
            case "System.UInt16":
                return new BasicUInt16(){ value = (UInt16)entry };
            case "System.Int32":
                return new BasicInt32(){ value = (Int32)entry };
            case "System.UInt32":
                return new BasicUInt32(){ value = (UInt32)entry };
            case "System.Int64":
                return new BasicInt64(){ value = (Int64)entry };
            case "System.UInt64":
                return new BasicUInt64(){ value = (UInt64)entry };
            case "System.IntPtr":
                return new BasicIntPtr(){ value = (IntPtr)entry };
            case "System.UIntPtr":
                return new BasicUIntPtr(){ value = (UIntPtr)entry };
            case "System.Char":
                return new BasicChar(){ value = (Char)entry };
            case "System.Double":
                return new BasicDouble(){ value = (Double)entry };
            case "System.Single":
                return new BasicSingle(){ value = (Single)entry };
            case "System.Enum":
                return new BasicEnum(){ value = (Enum)entry };
            case "System.DateTime":
                return new BasicDateTime(){ value = (DateTime)entry };
            case "System.TimeSpan":
                return new BasicTimeSpan(){ value = (TimeSpan)entry };
            case "System.Guid":
                return new BasicGuid(){ value = (Guid)entry };
            case "System.Decimal":
                return new BasicDecimal(){ value = (Decimal)entry };
            case "System.String":
                return new BasicString(){ value = (String)entry };
            default:
                return entry;
        }
    }

    public static Type ResolveType(Type t)
    {
        switch (t.FullName)
        {
            case "System.Boolean":
                return typeof(BasicBoolean);
            case "System.Byte":
                return typeof(BasicByte);
            case "System.SByte":
                return typeof(BasicSByte);
            case "System.Int16":
                return typeof(BasicInt16);
            case "System.UInt16":
                return typeof(BasicUInt16);
            case "System.Int32":
                return typeof(BasicInt32);
            case "System.UInt32":
                return typeof(BasicUInt32);
            case "System.Int64":
                return typeof(BasicInt64);
            case "System.UInt64":
                return typeof(BasicUInt64);
            case "System.IntPtr":
                return typeof(BasicIntPtr);
            case "System.UIntPtr":
                return typeof(BasicUIntPtr);
            case "System.Char":
                return typeof(BasicChar);
            case "System.Double":
                return typeof(BasicDouble);
            case "System.Single":
                return typeof(BasicSingle);
            case "System.Enum":
                return typeof(BasicEnum);
            case "System.DateTime":
                return typeof(BasicDateTime);
            case "System.TimeSpan":
                return typeof(BasicTimeSpan);
            case "System.Guid":
                return typeof(BasicGuid);
            case "System.Decimal":
                return typeof(BasicDecimal);
            case "System.String":
                return typeof(BasicString);
            default:
                return typeof(String);
        }
    }

    public static object GetValue(object entry, Type t)
    {
        FieldInfo fieldInfo = t.GetField("value");
        return fieldInfo.GetValue(entry);
    }
}
