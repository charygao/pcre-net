﻿using System;
using PCRE.Wrapper;

namespace PCRE
{
    public static class PcreBuildInfo
    {
        public static PcreBackslashR BackslashR { get; } = (PcreBackslashR) GetConfigUInt32(ConfigKey.Bsr);
        public static bool Jit { get; } = GetConfigBool(ConfigKey.Jit);
        public static string JitTarget { get; } = PcreBuild.GetConfigString(ConfigKey.JitTarget);
        public static uint LinkSize { get; } = GetConfigUInt32(ConfigKey.LinkSize);
        public static uint MatchLimit { get; } = GetConfigUInt32(ConfigKey.MatchLimit);
        public static PcreNewLine NewLine { get; } = (PcreNewLine) GetConfigUInt32(ConfigKey.NewLine);
        public static uint ParensLimit { get; } = GetConfigUInt32(ConfigKey.ParensLimit);
        public static uint DepthLimit { get; } = GetConfigUInt32(ConfigKey.DepthLimit);
        public static bool Unicode { get; } = GetConfigBool(ConfigKey.Unicode);
        public static string UnicodeVersion { get; } = GetConfigString(ConfigKey.UnicodeVersion);
        public static string Version { get; } = GetConfigString(ConfigKey.Version);
        public static uint HeapLimit { get; } = GetConfigUInt32(ConfigKey.HeapLimit);
        public static bool NeverBackslashC { get; } = GetConfigBool(ConfigKey.NeverBackslashC);
        public static uint CompiledWidths { get; } = GetConfigUInt32(ConfigKey.CompiledWidths);

        private static bool GetConfigBool(ConfigKey key) 
            => PcreBuild.GetConfigUInt32(key).GetValueOrDefault() != 0;

        private static uint GetConfigUInt32(ConfigKey key)
        {
            var value = PcreBuild.GetConfigUInt32(key);
            if (value == null)
                throw new InvalidOperationException("Could not retrieve the configuration property: " + key);

            return value.Value;
        }

        private static string GetConfigString(ConfigKey key)
        {
            var value = PcreBuild.GetConfigString(key);
            if (value == null)
                throw new InvalidOperationException("Could not retrieve the configuration property: " + key);

            return value;
        }
    }
}
