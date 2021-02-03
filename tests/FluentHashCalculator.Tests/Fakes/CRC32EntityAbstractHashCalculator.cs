﻿namespace FluentHashCalculator.Tests.Fakes
{
    public class CRC32EntityAbstractHashCalculator : AbstractHashCalculator<Entity>.CRC32
    {
        public CRC32EntityAbstractHashCalculator(bool ignoreErrors = true)
        {
            IgnoreErrors = ignoreErrors;

            Calculate
                .Using(e => e.Id)
                .Using(e => e.Name)
                .Using(e => e.LastName)
                .Using(e => e.Birthday)
                .Using(e => e.Another).WithCRC32(calc => calc.Using(p => p.Id).Using(p => p.Name).Using(p => p.Birthday))
                .UsingEach(e => e.AnotherList).WithCRC32(calc => calc.Using(p => p.Id))
                .Using(e => e.Null.Name, ignoreError: true)
                .Using(e => e.Age());
        }
    }
}
