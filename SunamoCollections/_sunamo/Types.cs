namespace SunamoCollections._sunamo;

/// <summary>
/// Cached type references for common .NET types used in reflection operations.
/// </summary>
internal class Types
{
    /// <summary>Cached type reference for <see cref="object"/>.</summary>
    internal static readonly Type TObject = typeof(object);
    /// <summary>Cached type reference for <see cref="StringBuilder"/>.</summary>
    internal static readonly Type TStringBuilder = typeof(StringBuilder);
    /// <summary>Cached type reference for <see cref="IEnumerable"/>.</summary>
    internal static readonly Type TIEnumerable = typeof(IEnumerable);
    /// <summary>Cached type reference for <see cref="string"/>.</summary>
    internal static readonly Type TString = typeof(string);
    /// <summary>Cached type reference for <see cref="float"/>.</summary>
    internal static readonly Type TFloat = typeof(float);
    /// <summary>Cached type reference for <see cref="double"/>.</summary>
    internal static readonly Type TDouble = typeof(double);
    /// <summary>Cached type reference for <see cref="int"/>.</summary>
    internal static readonly Type TInt = typeof(int);
    /// <summary>Cached type reference for <see cref="long"/>.</summary>
    internal static readonly Type TLong = typeof(long);
    /// <summary>Cached type reference for <see cref="short"/>.</summary>
    internal static readonly Type TShort = typeof(short);
    /// <summary>Cached type reference for <see cref="decimal"/>.</summary>
    internal static readonly Type TDecimal = typeof(decimal);
    /// <summary>Cached type reference for <see cref="sbyte"/>.</summary>
    internal static readonly Type TSbyte = typeof(sbyte);
    /// <summary>Cached type reference for <see cref="byte"/>.</summary>
    internal static readonly Type TByte = typeof(byte);
    /// <summary>Cached type reference for <see cref="ushort"/>.</summary>
    internal static readonly Type TUshort = typeof(ushort);
    /// <summary>Cached type reference for <see cref="uint"/>.</summary>
    internal static readonly Type TUint = typeof(uint);
    /// <summary>Cached type reference for <see cref="ulong"/>.</summary>
    internal static readonly Type TUlong = typeof(ulong);
    /// <summary>Cached type reference for <see cref="DateTime"/>.</summary>
    internal static readonly Type TDateTime = typeof(DateTime);
    /// <summary>Cached type reference for byte array.</summary>
    internal static readonly Type TBinary = typeof(byte[]);
    /// <summary>Cached type reference for <see cref="char"/>.</summary>
    internal static readonly Type TChar = typeof(char);
    /// <summary>List of all basic .NET types.</summary>
    internal static readonly List<Type> AllBasicTypes = new()
    {
        TObject, TString, TStringBuilder, TInt, TDateTime,
        TDouble, TFloat, TChar, TBinary, TByte, TShort, TBinary, TLong, TDecimal, TSbyte, TUshort, TUint, TUlong
    };
    /// <summary>Cached type reference for <see cref="IList"/>.</summary>
    internal static readonly Type ListType = typeof(IList);
    /// <summary>Cached type reference for <see cref="bool"/>.</summary>
    internal static readonly Type TBool = typeof(bool);
    /// <summary>Cached type reference for <see cref="Guid"/>.</summary>
    internal static readonly Type TGuid = typeof(Guid);
}
