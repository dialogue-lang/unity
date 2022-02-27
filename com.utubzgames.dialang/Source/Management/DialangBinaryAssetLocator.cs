using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.ResourceManagement.Util;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;

using Dialang;

namespace Dialang.Unity.Management
{
    public class DialangBinaryAssetLocator : IResourceLocator
    {
        public string LocatorId => "dialang_binasset_locator";

        public IEnumerable<object> Keys => throw new NotImplementedException();

        public bool Locate(object key, Type type, out IList<IResourceLocation> locations)
        {
            Debug.Log(key);

            if (key is string path && !path.StartsWith("url:"))
            {
                locations = new List<IResourceLocation>() { new ResourceLocationBase(path, path, "dialang_binasset_provider", typeof(DialangBinaryAsset)) };
                return true;
            }

            locations = null;
            return false;
        }
    }
}
