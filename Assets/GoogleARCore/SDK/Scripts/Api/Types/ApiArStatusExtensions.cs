//-----------------------------------------------------------------------
// <copyright file="ApiArStatusExtensions.cs" company="Google">
//
// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.InstantPreview.Editor.CrossPlatform
{
    using GoogleARCore.CrossPlatform;

    internal static class ApiArStatusExtensions
    {
        public static CloudServiceResponse ToCloudServiceResponse(this ApiArStatus status)
        {
            switch (status)
            {
                case ApiArStatus.Success:
                    return CloudServiceResponse.Success;
                case ApiArStatus.ErrorCloudAnchorsNotConfigured:
                    return CloudServiceResponse.ErrorNotSupportedByConfiguration;
                case ApiArStatus.ErrorNotTracking:
                case ApiArStatus.ErrorSessionPaused:
                    return CloudServiceResponse.ErrorNotTracking;
                case ApiArStatus.ErrorResourceExhausted:
                default:
                    return CloudServiceResponse.ErrorInternal;
            }
        }
    }
}
