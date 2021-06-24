﻿using FluentHashCalculator.Internal;
using System.IO;
using System.Security.Cryptography;

namespace FluentHashCalculator.Benchmark.Calculators
{
    public abstract partial class AbstractHashCalculatorBuilder<T>
           where T : class
    {
        public class SHA384WithoutAppendData : FluentHashCalculator.AbstractHashCalculatorBuilder<T>, IAbstractHashCalculator<T, byte[]>
        {
            private static readonly HashAlgorithm hash
                = System.Security.Cryptography.SHA384.Create();

            public byte[] Compute(T instance)
            {
                if (ReferenceEquals(instance, null))
                    return Bytes.Empty;
                using (var mem = new MemoryStream())
                {
                    foreach ((var value, var context) in ValuesFor(instance))
                        foreach (var item in Bytes.From(value, context))
                            mem.Write(item);
                    return hash.ComputeHash(mem.ToArray());
                }
            }
        }
    }

    
}
