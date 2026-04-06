namespace SunamoCollections._sunamo;

/// <summary>
/// Cached type references for common .NET types used in reflection operations.
/// </summary>
internal class Types
{
    internal static readonly Type TObject = typeof(object);
    internal static readonly Type TStringBuilder = typeof(StringBuilder);
    internal static readonly Type TIEnumerable = typeof(IEnumerable);
    internal static readonly Type TString = typeof(string);
    internal static readonly Type TFloat = typeof(float);
    internal static readonly Type TDouble = typeof(double);
    internal static readonly Type TInt = typeof(int);
    internal static readonly Type TLong = typeof(long);
    internal static readonly Type TShort = typeof(short);
    internal static readonly Type TDecimal = typeof(decimal);
    internal static readonly Type TSbyte = typeof(sbyte);
    internal static readonly Type TByte = typeof(byte);
    internal static readonly Type TUshort = typeof(ushort);
    internal static readonly Type TUint = typeof(uint);
    internal static readonly Type TUlong = typeof(ulong);
    internal static readonly Type TDateTime = typeof(DateTime);
    internal static readonly Type TBinary = typeof(byte[]);
    internal static readonly Type TChar = typeof(char);
    internal static readonly List<Type> AllBasicTypes = new()
    {
        TObject, TString, TStringBuilder, TInt, TDateTime,
        TDouble, TFloat, TChar, TBinary, TByte, TShort, TBinary, TLong, TDecimal, TSbyte, TUshort, TUint, TUlong
    };
    internal static readonly Type ListType = typeof(IList);
    internal static readonly Type TBool = typeof(bool);
    internal static readonly Type TGuid = typeof(Guid);
}
