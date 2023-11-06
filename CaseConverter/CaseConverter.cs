using System.Text;

namespace Ruboarm.CaseConverter;

public static class CaseConverter
{
    private static bool IsCaseConvertable(this string? text)
    {
        if (text == null)
            return false;

        if (text.Contains('_') || text.Contains('-'))
            return text.Length >= 3;

        return text.Length >= 2;
    }

    private static bool IsSnakeCase(this string text)
    {
        if (!text.IsCaseConvertable())
        {
            throw new ArgumentNullException(nameof(text));
        }

        return char.IsLower(text.First()) && text.Contains('_')
                                          && !text.Any(char.IsUpper) && !text.Contains('-');
    }

    private static bool IsCamelCase(this string text)
    {
        if (!text.IsCaseConvertable())
        {
            throw new ArgumentNullException(nameof(text));
        }

        return char.IsLower(text.First()) && text.Any(char.IsUpper)
                                          && !text.Contains('_') && !text.Contains('-');
    }

    private static bool IsPascalCase(this string text)
    {
        if (!text.IsCaseConvertable())
        {
            throw new ArgumentNullException(nameof(text));
        }

        return char.IsUpper(text.First())
               && !text.Contains('_') && !text.Contains('-');
    }

    private static bool IsKebabCase(this string text)
    {
        if (!text.IsCaseConvertable())
        {
            throw new ArgumentNullException(nameof(text));
        }

        return char.IsLower(text.First()) && !text.Any(char.IsUpper)
                                          && text.Contains('-') && !text.Contains('_');
    }

    private enum ConversionCase
    {
        SnakeCase,
        CamelCase,
        PascalCase,
        KebabCase,
        Unknown
    }

    private static ConversionCase GetCase(this string text)
    {
        if (text.IsSnakeCase())
            return ConversionCase.SnakeCase;

        if (text.IsCamelCase())
            return ConversionCase.CamelCase;

        if (text.IsPascalCase())
            return ConversionCase.PascalCase;

        if (text.IsKebabCase())
            return ConversionCase.KebabCase;

        return ConversionCase.Unknown;
    }

    public static string ToSnakeCase(this string text)
    {
        if (text.IsCamelCase()) return CamelCaseToSnakeCase(text);

        if (text.IsPascalCase()) return PascalCaseToSnakeCase(text);

        if (text.IsKebabCase()) return KebabCaseToSnakeCase(text);

        return text;
    }

    public static string ToCamelCase(this string text)
    {
        if (text.IsSnakeCase()) return SnakeCaseToCamelCase(text);

        if (text.IsPascalCase()) return PascalCaseToCamelCase(text);

        if (text.IsKebabCase()) return KebabCaseToCamelCase(text);

        return text;
    }

    public static string ToPascalCase(this string text)
    {
        if (text.IsSnakeCase()) return SnakeCaseToPascalCase(text);

        if (text.IsCamelCase()) return CamelCaseToPascalCase(text);

        if (text.IsKebabCase()) return KebabCaseToPascalCase(text);

        return text;
    }

    public static string ToKebabCase(this string text)
    {
        if (text.IsCamelCase()) return CamelCaseToKebabCase(text);

        if (text.IsPascalCase()) return PascalCaseToKebabCase(text);

        if (text.IsSnakeCase()) return SnakeCaseToKebabCase(text);

        return text;
    }


    private static string CamelCaseToSnakeCase(string text)
    {
        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(text[0]));

        for (var i = 1; i < text.Length; ++i)
        {
            var c = text[i];
            if (char.IsUpper(c))
            {
                sb.Append('_');
                sb.Append(char.ToLowerInvariant(c));
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    private static string PascalCaseToSnakeCase(string text)
    {
        return CamelCaseToSnakeCase(text);
    }

    private static string KebabCaseToSnakeCase(string text)
    {
        return text.Replace('-', '_');
    }

    private static string SnakeCaseToCamelCase(string text)
    {
        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(text[0]));

        for (var i = 1; i < text.Length; ++i)
        {
            var c = text[i];
            if (c == '-' || c == '_')
            {
                i++;
                sb.Append(char.ToUpperInvariant(text[i]));
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    private static string PascalCaseToCamelCase(string text)
    {
        return text.Replace(text[0], char.ToLowerInvariant(text[0]));
    }

    private static string KebabCaseToCamelCase(string text)
    {
        return SnakeCaseToCamelCase(text);
    }

    private static string SnakeCaseToPascalCase(string text)
    {
        var sb = new StringBuilder();
        sb.Append(char.ToUpperInvariant(text[0]));

        for (var i = 1; i < text.Length; ++i)
        {
            var c = text[i];
            if (c == '-' || c == '_')
            {
                i++;
                sb.Append(char.ToUpperInvariant(text[i]));
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    private static string CamelCaseToPascalCase(string text)
    {
        return char.ToUpperInvariant(text[0]) + text.Substring(1, text.Length - 1);
    }

    private static string KebabCaseToPascalCase(string text)
    {
        return SnakeCaseToPascalCase(text);
    }

    private static string CamelCaseToKebabCase(string text)
    {
        return PascalCaseToKebabCase(text);
    }

    private static string PascalCaseToKebabCase(string text)
    {
        var sb = new StringBuilder();
        sb.Append(char.ToLowerInvariant(text[0]));

        for (var i = 1; i < text.Length; ++i)
        {
            var c = text[i];
            if (char.IsUpper(c))
            {
                sb.Append('-');
                sb.Append(char.ToLowerInvariant(c));
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    private static string SnakeCaseToKebabCase(string text)
    {
        return text.Replace('_', '-');
    }
}