using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

namespace Unity.Netcode.Components
{
    /// <summary>
    /// Just a hack for quick NetworkTransform hot-fixes
    /// Own implementation of `Unity.Multiplayer.Samples.Utilities.ClientAuthority.ClientNetworkTransform`
    /// </summary>

    [DisallowMultipleComponent]
    public class ParentedNetworkTransform : NetworkTransform
    {
        public void SetParent(NetworkObject parent)
        {
            if (!IsOwner)
            {
                NetworkLog.LogError("Only owner can set parent");
                return;
            }

            transform.SetParent(parent?.transform, true);
        }

        // Just to got rid of Unity.Multiplayer.Samples.Utilities.ClientAuthority.ClientNetworkTransform
        protected override bool OnIsServerAuthoritative()
        {
            return false;
        }
    }
}
