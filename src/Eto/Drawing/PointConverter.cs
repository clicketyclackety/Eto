using System;
using sc = System.ComponentModel;
using System.Globalization;

namespace Eto.Drawing;

/// <summary>
/// Converter for the <see cref="Point"/> class
/// </summary>
/// <remarks>
/// Allows conversion from a string to a <see cref="Point"/> via json/xaml or other sources.
/// </remarks>
/// <copyright>(c) 2014 by Curtis Wensley</copyright>
/// <license type="BSD-3">See LICENSE for full terms</license>
class PointConverterInternal : sc.TypeConverter
{
	/// <summary>
	/// The character to split up the string which will be converted
	/// </summary>
	static readonly char[] DimensionSplitter = new char[1] { ',' };

	/// <summary>
	/// Determines if this converter can convert from the specified <paramref name="sourceType"/>
	/// </summary>
	/// <param name="context">Conversion context</param>
	/// <param name="sourceType">Type to convert from</param>
	/// <returns>True if this converter can convert from the specified type, false otherwise</returns>
	public override bool CanConvertFrom(sc.ITypeDescriptorContext context, Type sourceType)
	{
		return sourceType == typeof(string);
	}

	/// <summary>
	/// Converts the specified value to a <see cref="Point"/>
	/// </summary>
	/// <param name="context">Conversion context</param>
	/// <param name="culture">Culture to perform the conversion</param>
	/// <param name="value">Value to convert</param>
	/// <returns>A new instance of a <see cref="Point"/> converted from the specified <paramref name="value"/></returns>
	public override object ConvertFrom(sc.ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		string text = value as string;
		if (text != null)
		{
			string[] parts = text.Split(DimensionSplitter, StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length != 2)
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Cannot parse value '{0}' as Point. Should be in the form of 'x, y'", text));

			try
			{
				return new Point(
					int.Parse(parts[0]),
					int.Parse(parts[1])
				);
			}
			catch
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Cannot parse value '{0}' as Point. Should be in the form of 'x, y'", text));
			}
		}
		return base.ConvertFrom(context, culture, value);
	}
}

/// <summary>
/// Converter for the <see cref="Point"/> class
/// </summary>
/// <remarks>
/// Allows conversion from a string to a <see cref="Point"/> via json/xaml or other sources.
/// </remarks>
/// <copyright>(c) 2014 by Curtis Wensley</copyright>
/// <license type="BSD-3">See LICENSE for full terms</license>
[Obsolete("Since 2.5. Use TypeDescriptor.GetConverter instead")]
public class PointConverter : TypeConverter
{
	/// <summary>
	/// The character to split up the string which will be converted
	/// </summary>
	static readonly char[] DimensionSplitter = new char[1] { ',' };

	/// <summary>
	/// Determines if this converter can convert from the specified <paramref name="sourceType"/>
	/// </summary>
	/// <param name="context">Conversion context</param>
	/// <param name="sourceType">Type to convert from</param>
	/// <returns>True if this converter can convert from the specified type, false otherwise</returns>
	public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
	{
		return sourceType == typeof(string);
	}

	/// <summary>
	/// Converts the specified value to a <see cref="Point"/>
	/// </summary>
	/// <param name="context">Conversion context</param>
	/// <param name="culture">Culture to perform the conversion</param>
	/// <param name="value">Value to convert</param>
	/// <returns>A new instance of a <see cref="Point"/> converted from the specified <paramref name="value"/></returns>
	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		string text = value as string;
		if (text != null)
		{
			string[] parts = text.Split(DimensionSplitter, StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length != 2)
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Cannot parse value '{0}' as Point. Should be in the form of 'x, y'", text));

			try
			{
				return new Point(
					int.Parse(parts[0]),
					int.Parse(parts[1])
				);
			}
			catch
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Cannot parse value '{0}' as Point. Should be in the form of 'x, y'", text));
			}
		}
		return base.ConvertFrom(context, culture, value);
	}
}