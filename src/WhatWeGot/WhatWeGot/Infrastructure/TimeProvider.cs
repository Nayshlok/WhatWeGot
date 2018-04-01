using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatWeGot.Infrastructure
{
    public abstract class TimeProvider
    {
        private static TimeProvider current = DefaultTimeProvider.Instance;

        public static TimeProvider Current
        {
            get { return TimeProvider.current; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentException("Time provider was null");
                }
                TimeProvider.current = value;
            }
        }

        public abstract DateTime Now { get; }

        public abstract DateTime GetUtc { get; }

        public static void ResetToDefault()
        {
            TimeProvider.current = DefaultTimeProvider.Instance;
        }
    }

    internal class DefaultTimeProvider : TimeProvider
    {
        private static TimeProvider _instance;

        public static TimeProvider Instance {
            get
            {
                if(_instance == null)
                {
                    _instance = new DefaultTimeProvider();
                }
                return _instance;
            }
        }

        public override DateTime Now => DateTime.Now;

        public override DateTime GetUtc => DateTime.UtcNow;
    }
}
