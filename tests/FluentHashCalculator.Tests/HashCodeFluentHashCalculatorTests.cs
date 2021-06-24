﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FluentHashCalculator.Tests.Fakes;
using Xunit;

namespace FluentHashCalculator.Tests
{
    public class HashCodeFluentHashCalculatorTests
    {
        [Fact]
        public int UsingBoolPropertyInCalculatorWhenComputeThenReturnBoolHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.BoolProperty);
            Expression<Func<EntityWithAllSupportedTypes, bool>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.BOOL_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingBoolArrayPropertyInCalculatorWhenComputeThenReturnBoolArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.BoolArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<bool>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.BOOL_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableBoolPropertyInCalculatorWhenComputeThenReturnNullableBoolHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableBoolProperty);
            Expression<Func<EntityWithAllSupportedTypes, bool?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_BOOL_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableBoolArrayPropertyInCalculatorWhenComputeThenReturnNullableBoolArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableBoolArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<bool?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_BOOL_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingBytePropertyInCalculatorWhenComputeThenReturnByteHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.ByteProperty);
            Expression<Func<EntityWithAllSupportedTypes, byte>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.BYTE_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingByteArrayPropertyInCalculatorWhenComputeThenReturnByteArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.ByteArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<byte>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.BYTE_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableBytePropertyInCalculatorWhenComputeThenReturnNullableByteHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableByteProperty);
            Expression<Func<EntityWithAllSupportedTypes, byte?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_BYTE_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableByteArrayPropertyInCalculatorWhenComputeThenReturnNullableByteArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableByteArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<byte?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_BYTE_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingSbytePropertyInCalculatorWhenComputeThenReturnSbyteHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.SbyteProperty);
            Expression<Func<EntityWithAllSupportedTypes, sbyte>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.SBYTE_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingSbyteArrayPropertyInCalculatorWhenComputeThenReturnSbyteArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.SbyteArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<sbyte>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.SBYTE_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableSbytePropertyInCalculatorWhenComputeThenReturnNullableSbyteHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableSbyteProperty);
            Expression<Func<EntityWithAllSupportedTypes, sbyte?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_SBYTE_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableSbyteArrayPropertyInCalculatorWhenComputeThenReturnNullableSbyteArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableSbyteArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<sbyte?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_SBYTE_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingShortPropertyInCalculatorWhenComputeThenReturnShortHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.ShortProperty);
            Expression<Func<EntityWithAllSupportedTypes, short>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.SHORT_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingShortArrayPropertyInCalculatorWhenComputeThenReturnShortArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.ShortArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<short>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.SHORT_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableShortPropertyInCalculatorWhenComputeThenReturnNullableShortHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableShortProperty);
            Expression<Func<EntityWithAllSupportedTypes, short?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_SHORT_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableShortArrayPropertyInCalculatorWhenComputeThenReturnNullableShortArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableShortArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<short?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_SHORT_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingUshortPropertyInCalculatorWhenComputeThenReturnUshortHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.UshortProperty);
            Expression<Func<EntityWithAllSupportedTypes, ushort>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.USHORT_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingUshortArrayPropertyInCalculatorWhenComputeThenReturnUshortArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.UshortArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<ushort>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.USHORT_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableUshortPropertyInCalculatorWhenComputeThenReturnNullableUshortHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableUshortProperty);
            Expression<Func<EntityWithAllSupportedTypes, ushort?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_USHORT_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableUshortArrayPropertyInCalculatorWhenComputeThenReturnNullableUshortArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableUshortArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<ushort?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_USHORT_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingIntPropertyInCalculatorWhenComputeThenReturnIntHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.IntProperty);
            Expression<Func<EntityWithAllSupportedTypes, int>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.INT_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingIntArrayPropertyInCalculatorWhenComputeThenReturnIntArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.IntArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<int>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.INT_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableIntPropertyInCalculatorWhenComputeThenReturnNullableIntHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableIntProperty);
            Expression<Func<EntityWithAllSupportedTypes, int?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_INT_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableIntArrayPropertyInCalculatorWhenComputeThenReturnNullableIntArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableIntArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<int?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_INT_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingUintPropertyInCalculatorWhenComputeThenReturnUintHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.UintProperty);
            Expression<Func<EntityWithAllSupportedTypes, uint>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.UINT_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingUintArrayPropertyInCalculatorWhenComputeThenReturnUintArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.UintArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<uint>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.UINT_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableUintPropertyInCalculatorWhenComputeThenReturnNullableUintHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableUintProperty);
            Expression<Func<EntityWithAllSupportedTypes, uint?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_UINT_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableUintArrayPropertyInCalculatorWhenComputeThenReturnNullableUintArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableUintArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<uint?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_UINT_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingLongPropertyInCalculatorWhenComputeThenReturnLongHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.LongProperty);
            Expression<Func<EntityWithAllSupportedTypes, long>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.LONG_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingLongArrayPropertyInCalculatorWhenComputeThenReturnLongArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.LongArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<long>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.LONG_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableLongPropertyInCalculatorWhenComputeThenReturnNullableLongHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableLongProperty);
            Expression<Func<EntityWithAllSupportedTypes, long?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_LONG_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableLongArrayPropertyInCalculatorWhenComputeThenReturnNullableLongArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableLongArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<long?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_LONG_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingUlongPropertyInCalculatorWhenComputeThenReturnUlongHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.UlongProperty);
            Expression<Func<EntityWithAllSupportedTypes, ulong>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.ULONG_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingUlongArrayPropertyInCalculatorWhenComputeThenReturnUlongArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.UlongArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<ulong>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.ULONG_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableUlongPropertyInCalculatorWhenComputeThenReturnNullableUlongHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableUlongProperty);
            Expression<Func<EntityWithAllSupportedTypes, ulong?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_ULONG_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableUlongArrayPropertyInCalculatorWhenComputeThenReturnNullableUlongArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableUlongArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<ulong?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_ULONG_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingFloatPropertyInCalculatorWhenComputeThenReturnFloatHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.FloatProperty);
            Expression<Func<EntityWithAllSupportedTypes, float>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.FLOAT_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingFloatArrayPropertyInCalculatorWhenComputeThenReturnFloatArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.FloatArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<float>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.FLOAT_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableFloatPropertyInCalculatorWhenComputeThenReturnNullableFloatHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableFloatProperty);
            Expression<Func<EntityWithAllSupportedTypes, float?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_FLOAT_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableFloatArrayPropertyInCalculatorWhenComputeThenReturnNullableFloatArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableFloatArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<float?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_FLOAT_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingDoublePropertyInCalculatorWhenComputeThenReturnDoubleHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.DoubleProperty);
            Expression<Func<EntityWithAllSupportedTypes, double>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.DOUBLE_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingDoubleArrayPropertyInCalculatorWhenComputeThenReturnDoubleArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.DoubleArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<double>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.DOUBLE_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableDoublePropertyInCalculatorWhenComputeThenReturnNullableDoubleHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableDoubleProperty);
            Expression<Func<EntityWithAllSupportedTypes, double?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_DOUBLE_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableDoubleArrayPropertyInCalculatorWhenComputeThenReturnNullableDoubleArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableDoubleArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<double?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_DOUBLE_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingDecimalPropertyInCalculatorWhenComputeThenReturnDecimalHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.DecimalProperty);
            Expression<Func<EntityWithAllSupportedTypes, decimal>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.DECIMAL_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingDecimalArrayPropertyInCalculatorWhenComputeThenReturnDecimalArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.DecimalArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<decimal>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.DECIMAL_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableDecimalPropertyInCalculatorWhenComputeThenReturnNullableDecimalHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableDecimalProperty);
            Expression<Func<EntityWithAllSupportedTypes, decimal?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_DECIMAL_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableDecimalArrayPropertyInCalculatorWhenComputeThenReturnNullableDecimalArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableDecimalArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<decimal?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_DECIMAL_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingDateTimePropertyInCalculatorWhenComputeThenReturnDateTimeHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.DateTimeProperty);
            Expression<Func<EntityWithAllSupportedTypes, DateTime>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.DATETIME_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingDateTimeArrayPropertyInCalculatorWhenComputeThenReturnDateTimeArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.DateTimeArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<DateTime>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.DATETIME_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableDateTimePropertyInCalculatorWhenComputeThenReturnNullableDateTimeHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableDateTimeProperty);
            Expression<Func<EntityWithAllSupportedTypes, DateTime?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_DATETIME_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableDateTimeArrayPropertyInCalculatorWhenComputeThenReturnNullableDateTimeArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableDateTimeArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<DateTime?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_DATETIME_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingTimeSpanPropertyInCalculatorWhenComputeThenReturnTimeSpanHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.TimeSpanProperty);
            Expression<Func<EntityWithAllSupportedTypes, TimeSpan>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.TIMESPAN_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnTimeSpanArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.TimeSpanArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<TimeSpan>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.TIMESPAN_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableTimeSpanPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableTimeSpanProperty);
            Expression<Func<EntityWithAllSupportedTypes, TimeSpan?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_TIMESPAN_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableTimeSpanArrayPropertyInCalculatorWhenComputeThenReturnNullableTimeSpanArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableTimeSpanArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<TimeSpan?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_TIMESPAN_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingCharPropertyInCalculatorWhenComputeThenReturnCharHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.CharProperty);
            Expression<Func<EntityWithAllSupportedTypes, char>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHAR_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingCharArrayPropertyInCalculatorWhenComputeThenReturnCharArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.CharArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<char>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHAR_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableCharPropertyInCalculatorWhenComputeThenReturnNullableCharHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableCharProperty);
            Expression<Func<EntityWithAllSupportedTypes, char?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_CHAR_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableCharArrayPropertyInCalculatorWhenComputeThenReturnNullableCharArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableCharArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<char?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_CHAR_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableStringPropertyInCalculatorWhenComputeThenReturnNullableStringHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableStringProperty);
            Expression<Func<EntityWithAllSupportedTypes, string>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_UTF8_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableStringPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableStringProperty, Encoding.Unicode);
            Expression<Func<EntityWithAllSupportedTypes, string>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression, Encoding.Unicode));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_UNICODE_HASH_CODE, actual);

            calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Context.Encoding = Encoding.Unicode;
            calculator.Using(e => e.NullableStringProperty, Encoding.UTF8);
            actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_UTF8_HASH_CODE, actual);

            calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Context.Encoding = Encoding.Unicode;
            calculator.Using(e => e.NullableStringProperty);
            actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_UNICODE_HASH_CODE, actual);

            return actual;
        }

        [Fact]
        public int UsingNullableStringPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableStringProperty, Encoding.UTF32);
            Expression<Func<EntityWithAllSupportedTypes, string>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression, Encoding.UTF32));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_UTF32_HASH_CODE, actual);

            calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Context.Encoding = Encoding.UTF32;
            calculator.Using(e => e.NullableStringProperty, Encoding.UTF8);
            actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_UTF8_HASH_CODE, actual);

            calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Context.Encoding = Encoding.UTF32;
            calculator.Using(e => e.NullableStringProperty);
            actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_UTF32_HASH_CODE, actual);

            return actual;
        }

        [Fact]
        public int UsingNullableStringArrayPropertyInCalculatorWhenComputeThenReturnNullableStringArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableStringArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<string>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_ARRAY_UTF8_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableStringArrayPropertyAndUnicodeEncodingInCalculatorWhenComputeThenReturnNullableStringArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableStringArrayProperty, Encoding.Unicode);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<string>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression, Encoding.Unicode));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_ARRAY_UNICODE_HASH_CODE, actual);

            calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Context.Encoding = Encoding.Unicode;
            calculator.UsingEach(e => e.NullableStringArrayProperty, Encoding.UTF8);
            actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_ARRAY_UTF8_HASH_CODE, actual);

            calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Context.Encoding = Encoding.Unicode;
            calculator.UsingEach(e => e.NullableStringArrayProperty);
            actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_ARRAY_UNICODE_HASH_CODE, actual);

            return actual;
        }

        [Fact]
        public int UsingNullableStringArrayPropertyAndUTF32EncodingInCalculatorWhenComputeThenReturnNullableStringArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableStringArrayProperty, Encoding.UTF32);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<string>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression, Encoding.UTF32));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_ARRAY_UTF32_HASH_CODE, actual);

            calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Context.Encoding = Encoding.UTF32;
            calculator.UsingEach(e => e.NullableStringArrayProperty, Encoding.UTF8);
            actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_ARRAY_UTF8_HASH_CODE, actual);

            calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Context.Encoding = Encoding.UTF32;
            calculator.UsingEach(e => e.NullableStringArrayProperty);
            actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_STRING_ARRAY_UTF32_HASH_CODE, actual);

            return actual;
        }

        [Fact]
        public int UsingGuidPropertyInCalculatorWhenComputeThenReturnGuidHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.GuidProperty);
            Expression<Func<EntityWithAllSupportedTypes, Guid>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.GUID_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingGuidArrayPropertyInCalculatorWhenComputeThenReturnGuidArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.GuidArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<Guid>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.GUID_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableGuidPropertyInCalculatorWhenComputeThenReturnNullableGuidHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.NullableGuidProperty);
            Expression<Func<EntityWithAllSupportedTypes, Guid?>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_GUID_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullableGuidArrayPropertyInCalculatorWhenComputeThenReturnNullableGuidArrayHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.NullableGuidArrayProperty);
            Expression<Func<EntityWithAllSupportedTypes, IEnumerable<Guid?>>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.UsingEach(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.NULLABLE_GUID_ARRAY_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingNullEntityWhenComputeThenReturnNullableGuidHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.BoolProperty);

            var actual = calculator.Compute(null);
            Assert.Equal(0, actual);
            return actual;
        }

        [Fact]
        public int UsingComplexPropertyInCalculatorWhenComputeThenReturnEntityIdHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.Child);
            Expression<Func<EntityWithAllSupportedTypes, Entity>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
            Assert.Equal(int.MinValue, actual);
            calculator.Using(e => e.Child).WithHashCode(calc => calc.Using(e => e.Id));
            actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILD_ENTITY_ID_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public int UsingComplexListPropertyInCalculatorWhenComputeThenReturnEntityIdHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.ChildList);
            Expression<Func<EntityWithAllSupportedTypes, Entity>> nullExpression = null;
            Assert.Throws<ArgumentNullException>(() => calculator.Using(nullExpression));
            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
            Assert.Equal(int.MinValue, actual);
            calculator.UsingEach(e => e.ChildList).WithHashCode(calc => calc.Using(e => e.Id));
            actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILDLIST_ENTITY_ID_HASH_CODE, actual);
            return actual;
        }

        [Fact]
        public (int, int) UsingAllPropertiesInCalculatorWhenComputeThenReturnHashCode()
        {
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.BoolProperty)
                .UsingEach(e => e.BoolArrayProperty)
                .Using(e => e.NullableBoolProperty)
                .UsingEach(e => e.NullableBoolArrayProperty)
                .Using(e => e.ByteProperty)
                .UsingEach(e => e.ByteArrayProperty)
                .Using(e => e.NullableByteProperty)
                .UsingEach(e => e.NullableByteArrayProperty)
                .Using(e => e.SbyteProperty)
                .UsingEach(e => e.SbyteArrayProperty)
                .Using(e => e.NullableSbyteProperty)
                .UsingEach(e => e.NullableSbyteArrayProperty)
                .Using(e => e.ShortProperty)
                .UsingEach(e => e.ShortArrayProperty)
                .Using(e => e.NullableShortProperty)
                .UsingEach(e => e.NullableShortArrayProperty)
                .Using(e => e.IntProperty)
                .UsingEach(e => e.IntArrayProperty)
                .Using(e => e.NullableIntProperty)
                .UsingEach(e => e.NullableIntArrayProperty)
                .Using(e => e.IntProperty)
                .UsingEach(e => e.IntArrayProperty)
                .Using(e => e.NullableIntProperty)
                .UsingEach(e => e.NullableIntArrayProperty)
                .Using(e => e.UintProperty)
                .UsingEach(e => e.UintArrayProperty)
                .Using(e => e.NullableUintProperty)
                .UsingEach(e => e.NullableUintArrayProperty)
                .Using(e => e.LongProperty)
                .UsingEach(e => e.LongArrayProperty)
                .Using(e => e.NullableLongProperty)
                .UsingEach(e => e.NullableLongArrayProperty)
                .Using(e => e.UlongProperty)
                .UsingEach(e => e.UlongArrayProperty)
                .Using(e => e.NullableUlongProperty)
                .UsingEach(e => e.NullableUlongArrayProperty)
                .Using(e => e.FloatProperty)
                .UsingEach(e => e.FloatArrayProperty)
                .Using(e => e.NullableFloatProperty)
                .UsingEach(e => e.NullableFloatArrayProperty)
                .Using(e => e.DoubleProperty)
                .UsingEach(e => e.DoubleArrayProperty)
                .Using(e => e.NullableDoubleProperty)
                .UsingEach(e => e.NullableDoubleArrayProperty)
                .Using(e => e.DecimalProperty)
                .UsingEach(e => e.DecimalArrayProperty)
                .Using(e => e.NullableDecimalProperty)
                .UsingEach(e => e.NullableDecimalArrayProperty)
                .Using(e => e.DateTimeProperty)
                .UsingEach(e => e.DateTimeArrayProperty)
                .Using(e => e.NullableDateTimeProperty)
                .UsingEach(e => e.NullableDateTimeArrayProperty)
                .Using(e => e.TimeSpanProperty)
                .UsingEach(e => e.TimeSpanArrayProperty)
                .Using(e => e.NullableTimeSpanProperty)
                .UsingEach(e => e.NullableTimeSpanArrayProperty)
                .Using(e => e.CharProperty)
                .UsingEach(e => e.CharArrayProperty)
                .Using(e => e.NullableCharProperty)
                .UsingEach(e => e.NullableCharArrayProperty)
                .Using(e => e.NullableStringProperty)
                .UsingEach(e => e.NullableStringArrayProperty)
                .Using(e => e.GuidProperty)
                .UsingEach(e => e.GuidArrayProperty)
                .Using(e => e.NullableGuidProperty)
                .UsingEach(e => e.NullableGuidArrayProperty);

            var actual = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.ENTITY_WITH_ALL_SUPPORTED_TYPES_HASH_CODE, actual);

            var actual2 = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.ENTITY_WITH_ALL_SUPPORTED_TYPES_HASH_CODE, actual2);


            var calculator2 = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator2.Using(e => e.BoolProperty)
                .UsingEach(e => e.BoolArrayProperty)
                .Using(e => e.NullableBoolProperty)
                .UsingEach(e => e.NullableBoolArrayProperty)
                .Using(e => e.ByteProperty)
                .UsingEach(e => e.ByteArrayProperty)
                .Using(e => e.NullableByteProperty)
                .UsingEach(e => e.NullableByteArrayProperty)
                .Using(e => e.SbyteProperty)
                .UsingEach(e => e.SbyteArrayProperty)
                .Using(e => e.NullableSbyteProperty)
                .UsingEach(e => e.NullableSbyteArrayProperty)
                .Using(e => e.ShortProperty)
                .UsingEach(e => e.ShortArrayProperty)
                .Using(e => e.NullableShortProperty)
                .UsingEach(e => e.NullableShortArrayProperty)
                .Using(e => e.IntProperty)
                .UsingEach(e => e.IntArrayProperty)
                .Using(e => e.NullableIntProperty)
                .UsingEach(e => e.NullableIntArrayProperty)
                .Using(e => e.IntProperty)
                .UsingEach(e => e.IntArrayProperty)
                .Using(e => e.NullableIntProperty)
                .UsingEach(e => e.NullableIntArrayProperty)
                .UsingEach(e => e.UintArrayProperty)
                .Using(e => e.NullableUintProperty)
                .UsingEach(e => e.NullableUintArrayProperty)
                .Using(e => e.LongProperty)
                .UsingEach(e => e.LongArrayProperty)
                .Using(e => e.NullableLongProperty)
                .UsingEach(e => e.NullableLongArrayProperty)
                .Using(e => e.UlongProperty)
                .UsingEach(e => e.UlongArrayProperty)
                .Using(e => e.NullableUlongProperty)
                .UsingEach(e => e.NullableUlongArrayProperty)
                .Using(e => e.FloatProperty)
                .UsingEach(e => e.FloatArrayProperty)
                .Using(e => e.NullableFloatProperty)
                .UsingEach(e => e.NullableFloatArrayProperty)
                .Using(e => e.DoubleProperty)
                .UsingEach(e => e.DoubleArrayProperty)
                .Using(e => e.NullableDoubleProperty)
                .UsingEach(e => e.NullableDoubleArrayProperty)
                .Using(e => e.DecimalProperty)
                .UsingEach(e => e.DecimalArrayProperty)
                .Using(e => e.NullableDecimalProperty)
                .UsingEach(e => e.NullableDecimalArrayProperty)
                .Using(e => e.DateTimeProperty)
                .UsingEach(e => e.DateTimeArrayProperty)
                .Using(e => e.NullableDateTimeProperty)
                .UsingEach(e => e.NullableDateTimeArrayProperty)
                .Using(e => e.TimeSpanProperty)
                .UsingEach(e => e.TimeSpanArrayProperty)
                .Using(e => e.NullableTimeSpanProperty)
                .UsingEach(e => e.NullableTimeSpanArrayProperty)
                .Using(e => e.CharProperty)
                .UsingEach(e => e.CharArrayProperty)
                .Using(e => e.NullableCharProperty)
                .UsingEach(e => e.NullableCharArrayProperty)
                .Using(e => e.NullableStringProperty)
                .UsingEach(e => e.NullableStringArrayProperty)
                .Using(e => e.GuidProperty)
                .UsingEach(e => e.GuidArrayProperty)
                .Using(e => e.NullableGuidProperty)
                .UsingEach(e => e.NullableGuidArrayProperty);

            var actual3 = calculator2.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.ENTITY_WITH_ALL_SUPPORTED_TYPESBUT_WITH_NO_UINT_PROPERTY_HASH_CODE, actual3);

            //Assert.NotEqual(actual, actual3);

            return (actual, actual3);
        }

        [Fact]
        public (int, int, int) UsingComplexPropertyWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorHashCode()
        {
            // Tests without context inheritance
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.WithEncoding(Encoding.Unicode).Using(e => e.Child).WithHashCode(calc => calc.WithEncoding(Encoding.UTF8).Using(e => e.Name));
            var utf8Hash = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILD_ENTITY_STRING_UTF8_HASH_CODE, utf8Hash);
            calculator.Context.Encoding = Encoding.Unicode;
            var unicodeHash = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILD_ENTITY_STRING_UTF8_HASH_CODE, unicodeHash);
            calculator.Context.Encoding = Encoding.UTF32;
            var utf32Hash = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILD_ENTITY_STRING_UTF8_HASH_CODE, utf32Hash);

            // Tests with context inheritance
            calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.Using(e => e.Child, inheritContext: true).WithHashCode(calc => calc.Using(e => e.Name));
            utf8Hash = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILD_ENTITY_STRING_UTF8_HASH_CODE, utf8Hash);
            calculator.Context.Encoding = Encoding.Unicode;
            unicodeHash = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILD_ENTITY_STRING_UNICODE_HASH_CODE, unicodeHash);
            calculator.Context.Encoding = Encoding.UTF32;
            utf32Hash = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILD_ENTITY_STRING_UTF32_HASH_CODE, utf32Hash);

            return (utf8Hash, unicodeHash, utf32Hash);
        }

        [Fact]
        public (int, int, int) UsingComplexPropertyListWithStringInCalculatorWhenComputeThenReturnEntityIdWithSameEncodingToParentCalculatorHashCode()
        {
            // Tests without context inheritance
            var calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.WithEncoding(Encoding.Unicode).UsingEach(e => e.ChildList).WithHashCode(calc => calc.WithEncoding(Encoding.UTF8).Using(e => e.Name));
            var utf8Hash = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILDLIST_ENTITY_STRING_UTF8_HASH_CODE, utf8Hash);
            calculator.Context.Encoding = Encoding.Unicode;
            var unicodeHash = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILDLIST_ENTITY_STRING_UTF8_HASH_CODE, unicodeHash);
            calculator.Context.Encoding = Encoding.UTF32;
            var utf32Hash = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILDLIST_ENTITY_STRING_UTF8_HASH_CODE, utf32Hash);

            // Tests with context inheritance
            calculator = new AbstractHashCalculatorBuilder<EntityWithAllSupportedTypes>.HashCode();
            calculator.UsingEach(e => e.ChildList, inheritContext: true).WithHashCode(calc => calc.Using(e => e.Name));
            utf8Hash = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILDLIST_ENTITY_STRING_UTF8_HASH_CODE, utf8Hash);
            calculator.Context.Encoding = Encoding.Unicode;
            unicodeHash = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILDLIST_ENTITY_STRING_UNICODE_HASH_CODE, unicodeHash);
            calculator.Context.Encoding = Encoding.UTF32;
            utf32Hash = calculator.Compute(new EntityWithAllSupportedTypes());
           Assert.Equal(Consts.CHILDLIST_ENTITY_STRING_UTF32_HASH_CODE, utf32Hash);

            return (utf8Hash, unicodeHash, utf32Hash);
        }
    }
}
