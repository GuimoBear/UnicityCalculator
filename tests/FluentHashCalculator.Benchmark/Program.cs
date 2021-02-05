﻿using BenchmarkDotNet.Running;
using FluentHashCalculator.Tests;
using System;
using System.Security.Cryptography;

namespace FluentHashCalculator.Benchmark
{
    class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public DateTime Birthday { get; set; }
        }

        public class PersonHashCalculator : AbstractHashCalculator<Person>.CRC32
        {
            public PersonHashCalculator()
            {
                IgnoreErrors = false;

                GlobalSettings.StringSettings.Encoding = System.Text.Encoding.Latin1;

                Calculate
                    .Using(p => p.Name, encoding: System.Text.Encoding.Latin1)
                    .Using(e => e.Birthday);
            }
        }

        static void Main(string[] args)
        {
            /*
            var crc32Calculator = new PersonHashCalculator();

            var person = new Person
            {
                Name = "John Krasinski", 
                Birthday = new DateTime(1979, 10, 20)
            };

            var crc32 = crc32Calculator.Compute(person);

            // Print 1158920806
            Console.WriteLine(crc32);
            */

            /*
            // BenchmarkRunner.Run<CRC16FluentHashCalculatorBenchmark>();
            // BenchmarkRunner.Run<CRC32FluentHashCalculatorBenchmark>();
            // BenchmarkRunner.Run<CRC64FluentHashCalculatorBenchmark>();
            BenchmarkRunner.Run<SHA1FluentHashCalculatorBenchmark>();
            BenchmarkRunner.Run<SHA1FluentHashCalculatorWithoutPoolBenchmark>();
            BenchmarkRunner.Run<SHA1FluentHashCalculatorWithoutPoolAndAppendDataBenchmark>();
            BenchmarkRunner.Run<SHA256FluentHashCalculatorBenchmark>();
            BenchmarkRunner.Run<SHA256FluentHashCalculatorWithoutPoolBenchmark>();
            BenchmarkRunner.Run<SHA256FluentHashCalculatorWithoutPoolAndAppendDataBenchmark>();
            BenchmarkRunner.Run<SHA384FluentHashCalculatorBenchmark>();
            BenchmarkRunner.Run<SHA384FluentHashCalculatorWithoutPoolBenchmark>();
            BenchmarkRunner.Run<SHA384FluentHashCalculatorWithoutPoolAndAppendDataBenchmark>();
            BenchmarkRunner.Run<SHA512FluentHashCalculatorBenchmark>();
            BenchmarkRunner.Run<SHA512FluentHashCalculatorWithoutPoolBenchmark>();
            BenchmarkRunner.Run<SHA512FluentHashCalculatorWithoutPoolAndAppendDataBenchmark>();
            */
            PrintResults();
        }

        private static void PrintResults()
        {
            var crc64test = new CRC64FluentHashCalculatorTests();
            var crc32test = new CRC32FluentHashCalculatorTests();
            var crc16test = new CRC16FluentHashCalculatorTests();
            var sha1test = new SHA1FluentHashCalculatorTests();
            var sha256test = new SHA256FluentHashCalculatorTests();
            var sha384test = new SHA384FluentHashCalculatorTests();
            var sha512test = new SHA512FluentHashCalculatorTests();
            var md5test = new MD5FluentHashCalculatorTests();

            var (crc64With, crc64Without) = crc64test.UsingAllPropertiesInCalculatorWhenComputeThenReturnCRC64();
            var (crc32With, crc32Without) = crc32test.UsingAllPropertiesInCalculatorWhenComputeThenReturnCRC32();
            var (crc16With, crc16Without) = crc16test.UsingAllPropertiesInCalculatorWhenComputeThenReturnCRC16();
            var (sha1With, sha1Without) = sha1test.UsingAllPropertiesInCalculatorWhenComputeThenReturnSHA1();
            var (sha256With, sha256Without) = sha256test.UsingAllPropertiesInCalculatorWhenComputeThenReturnSHA256();
            var (sha384With, sha384Without) = sha384test.UsingAllPropertiesInCalculatorWhenComputeThenReturnSHA384();
            var (sha512With, sha512Without) = sha512test.UsingAllPropertiesInCalculatorWhenComputeThenReturnSHA512();
            var (md5With, md5Without) = md5test.UsingAllPropertiesInCalculatorWhenComputeThenReturnMD5();

            Console.WriteLine("        #region Valores dos Hash das entidades");
            Console.WriteLine($"        public const ulong ENTITY_WITH_ALL_SUPPORTED_TYPES_CRC64 = {crc64With};");
            Console.WriteLine($"        public const ulong ENTITY_WITH_ALL_SUPPORTED_TYPESBUT_WITH_NO_UINT_PROPERTY_CRC64 = {crc64Without};");
            Console.WriteLine($"");
            Console.WriteLine($"        public const uint ENTITY_WITH_ALL_SUPPORTED_TYPES_CRC32 = {crc32With};");
            Console.WriteLine($"        public const uint ENTITY_WITH_ALL_SUPPORTED_TYPESBUT_WITH_NO_UINT_PROPERTY_CRC32 = {crc32Without};");
            Console.WriteLine($"");
            Console.WriteLine($"        public const ushort ENTITY_WITH_ALL_SUPPORTED_TYPES_CRC16 = {crc16With};");
            Console.WriteLine($"        public const ushort ENTITY_WITH_ALL_SUPPORTED_TYPESBUT_WITH_NO_UINT_PROPERTY_CRC16 = {crc16Without};");
            Console.WriteLine($"");
            Console.WriteLine($"        public static readonly byte[] ENTITY_WITH_ALL_SUPPORTED_TYPES_SHA1 = new byte[] {{ {string.Join(", ", sha1With)} }};");
            Console.WriteLine($"        public static readonly byte[] ENTITY_WITH_ALL_SUPPORTED_TYPESBUT_WITH_NO_UINT_PROPERTY_SHA1 = new byte[] {{ {string.Join(", ", sha1Without)} }};");
            Console.WriteLine($"");
            Console.WriteLine($"        public static readonly byte[] ENTITY_WITH_ALL_SUPPORTED_TYPES_SHA256 = new byte[] {{ {string.Join(", ", sha256With)} }};");
            Console.WriteLine($"        public static readonly byte[] ENTITY_WITH_ALL_SUPPORTED_TYPESBUT_WITH_NO_UINT_PROPERTY_SHA256 = new byte[] {{ {string.Join(", ", sha256Without)} }};");
            Console.WriteLine($"");
            Console.WriteLine($"        public static readonly byte[] ENTITY_WITH_ALL_SUPPORTED_TYPES_SHA384 = new byte[] {{ {string.Join(", ", sha384With)} }};");
            Console.WriteLine($"        public static readonly byte[] ENTITY_WITH_ALL_SUPPORTED_TYPESBUT_WITH_NO_UINT_PROPERTY_SHA384 = new byte[] {{ {string.Join(", ", sha384Without)} }};");
            Console.WriteLine($"");
            Console.WriteLine($"        public static readonly byte[] ENTITY_WITH_ALL_SUPPORTED_TYPES_SHA512 = new byte[] {{ {string.Join(", ", sha512With)} }};");
            Console.WriteLine($"        public static readonly byte[] ENTITY_WITH_ALL_SUPPORTED_TYPESBUT_WITH_NO_UINT_PROPERTY_SHA512 = new byte[] {{ {string.Join(", ", sha512Without)} }};");
            Console.WriteLine($"");
            Console.WriteLine($"        public static readonly byte[] ENTITY_WITH_ALL_SUPPORTED_TYPES_MD5 = new byte[] {{ {string.Join(", ", md5With)} }};");
            Console.WriteLine($"        public static readonly byte[] ENTITY_WITH_ALL_SUPPORTED_TYPESBUT_WITH_NO_UINT_PROPERTY_MD5 = new byte[] {{ {string.Join(", ", md5Without)} }};");
            Console.WriteLine("        #endregion");
            Console.WriteLine("");
            Console.WriteLine("        #region Valores dos CRC64 dos valores padrão");
            Console.WriteLine($"        public const ulong BOOL_CRC64 = {crc64test.UsingBoolPropertyInCalculatorWhenComputeThenReturnBoolCRC64()};");
            Console.WriteLine($"        public const ulong BOOL_ARRAY_CRC64 = {crc64test.UsingBoolArrayPropertyInCalculatorWhenComputeThenReturnBoolArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_BOOL_CRC64 = {crc64test.UsingNullableBoolPropertyInCalculatorWhenComputeThenReturnNullableBoolCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_BOOL_ARRAY_CRC64 = {crc64test.UsingNullableBoolArrayPropertyInCalculatorWhenComputeThenReturnNullableBoolArrayCRC64()};");
            Console.WriteLine($"        public const ulong BYTE_CRC64 = {crc64test.UsingBytePropertyInCalculatorWhenComputeThenReturnByteCRC64()};");
            Console.WriteLine($"        public const ulong BYTE_ARRAY_CRC64 = {crc64test.UsingByteArrayPropertyInCalculatorWhenComputeThenReturnByteArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_BYTE_CRC64 = {crc64test.UsingNullableBytePropertyInCalculatorWhenComputeThenReturnNullableByteCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_BYTE_ARRAY_CRC64 = {crc64test.UsingNullableByteArrayPropertyInCalculatorWhenComputeThenReturnNullableByteArrayCRC64()};");
            Console.WriteLine($"        public const ulong SBYTE_CRC64 = {crc64test.UsingSbytePropertyInCalculatorWhenComputeThenReturnSbyteCRC64()};");
            Console.WriteLine($"        public const ulong SBYTE_ARRAY_CRC64 = {crc64test.UsingSbyteArrayPropertyInCalculatorWhenComputeThenReturnSbyteArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_SBYTE_CRC64 = {crc64test.UsingNullableSbytePropertyInCalculatorWhenComputeThenReturnNullableSbyteCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_SBYTE_ARRAY_CRC64 = {crc64test.UsingNullableSbyteArrayPropertyInCalculatorWhenComputeThenReturnNullableSbyteArrayCRC64()};");
            Console.WriteLine($"        public const ulong SHORT_CRC64 = {crc64test.UsingShortPropertyInCalculatorWhenComputeThenReturnShortCRC64()};");
            Console.WriteLine($"        public const ulong SHORT_ARRAY_CRC64 = {crc64test.UsingShortArrayPropertyInCalculatorWhenComputeThenReturnShortArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_SHORT_CRC64 = {crc64test.UsingNullableShortPropertyInCalculatorWhenComputeThenReturnNullableShortCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_SHORT_ARRAY_CRC64 = {crc64test.UsingNullableShortArrayPropertyInCalculatorWhenComputeThenReturnNullableShortArrayCRC64()};");
            Console.WriteLine($"        public const ulong USHORT_CRC64 = {crc64test.UsingUshortPropertyInCalculatorWhenComputeThenReturnUshortCRC64()};");
            Console.WriteLine($"        public const ulong USHORT_ARRAY_CRC64 = {crc64test.UsingUshortArrayPropertyInCalculatorWhenComputeThenReturnUshortArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_USHORT_CRC64 = {crc64test.UsingNullableUshortPropertyInCalculatorWhenComputeThenReturnNullableUshortCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_USHORT_ARRAY_CRC64 = {crc64test.UsingNullableUshortArrayPropertyInCalculatorWhenComputeThenReturnNullableUshortArrayCRC64()};");
            Console.WriteLine($"        public const ulong INT_CRC64 = {crc64test.UsingIntPropertyInCalculatorWhenComputeThenReturnIntCRC64()};");
            Console.WriteLine($"        public const ulong INT_ARRAY_CRC64 = {crc64test.UsingIntArrayPropertyInCalculatorWhenComputeThenReturnIntArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_INT_CRC64 = {crc64test.UsingNullableIntPropertyInCalculatorWhenComputeThenReturnNullableIntCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_INT_ARRAY_CRC64 = {crc64test.UsingNullableIntArrayPropertyInCalculatorWhenComputeThenReturnNullableIntArrayCRC64()};");
            Console.WriteLine($"        public const ulong UINT_CRC64 = {crc64test.UsingUintPropertyInCalculatorWhenComputeThenReturnUintCRC64()};");
            Console.WriteLine($"        public const ulong UINT_ARRAY_CRC64 = {crc64test.UsingUintArrayPropertyInCalculatorWhenComputeThenReturnUintArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_UINT_CRC64 = {crc64test.UsingNullableUintPropertyInCalculatorWhenComputeThenReturnNullableUintCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_UINT_ARRAY_CRC64 = {crc64test.UsingNullableUintArrayPropertyInCalculatorWhenComputeThenReturnNullableUintArrayCRC64()};");
            Console.WriteLine($"        public const ulong LONG_CRC64 = {crc64test.UsingLongPropertyInCalculatorWhenComputeThenReturnLongCRC64()};");
            Console.WriteLine($"        public const ulong LONG_ARRAY_CRC64 = {crc64test.UsingLongArrayPropertyInCalculatorWhenComputeThenReturnLongArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_LONG_CRC64 = {crc64test.UsingNullableLongPropertyInCalculatorWhenComputeThenReturnNullableLongCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_LONG_ARRAY_CRC64 = {crc64test.UsingNullableLongArrayPropertyInCalculatorWhenComputeThenReturnNullableLongArrayCRC64()};");
            Console.WriteLine($"        public const ulong ULONG_CRC64 = {crc64test.UsingUlongPropertyInCalculatorWhenComputeThenReturnUlongCRC64()};");
            Console.WriteLine($"        public const ulong ULONG_ARRAY_CRC64 = {crc64test.UsingUlongArrayPropertyInCalculatorWhenComputeThenReturnUlongArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_ULONG_CRC64 = {crc64test.UsingNullableUlongPropertyInCalculatorWhenComputeThenReturnNullableUlongCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_ULONG_ARRAY_CRC64 = {crc64test.UsingNullableUlongArrayPropertyInCalculatorWhenComputeThenReturnNullableUlongArrayCRC64()};");
            Console.WriteLine($"        public const ulong FLOAT_CRC64 = {crc64test.UsingFloatPropertyInCalculatorWhenComputeThenReturnFloatCRC64()};");
            Console.WriteLine($"        public const ulong FLOAT_ARRAY_CRC64 = {crc64test.UsingFloatArrayPropertyInCalculatorWhenComputeThenReturnFloatArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_FLOAT_CRC64 = {crc64test.UsingNullableFloatPropertyInCalculatorWhenComputeThenReturnNullableFloatCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_FLOAT_ARRAY_CRC64 = {crc64test.UsingNullableFloatArrayPropertyInCalculatorWhenComputeThenReturnNullableFloatArrayCRC64()};");
            Console.WriteLine($"        public const ulong DOUBLE_CRC64 = {crc64test.UsingDoublePropertyInCalculatorWhenComputeThenReturnDoubleCRC64()};");
            Console.WriteLine($"        public const ulong DOUBLE_ARRAY_CRC64 = {crc64test.UsingDoubleArrayPropertyInCalculatorWhenComputeThenReturnDoubleArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_DOUBLE_CRC64 = {crc64test.UsingNullableDoublePropertyInCalculatorWhenComputeThenReturnNullableDoubleCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_DOUBLE_ARRAY_CRC64 = {crc64test.UsingNullableDoubleArrayPropertyInCalculatorWhenComputeThenReturnNullableDoubleArrayCRC64()};");
            Console.WriteLine($"        public const ulong DECIMAL_CRC64 = {crc64test.UsingDecimalPropertyInCalculatorWhenComputeThenReturnDecimalCRC64()};");
            Console.WriteLine($"        public const ulong DECIMAL_ARRAY_CRC64 = {crc64test.UsingDecimalArrayPropertyInCalculatorWhenComputeThenReturnDecimalArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_DECIMAL_CRC64 = {crc64test.UsingNullableDecimalPropertyInCalculatorWhenComputeThenReturnNullableDecimalCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_DECIMAL_ARRAY_CRC64 = {crc64test.UsingNullableDecimalArrayPropertyInCalculatorWhenComputeThenReturnNullableDecimalArrayCRC64()};");
            Console.WriteLine($"        public const ulong DATETIME_CRC64 = {crc64test.UsingDateTimePropertyInCalculatorWhenComputeThenReturnDateTimeCRC64()};");
            Console.WriteLine($"        public const ulong DATETIME_ARRAY_CRC64 = {crc64test.UsingDateTimeArrayPropertyInCalculatorWhenComputeThenReturnDateTimeArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_DATETIME_CRC64 = {crc64test.UsingNullableDateTimePropertyInCalculatorWhenComputeThenReturnNullableDateTimeCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_DATETIME_ARRAY_CRC64 = {crc64test.UsingNullableDateTimeArrayPropertyInCalculatorWhenComputeThenReturnNullableDateTimeArrayCRC64()};");
            Console.WriteLine($"        public const ulong TIMESPAN_CRC64 = {crc64test.UsingTimeSpanPropertyInCalculatorWhenComputeThenReturnTimeSpanCRC64()};");
            Console.WriteLine($"        public const ulong TIMESPAN_ARRAY_CRC64 = {crc64test.UsingTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnTimeSpanArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_TIMESPAN_CRC64 = {crc64test.UsingNullableTimeSpanPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_TIMESPAN_ARRAY_CRC64 = {crc64test.UsingNullableTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanArrayCRC64()};");
            Console.WriteLine($"        public const ulong CHAR_CRC64 = {crc64test.UsingCharPropertyInCalculatorWhenComputeThenReturnCharCRC64()};");
            Console.WriteLine($"        public const ulong CHAR_ARRAY_CRC64 = {crc64test.UsingCharArrayPropertyInCalculatorWhenComputeThenReturnCharArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_CHAR_CRC64 = {crc64test.UsingNullableCharPropertyInCalculatorWhenComputeThenReturnNullableCharCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_CHAR_ARRAY_CRC64 = {crc64test.UsingNullableCharArrayPropertyInCalculatorWhenComputeThenReturnNullableCharArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_STRING_UTF8_CRC64 = {crc64test.UsingNullableStringPropertyInCalculatorWhenComputeThenReturnNullableStringCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_STRING_UNICODE_CRC64 = {crc64test.UsingNullableStringPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_STRING_UTF32_CRC64 = {crc64test.UsingNullableStringPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_STRING_ARRAY_UTF8_CRC64 = {crc64test.UsingNullableStringArrayPropertyInCalculatorWhenComputeThenReturnNullableStringArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_STRING_ARRAY_UNICODE_CRC64 = {crc64test.UsingNullableStringArrayPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_STRING_ARRAY_UTF32_CRC64 = {crc64test.UsingNullableStringArrayPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringArrayCRC64()};");
            Console.WriteLine($"        public const ulong GUID_CRC64 = {crc64test.UsingGuidPropertyInCalculatorWhenComputeThenReturnGuidCRC64()};");
            Console.WriteLine($"        public const ulong GUID_ARRAY_CRC64 = {crc64test.UsingGuidArrayPropertyInCalculatorWhenComputeThenReturnGuidArrayCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_GUID_CRC64 = {crc64test.UsingNullableGuidPropertyInCalculatorWhenComputeThenReturnNullableGuidCRC64()};");
            Console.WriteLine($"        public const ulong NULLABLE_GUID_ARRAY_CRC64 = {crc64test.UsingNullableGuidArrayPropertyInCalculatorWhenComputeThenReturnNullableGuidArrayCRC64()};");
            Console.WriteLine($"");
            Console.WriteLine($"        public const ulong CHILD_ENTITY_ID_CRC64 = {crc64test.UsingComplexPropertyInCalculatorWhenComputeThenReturnEntityIdCRC64()};");
            Console.WriteLine($"        public const ulong CHILDLIST_ENTITY_ID_CRC64 = {crc64test.UsingComplexListPropertyInCalculatorWhenComputeThenReturnEntityIdCRC64()};");

            var (utf8CRC64, unicodeCRC64, utf32CRC64) = crc64test.UsingComplexPropertyWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorCRC64();
            Console.WriteLine("");
            Console.WriteLine($"        public const ulong CHILD_ENTITY_STRING_UTF8_CRC64 = {utf8CRC64};");
            Console.WriteLine($"        public const ulong CHILD_ENTITY_STRING_UNICODE_CRC64 = {unicodeCRC64};");
            Console.WriteLine($"        public const ulong CHILD_ENTITY_STRING_UTF32_CRC64 = {utf32CRC64};");

            (utf8CRC64, unicodeCRC64, utf32CRC64) = crc64test.UsingComplexPropertyListWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorCRC64();

            Console.WriteLine($"        public const ulong CHILDLIST_ENTITY_STRING_UTF8_CRC64 = {utf8CRC64};");
            Console.WriteLine($"        public const ulong CHILDLIST_ENTITY_STRING_UNICODE_CRC64 = {unicodeCRC64};");
            Console.WriteLine($"        public const ulong CHILDLIST_ENTITY_STRING_UTF32_CRC64 = {utf32CRC64};");

            Console.WriteLine("        #endregion");

            Console.WriteLine("");

            Console.WriteLine("        #region Valores dos CRC32 dos valores padrão");
            Console.WriteLine($"        public const uint BOOL_CRC32 = {crc32test.UsingBoolPropertyInCalculatorWhenComputeThenReturnBoolCRC32()};");
            Console.WriteLine($"        public const uint BOOL_ARRAY_CRC32 = {crc32test.UsingBoolArrayPropertyInCalculatorWhenComputeThenReturnBoolArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_BOOL_CRC32 = {crc32test.UsingNullableBoolPropertyInCalculatorWhenComputeThenReturnNullableBoolCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_BOOL_ARRAY_CRC32 = {crc32test.UsingNullableBoolArrayPropertyInCalculatorWhenComputeThenReturnNullableBoolArrayCRC32()};");
            Console.WriteLine($"        public const uint BYTE_CRC32 = {crc32test.UsingBytePropertyInCalculatorWhenComputeThenReturnByteCRC32()};");
            Console.WriteLine($"        public const uint BYTE_ARRAY_CRC32 = {crc32test.UsingByteArrayPropertyInCalculatorWhenComputeThenReturnByteArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_BYTE_CRC32 = {crc32test.UsingNullableBytePropertyInCalculatorWhenComputeThenReturnNullableByteCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_BYTE_ARRAY_CRC32 = {crc32test.UsingNullableByteArrayPropertyInCalculatorWhenComputeThenReturnNullableByteArrayCRC32()};");
            Console.WriteLine($"        public const uint SBYTE_CRC32 = {crc32test.UsingSbytePropertyInCalculatorWhenComputeThenReturnSbyteCRC32()};");
            Console.WriteLine($"        public const uint SBYTE_ARRAY_CRC32 = {crc32test.UsingSbyteArrayPropertyInCalculatorWhenComputeThenReturnSbyteArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_SBYTE_CRC32 = {crc32test.UsingNullableSbytePropertyInCalculatorWhenComputeThenReturnNullableSbyteCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_SBYTE_ARRAY_CRC32 = {crc32test.UsingNullableSbyteArrayPropertyInCalculatorWhenComputeThenReturnNullableSbyteArrayCRC32()};");
            Console.WriteLine($"        public const uint SHORT_CRC32 = {crc32test.UsingShortPropertyInCalculatorWhenComputeThenReturnShortCRC32()};");
            Console.WriteLine($"        public const uint SHORT_ARRAY_CRC32 = {crc32test.UsingShortArrayPropertyInCalculatorWhenComputeThenReturnShortArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_SHORT_CRC32 = {crc32test.UsingNullableShortPropertyInCalculatorWhenComputeThenReturnNullableShortCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_SHORT_ARRAY_CRC32 = {crc32test.UsingNullableShortArrayPropertyInCalculatorWhenComputeThenReturnNullableShortArrayCRC32()};");
            Console.WriteLine($"        public const uint USHORT_CRC32 = {crc32test.UsingUshortPropertyInCalculatorWhenComputeThenReturnUshortCRC32()};");
            Console.WriteLine($"        public const uint USHORT_ARRAY_CRC32 = {crc32test.UsingUshortArrayPropertyInCalculatorWhenComputeThenReturnUshortArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_USHORT_CRC32 = {crc32test.UsingNullableUshortPropertyInCalculatorWhenComputeThenReturnNullableUshortCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_USHORT_ARRAY_CRC32 = {crc32test.UsingNullableUshortArrayPropertyInCalculatorWhenComputeThenReturnNullableUshortArrayCRC32()};");
            Console.WriteLine($"        public const uint INT_CRC32 = {crc32test.UsingIntPropertyInCalculatorWhenComputeThenReturnIntCRC32()};");
            Console.WriteLine($"        public const uint INT_ARRAY_CRC32 = {crc32test.UsingIntArrayPropertyInCalculatorWhenComputeThenReturnIntArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_INT_CRC32 = {crc32test.UsingNullableIntPropertyInCalculatorWhenComputeThenReturnNullableIntCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_INT_ARRAY_CRC32 = {crc32test.UsingNullableIntArrayPropertyInCalculatorWhenComputeThenReturnNullableIntArrayCRC32()};");
            Console.WriteLine($"        public const uint UINT_CRC32 = {crc32test.UsingUintPropertyInCalculatorWhenComputeThenReturnUintCRC32()};");
            Console.WriteLine($"        public const uint UINT_ARRAY_CRC32 = {crc32test.UsingUintArrayPropertyInCalculatorWhenComputeThenReturnUintArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_UINT_CRC32 = {crc32test.UsingNullableUintPropertyInCalculatorWhenComputeThenReturnNullableUintCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_UINT_ARRAY_CRC32 = {crc32test.UsingNullableUintArrayPropertyInCalculatorWhenComputeThenReturnNullableUintArrayCRC32()};");
            Console.WriteLine($"        public const uint LONG_CRC32 = {crc32test.UsingLongPropertyInCalculatorWhenComputeThenReturnLongCRC32()};");
            Console.WriteLine($"        public const uint LONG_ARRAY_CRC32 = {crc32test.UsingLongArrayPropertyInCalculatorWhenComputeThenReturnLongArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_LONG_CRC32 = {crc32test.UsingNullableLongPropertyInCalculatorWhenComputeThenReturnNullableLongCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_LONG_ARRAY_CRC32 = {crc32test.UsingNullableLongArrayPropertyInCalculatorWhenComputeThenReturnNullableLongArrayCRC32()};");
            Console.WriteLine($"        public const uint ULONG_CRC32 = {crc32test.UsingUlongPropertyInCalculatorWhenComputeThenReturnUlongCRC32()};");
            Console.WriteLine($"        public const uint ULONG_ARRAY_CRC32 = {crc32test.UsingUlongArrayPropertyInCalculatorWhenComputeThenReturnUlongArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_ULONG_CRC32 = {crc32test.UsingNullableUlongPropertyInCalculatorWhenComputeThenReturnNullableUlongCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_ULONG_ARRAY_CRC32 = {crc32test.UsingNullableUlongArrayPropertyInCalculatorWhenComputeThenReturnNullableUlongArrayCRC32()};");
            Console.WriteLine($"        public const uint FLOAT_CRC32 = {crc32test.UsingFloatPropertyInCalculatorWhenComputeThenReturnFloatCRC32()};");
            Console.WriteLine($"        public const uint FLOAT_ARRAY_CRC32 = {crc32test.UsingFloatArrayPropertyInCalculatorWhenComputeThenReturnFloatArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_FLOAT_CRC32 = {crc32test.UsingNullableFloatPropertyInCalculatorWhenComputeThenReturnNullableFloatCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_FLOAT_ARRAY_CRC32 = {crc32test.UsingNullableFloatArrayPropertyInCalculatorWhenComputeThenReturnNullableFloatArrayCRC32()};");
            Console.WriteLine($"        public const uint DOUBLE_CRC32 = {crc32test.UsingDoublePropertyInCalculatorWhenComputeThenReturnDoubleCRC32()};");
            Console.WriteLine($"        public const uint DOUBLE_ARRAY_CRC32 = {crc32test.UsingDoubleArrayPropertyInCalculatorWhenComputeThenReturnDoubleArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_DOUBLE_CRC32 = {crc32test.UsingNullableDoublePropertyInCalculatorWhenComputeThenReturnNullableDoubleCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_DOUBLE_ARRAY_CRC32 = {crc32test.UsingNullableDoubleArrayPropertyInCalculatorWhenComputeThenReturnNullableDoubleArrayCRC32()};");
            Console.WriteLine($"        public const uint DECIMAL_CRC32 = {crc32test.UsingDecimalPropertyInCalculatorWhenComputeThenReturnDecimalCRC32()};");
            Console.WriteLine($"        public const uint DECIMAL_ARRAY_CRC32 = {crc32test.UsingDecimalArrayPropertyInCalculatorWhenComputeThenReturnDecimalArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_DECIMAL_CRC32 = {crc32test.UsingNullableDecimalPropertyInCalculatorWhenComputeThenReturnNullableDecimalCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_DECIMAL_ARRAY_CRC32 = {crc32test.UsingNullableDecimalArrayPropertyInCalculatorWhenComputeThenReturnNullableDecimalArrayCRC32()};");
            Console.WriteLine($"        public const uint DATETIME_CRC32 = {crc32test.UsingDateTimePropertyInCalculatorWhenComputeThenReturnDateTimeCRC32()};");
            Console.WriteLine($"        public const uint DATETIME_ARRAY_CRC32 = {crc32test.UsingDateTimeArrayPropertyInCalculatorWhenComputeThenReturnDateTimeArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_DATETIME_CRC32 = {crc32test.UsingNullableDateTimePropertyInCalculatorWhenComputeThenReturnNullableDateTimeCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_DATETIME_ARRAY_CRC32 = {crc32test.UsingNullableDateTimeArrayPropertyInCalculatorWhenComputeThenReturnNullableDateTimeArrayCRC32()};");
            Console.WriteLine($"        public const uint TIMESPAN_CRC32 = {crc32test.UsingTimeSpanPropertyInCalculatorWhenComputeThenReturnTimeSpanCRC32()};");
            Console.WriteLine($"        public const uint TIMESPAN_ARRAY_CRC32 = {crc32test.UsingTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnTimeSpanArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_TIMESPAN_CRC32 = {crc32test.UsingNullableTimeSpanPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_TIMESPAN_ARRAY_CRC32 = {crc32test.UsingNullableTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanArrayCRC32()};");
            Console.WriteLine($"        public const uint CHAR_CRC32 = {crc32test.UsingCharPropertyInCalculatorWhenComputeThenReturnCharCRC32()};");
            Console.WriteLine($"        public const uint CHAR_ARRAY_CRC32 = {crc32test.UsingCharArrayPropertyInCalculatorWhenComputeThenReturnCharArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_CHAR_CRC32 = {crc32test.UsingNullableCharPropertyInCalculatorWhenComputeThenReturnNullableCharCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_CHAR_ARRAY_CRC32 = {crc32test.UsingNullableCharArrayPropertyInCalculatorWhenComputeThenReturnNullableCharArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_STRING_UTF8_CRC32 = {crc32test.UsingNullableStringPropertyInCalculatorWhenComputeThenReturnNullableStringCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_STRING_UNICODE_CRC32 = {crc32test.UsingNullableStringPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_STRING_UTF32_CRC32 = {crc32test.UsingNullableStringPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_STRING_ARRAY_UTF8_CRC32 = {crc32test.UsingNullableStringArrayPropertyInCalculatorWhenComputeThenReturnNullableStringArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_STRING_ARRAY_UNICODE_CRC32 = {crc32test.UsingNullableStringArrayPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_STRING_ARRAY_UTF32_CRC32 = {crc32test.UsingNullableStringArrayPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringArrayCRC32()};");
            Console.WriteLine($"        public const uint GUID_CRC32 = {crc32test.UsingGuidPropertyInCalculatorWhenComputeThenReturnGuidCRC32()};");
            Console.WriteLine($"        public const uint GUID_ARRAY_CRC32 = {crc32test.UsingGuidArrayPropertyInCalculatorWhenComputeThenReturnGuidArrayCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_GUID_CRC32 = {crc32test.UsingNullableGuidPropertyInCalculatorWhenComputeThenReturnNullableGuidCRC32()};");
            Console.WriteLine($"        public const uint NULLABLE_GUID_ARRAY_CRC32 = {crc32test.UsingNullableGuidArrayPropertyInCalculatorWhenComputeThenReturnNullableGuidArrayCRC32()};");
            Console.WriteLine($"");
            Console.WriteLine($"        public const uint CHILD_ENTITY_ID_CRC32 = {crc32test.UsingComplexPropertyInCalculatorWhenComputeThenReturnEntityIdCRC32()};");
            Console.WriteLine($"        public const uint CHILDLIST_ENTITY_ID_CRC32 = {crc32test.UsingComplexListPropertyInCalculatorWhenComputeThenReturnEntityIdCRC32()};");

            var (utf8CRC32, unicodeCRC32, utf32CRC32) = crc32test.UsingComplexPropertyWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorCRC32();
            Console.WriteLine("");
            Console.WriteLine($"        public const uint CHILD_ENTITY_STRING_UTF8_CRC32 = {utf8CRC32};");
            Console.WriteLine($"        public const uint CHILD_ENTITY_STRING_UNICODE_CRC32 = {unicodeCRC32};");
            Console.WriteLine($"        public const uint CHILD_ENTITY_STRING_UTF32_CRC32 = {utf32CRC32};");

            (utf8CRC32, unicodeCRC32, utf32CRC32) = crc32test.UsingComplexPropertyListWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorCRC32();

            Console.WriteLine($"        public const uint CHILDLIST_ENTITY_STRING_UTF8_CRC32 = {utf8CRC32};");
            Console.WriteLine($"        public const uint CHILDLIST_ENTITY_STRING_UNICODE_CRC32 = {unicodeCRC32};");
            Console.WriteLine($"        public const uint CHILDLIST_ENTITY_STRING_UTF32_CRC32 = {utf32CRC32};");

            Console.WriteLine("        #endregion");

            Console.WriteLine("");

            Console.WriteLine("        #region Valores dos CRC16 dos valores padrão");
            Console.WriteLine($"        public const ushort BOOL_CRC16 = {crc16test.UsingBoolPropertyInCalculatorWhenComputeThenReturnBoolCRC16()};");
            Console.WriteLine($"        public const ushort BOOL_ARRAY_CRC16 = {crc16test.UsingBoolArrayPropertyInCalculatorWhenComputeThenReturnBoolArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_BOOL_CRC16 = {crc16test.UsingNullableBoolPropertyInCalculatorWhenComputeThenReturnNullableBoolCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_BOOL_ARRAY_CRC16 = {crc16test.UsingNullableBoolArrayPropertyInCalculatorWhenComputeThenReturnNullableBoolArrayCRC16()};");
            Console.WriteLine($"        public const ushort BYTE_CRC16 = {crc16test.UsingBytePropertyInCalculatorWhenComputeThenReturnByteCRC16()};");
            Console.WriteLine($"        public const ushort BYTE_ARRAY_CRC16 = {crc16test.UsingByteArrayPropertyInCalculatorWhenComputeThenReturnByteArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_BYTE_CRC16 = {crc16test.UsingNullableBytePropertyInCalculatorWhenComputeThenReturnNullableByteCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_BYTE_ARRAY_CRC16 = {crc16test.UsingNullableByteArrayPropertyInCalculatorWhenComputeThenReturnNullableByteArrayCRC16()};");
            Console.WriteLine($"        public const ushort SBYTE_CRC16 = {crc16test.UsingSbytePropertyInCalculatorWhenComputeThenReturnSbyteCRC16()};");
            Console.WriteLine($"        public const ushort SBYTE_ARRAY_CRC16 = {crc16test.UsingSbyteArrayPropertyInCalculatorWhenComputeThenReturnSbyteArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_SBYTE_CRC16 = {crc16test.UsingNullableSbytePropertyInCalculatorWhenComputeThenReturnNullableSbyteCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_SBYTE_ARRAY_CRC16 = {crc16test.UsingNullableSbyteArrayPropertyInCalculatorWhenComputeThenReturnNullableSbyteArrayCRC16()};");
            Console.WriteLine($"        public const ushort SHORT_CRC16 = {crc16test.UsingShortPropertyInCalculatorWhenComputeThenReturnShortCRC16()};");
            Console.WriteLine($"        public const ushort SHORT_ARRAY_CRC16 = {crc16test.UsingShortArrayPropertyInCalculatorWhenComputeThenReturnShortArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_SHORT_CRC16 = {crc16test.UsingNullableShortPropertyInCalculatorWhenComputeThenReturnNullableShortCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_SHORT_ARRAY_CRC16 = {crc16test.UsingNullableShortArrayPropertyInCalculatorWhenComputeThenReturnNullableShortArrayCRC16()};");
            Console.WriteLine($"        public const ushort USHORT_CRC16 = {crc16test.UsingUshortPropertyInCalculatorWhenComputeThenReturnUshortCRC16()};");
            Console.WriteLine($"        public const ushort USHORT_ARRAY_CRC16 = {crc16test.UsingUshortArrayPropertyInCalculatorWhenComputeThenReturnUshortArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_USHORT_CRC16 = {crc16test.UsingNullableUshortPropertyInCalculatorWhenComputeThenReturnNullableUshortCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_USHORT_ARRAY_CRC16 = {crc16test.UsingNullableUshortArrayPropertyInCalculatorWhenComputeThenReturnNullableUshortArrayCRC16()};");
            Console.WriteLine($"        public const ushort INT_CRC16 = {crc16test.UsingIntPropertyInCalculatorWhenComputeThenReturnIntCRC16()};");
            Console.WriteLine($"        public const ushort INT_ARRAY_CRC16 = {crc16test.UsingIntArrayPropertyInCalculatorWhenComputeThenReturnIntArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_INT_CRC16 = {crc16test.UsingNullableIntPropertyInCalculatorWhenComputeThenReturnNullableIntCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_INT_ARRAY_CRC16 = {crc16test.UsingNullableIntArrayPropertyInCalculatorWhenComputeThenReturnNullableIntArrayCRC16()};");
            Console.WriteLine($"        public const ushort UINT_CRC16 = {crc16test.UsingUintPropertyInCalculatorWhenComputeThenReturnUintCRC16()};");
            Console.WriteLine($"        public const ushort UINT_ARRAY_CRC16 = {crc16test.UsingUintArrayPropertyInCalculatorWhenComputeThenReturnUintArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_UINT_CRC16 = {crc16test.UsingNullableUintPropertyInCalculatorWhenComputeThenReturnNullableUintCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_UINT_ARRAY_CRC16 = {crc16test.UsingNullableUintArrayPropertyInCalculatorWhenComputeThenReturnNullableUintArrayCRC16()};");
            Console.WriteLine($"        public const ushort LONG_CRC16 = {crc16test.UsingLongPropertyInCalculatorWhenComputeThenReturnLongCRC16()};");
            Console.WriteLine($"        public const ushort LONG_ARRAY_CRC16 = {crc16test.UsingLongArrayPropertyInCalculatorWhenComputeThenReturnLongArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_LONG_CRC16 = {crc16test.UsingNullableLongPropertyInCalculatorWhenComputeThenReturnNullableLongCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_LONG_ARRAY_CRC16 = {crc16test.UsingNullableLongArrayPropertyInCalculatorWhenComputeThenReturnNullableLongArrayCRC16()};");
            Console.WriteLine($"        public const ushort ULONG_CRC16 = {crc16test.UsingUlongPropertyInCalculatorWhenComputeThenReturnUlongCRC16()};");
            Console.WriteLine($"        public const ushort ULONG_ARRAY_CRC16 = {crc16test.UsingUlongArrayPropertyInCalculatorWhenComputeThenReturnUlongArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_ULONG_CRC16 = {crc16test.UsingNullableUlongPropertyInCalculatorWhenComputeThenReturnNullableUlongCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_ULONG_ARRAY_CRC16 = {crc16test.UsingNullableUlongArrayPropertyInCalculatorWhenComputeThenReturnNullableUlongArrayCRC16()};");
            Console.WriteLine($"        public const ushort FLOAT_CRC16 = {crc16test.UsingFloatPropertyInCalculatorWhenComputeThenReturnFloatCRC16()};");
            Console.WriteLine($"        public const ushort FLOAT_ARRAY_CRC16 = {crc16test.UsingFloatArrayPropertyInCalculatorWhenComputeThenReturnFloatArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_FLOAT_CRC16 = {crc16test.UsingNullableFloatPropertyInCalculatorWhenComputeThenReturnNullableFloatCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_FLOAT_ARRAY_CRC16 = {crc16test.UsingNullableFloatArrayPropertyInCalculatorWhenComputeThenReturnNullableFloatArrayCRC16()};");
            Console.WriteLine($"        public const ushort DOUBLE_CRC16 = {crc16test.UsingDoublePropertyInCalculatorWhenComputeThenReturnDoubleCRC16()};");
            Console.WriteLine($"        public const ushort DOUBLE_ARRAY_CRC16 = {crc16test.UsingDoubleArrayPropertyInCalculatorWhenComputeThenReturnDoubleArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_DOUBLE_CRC16 = {crc16test.UsingNullableDoublePropertyInCalculatorWhenComputeThenReturnNullableDoubleCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_DOUBLE_ARRAY_CRC16 = {crc16test.UsingNullableDoubleArrayPropertyInCalculatorWhenComputeThenReturnNullableDoubleArrayCRC16()};");
            Console.WriteLine($"        public const ushort DECIMAL_CRC16 = {crc16test.UsingDecimalPropertyInCalculatorWhenComputeThenReturnDecimalCRC16()};");
            Console.WriteLine($"        public const ushort DECIMAL_ARRAY_CRC16 = {crc16test.UsingDecimalArrayPropertyInCalculatorWhenComputeThenReturnDecimalArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_DECIMAL_CRC16 = {crc16test.UsingNullableDecimalPropertyInCalculatorWhenComputeThenReturnNullableDecimalCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_DECIMAL_ARRAY_CRC16 = {crc16test.UsingNullableDecimalArrayPropertyInCalculatorWhenComputeThenReturnNullableDecimalArrayCRC16()};");
            Console.WriteLine($"        public const ushort DATETIME_CRC16 = {crc16test.UsingDateTimePropertyInCalculatorWhenComputeThenReturnDateTimeCRC16()};");
            Console.WriteLine($"        public const ushort DATETIME_ARRAY_CRC16 = {crc16test.UsingDateTimeArrayPropertyInCalculatorWhenComputeThenReturnDateTimeArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_DATETIME_CRC16 = {crc16test.UsingNullableDateTimePropertyInCalculatorWhenComputeThenReturnNullableDateTimeCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_DATETIME_ARRAY_CRC16 = {crc16test.UsingNullableDateTimeArrayPropertyInCalculatorWhenComputeThenReturnNullableDateTimeArrayCRC16()};");
            Console.WriteLine($"        public const ushort TIMESPAN_CRC16 = {crc16test.UsingTimeSpanPropertyInCalculatorWhenComputeThenReturnTimeSpanCRC16()};");
            Console.WriteLine($"        public const ushort TIMESPAN_ARRAY_CRC16 = {crc16test.UsingTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnTimeSpanArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_TIMESPAN_CRC16 = {crc16test.UsingNullableTimeSpanPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_TIMESPAN_ARRAY_CRC16 = {crc16test.UsingNullableTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanArrayCRC16()};");
            Console.WriteLine($"        public const ushort CHAR_CRC16 = {crc16test.UsingCharPropertyInCalculatorWhenComputeThenReturnCharCRC16()};");
            Console.WriteLine($"        public const ushort CHAR_ARRAY_CRC16 = {crc16test.UsingCharArrayPropertyInCalculatorWhenComputeThenReturnCharArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_CHAR_CRC16 = {crc16test.UsingNullableCharPropertyInCalculatorWhenComputeThenReturnNullableCharCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_CHAR_ARRAY_CRC16 = {crc16test.UsingNullableCharArrayPropertyInCalculatorWhenComputeThenReturnNullableCharArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_STRING_UTF8_CRC16 = {crc16test.UsingNullableStringPropertyInCalculatorWhenComputeThenReturnNullableStringCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_STRING_UNICODE_CRC16 = {crc16test.UsingNullableStringPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_STRING_UTF32_CRC16 = {crc16test.UsingNullableStringPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_STRING_ARRAY_UTF8_CRC16 = {crc16test.UsingNullableStringArrayPropertyInCalculatorWhenComputeThenReturnNullableStringArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_STRING_ARRAY_UNICODE_CRC16 = {crc16test.UsingNullableStringArrayPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_STRING_ARRAY_UTF32_CRC16 = {crc16test.UsingNullableStringArrayPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringArrayCRC16()};");
            Console.WriteLine($"        public const ushort GUID_CRC16 = {crc16test.UsingGuidPropertyInCalculatorWhenComputeThenReturnGuidCRC16()};");
            Console.WriteLine($"        public const ushort GUID_ARRAY_CRC16 = {crc16test.UsingGuidArrayPropertyInCalculatorWhenComputeThenReturnGuidArrayCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_GUID_CRC16 = {crc16test.UsingNullableGuidPropertyInCalculatorWhenComputeThenReturnNullableGuidCRC16()};");
            Console.WriteLine($"        public const ushort NULLABLE_GUID_ARRAY_CRC16 = {crc16test.UsingNullableGuidArrayPropertyInCalculatorWhenComputeThenReturnNullableGuidArrayCRC16()};");
            Console.WriteLine($"");
            Console.WriteLine($"        public const ushort CHILD_ENTITY_ID_CRC16 = {crc16test.UsingComplexPropertyInCalculatorWhenComputeThenReturnEntityIdCRC16()};");
            Console.WriteLine($"        public const ushort CHILDLIST_ENTITY_ID_CRC16 = {crc16test.UsingComplexListPropertyInCalculatorWhenComputeThenReturnEntityIdCRC16()};");

            var (utf8CRC16, unicodeCRC16, utf32CRC16) = crc16test.UsingComplexPropertyWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorCRC16();
            Console.WriteLine("");
            Console.WriteLine($"        public const ushort CHILD_ENTITY_STRING_UTF8_CRC16 = {utf8CRC16};");
            Console.WriteLine($"        public const ushort CHILD_ENTITY_STRING_UNICODE_CRC16 = {unicodeCRC16};");
            Console.WriteLine($"        public const ushort CHILD_ENTITY_STRING_UTF32_CRC16 = {utf32CRC16};");

            (utf8CRC16, unicodeCRC16, utf32CRC16) = crc16test.UsingComplexPropertyListWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorCRC16();

            Console.WriteLine($"        public const ushort CHILDLIST_ENTITY_STRING_UTF8_CRC16 = {utf8CRC16};");
            Console.WriteLine($"        public const ushort CHILDLIST_ENTITY_STRING_UNICODE_CRC16 = {unicodeCRC16};");
            Console.WriteLine($"        public const ushort CHILDLIST_ENTITY_STRING_UTF32_CRC16 = {utf32CRC16};");

            Console.WriteLine("        #endregion");

            Console.WriteLine("");

            Console.WriteLine("        #region Valores dos SHA1 dos valores padrão");
            Console.WriteLine($"        public static readonly byte[] BOOL_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingBoolPropertyInCalculatorWhenComputeThenReturnBoolSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] BOOL_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingBoolArrayPropertyInCalculatorWhenComputeThenReturnBoolArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BOOL_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableBoolPropertyInCalculatorWhenComputeThenReturnNullableBoolSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BOOL_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableBoolArrayPropertyInCalculatorWhenComputeThenReturnNullableBoolArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] BYTE_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingBytePropertyInCalculatorWhenComputeThenReturnByteSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] BYTE_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingByteArrayPropertyInCalculatorWhenComputeThenReturnByteArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BYTE_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableBytePropertyInCalculatorWhenComputeThenReturnNullableByteSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BYTE_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableByteArrayPropertyInCalculatorWhenComputeThenReturnNullableByteArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] SBYTE_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingSbytePropertyInCalculatorWhenComputeThenReturnSbyteSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] SBYTE_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingSbyteArrayPropertyInCalculatorWhenComputeThenReturnSbyteArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SBYTE_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableSbytePropertyInCalculatorWhenComputeThenReturnNullableSbyteSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SBYTE_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableSbyteArrayPropertyInCalculatorWhenComputeThenReturnNullableSbyteArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] SHORT_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingShortPropertyInCalculatorWhenComputeThenReturnShortSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] SHORT_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingShortArrayPropertyInCalculatorWhenComputeThenReturnShortArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SHORT_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableShortPropertyInCalculatorWhenComputeThenReturnNullableShortSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SHORT_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableShortArrayPropertyInCalculatorWhenComputeThenReturnNullableShortArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] USHORT_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingUshortPropertyInCalculatorWhenComputeThenReturnUshortSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] USHORT_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingUshortArrayPropertyInCalculatorWhenComputeThenReturnUshortArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_USHORT_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableUshortPropertyInCalculatorWhenComputeThenReturnNullableUshortSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_USHORT_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableUshortArrayPropertyInCalculatorWhenComputeThenReturnNullableUshortArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] INT_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingIntPropertyInCalculatorWhenComputeThenReturnIntSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] INT_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingIntArrayPropertyInCalculatorWhenComputeThenReturnIntArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_INT_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableIntPropertyInCalculatorWhenComputeThenReturnNullableIntSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_INT_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableIntArrayPropertyInCalculatorWhenComputeThenReturnNullableIntArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] UINT_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingUintPropertyInCalculatorWhenComputeThenReturnUintSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] UINT_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingUintArrayPropertyInCalculatorWhenComputeThenReturnUintArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_UINT_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableUintPropertyInCalculatorWhenComputeThenReturnNullableUintSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_UINT_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableUintArrayPropertyInCalculatorWhenComputeThenReturnNullableUintArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] LONG_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingLongPropertyInCalculatorWhenComputeThenReturnLongSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] LONG_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingLongArrayPropertyInCalculatorWhenComputeThenReturnLongArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_LONG_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableLongPropertyInCalculatorWhenComputeThenReturnNullableLongSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_LONG_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableLongArrayPropertyInCalculatorWhenComputeThenReturnNullableLongArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] ULONG_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingUlongPropertyInCalculatorWhenComputeThenReturnUlongSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] ULONG_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingUlongArrayPropertyInCalculatorWhenComputeThenReturnUlongArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_ULONG_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableUlongPropertyInCalculatorWhenComputeThenReturnNullableUlongSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_ULONG_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableUlongArrayPropertyInCalculatorWhenComputeThenReturnNullableUlongArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] FLOAT_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingFloatPropertyInCalculatorWhenComputeThenReturnFloatSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] FLOAT_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingFloatArrayPropertyInCalculatorWhenComputeThenReturnFloatArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_FLOAT_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableFloatPropertyInCalculatorWhenComputeThenReturnNullableFloatSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_FLOAT_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableFloatArrayPropertyInCalculatorWhenComputeThenReturnNullableFloatArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] DOUBLE_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingDoublePropertyInCalculatorWhenComputeThenReturnDoubleSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] DOUBLE_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingDoubleArrayPropertyInCalculatorWhenComputeThenReturnDoubleArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DOUBLE_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableDoublePropertyInCalculatorWhenComputeThenReturnNullableDoubleSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DOUBLE_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableDoubleArrayPropertyInCalculatorWhenComputeThenReturnNullableDoubleArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] DECIMAL_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingDecimalPropertyInCalculatorWhenComputeThenReturnDecimalSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] DECIMAL_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingDecimalArrayPropertyInCalculatorWhenComputeThenReturnDecimalArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DECIMAL_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableDecimalPropertyInCalculatorWhenComputeThenReturnNullableDecimalSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DECIMAL_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableDecimalArrayPropertyInCalculatorWhenComputeThenReturnNullableDecimalArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] DATETIME_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingDateTimePropertyInCalculatorWhenComputeThenReturnDateTimeSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] DATETIME_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingDateTimeArrayPropertyInCalculatorWhenComputeThenReturnDateTimeArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DATETIME_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableDateTimePropertyInCalculatorWhenComputeThenReturnNullableDateTimeSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DATETIME_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableDateTimeArrayPropertyInCalculatorWhenComputeThenReturnNullableDateTimeArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] TIMESPAN_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingTimeSpanPropertyInCalculatorWhenComputeThenReturnTimeSpanSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] TIMESPAN_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnTimeSpanArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_TIMESPAN_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableTimeSpanPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_TIMESPAN_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] CHAR_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingCharPropertyInCalculatorWhenComputeThenReturnCharSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] CHAR_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingCharArrayPropertyInCalculatorWhenComputeThenReturnCharArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_CHAR_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableCharPropertyInCalculatorWhenComputeThenReturnNullableCharSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_CHAR_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableCharArrayPropertyInCalculatorWhenComputeThenReturnNullableCharArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UTF8_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableStringPropertyInCalculatorWhenComputeThenReturnNullableStringSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UNICODE_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableStringPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UTF32_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableStringPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UTF8_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableStringArrayPropertyInCalculatorWhenComputeThenReturnNullableStringArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UNICODE_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableStringArrayPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UTF32_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableStringArrayPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] GUID_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingGuidPropertyInCalculatorWhenComputeThenReturnGuidSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] GUID_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingGuidArrayPropertyInCalculatorWhenComputeThenReturnGuidArraySHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_GUID_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableGuidPropertyInCalculatorWhenComputeThenReturnNullableGuidSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_GUID_ARRAY_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingNullableGuidArrayPropertyInCalculatorWhenComputeThenReturnNullableGuidArraySHA1())} }};");
            Console.WriteLine($"");
            Console.WriteLine($"        public static readonly byte[] DEFAULT_SHA1 = IncrementalHash.CreateHash(HashAlgorithmName.SHA1).GetHashAndReset();");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_ID_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingComplexPropertyInCalculatorWhenComputeThenReturnEntityIdSHA1())} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_ID_SHA1 = new byte[] {{ {string.Join(", ", sha1test.UsingComplexListPropertyInCalculatorWhenComputeThenReturnEntityIdSHA1())} }};");

            var (utf8Hash, unicodeHash, utf32Hash) = sha1test.UsingComplexPropertyWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorSHA1();
            Console.WriteLine("");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UTF8_SHA1 = new byte[] {{ {string.Join(", ", utf8Hash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UNICODE_SHA1 = new byte[] {{ {string.Join(", ", unicodeHash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UTF32_SHA1 = new byte[] {{ {string.Join(", ", utf32Hash)} }};");

            (utf8Hash, unicodeHash, utf32Hash) = sha1test.UsingComplexPropertyListWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorSHA1();

            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UTF8_SHA1 = new byte[] {{ {string.Join(", ", utf8Hash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UNICODE_SHA1 = new byte[] {{ {string.Join(", ", unicodeHash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UTF32_SHA1 = new byte[] {{ {string.Join(", ", utf32Hash)} }};");

            Console.WriteLine("        #endregion");

            Console.WriteLine("");

            Console.WriteLine("        #region Valores dos SHA256 dos valores padrão");
            Console.WriteLine($"        public static readonly byte[] BOOL_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingBoolPropertyInCalculatorWhenComputeThenReturnBoolSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] BOOL_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingBoolArrayPropertyInCalculatorWhenComputeThenReturnBoolArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BOOL_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableBoolPropertyInCalculatorWhenComputeThenReturnNullableBoolSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BOOL_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableBoolArrayPropertyInCalculatorWhenComputeThenReturnNullableBoolArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] BYTE_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingBytePropertyInCalculatorWhenComputeThenReturnByteSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] BYTE_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingByteArrayPropertyInCalculatorWhenComputeThenReturnByteArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BYTE_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableBytePropertyInCalculatorWhenComputeThenReturnNullableByteSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BYTE_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableByteArrayPropertyInCalculatorWhenComputeThenReturnNullableByteArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] SBYTE_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingSbytePropertyInCalculatorWhenComputeThenReturnSbyteSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] SBYTE_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingSbyteArrayPropertyInCalculatorWhenComputeThenReturnSbyteArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SBYTE_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableSbytePropertyInCalculatorWhenComputeThenReturnNullableSbyteSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SBYTE_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableSbyteArrayPropertyInCalculatorWhenComputeThenReturnNullableSbyteArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] SHORT_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingShortPropertyInCalculatorWhenComputeThenReturnShortSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] SHORT_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingShortArrayPropertyInCalculatorWhenComputeThenReturnShortArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SHORT_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableShortPropertyInCalculatorWhenComputeThenReturnNullableShortSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SHORT_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableShortArrayPropertyInCalculatorWhenComputeThenReturnNullableShortArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] USHORT_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingUshortPropertyInCalculatorWhenComputeThenReturnUshortSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] USHORT_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingUshortArrayPropertyInCalculatorWhenComputeThenReturnUshortArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_USHORT_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableUshortPropertyInCalculatorWhenComputeThenReturnNullableUshortSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_USHORT_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableUshortArrayPropertyInCalculatorWhenComputeThenReturnNullableUshortArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] INT_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingIntPropertyInCalculatorWhenComputeThenReturnIntSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] INT_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingIntArrayPropertyInCalculatorWhenComputeThenReturnIntArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_INT_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableIntPropertyInCalculatorWhenComputeThenReturnNullableIntSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_INT_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableIntArrayPropertyInCalculatorWhenComputeThenReturnNullableIntArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] UINT_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingUintPropertyInCalculatorWhenComputeThenReturnUintSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] UINT_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingUintArrayPropertyInCalculatorWhenComputeThenReturnUintArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_UINT_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableUintPropertyInCalculatorWhenComputeThenReturnNullableUintSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_UINT_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableUintArrayPropertyInCalculatorWhenComputeThenReturnNullableUintArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] LONG_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingLongPropertyInCalculatorWhenComputeThenReturnLongSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] LONG_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingLongArrayPropertyInCalculatorWhenComputeThenReturnLongArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_LONG_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableLongPropertyInCalculatorWhenComputeThenReturnNullableLongSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_LONG_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableLongArrayPropertyInCalculatorWhenComputeThenReturnNullableLongArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] ULONG_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingUlongPropertyInCalculatorWhenComputeThenReturnUlongSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] ULONG_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingUlongArrayPropertyInCalculatorWhenComputeThenReturnUlongArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_ULONG_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableUlongPropertyInCalculatorWhenComputeThenReturnNullableUlongSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_ULONG_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableUlongArrayPropertyInCalculatorWhenComputeThenReturnNullableUlongArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] FLOAT_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingFloatPropertyInCalculatorWhenComputeThenReturnFloatSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] FLOAT_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingFloatArrayPropertyInCalculatorWhenComputeThenReturnFloatArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_FLOAT_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableFloatPropertyInCalculatorWhenComputeThenReturnNullableFloatSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_FLOAT_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableFloatArrayPropertyInCalculatorWhenComputeThenReturnNullableFloatArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] DOUBLE_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingDoublePropertyInCalculatorWhenComputeThenReturnDoubleSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] DOUBLE_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingDoubleArrayPropertyInCalculatorWhenComputeThenReturnDoubleArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DOUBLE_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableDoublePropertyInCalculatorWhenComputeThenReturnNullableDoubleSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DOUBLE_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableDoubleArrayPropertyInCalculatorWhenComputeThenReturnNullableDoubleArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] DECIMAL_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingDecimalPropertyInCalculatorWhenComputeThenReturnDecimalSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] DECIMAL_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingDecimalArrayPropertyInCalculatorWhenComputeThenReturnDecimalArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DECIMAL_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableDecimalPropertyInCalculatorWhenComputeThenReturnNullableDecimalSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DECIMAL_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableDecimalArrayPropertyInCalculatorWhenComputeThenReturnNullableDecimalArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] DATETIME_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingDateTimePropertyInCalculatorWhenComputeThenReturnDateTimeSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] DATETIME_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingDateTimeArrayPropertyInCalculatorWhenComputeThenReturnDateTimeArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DATETIME_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableDateTimePropertyInCalculatorWhenComputeThenReturnNullableDateTimeSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DATETIME_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableDateTimeArrayPropertyInCalculatorWhenComputeThenReturnNullableDateTimeArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] TIMESPAN_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingTimeSpanPropertyInCalculatorWhenComputeThenReturnTimeSpanSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] TIMESPAN_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnTimeSpanArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_TIMESPAN_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableTimeSpanPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_TIMESPAN_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] CHAR_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingCharPropertyInCalculatorWhenComputeThenReturnCharSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] CHAR_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingCharArrayPropertyInCalculatorWhenComputeThenReturnCharArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_CHAR_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableCharPropertyInCalculatorWhenComputeThenReturnNullableCharSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_CHAR_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableCharArrayPropertyInCalculatorWhenComputeThenReturnNullableCharArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UTF8_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableStringPropertyInCalculatorWhenComputeThenReturnNullableStringSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UNICODE_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableStringPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UTF32_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableStringPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UTF8_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableStringArrayPropertyInCalculatorWhenComputeThenReturnNullableStringArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UNICODE_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableStringArrayPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UTF32_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableStringArrayPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] GUID_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingGuidPropertyInCalculatorWhenComputeThenReturnGuidSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] GUID_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingGuidArrayPropertyInCalculatorWhenComputeThenReturnGuidArraySHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_GUID_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableGuidPropertyInCalculatorWhenComputeThenReturnNullableGuidSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_GUID_ARRAY_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingNullableGuidArrayPropertyInCalculatorWhenComputeThenReturnNullableGuidArraySHA256())} }};");
            Console.WriteLine($"");
            Console.WriteLine($"        public static readonly byte[] DEFAULT_SHA256 = IncrementalHash.CreateHash(HashAlgorithmName.SHA256).GetHashAndReset();");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_ID_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingComplexPropertyInCalculatorWhenComputeThenReturnEntityIdSHA256())} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_ID_SHA256 = new byte[] {{ {string.Join(", ", sha256test.UsingComplexListPropertyInCalculatorWhenComputeThenReturnEntityIdSHA256())} }};");

            (utf8Hash, unicodeHash, utf32Hash) = sha256test.UsingComplexPropertyWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorSHA256();
            Console.WriteLine("");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UTF8_SHA256 = new byte[] {{ {string.Join(", ", utf8Hash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UNICODE_SHA256 = new byte[] {{ {string.Join(", ", unicodeHash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UTF32_SHA256 = new byte[] {{ {string.Join(", ", utf32Hash)} }};");

            (utf8Hash, unicodeHash, utf32Hash) = sha256test.UsingComplexPropertyListWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorSHA256();

            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UTF8_SHA256 = new byte[] {{ {string.Join(", ", utf8Hash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UNICODE_SHA256 = new byte[] {{ {string.Join(", ", unicodeHash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UTF32_SHA256 = new byte[] {{ {string.Join(", ", utf32Hash)} }};");

            Console.WriteLine("        #endregion");

            Console.WriteLine("");

            Console.WriteLine("        #region Valores dos SHA384 dos valores padrão");
            Console.WriteLine($"        public static readonly byte[] BOOL_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingBoolPropertyInCalculatorWhenComputeThenReturnBoolSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] BOOL_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingBoolArrayPropertyInCalculatorWhenComputeThenReturnBoolArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BOOL_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableBoolPropertyInCalculatorWhenComputeThenReturnNullableBoolSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BOOL_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableBoolArrayPropertyInCalculatorWhenComputeThenReturnNullableBoolArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] BYTE_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingBytePropertyInCalculatorWhenComputeThenReturnByteSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] BYTE_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingByteArrayPropertyInCalculatorWhenComputeThenReturnByteArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BYTE_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableBytePropertyInCalculatorWhenComputeThenReturnNullableByteSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BYTE_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableByteArrayPropertyInCalculatorWhenComputeThenReturnNullableByteArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] SBYTE_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingSbytePropertyInCalculatorWhenComputeThenReturnSbyteSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] SBYTE_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingSbyteArrayPropertyInCalculatorWhenComputeThenReturnSbyteArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SBYTE_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableSbytePropertyInCalculatorWhenComputeThenReturnNullableSbyteSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SBYTE_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableSbyteArrayPropertyInCalculatorWhenComputeThenReturnNullableSbyteArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] SHORT_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingShortPropertyInCalculatorWhenComputeThenReturnShortSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] SHORT_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingShortArrayPropertyInCalculatorWhenComputeThenReturnShortArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SHORT_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableShortPropertyInCalculatorWhenComputeThenReturnNullableShortSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SHORT_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableShortArrayPropertyInCalculatorWhenComputeThenReturnNullableShortArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] USHORT_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingUshortPropertyInCalculatorWhenComputeThenReturnUshortSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] USHORT_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingUshortArrayPropertyInCalculatorWhenComputeThenReturnUshortArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_USHORT_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableUshortPropertyInCalculatorWhenComputeThenReturnNullableUshortSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_USHORT_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableUshortArrayPropertyInCalculatorWhenComputeThenReturnNullableUshortArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] INT_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingIntPropertyInCalculatorWhenComputeThenReturnIntSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] INT_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingIntArrayPropertyInCalculatorWhenComputeThenReturnIntArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_INT_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableIntPropertyInCalculatorWhenComputeThenReturnNullableIntSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_INT_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableIntArrayPropertyInCalculatorWhenComputeThenReturnNullableIntArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] UINT_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingUintPropertyInCalculatorWhenComputeThenReturnUintSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] UINT_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingUintArrayPropertyInCalculatorWhenComputeThenReturnUintArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_UINT_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableUintPropertyInCalculatorWhenComputeThenReturnNullableUintSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_UINT_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableUintArrayPropertyInCalculatorWhenComputeThenReturnNullableUintArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] LONG_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingLongPropertyInCalculatorWhenComputeThenReturnLongSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] LONG_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingLongArrayPropertyInCalculatorWhenComputeThenReturnLongArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_LONG_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableLongPropertyInCalculatorWhenComputeThenReturnNullableLongSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_LONG_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableLongArrayPropertyInCalculatorWhenComputeThenReturnNullableLongArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] ULONG_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingUlongPropertyInCalculatorWhenComputeThenReturnUlongSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] ULONG_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingUlongArrayPropertyInCalculatorWhenComputeThenReturnUlongArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_ULONG_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableUlongPropertyInCalculatorWhenComputeThenReturnNullableUlongSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_ULONG_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableUlongArrayPropertyInCalculatorWhenComputeThenReturnNullableUlongArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] FLOAT_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingFloatPropertyInCalculatorWhenComputeThenReturnFloatSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] FLOAT_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingFloatArrayPropertyInCalculatorWhenComputeThenReturnFloatArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_FLOAT_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableFloatPropertyInCalculatorWhenComputeThenReturnNullableFloatSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_FLOAT_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableFloatArrayPropertyInCalculatorWhenComputeThenReturnNullableFloatArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] DOUBLE_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingDoublePropertyInCalculatorWhenComputeThenReturnDoubleSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] DOUBLE_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingDoubleArrayPropertyInCalculatorWhenComputeThenReturnDoubleArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DOUBLE_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableDoublePropertyInCalculatorWhenComputeThenReturnNullableDoubleSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DOUBLE_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableDoubleArrayPropertyInCalculatorWhenComputeThenReturnNullableDoubleArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] DECIMAL_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingDecimalPropertyInCalculatorWhenComputeThenReturnDecimalSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] DECIMAL_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingDecimalArrayPropertyInCalculatorWhenComputeThenReturnDecimalArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DECIMAL_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableDecimalPropertyInCalculatorWhenComputeThenReturnNullableDecimalSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DECIMAL_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableDecimalArrayPropertyInCalculatorWhenComputeThenReturnNullableDecimalArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] DATETIME_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingDateTimePropertyInCalculatorWhenComputeThenReturnDateTimeSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] DATETIME_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingDateTimeArrayPropertyInCalculatorWhenComputeThenReturnDateTimeArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DATETIME_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableDateTimePropertyInCalculatorWhenComputeThenReturnNullableDateTimeSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DATETIME_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableDateTimeArrayPropertyInCalculatorWhenComputeThenReturnNullableDateTimeArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] TIMESPAN_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingTimeSpanPropertyInCalculatorWhenComputeThenReturnTimeSpanSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] TIMESPAN_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnTimeSpanArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_TIMESPAN_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableTimeSpanPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_TIMESPAN_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] CHAR_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingCharPropertyInCalculatorWhenComputeThenReturnCharSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] CHAR_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingCharArrayPropertyInCalculatorWhenComputeThenReturnCharArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_CHAR_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableCharPropertyInCalculatorWhenComputeThenReturnNullableCharSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_CHAR_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableCharArrayPropertyInCalculatorWhenComputeThenReturnNullableCharArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UTF8_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableStringPropertyInCalculatorWhenComputeThenReturnNullableStringSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UNICODE_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableStringPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UTF32_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableStringPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UTF8_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableStringArrayPropertyInCalculatorWhenComputeThenReturnNullableStringArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UNICODE_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableStringArrayPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UTF32_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableStringArrayPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] GUID_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingGuidPropertyInCalculatorWhenComputeThenReturnGuidSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] GUID_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingGuidArrayPropertyInCalculatorWhenComputeThenReturnGuidArraySHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_GUID_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableGuidPropertyInCalculatorWhenComputeThenReturnNullableGuidSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_GUID_ARRAY_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingNullableGuidArrayPropertyInCalculatorWhenComputeThenReturnNullableGuidArraySHA384())} }};");
            Console.WriteLine($"");
            Console.WriteLine($"        public static readonly byte[] DEFAULT_SHA384 = IncrementalHash.CreateHash(HashAlgorithmName.SHA384).GetHashAndReset();");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_ID_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingComplexPropertyInCalculatorWhenComputeThenReturnEntityIdSHA384())} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_ID_SHA384 = new byte[] {{ {string.Join(", ", sha384test.UsingComplexListPropertyInCalculatorWhenComputeThenReturnEntityIdSHA384())} }};");

            (utf8Hash, unicodeHash, utf32Hash) = sha384test.UsingComplexPropertyWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorSHA384();
            Console.WriteLine("");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UTF8_SHA384 = new byte[] {{ {string.Join(", ", utf8Hash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UNICODE_SHA384 = new byte[] {{ {string.Join(", ", unicodeHash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UTF32_SHA384 = new byte[] {{ {string.Join(", ", utf32Hash)} }};");

            (utf8Hash, unicodeHash, utf32Hash) = sha384test.UsingComplexPropertyListWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorSHA384();

            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UTF8_SHA384 = new byte[] {{ {string.Join(", ", utf8Hash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UNICODE_SHA384 = new byte[] {{ {string.Join(", ", unicodeHash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UTF32_SHA384 = new byte[] {{ {string.Join(", ", utf32Hash)} }};");

            Console.WriteLine("        #endregion");

            Console.WriteLine("");

            Console.WriteLine("        #region Valores dos SHA512 dos valores padrão");
            Console.WriteLine($"        public static readonly byte[] BOOL_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingBoolPropertyInCalculatorWhenComputeThenReturnBoolSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] BOOL_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingBoolArrayPropertyInCalculatorWhenComputeThenReturnBoolArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BOOL_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableBoolPropertyInCalculatorWhenComputeThenReturnNullableBoolSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BOOL_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableBoolArrayPropertyInCalculatorWhenComputeThenReturnNullableBoolArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] BYTE_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingBytePropertyInCalculatorWhenComputeThenReturnByteSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] BYTE_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingByteArrayPropertyInCalculatorWhenComputeThenReturnByteArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BYTE_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableBytePropertyInCalculatorWhenComputeThenReturnNullableByteSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BYTE_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableByteArrayPropertyInCalculatorWhenComputeThenReturnNullableByteArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] SBYTE_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingSbytePropertyInCalculatorWhenComputeThenReturnSbyteSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] SBYTE_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingSbyteArrayPropertyInCalculatorWhenComputeThenReturnSbyteArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SBYTE_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableSbytePropertyInCalculatorWhenComputeThenReturnNullableSbyteSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SBYTE_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableSbyteArrayPropertyInCalculatorWhenComputeThenReturnNullableSbyteArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] SHORT_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingShortPropertyInCalculatorWhenComputeThenReturnShortSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] SHORT_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingShortArrayPropertyInCalculatorWhenComputeThenReturnShortArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SHORT_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableShortPropertyInCalculatorWhenComputeThenReturnNullableShortSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SHORT_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableShortArrayPropertyInCalculatorWhenComputeThenReturnNullableShortArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] USHORT_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingUshortPropertyInCalculatorWhenComputeThenReturnUshortSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] USHORT_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingUshortArrayPropertyInCalculatorWhenComputeThenReturnUshortArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_USHORT_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableUshortPropertyInCalculatorWhenComputeThenReturnNullableUshortSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_USHORT_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableUshortArrayPropertyInCalculatorWhenComputeThenReturnNullableUshortArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] INT_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingIntPropertyInCalculatorWhenComputeThenReturnIntSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] INT_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingIntArrayPropertyInCalculatorWhenComputeThenReturnIntArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_INT_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableIntPropertyInCalculatorWhenComputeThenReturnNullableIntSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_INT_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableIntArrayPropertyInCalculatorWhenComputeThenReturnNullableIntArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] UINT_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingUintPropertyInCalculatorWhenComputeThenReturnUintSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] UINT_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingUintArrayPropertyInCalculatorWhenComputeThenReturnUintArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_UINT_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableUintPropertyInCalculatorWhenComputeThenReturnNullableUintSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_UINT_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableUintArrayPropertyInCalculatorWhenComputeThenReturnNullableUintArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] LONG_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingLongPropertyInCalculatorWhenComputeThenReturnLongSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] LONG_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingLongArrayPropertyInCalculatorWhenComputeThenReturnLongArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_LONG_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableLongPropertyInCalculatorWhenComputeThenReturnNullableLongSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_LONG_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableLongArrayPropertyInCalculatorWhenComputeThenReturnNullableLongArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] ULONG_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingUlongPropertyInCalculatorWhenComputeThenReturnUlongSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] ULONG_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingUlongArrayPropertyInCalculatorWhenComputeThenReturnUlongArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_ULONG_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableUlongPropertyInCalculatorWhenComputeThenReturnNullableUlongSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_ULONG_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableUlongArrayPropertyInCalculatorWhenComputeThenReturnNullableUlongArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] FLOAT_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingFloatPropertyInCalculatorWhenComputeThenReturnFloatSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] FLOAT_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingFloatArrayPropertyInCalculatorWhenComputeThenReturnFloatArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_FLOAT_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableFloatPropertyInCalculatorWhenComputeThenReturnNullableFloatSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_FLOAT_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableFloatArrayPropertyInCalculatorWhenComputeThenReturnNullableFloatArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] DOUBLE_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingDoublePropertyInCalculatorWhenComputeThenReturnDoubleSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] DOUBLE_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingDoubleArrayPropertyInCalculatorWhenComputeThenReturnDoubleArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DOUBLE_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableDoublePropertyInCalculatorWhenComputeThenReturnNullableDoubleSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DOUBLE_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableDoubleArrayPropertyInCalculatorWhenComputeThenReturnNullableDoubleArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] DECIMAL_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingDecimalPropertyInCalculatorWhenComputeThenReturnDecimalSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] DECIMAL_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingDecimalArrayPropertyInCalculatorWhenComputeThenReturnDecimalArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DECIMAL_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableDecimalPropertyInCalculatorWhenComputeThenReturnNullableDecimalSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DECIMAL_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableDecimalArrayPropertyInCalculatorWhenComputeThenReturnNullableDecimalArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] DATETIME_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingDateTimePropertyInCalculatorWhenComputeThenReturnDateTimeSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] DATETIME_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingDateTimeArrayPropertyInCalculatorWhenComputeThenReturnDateTimeArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DATETIME_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableDateTimePropertyInCalculatorWhenComputeThenReturnNullableDateTimeSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DATETIME_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableDateTimeArrayPropertyInCalculatorWhenComputeThenReturnNullableDateTimeArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] TIMESPAN_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingTimeSpanPropertyInCalculatorWhenComputeThenReturnTimeSpanSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] TIMESPAN_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnTimeSpanArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_TIMESPAN_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableTimeSpanPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_TIMESPAN_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] CHAR_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingCharPropertyInCalculatorWhenComputeThenReturnCharSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] CHAR_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingCharArrayPropertyInCalculatorWhenComputeThenReturnCharArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_CHAR_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableCharPropertyInCalculatorWhenComputeThenReturnNullableCharSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_CHAR_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableCharArrayPropertyInCalculatorWhenComputeThenReturnNullableCharArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UTF8_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableStringPropertyInCalculatorWhenComputeThenReturnNullableStringSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UNICODE_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableStringPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UTF32_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableStringPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UTF8_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableStringArrayPropertyInCalculatorWhenComputeThenReturnNullableStringArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UNICODE_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableStringArrayPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UTF32_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableStringArrayPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] GUID_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingGuidPropertyInCalculatorWhenComputeThenReturnGuidSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] GUID_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingGuidArrayPropertyInCalculatorWhenComputeThenReturnGuidArraySHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_GUID_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableGuidPropertyInCalculatorWhenComputeThenReturnNullableGuidSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_GUID_ARRAY_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingNullableGuidArrayPropertyInCalculatorWhenComputeThenReturnNullableGuidArraySHA512())} }};");
            Console.WriteLine($"");
            Console.WriteLine($"        public static readonly byte[] DEFAULT_SHA512 = IncrementalHash.CreateHash(HashAlgorithmName.SHA512).GetHashAndReset();");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_ID_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingComplexPropertyInCalculatorWhenComputeThenReturnEntityIdSHA512())} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_ID_SHA512 = new byte[] {{ {string.Join(", ", sha512test.UsingComplexListPropertyInCalculatorWhenComputeThenReturnEntityIdSHA512())} }};");

            (utf8Hash, unicodeHash, utf32Hash) = sha512test.UsingComplexPropertyWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorSHA512();
            Console.WriteLine("");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UTF8_SHA512 = new byte[] {{ {string.Join(", ", utf8Hash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UNICODE_SHA512 = new byte[] {{ {string.Join(", ", unicodeHash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UTF32_SHA512 = new byte[] {{ {string.Join(", ", utf32Hash)} }};");

            (utf8Hash, unicodeHash, utf32Hash) = sha512test.UsingComplexPropertyListWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorSHA512();

            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UTF8_SHA512 = new byte[] {{ {string.Join(", ", utf8Hash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UNICODE_SHA512 = new byte[] {{ {string.Join(", ", unicodeHash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UTF32_SHA512 = new byte[] {{ {string.Join(", ", utf32Hash)} }};");

            Console.WriteLine("        #endregion");

            Console.WriteLine("");

            Console.WriteLine("        #region Valores dos MD5 dos valores padrão");
            Console.WriteLine($"        public static readonly byte[] BOOL_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingBoolPropertyInCalculatorWhenComputeThenReturnBoolMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] BOOL_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingBoolArrayPropertyInCalculatorWhenComputeThenReturnBoolArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BOOL_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableBoolPropertyInCalculatorWhenComputeThenReturnNullableBoolMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BOOL_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableBoolArrayPropertyInCalculatorWhenComputeThenReturnNullableBoolArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] BYTE_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingBytePropertyInCalculatorWhenComputeThenReturnByteMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] BYTE_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingByteArrayPropertyInCalculatorWhenComputeThenReturnByteArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BYTE_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableBytePropertyInCalculatorWhenComputeThenReturnNullableByteMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_BYTE_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableByteArrayPropertyInCalculatorWhenComputeThenReturnNullableByteArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] SBYTE_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingSbytePropertyInCalculatorWhenComputeThenReturnSbyteMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] SBYTE_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingSbyteArrayPropertyInCalculatorWhenComputeThenReturnSbyteArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SBYTE_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableSbytePropertyInCalculatorWhenComputeThenReturnNullableSbyteMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SBYTE_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableSbyteArrayPropertyInCalculatorWhenComputeThenReturnNullableSbyteArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] SHORT_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingShortPropertyInCalculatorWhenComputeThenReturnShortMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] SHORT_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingShortArrayPropertyInCalculatorWhenComputeThenReturnShortArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SHORT_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableShortPropertyInCalculatorWhenComputeThenReturnNullableShortMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_SHORT_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableShortArrayPropertyInCalculatorWhenComputeThenReturnNullableShortArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] USHORT_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingUshortPropertyInCalculatorWhenComputeThenReturnUshortMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] USHORT_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingUshortArrayPropertyInCalculatorWhenComputeThenReturnUshortArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_USHORT_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableUshortPropertyInCalculatorWhenComputeThenReturnNullableUshortMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_USHORT_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableUshortArrayPropertyInCalculatorWhenComputeThenReturnNullableUshortArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] INT_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingIntPropertyInCalculatorWhenComputeThenReturnIntMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] INT_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingIntArrayPropertyInCalculatorWhenComputeThenReturnIntArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_INT_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableIntPropertyInCalculatorWhenComputeThenReturnNullableIntMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_INT_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableIntArrayPropertyInCalculatorWhenComputeThenReturnNullableIntArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] UINT_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingUintPropertyInCalculatorWhenComputeThenReturnUintMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] UINT_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingUintArrayPropertyInCalculatorWhenComputeThenReturnUintArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_UINT_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableUintPropertyInCalculatorWhenComputeThenReturnNullableUintMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_UINT_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableUintArrayPropertyInCalculatorWhenComputeThenReturnNullableUintArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] LONG_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingLongPropertyInCalculatorWhenComputeThenReturnLongMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] LONG_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingLongArrayPropertyInCalculatorWhenComputeThenReturnLongArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_LONG_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableLongPropertyInCalculatorWhenComputeThenReturnNullableLongMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_LONG_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableLongArrayPropertyInCalculatorWhenComputeThenReturnNullableLongArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] ULONG_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingUlongPropertyInCalculatorWhenComputeThenReturnUlongMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] ULONG_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingUlongArrayPropertyInCalculatorWhenComputeThenReturnUlongArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_ULONG_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableUlongPropertyInCalculatorWhenComputeThenReturnNullableUlongMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_ULONG_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableUlongArrayPropertyInCalculatorWhenComputeThenReturnNullableUlongArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] FLOAT_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingFloatPropertyInCalculatorWhenComputeThenReturnFloatMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] FLOAT_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingFloatArrayPropertyInCalculatorWhenComputeThenReturnFloatArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_FLOAT_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableFloatPropertyInCalculatorWhenComputeThenReturnNullableFloatMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_FLOAT_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableFloatArrayPropertyInCalculatorWhenComputeThenReturnNullableFloatArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] DOUBLE_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingDoublePropertyInCalculatorWhenComputeThenReturnDoubleMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] DOUBLE_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingDoubleArrayPropertyInCalculatorWhenComputeThenReturnDoubleArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DOUBLE_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableDoublePropertyInCalculatorWhenComputeThenReturnNullableDoubleMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DOUBLE_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableDoubleArrayPropertyInCalculatorWhenComputeThenReturnNullableDoubleArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] DECIMAL_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingDecimalPropertyInCalculatorWhenComputeThenReturnDecimalMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] DECIMAL_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingDecimalArrayPropertyInCalculatorWhenComputeThenReturnDecimalArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DECIMAL_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableDecimalPropertyInCalculatorWhenComputeThenReturnNullableDecimalMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DECIMAL_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableDecimalArrayPropertyInCalculatorWhenComputeThenReturnNullableDecimalArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] DATETIME_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingDateTimePropertyInCalculatorWhenComputeThenReturnDateTimeMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] DATETIME_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingDateTimeArrayPropertyInCalculatorWhenComputeThenReturnDateTimeArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DATETIME_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableDateTimePropertyInCalculatorWhenComputeThenReturnNullableDateTimeMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_DATETIME_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableDateTimeArrayPropertyInCalculatorWhenComputeThenReturnNullableDateTimeArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] TIMESPAN_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingTimeSpanPropertyInCalculatorWhenComputeThenReturnTimeSpanMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] TIMESPAN_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnTimeSpanArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_TIMESPAN_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableTimeSpanPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_TIMESPAN_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] CHAR_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingCharPropertyInCalculatorWhenComputeThenReturnCharMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] CHAR_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingCharArrayPropertyInCalculatorWhenComputeThenReturnCharArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_CHAR_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableCharPropertyInCalculatorWhenComputeThenReturnNullableCharMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_CHAR_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableCharArrayPropertyInCalculatorWhenComputeThenReturnNullableCharArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UTF8_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableStringPropertyInCalculatorWhenComputeThenReturnNullableStringMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UNICODE_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableStringPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_UTF32_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableStringPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UTF8_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableStringArrayPropertyInCalculatorWhenComputeThenReturnNullableStringArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UNICODE_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableStringArrayPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_STRING_ARRAY_UTF32_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableStringArrayPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] GUID_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingGuidPropertyInCalculatorWhenComputeThenReturnGuidMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] GUID_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingGuidArrayPropertyInCalculatorWhenComputeThenReturnGuidArrayMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_GUID_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableGuidPropertyInCalculatorWhenComputeThenReturnNullableGuidMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] NULLABLE_GUID_ARRAY_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingNullableGuidArrayPropertyInCalculatorWhenComputeThenReturnNullableGuidArrayMD5())} }};");
            Console.WriteLine($"");
            Console.WriteLine($"        public static readonly byte[] DEFAULT_MD5 = IncrementalHash.CreateHash(HashAlgorithmName.MD5).GetHashAndReset();");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_ID_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingComplexPropertyInCalculatorWhenComputeThenReturnEntityIdMD5())} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_ID_MD5 = new byte[] {{ {string.Join(", ", md5test.UsingComplexListPropertyInCalculatorWhenComputeThenReturnEntityIdMD5())} }};");

            (utf8Hash, unicodeHash, utf32Hash) = md5test.UsingComplexPropertyWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorMD5();
            Console.WriteLine("");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UTF8_MD5 = new byte[] {{ {string.Join(", ", utf8Hash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UNICODE_MD5 = new byte[] {{ {string.Join(", ", unicodeHash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILD_ENTITY_STRING_UTF32_MD5 = new byte[] {{ {string.Join(", ", utf32Hash)} }};");

            (utf8Hash, unicodeHash, utf32Hash) = md5test.UsingComplexPropertyListWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorMD5();

            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UTF8_MD5 = new byte[] {{ {string.Join(", ", utf8Hash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UNICODE_MD5 = new byte[] {{ {string.Join(", ", unicodeHash)} }};");
            Console.WriteLine($"        public static readonly byte[] CHILDLIST_ENTITY_STRING_UTF32_MD5 = new byte[] {{ {string.Join(", ", utf32Hash)} }};");

            Console.WriteLine("        #endregion");
        }
    }
}
