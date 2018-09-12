﻿using System;
using System.Collections.Generic;
using HipHopFile;
using static IndustrialPark.ConverterFunctions;

namespace IndustrialPark
{
    public class EntrySHDW
    {
        public AssetID ModelAssetID { get; set; }
        public AssetID ShadowModelAssetID { get; set; }
        public int Unknown { get; set; }

        public override string ToString()
        {
            return $"[{ModelAssetID.ToString()}] - {ShadowModelAssetID}";
        }
    }

    public class AssetSHDW : Asset
    {
        public AssetSHDW(Section_AHDR AHDR) : base(AHDR)
        {
        }
        
        public EntrySHDW[] PICKentries
        {
            get
            {
                List<EntrySHDW> entries = new List<EntrySHDW>();
                int amount = ReadInt(0);

                for (int i = 0; i < amount; i++)
                {
                    entries.Add(new EntrySHDW()
                    {
                        ModelAssetID = ReadUInt(4 + i * 0xC),
                        ShadowModelAssetID = ReadUInt(8 + i * 0xC),
                        Unknown = ReadInt(12 + i * 0xC)
                    });
                }
                
                return entries.ToArray();
            }
            set
            {
                List<byte> newData = new List<byte>();
                newData.AddRange(BitConverter.GetBytes(Switch(value.Length)));

                foreach (EntrySHDW i in value)
                {
                    newData.AddRange(BitConverter.GetBytes(Switch(i.ModelAssetID)));
                    newData.AddRange(BitConverter.GetBytes(Switch(i.ShadowModelAssetID)));
                    newData.AddRange(BitConverter.GetBytes(Switch(i.Unknown)));
                }
                
                Data = newData.ToArray();
            }
        }
    }
}