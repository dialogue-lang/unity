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

using Dialang;

namespace Dialang.Unity.Management
{
    public class DialangBinaryAssetProvider : IResourceProvider
    {
        public string ProviderId => "dialang_binasset_provider";

        public ProviderBehaviourFlags BehaviourFlags => ProviderBehaviourFlags.CanProvideWithFailedDependencies;

        private Project InternalProvide(ProvideHandle h)
        {
            string path = h.ResourceManager.TransformInternalId(h.Location);

            if (ResourceManagerConfig.ShouldPathUseWebRequest(path))
            {
                
            } else
            {
                
            }

            Debug.Log(path);
            return null;
        }

        public void Provide(ProvideHandle handle)
        {
            Debug.Log($"Provide {handle.Location.InternalId}");

            DialangBinaryAsset asset = ScriptableObject.CreateInstance<DialangBinaryAsset>();
            asset.Set(InternalProvide(handle));

            handle.Complete(asset, asset.Value != null, null);
        }

        public bool CanProvide(Type t, IResourceLocation location)
        {
            return t.IsAssignableFrom(typeof(DialangBinaryAsset));
        }

        public Type GetDefaultType(IResourceLocation location)
        {
            return typeof(DialangBinaryAsset);
        }

        public void Release(IResourceLocation location, object asset)
        {
        }
    }
}
