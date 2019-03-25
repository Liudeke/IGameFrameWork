﻿//------------------------------------------------------------
// Game Framework v3.x
// Copyright © 2013-2018 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using System.Collections.Generic;
using UnityEditor;

namespace Icarus.UnityGameFramework.Editor.AssetBundleTools
{
    internal partial class AssetBundleBuilderController
    {
        private sealed class AssetBundleData
        {
            private readonly string m_Name;
            private readonly string m_Variant;
            private readonly AssetBundleLoadType m_LoadType;
            private readonly bool m_Optional;
            private readonly List<AssetData> m_AssetDatas;
            private readonly List<AssetBundleCode> m_Codes;
            private readonly string _groupTag;

            public AssetBundleData(string name, string variant, AssetBundleLoadType loadType, 
                bool optional,string groupTag)
            {
                m_Name = name;
                m_Variant = variant;
                m_LoadType = loadType;
                m_Optional = optional;
                m_AssetDatas = new List<AssetData>();
                m_Codes = new List<AssetBundleCode>();
                _groupTag = groupTag;
            }

            public string Name
            {
                get
                {
                    return m_Name;
                }
            }

            public string Variant
            {
                get
                {
                    return m_Variant;
                }
            }

            public AssetBundleLoadType LoadType
            {
                get
                {
                    return m_LoadType;
                }
            }

            public bool Optional
            {
                get
                {
                    return m_Optional;
                }
            }

            public string GroupTag
            {
                get
                {
                    return _groupTag;
                }
            }

            public int AssetCount
            {
                get
                {
                    return m_AssetDatas.Count;
                }
            }

            public string[] GetAssetNames()
            {
                string[] assetNames = new string[m_AssetDatas.Count];
                for (int i = 0; i < m_AssetDatas.Count; i++)
                {
                    assetNames[i] = m_AssetDatas[i].Name;
                }

                return assetNames;
            }

            public AssetData[] GetAssetDatas()
            {
                return m_AssetDatas.ToArray();
            }

            public AssetData GetAssetData(string assetName)
            {
                foreach (AssetData assetData in m_AssetDatas)
                {
                    if (assetData.Name == assetName)
                    {
                        return assetData;
                    }
                }

                return null;
            }

            public void AddAssetData(string guid, string name, int length, int hashCode, string[] dependencyAssetNames)
            {
                m_AssetDatas.Add(new AssetData(guid, name, length, hashCode, dependencyAssetNames));
            }

            public AssetBundleCode GetCode(Platform platform)
            {
                foreach (AssetBundleCode code in m_Codes)
                {
                    if (code.Platform == platform)
                    {
                        return code;
                    }
                }

                return null;
            }

            public AssetBundleCode[] GetCodes()
            {
                return m_Codes.ToArray();
            }

            public void AddCode(Platform platform, int length, int hashCode, int zipLength, int zipHashCode)
            {
                m_Codes.Add(new AssetBundleCode(platform, length, hashCode, zipLength, zipHashCode));
            }

            public override string ToString()
            {
                return string.Format("资源包名:{0}," +
                                     "加载方式:{1}," +
                                     "资源个数:{2}," +
                                     "变体:{3}," +
                                     "是否可选:{4}", m_Name, m_LoadType, m_AssetDatas.Count, m_Variant, m_Optional);
            }
        }
    }
}
